using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class SceneManager : MonoBehaviour
{
    private LoadingUI loadingUI;

    private BaseScene curScene;
    public BaseScene CurScene
    {
        get
        {
            if (curScene == null)
                curScene = GameObject.FindObjectOfType<BaseScene>();

            return curScene;
        }
    }

    private void Awake()
    {
        LoadingUI loadingUI = Resources.Load<LoadingUI>("UI/LoadingUI");
        this.loadingUI = Instantiate(loadingUI);
        this.loadingUI.transform.SetParent(transform);
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadingRoutine(sceneName));
    }

    IEnumerator LoadingRoutine(string sceneName)
    {
        loadingUI.SetProgress(0f);
        loadingUI.FadeOut();
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0f;

        AsyncOperation oper = UnitySceneManager.LoadSceneAsync(sceneName);
        while (!oper.isDone)
        {
            loadingUI.SetProgress(oper.progress);
            yield return null;
        }

        loadingUI.SetProgress(1f);
        loadingUI.FadeIn();
        Time.timeScale = 1f;
        yield return new WaitForSeconds(0.5f);
    }
}
