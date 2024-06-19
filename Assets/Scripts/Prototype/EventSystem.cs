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

    private void Awake()
    {
        GameManager.Instance().SetEventSystem(this);
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
}
