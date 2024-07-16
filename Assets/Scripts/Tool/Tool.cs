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

    protected Vector3 m_startPos;
    protected Quaternion m_startRot;

    [SerializeField] protected AudioSource shoot;

    [SerializeField] protected AudioClip m_impactSound;
    [SerializeField] protected AudioClip m_travelSound;

    private Rigidbody m_rb;

    protected float m_lastShot;

    virtual protected void Start()
    {
        m_startPos = transform.position;
        m_startRot = transform.rotation;

        m_rb = GetComponent<Rigidbody>();
    }

    virtual public void Shot()
    {
        if (m_lastShot > Time.time) return;

        m_lastShot = Time.time + m_shootDelay;
    }

    virtual protected void Update()
    {
        if (Vector3.Distance(transform.position, Vector3.zero) > 10.0f)
        {
            transform.position = m_startPos;
            transform.rotation = m_startRot;

            m_rb.velocity = Vector3.zero;
            m_rb.angularVelocity = Vector3.zero;
        }
    }
}
