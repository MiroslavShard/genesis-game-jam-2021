using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public int sceneIndex;

    void OnMouseDown()
    {
        SceneManager.LoadScene(sceneIndex);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
