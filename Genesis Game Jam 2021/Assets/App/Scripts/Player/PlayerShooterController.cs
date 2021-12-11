using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class PlayerShooterController : MonoBehaviour
{
    [Header("Properties")]
    public float m_damage = 10f;
    public float m_range = 100f;
    public float m_fireRate = 15f;
    [Space(5)]

    public bool m_allowShooting = true;

    [Header("Other")]
    public GameObject m_impactEffect;
    [Space(5)]

    public AudioClip[] m_shotSounds;

    private float m_nextTimeToFire = 0f;

    private Camera m_camera;
    private AudioSource m_audioSource;

    private void Start()
    {
        m_camera = GetComponent<Camera>();
        m_audioSource = GetComponent<AudioSource>();
    }

    public void Update()
    {
        if (m_allowShooting && Input.GetMouseButton(0) && Time.time >= m_nextTimeToFire)
        {
            m_nextTimeToFire = Time.time + 1f / m_fireRate;
            Shoot();
        }
    }

    private void Shoot()
    {
        // Play particle effect

        RaycastHit hit;

        if (Physics.Raycast(m_camera.transform.position, m_camera.transform.forward, out hit, m_range))
        {
            Debug.Log(hit.transform.name);

            if (hit.transform.GetComponent<EnemyHealth>() != null)
            {
                EnemyHealth enemyHealth = hit.transform.GetComponent<EnemyHealth>();
                enemyHealth.TakeDamage(m_damage);
            }
        }

        // Play sound
        m_audioSource.clip = m_shotSounds[Random.Range(0, m_shotSounds.Length)];
        m_audioSource.Play();

        // Impact effect
        GameObject impact = Instantiate(m_impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 2f);
    }
}