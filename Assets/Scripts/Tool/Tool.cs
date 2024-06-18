using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{
    [Range(0, 2000), SerializeField] protected float m_speed;
    [Range(1, 3), SerializeField] protected int m_level;
    public Type currentType;

    [Space]

    protected Manager m_manager;

    [Space]

    [SerializeField] protected GameObject m_bulletPrefab;
    [SerializeField] protected Transform m_bulletPos;
    [SerializeField] protected float m_shootDelay;

    protected float m_lastShot;

    virtual protected void Start()
    {
        m_manager = FindObjectOfType<Manager>();
    }

    virtual public void Shot()
    {
        if (m_lastShot > Time.time) return;

        m_lastShot = Time.time + m_shootDelay;


    }
}
