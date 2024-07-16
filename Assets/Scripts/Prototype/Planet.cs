using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The planet. Does whatever a planet can.
/// </summary>
public class Planet : MonoBehaviour
{
    public float rotateSpeed = 1.0f;

    private float m_rotation = 0.0f;

    private void FixedUpdate()
    {
        // Rotate planet.
        m_rotation -= Time.fixedDeltaTime * rotateSpeed;

        // Clamp variable to avoid potential overflow.
        if (m_rotation > 360.0f)
            m_rotation -= 360.0f;
        if (m_rotation < -360.0f)
            m_rotation += 360.0f;

        transform.localRotation = Quaternion.Euler(m_rotation * transform.up);
    }

}
