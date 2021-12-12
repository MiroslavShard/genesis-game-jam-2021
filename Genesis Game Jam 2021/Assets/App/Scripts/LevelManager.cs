using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public int m_time = 0;
    [Space(5)]

    public Text m_timeText;

    private int m_totalTime = 0;

    private void Start()
    {
        m_totalTime = m_time;

        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        System.TimeSpan time = System.TimeSpan.FromSeconds(m_time);
        m_timeText.text = $"Осталось времени: {time.Hours:D2}:{time.Minutes:D2}:{time.Seconds:D2}";

        while (true)
        {
            yield return new WaitForSeconds(1f);

            m_time -= 1;

            time = System.TimeSpan.FromSeconds(m_time);
            m_timeText.text = $"Осталось времени: {time.Hours:D2}:{time.Minutes:D2}:{time.Seconds:D2}";

            if (m_time <= 0)
            {
                ApplicationManager.LoadLevel("Fail");
            }

            float progress = (float)m_time / (float)m_totalTime;
            GameObject.Find("Camera").GetComponent<CameraController>().UpdateCameraEffect(1f - progress);
        }
    }
}