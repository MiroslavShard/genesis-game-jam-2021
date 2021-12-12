using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlasherController : MonoBehaviour
{
    [Header("Properties")]
    public float m_damage = 10f;
    public float m_range = 3f;
    public float m_slashrate = 3f;

    [Header("Other")]
    public GameObject m_impactEffect;
    public Animation anim;

    [Header("Audio")]
    private AudioSource player_sound;
    public AudioClip slash_sound;
    public AudioClip super_slash_sound;
    public AudioClip finish_sound;

    private float m_nextTimeToSlash = 0f;

    private Camera m_camera;

    bool wasFINISHED = false;
    public bool canHit = false;
    public GameObject enemy;

    public MKGameManager manager;

    void Start()
    {
        m_camera = GetComponent<Camera>();
        anim = transform.GetComponent<Animation>();
        player_sound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= m_nextTimeToSlash)
        {
            m_nextTimeToSlash = Time.time + 1f / m_slashrate;
            Slash();
        }
        if (manager.wasThirdDefeated == true)
        {
            canHit = false;
            wasFINISHED = true;
        }
    }
    public void Slash()
    {
        RaycastHit hit;
        Physics.Raycast(m_camera.transform.position, m_camera.transform.forward, out hit, m_range);

        if (canHit == true)
        {
            if (transform.GetComponent<Animation>().isPlaying == false)
            {
                if (enemy.transform.GetComponent<EnemyHealth>() != null)
                {
                    EnemyHealth enemyHealth = enemy.transform.GetComponent<EnemyHealth>();

                    if (enemyHealth.m_health <= 10.0f)
                    {
                        StartCoroutine(FinishHim(enemyHealth, hit));
                    }
                    else 
                    {
                        player_sound.clip = slash_sound;
                        player_sound.Play();

                        enemyHealth.TakeDamage(m_damage);

                        GameObject impact = Instantiate(m_impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                        Destroy(impact, 2f);
                    }
                }
            }
        }
        if (wasFINISHED == false)
        {
            anim.Play("player_swing"); 
        }
    }

    IEnumerator FinishHim(EnemyHealth hp, RaycastHit enemy)
    {
        hp.HPdown();
        wasFINISHED = true;

        //enemy.transform.GetComponent<EnemySlasherAI>().isAttacking = false;

        player_sound.clip = finish_sound;
        player_sound.Play();

        anim.Play("super_slash");
        yield return new WaitForSeconds(finish_sound.length - 0.5f);

        player_sound.clip = super_slash_sound;
        player_sound.Play();
        if (manager.killcount == 0)
        {
            manager.wasFirstDefeated = true;
        }
        else if (manager.killcount == 1)
        {
            manager.wasSecondDefeated = true;
        }
        else if (manager.killcount == 2)
        {
            manager.wasThirdDefeated = true;
        }
        manager.killcount++;

        hp.TakeDamage(m_damage);
        GameObject impact = Instantiate(m_impactEffect, enemy.point, Quaternion.LookRotation(enemy.normal));
        Destroy(impact, 2f);

        wasFINISHED = false;
    }

    


}
