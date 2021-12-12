using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationManager : MonoBehaviour
{
    public static string m_nextSceneName;
    public static string m_lastSceneName;

    #region Singleton activation
    [HideInInspector] public static ApplicationManager instance;

    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    public static void LoadLevel(string levelName)
    {
        m_nextSceneName = levelName;
        m_lastSceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Loading");
    }
}
