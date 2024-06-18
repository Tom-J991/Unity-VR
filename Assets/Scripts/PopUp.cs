using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type
{
    sinner,
    prayer
}
public class PopUp : MonoBehaviour
{
    public Type m_type;
    [Range(1,3), SerializeField] private int m_level;

    private bool m_isPlagued;

    public bool Plagued
    {
        get { return m_isPlagued; }
        set
        {
            m_isPlagued = value;
        }
    }

    public int Level 
    { 
        get { return m_level; }
        set { m_level = value; }
    }
    private void Start()
    {
    
    }
}
