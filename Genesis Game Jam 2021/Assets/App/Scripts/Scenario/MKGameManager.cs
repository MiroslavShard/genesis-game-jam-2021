using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MKGameManager : MonoBehaviour
{
    [Header("Objects")]
    public GameObject player;
    public GameObject[] enemies;
    public GameObject gate;

    public bool wasFirstDefeated = false;
    public bool wasSecondDefeated = false;
    public bool wasThirdDefeated = false;

    public int killcount = 0;


    void Start()
    {
        
    }

    
    void Update()
    {
        if (killcount == 3)
        {
            EnemiesDefeated();
        }
        if (wasFirstDefeated == true)
        {
            enemies[1].SetActive(true);
            wasFirstDefeated = false;
        }
        if (wasSecondDefeated == true) 
        {
            enemies[2].SetActive(true);
            wasSecondDefeated = false;
        }
    }


    public void EnemiesDefeated() 
    {
        killcount = 0;
        gate.GetComponent<Animation>().Play(); //gate is lifted
    }

    public void GoNextLevel()
    {
        ApplicationManager.LoadLevel("Mario");
    }

}
