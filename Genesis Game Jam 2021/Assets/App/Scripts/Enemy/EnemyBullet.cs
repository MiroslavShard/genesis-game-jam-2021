using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float m_speed = 10f;

    private Rigidbody m_rigidbody;

    private void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.position += transform.forward * m_speed * Time.deltaTime;
    }
}
