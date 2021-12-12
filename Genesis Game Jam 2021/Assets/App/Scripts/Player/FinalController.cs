using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalController : MonoBehaviour
{
    public Text gt;
    public Text coundowntxt;
    bool hasWon = false;

    public Image agentSm;
    public Sprite errorTxt;
    public AudioClip winSound;
    public GameObject loseScr;

    public float timeRemaining = 11;

    public string[] line;
    public int step = 0;

    void Start()
    {
        show();
    }

    public void show()
    {
        gt.text = line[step];
    }


    void Update()
    {
        if (hasWon == false)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                coundowntxt.text = ((int)timeRemaining).ToString();
            }
            else 
            {
                ApplicationManager.LoadLevel("Fail");
                loseScr.SetActive(true);
            }

            foreach (char c in Input.inputString)
            {
                if (gt.text == line[step])
                    gt.text = ""; //clears the initial text 

                if (c == '\b') // has backspace/delete been pressed?
                {
                    if (gt.text.Length != 0)
                    {
                        gt.text = gt.text.Substring(0, gt.text.Length - 1);
                    }
                }
                else if ((c == '\n') || (c == '\r')) // enter/return
                {
                    if (gt.text == "Start hack" && step == 0) //check if user entered correct command
                    {
                        gt.text = string.Empty;
                        step += 1;
                        timeRemaining = 8;
                        show();
                    }

                    if (gt.text == "Destroy virus" && step == 1) //check if user entered correct command
                    {
                        gt.text = string.Empty;
                        step += 1;
                        timeRemaining = 6;
                        show();
                    }

                    if (gt.text == "Fix bugs" && step == 2) //check if user entered correct command
                    {
                        gt.text = string.Empty;
                        step += 1;
                        timeRemaining = 99;
                        show();
                    }

                    if (gt.text == "Genesis the best" && step == 3) //check if user entered correct command
                    {
                        gt.text = string.Empty;
                        step += 1;
                        timeRemaining = 4;
                        show();
                    }

                    if (gt.text == "Kill Smith" && step == 4) //check if user entered correct command
                    {
                        gt.text = string.Empty;
                        step += 1;
                        show();
                    }

                    if (step == 5 && !hasWon)
                    {
                        Win();
                        hasWon = true;
                        agentSm.sprite = errorTxt;
                    }
                }
                else
                {
                    gt.text += c;
                }
            }
        }
    }

    public void Win() 
    {
        gameObject.GetComponent<AudioSource>().clip = winSound;
        gameObject.GetComponent<AudioSource>().volume = 0.35f;
        gameObject.GetComponent<AudioSource>().Play();
        gt.text = line[step];
        coundowntxt.gameObject.GetComponentInParent<AudioSource>().Stop();
    }

    public void Retry() 
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}