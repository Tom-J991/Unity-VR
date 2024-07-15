using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tool : MonoBehaviour
{
    [Range(0, 2000), SerializeField] protected float m_speed;
    [Range(1, 3), SerializeField] protected int m_level;

    [SerializeField] protected Transform m_infoPos;

    [SerializeField] protected GameObject m_bulletPrefab;
    [SerializeField] protected Transform m_bulletPos;
    [SerializeField] protected float m_shootDelay;

    protected float m_lastShot;

    virtual protected void Start()
    {
    }

    virtual public void Shot()
    {
        if (m_lastShot > Time.time) return;

        m_lastShot = Time.time + m_shootDelay;


    }

    protected void Update()
    {
    }
}
