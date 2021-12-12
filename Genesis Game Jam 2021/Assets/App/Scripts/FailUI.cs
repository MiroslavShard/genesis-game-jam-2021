using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailUI : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Retry();
        }    
    }

    public void Retry()
    {
        ApplicationManager.LoadLevel(ApplicationManager.m_lastSceneName);
    }
}