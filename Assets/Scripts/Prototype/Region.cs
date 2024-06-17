using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Region : MonoBehaviour
{
    public Transform position = null;
    public Collider trigger = null;

    public int sinTier = 0;

    private EventSystem m_eventSystem = null;

    [SerializeField] private MeshRenderer m_rendererTemp;
    [SerializeField] private Material[] m_testMaterials;
    [SerializeField] private int m_sinChance = 2;

    private float m_timer = 0.0f;
    private float m_delay = 0.0f;

    private void Start()
    {
        m_eventSystem = GameManager.Instance().eventSystem;
        m_eventSystem.regions.Add(this);

        m_timer = 0.0f;
        m_delay = Random.Range(1, m_sinChance);

        sinTier = 0;
    }

    private void Update()
    {
        if (sinTier >= 3)
        {
            m_timer = 0.0f;
            return;
        }

        m_timer += Time.deltaTime;

        if (m_timer >= m_delay)
        {
            Sin();

            m_delay = Random.Range(1, m_sinChance);
            m_timer = 0.0f;
        }
    }

    public void Strike()
    {
        Debug.Log("Strike!");

        sinTier--;

        if (sinTier <= 0)
        {
            m_eventSystem.RegionStoppedSinning(this);

            sinTier = 0;
        }

        m_rendererTemp.sharedMaterial = m_testMaterials[sinTier];
    }

    public void Sin()
    {
        Debug.Log("Sin!");

        if (sinTier <= 0)
        {
            m_eventSystem.RegionStartedSinning(this);
        }

        sinTier++;

        if (sinTier >= 3)
        {
            sinTier = 3;
        }

        m_rendererTemp.sharedMaterial = m_testMaterials[sinTier];
    }

}
