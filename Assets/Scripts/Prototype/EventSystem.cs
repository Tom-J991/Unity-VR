using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void RegionStoppedSinning(Region region)
    {
        m_regionsSinning--;

        Debug.Log("Regions Sinning: " + m_regionsSinning);
    }
    
    public void RegionStartedSinning(Region region)
    {
        m_regionsSinning++;

        Debug.Log("Regions Sinning: " + m_regionsSinning);
    }
}
