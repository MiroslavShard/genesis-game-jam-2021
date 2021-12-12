using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScenario : MonoBehaviour
{
    public GameObject Music;
    private void Start()
    {
        StartCoroutine(PlayScenario1());
        
    }

    private IEnumerator PlayScenario1()
    {
        GameObject.Find("Player").GetComponent<CMF.AdvancedWalkerController>().enabled = false;
        yield return new WaitForSeconds(24f);
        GameObject.Find("Player").GetComponent<CMF.AdvancedWalkerController>().enabled = true;
        Music.SetActive(true);
    }

    private IEnumerator PlayScenario2()
    {
        GameObject.Find("Pill - Red").GetComponent<Collider>().enabled = false;
        GameObject.Find("Subtitles Controller").GetComponent<SubtitlesController>().Play(8, 11);
        Music.GetComponent<AudioSource>().volume = 0.12f;
        yield return new WaitForSeconds(6f);
        GameObject.Find("Pill - Red").GetComponent<Collider>().enabled = true;
    }

    private IEnumerator PlayScenario3()
    {
        try { Destroy(GameObject.Find("Pill - Blue")); } catch { }
        GameObject.Find("Subtitles Controller").GetComponent<SubtitlesController>().Play(11, 16);
        Music.GetComponent<AudioSource>().volume = 0.12f;
        yield return new WaitForSeconds(19f);
        ApplicationManager.LoadLevel("Tutorial");
    }

    public void OnBluePillPicked()
    {
        StartCoroutine(PlayScenario2());
    }

    public void OnRedPillPicked()
    {
        StartCoroutine(PlayScenario3());
    }
}