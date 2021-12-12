using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySlasherAI : MonoBehaviour
{
    public float m_viewRange = 0f;
    public float m_attackRange = 0f;
    public float m_slashRate = 1.5f;

    public GameObject m_sword;
    public PlayerSlasherController player;

    private AudioSource enemy_sound;
    

    private float m_nextTimeToSlash = 0f;

    private NavMeshAgent m_agent;
    private Transform m_player;

    public bool isAttacking = true;
    public float player_distance;

    private void Start()
    {
        m_viewRange = 20;
        m_attackRange = 3;
    }

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerSlasherController>();
        m_agent = GetComponent<NavMeshAgent>();
        enemy_sound = GetComponent<AudioSource>();
        m_player = player.transform;
    }


    void Update()
    {
        float distance = Vector3.Distance(transform.position, m_player.transform.position);
        player_distance = distance;

        if (distance <= m_attackRange)
        {
            if (m_agent.destination != null)
                m_agent.ResetPath();

            if (isAttacking == true)
                Attack();
        }
        else if (distance > m_attackRange && distance <= m_viewRange)
        {
            Chase();
        }
    }

    private void Attack() 
    {
        transform.LookAt(m_player);
        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);

        if (Time.time >= m_nextTimeToSlash)
        {
            m_nextTimeToSlash = Time.time + 2f / m_slashRate;

            transform.GetComponentInChildren<Animation>().Play();
            enemy_sound.Play();

            //reduce time and play slash sound
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

    void OnTriggerEnter(Collider targetObj)
    {
        if (targetObj.gameObject.CompareTag("PlayerSword"))
        {
            //sword is in the strike zone
            player.canHit = true;
            player.enemy = gameObject;
        }
    }
    void OnTriggerExit(Collider targetObj)
    {
        if (targetObj.gameObject.CompareTag("PlayerSword"))
        {
            //sword isn't in the strike zone
            player.canHit = false;
        }
    }
}
