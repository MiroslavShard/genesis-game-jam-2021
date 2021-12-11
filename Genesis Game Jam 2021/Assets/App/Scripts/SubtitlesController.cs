using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubtitlesController : MonoBehaviour
{
    public List<Subtitle> subtitles = new List<Subtitle>();
    [Space(5)]

    public Text m_text;

    private AudioSource m_audioSource;

    private void Start()
    {
        m_audioSource = GetComponent<AudioSource>();

        Play(0, 8);
    }

    public void Play(int startLine, int endLine)
    {
        StartCoroutine(Animate(startLine, endLine));
    }

    private IEnumerator Animate(int startLine, int endLine)
    {
        int currnetLine = startLine;

        while (currnetLine < endLine)
        {
            m_text.text = subtitles[currnetLine].m_text;
            m_audioSource.clip = subtitles[currnetLine].m_clip;
            m_audioSource.Play();
            yield return new WaitForSeconds(subtitles[currnetLine].m_duration);

            currnetLine += 1;
        }
    }
}

[System.Serializable]
public class Subtitle
{
    public string m_text;
    public float m_duration = 0f;
    [Space(5)]

    public AudioClip m_clip;
}