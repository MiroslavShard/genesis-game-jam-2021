using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScenario : MonoBehaviour
{
    public GameObject[] m_firstEnemies;
    public GameObject[] m_secondEnemies;
    public GameObject m_door;

    private bool m_firstKilled = false;

    private void Update()
    {
        if (!m_firstKilled && !m_firstEnemies[0] && !m_firstEnemies[1] && !m_firstEnemies[2])
        {
            m_firstKilled = true;
            OpenSecondRoom();
        }
    }

    public void OpenSecondRoom()
    {
        m_door.SetActive(false);

        foreach (var item in m_secondEnemies)
        {
            item.SetActive(true);
        }
    }

    public void GoNextLevel()
    {
        ApplicationManager.LoadLevel("Portal");
    }
}