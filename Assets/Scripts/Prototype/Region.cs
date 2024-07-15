using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A region. Does everything necessary for a specific region.
/// </summary>
public class Region : MonoBehaviour
{
    public List<Region> neighbors;

    public Transform position = null; // Temp.
    public Collider trigger = null;

    public int sinTier = 0; // Should be 0 if beliefTier is greater than 0.
    public int miracleTier = 0; // Should be 0 if sinTier is greater than 0.

    public bool plagued = false;

    private EventSystem m_eventSystem = null;

    public Transform linePointPos;
    public GameObject line;

    // Temp testing stuff
    [SerializeField] private MeshRenderer m_rendererTemp;
    [SerializeField] private Material[] m_testMaterials;

    private void Start()
    {
        m_eventSystem = GameManager.Instance().eventSystem;
        m_eventSystem.regions.Add(this); // Make sure the event system is aware of us.

        sinTier = 0;
        miracleTier = 0;
    }

    private void Update()
    {
        if (sinTier >= 3 || miracleTier >= 3) // If it's already sinning or believing too much, don't continue.
        {
            return;
        }

        // Unused for now.
    }

    /// <summary>
    /// Strike the region, reduces sin tier.
    /// </summary>
    public void Strike()
    {
        Debug.Log("Strike!");

        sinTier--;

        if (sinTier <= 0)
        {
            m_eventSystem.RegionStoppedSinning(this); // Tell the event system we've stopped sinning.
            sinTier = 0; // Clamp.
            for (int i = 0; i < linePointPos.childCount; i++)
                Destroy(linePointPos.GetChild(i).gameObject);
        }

        int materialIdx = (sinTier > 0 || miracleTier > 0) ? (miracleTier > 0) ? 3 + miracleTier : sinTier : 0;
        m_rendererTemp.sharedMaterial = m_testMaterials[materialIdx]; // Temp.
    }

    private void SpawnLine()
    {
        for(int i = 0; i < linePointPos.childCount; i++)
            Destroy(linePointPos.GetChild(i).gameObject);

        GameObject a = Instantiate(line, linePointPos);

        Line lineScript = a.GetComponent<Line>();

        lineScript.ChangeIcon(sinTier, miracleTier, linePointPos.position);
    }

    /// <summary>
    /// The region sins, increases sin tier.
    /// </summary>
    public void Sin()
    {
        Debug.Log("Sin!");

        if (sinTier <= 0)
        {
            m_eventSystem.RegionStartedSinning(this); // Tell the event system we've started sinning.
        }
        if (miracleTier > 0)
        {
            miracleTier = 0;
            m_eventSystem.RegionStoppedBelieving(this); // Tell the event system we've stopped believing.
        }

        sinTier++;

        // Clamp.
        if (sinTier >= 3)
        {
            sinTier = 3;
        }

        SpawnLine();

        int materialIdx = (sinTier > 0 || miracleTier > 0) ? (miracleTier > 0) ? 3 + miracleTier : sinTier : 0;
        m_rendererTemp.sharedMaterial = m_testMaterials[materialIdx]; // Temp.
    }

    /// <summary>
    /// A miracle! Increases belief tier.
    /// </summary>
    public void Miracle()
    {
        Debug.Log("Miracle!");

        if (miracleTier <= 0)
        {
            m_eventSystem.RegionStartedBelieving(this); // Tell the event system we've started believing.
        }
        if (sinTier > 0)
        {
            sinTier = 0;
            m_eventSystem.RegionStoppedSinning(this); // Tell the event system we've stopped sinning.
        }

        miracleTier++;

        // Clamp.
        if (miracleTier >= 3)
        {
            miracleTier = 3;
        }

        SpawnLine();

        int materialIdx = (sinTier > 0 || miracleTier > 0) ? (miracleTier > 0) ? 3 + miracleTier : sinTier : 0;
        m_rendererTemp.sharedMaterial = m_testMaterials[materialIdx]; // Temp.
    }

    /// <summary>
    /// Sets the sin tier of the region to the specified value. Clamps it to a range of 0 to 3.
    /// </summary>
    public void SetSinTier(int sinTier)
    {
        int tier = math.clamp(sinTier, 0, 3); // Should be within range.

        if (this.sinTier <= 0 && tier > 0)
        {
            m_eventSystem.RegionStartedSinning(this); // Tell the event system we've started sinning.
        }
        if (this.sinTier > 0 && tier <= 0)
        {
            m_eventSystem.RegionStoppedSinning(this); // Tell the event system we've stopped sinning.
        }
        if (this.miracleTier > 0 && tier > 0)
        {
            this.miracleTier = 0; // Shouldn't be believing.
            m_eventSystem.RegionStoppedBelieving(this); // Tell the event system we've stopped believing.
        }

        this.sinTier = tier;
        Debug.Log("Set regions sin tier to " + tier);

        int materialIdx = (sinTier > 0 || miracleTier > 0) ? (miracleTier > 0) ? 3 + miracleTier : sinTier : 0;
        m_rendererTemp.sharedMaterial = m_testMaterials[materialIdx]; // Temp.
    }

    /// <summary>
    /// Sets the belief tier of the region to the specified value. Clamps it to a range of 0 to 3.
    /// </summary>
    public void SetBeliefTier(int beliefTier)
    {
        int tier = math.clamp(beliefTier, 0, 3); // Should be within range.

        if (this.miracleTier <= 0 && tier > 0)
        {
            m_eventSystem.RegionStartedBelieving(this); // Tell the event system we've started believing.
        }
        if (this.miracleTier > 0 && tier <= 0)
        {
            m_eventSystem.RegionStoppedBelieving(this); // Tell the event system we've stopped believing.
        }
        if (this.sinTier > 0 && tier > 0)
        {
            this.sinTier = 0; // Shouldn't be sinning.
            m_eventSystem.RegionStoppedSinning(this); // Tell the event system we've stopped sinning.
        }

        this.miracleTier = tier;
        Debug.Log("Set regions belief tier to " + tier);

        int materialIdx = (sinTier > 0 || beliefTier > 0) ? (beliefTier > 0) ? 3 + beliefTier : sinTier : 0;
        m_rendererTemp.sharedMaterial = m_testMaterials[materialIdx]; // Temp.
    }
}
