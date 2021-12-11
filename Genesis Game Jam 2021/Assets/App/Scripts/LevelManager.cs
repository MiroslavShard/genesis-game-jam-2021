using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int m_time = 0;

    private int m_totalTime = 0;

    private void Start()
    {
        m_totalTime = m_time;

        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            m_time -= 1;

            if (m_time <= 0)
            {
                // end game
            }

            float progress = (float)m_time / (float)m_totalTime;
            Camera.current.GetComponent<CameraController>().UpdateCameraEffect(1f - progress);
        }
    }
}