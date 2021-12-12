using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float m_health;
    public GameObject hp;

    public void Start()
    {
        if (gameObject.GetComponent<EnemySlasherAI>() != null)
        {
            hp = gameObject.transform.Find("hpbar").gameObject;
        }
    }


    public void TakeDamage(float damage)
    {
        m_health -= damage;

        if (gameObject.GetComponent<EnemySlasherAI>() != null)
        {
            HPdown();
        }

        if (m_health <= 0f)
        {
            Die();
        }
    }

    public void HPdown() 
    {
        Vector3 scaleChange = new Vector3(0.1f, 0, 0);

        hp.GetComponent<Transform>().localScale -= scaleChange;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}