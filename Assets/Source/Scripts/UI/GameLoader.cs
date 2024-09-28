using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
    public float Progress { get; private set; }

    public void Load(string sceneName) =>
        StartCoroutine(Loading(sceneName));

    private IEnumerator Loading(string sceneName)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);

        while (asyncOperation.isDone == false)
        {
            Progress = asyncOperation.progress;
            yield return null;
        }
    }
}
