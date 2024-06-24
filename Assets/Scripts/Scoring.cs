using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    [SerializeField] private float m_maxBarSize;
    [SerializeField] private float m_prayers;
    [SerializeField] private float m_sinners;
    [SerializeField] Slider slider;

    private void Start()
    {
        m_prayers = m_maxBarSize;
        m_sinners = 0;
    }
    private void Update()
    {
        Mathf.Clamp(m_sinners, 0, m_maxBarSize);
        Mathf.Clamp(m_prayers, 0, m_maxBarSize);

        slider.value = m_sinners / m_maxBarSize;
    }

    public void Sin(float amount)
    {
        m_sinners += amount;
    }
    public void Pray(float amount)
    {
        m_prayers += amount;
    }
}
