using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A region. Does everything necessary for a specific region.
/// </summary>
public class Region : MonoBehaviour
{
    public Transform position = null; // Temp.
    public Collider trigger = null;

    public int sinTier = 0;

    private EventSystem m_eventSystem = null;

    // Temp testing stuff
    [SerializeField] private MeshRenderer m_rendererTemp;
    [SerializeField] private Material[] m_testMaterials;
    [SerializeField] private int m_sinChance = 2;

    private float m_timer = 0.0f;
    private float m_delay = 0.0f;

    private void Start()
    {
        m_eventSystem = GameManager.Instance().eventSystem;
        m_eventSystem.regions.Add(this); // Make sure the event system is aware of us.

        m_timer = 0.0f;
        m_delay = Random.Range(1, m_sinChance); // Set initial random delay.

        sinTier = 0;
    }

    private void Update()
    {
        if (sinTier >= 3) // If it's already sinning too much, don't continue.
        {
            m_timer = 0.0f;
            return;
        }

        m_timer += Time.deltaTime;
        if (m_timer >= m_delay) // Tick tock.
        {
            //Sin();
            Strike();

            // Reset.
            m_delay = Random.Range(1, m_sinChance);
            m_timer = 0.0f;
        }
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
        }

        m_rendererTemp.sharedMaterial = m_testMaterials[sinTier]; // Temp.
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

        sinTier++;

        // Clamp.
        if (sinTier >= 3)
        {
            sinTier = 3;
        }

        m_rendererTemp.sharedMaterial = m_testMaterials[sinTier]; // Temp.
    }

}
