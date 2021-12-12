using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyShooterAI : MonoBehaviour
{
    public float m_viewRange = 0f;
    public float m_attackRange = 0f;
    public float m_fireRate = 0.5f;
    public int m_accuracy = 0;
    [Space(5)]

    public bool m_canChase = true;
    public bool m_canFire = true;

    public Transform m_pistolStart;
    public GameObject m_bullet;

    public AudioClip[] m_shotSounds;
    private AudioSource m_audioSource;

    private float m_nextTimeToFire = 0f;

    private NavMeshAgent m_agent;
    private Transform m_player;

    private void Awake()
    {
        m_agent = GetComponent<NavMeshAgent>();
        m_audioSource = GetComponent<AudioSource>();
        m_player = GameObject.Find("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, m_player.transform.position);

        if (distance <= m_attackRange)
        {
            if (m_agent.destination != null)
                m_agent.ResetPath();

            if (m_canFire) Attack();
        }
        else if (distance > m_attackRange && distance <= m_viewRange)
        {
            if (m_canChase) Chase();
        }
    }

    private void Attack()
    {
        transform.LookAt(m_player);
        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);

        if (Time.time >= m_nextTimeToFire)
        {
            m_nextTimeToFire = Time.time + 1f / m_fireRate;

            if (Random.Range(0, m_accuracy) == 0)
            {
                // Hit is ok
                try { GameObject.Find("Level Manager").GetComponent<LevelManager>().m_time -= 5; } catch { }
                try { GameObject.Find("Camera").GetComponent<CameraController>().OnDamageTaken(); } catch { }

                GameObject bullet = Instantiate(m_bullet, m_pistolStart.position, m_pistolStart.rotation);
                Destroy(bullet, 1f);
            }
            else
            {
                // Hit is not ok

                GameObject bullet = Instantiate(m_bullet, m_pistolStart.position, Quaternion.Euler(m_pistolStart.rotation.eulerAngles.x, m_pistolStart.rotation.eulerAngles.y + Random.Range(-25f, 25f), m_pistolStart.rotation.eulerAngles.z));
                Destroy(bullet, 1f);
            }

            // Play sound
            m_audioSource.clip = m_shotSounds[Random.Range(0, m_shotSounds.Length)];
            m_audioSource.Play();
        }
    }

    private void Chase()
    {
        m_agent.SetDestination(m_player.position);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, m_viewRange);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, m_attackRange);
    }
}