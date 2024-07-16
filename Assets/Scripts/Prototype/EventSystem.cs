using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The event system. Keeps track of every region and the events happening across them.
/// </summary>
public class EventSystem : MonoBehaviour
{
    public List<Region> regions;

    private int m_regionsSinning = 0;
    private int m_regionsBelieving = 0;

    public int score;

    public int[] sinScores = new int[3];
    public int[] miracleScores = new int[3];

    public int missMatchScore;
    public int leftScore;

    public int GetSinners() { return m_regionsSinning; }
    public int GetBelievers() { return m_regionsBelieving; }

    private void Awake()
    {
        GameManager.Instance().SetEventSystem(this);
        GameManager.Instance().OnStart();
    }

    private void Update()
    {
        
    }

    /// <summary>
    /// Tells the event system that a given region has stopped sinning. Sin tier <= 0
    /// </summary>
    /// <param name="region">The region.</param>
    public void RegionStoppedSinning(Region region)
    {
        m_regionsSinning--;

        if (m_regionsSinning < 0) // Clamp.
            m_regionsSinning = 0;

        Debug.Log("Regions Sinning: " + m_regionsSinning);
    }
    
    /// <summary>
    /// Tells the event system that a given region has begun to sin. Sin tier > 0
    /// </summary>
    /// <param name="region">The region.</param>
    public void RegionStartedSinning(Region region)
    {
        m_regionsSinning++;

        Debug.Log("Regions Sinning: " + m_regionsSinning);
    }

    /// <summary>
    /// Tells the event system that a given region has stopped believing. Believe tier <= 0
    /// </summary>
    /// <param name="region">The region.</param>
    public void RegionStoppedBelieving(Region region)
    {
        m_regionsBelieving--;

        if (m_regionsBelieving < 0) // Clamp.
            m_regionsBelieving = 0;

        Debug.Log("Regions Believing: " + m_regionsBelieving);
    }

    /// <summary>
    /// Tells the event system that a given region has begun to believe. Believe tier > 0
    /// </summary>
    /// <param name="region">The region.</param>
    public void RegionStartedBelieving(Region region)
    {
        m_regionsBelieving++;

        Debug.Log("Regions Believing: " + m_regionsBelieving);
    }
}
