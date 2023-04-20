using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierReflect : MonoBehaviour
{
    private Rigidbody m_rb;
    Vector3 m_velocity;

    private void Awake()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        m_velocity = m_rb.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            var speed = m_velocity.magnitude;
            var direction = Vector3.Reflect(m_velocity.normalized, collision.contacts[0].normal);

            m_velocity = direction * Mathf.Max(speed, 10f);
        }
    }
}
