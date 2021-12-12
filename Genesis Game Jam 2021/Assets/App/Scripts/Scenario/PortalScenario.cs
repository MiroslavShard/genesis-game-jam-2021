using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScenario : MonoBehaviour
{
    public GameObject[] m_enemies0;
    private bool m_killed0 = false;
    [Space(5)]

    public GameObject[] m_enemies1;
    public GameObject m_door1;
    private bool m_killed1 = false;
    [Space(5)]

    public GameObject[] m_enemies2;
    public GameObject m_door2;
    private bool m_killed2 = false;
    [Space(5)]

    public GameObject[] m_enemies3;
    public GameObject m_door3;
    private bool m_killed3 = false;

    // Sheeeeesh this code is piece of shit

    private void Update()
    {
        if (!m_killed0 && CheckKills(m_enemies0))
        {
            m_killed0 = true;
            OpenFirstRoom();
        }

        if (m_killed0 && !m_killed1 && CheckKills(m_enemies1))
        {
            m_killed1 = true;
            OpenSecondRoom();
        }

        if (m_killed0 && m_killed1 && !m_killed2 && CheckKills(m_enemies2))
        {
            m_killed2 = true;
            OpenThirdRoom();
        }
    }

    public void GoNextLevel()
    {
        ApplicationManager.LoadLevel("MortalKombat");
    }

    private void OpenFirstRoom()
    {
        m_door1.SetActive(false);

        foreach (var item in m_enemies1)
            item.SetActive(true);
    }

    private void OpenSecondRoom()
    {
        m_door2.SetActive(false);

        foreach (var item in m_enemies2)
            item.SetActive(true);
    }

    private void OpenThirdRoom()
    {
        m_door3.SetActive(false);

        foreach (var item in m_enemies3)
            item.SetActive(true);
    }

    private bool CheckKills(GameObject[] enemies)
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i])
            {
                return false;
            }
        }

        return true;
    }
}