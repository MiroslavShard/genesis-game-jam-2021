using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingController : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(LoadSceneAsync());
    }

    private IEnumerator LoadSceneAsync()
    {
        yield return new WaitForSeconds(1f);

        AsyncOperation asyncOperation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(ApplicationManager.m_nextSceneName, UnityEngine.SceneManagement.LoadSceneMode.Single);
        asyncOperation.allowSceneActivation = false;

        while (!asyncOperation.isDone)
        {
            yield return new WaitForSeconds(2f);
            asyncOperation.allowSceneActivation = true;
        }
    }
}
