using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] private List<Transform> m_contients = new();
    private List<PopUp> m_popUps = new();

    public PopUp Pop 
    { 
        set 
        {
            m_popUps.Add(value);
        } 
    }

    private int m_contientsIndex;
    [SerializeField] private float m_maxDelayOfSpawn;
    private float m_spawnDelay;

    private Scoring m_score;
    private SpawnEvent m_spawnEvent;

    private void Start()
    {
        m_contientsIndex = Random.Range(0, m_contients.Count);
        m_score = GetComponent<Scoring>();
        m_spawnEvent = GetComponent<SpawnEvent>();
        m_spawnEvent.SpawnPopUp(m_contients[m_contientsIndex], this);
    }

    private void Update()
    {
        SpawnEvent();
    }

    void SpawnEvent()
    {
        if (m_spawnDelay > Time.time) return;

        m_spawnDelay = Time.time + m_maxDelayOfSpawn;

        m_contientsIndex = Random.Range(0, m_contients.Count);

        m_spawnEvent.SpawnPopUp(m_contients[m_contientsIndex], this);
    }

    public Scoring ReturnScore() { return m_score; }

}
