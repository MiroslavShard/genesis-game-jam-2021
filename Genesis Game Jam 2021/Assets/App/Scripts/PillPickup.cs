using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PillPickup : MonoBehaviour
{
    public UnityEvent m_event;

    [Header("Rotation Settings")]
    public Vector3 m_rotation;
    public float m_speed = 3f;

    private void FixedUpdate()
    {
        transform.Rotate(m_rotation * m_speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_event.Invoke();

            Destroy(gameObject);
        }
    }
}