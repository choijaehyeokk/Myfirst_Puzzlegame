using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public Slider progressbar;
    public Text loadtext;
    public static string loadScene;
    public static int loadType;

    private void Start()
    {
        StartCoroutine(LoadScene());
    }
    public static void LoadScenehandle(string name, int loadtype)
    {
        loadScene = name;
        loadType = loadtype;
        SceneManager.LoadScene("Loading");

    }
    IEnumerator LoadScene()
    {
        yield return null;
        AsyncOperation operation = SceneManager.LoadSceneAsync("Game Scene");

        operation.allowSceneActivation = false;
        while (!operation.isDone)
        {
            yield return null;

            if (loadType == 0)
                Debug.Log("새게임");
            else if (loadType == 1)
                Debug.Log("이전게임");

            if (progressbar.value < 0.9f)
            {
                progressbar.value = Mathf.MoveTowards(progressbar.value, 0.9f, Time.deltaTime);
            }
            else if (operation.progress >= 0.9f)
            {
                progressbar.value = Mathf.MoveTowards(progressbar.value, 1f, Time.deltaTime);

            }

            if (progressbar.value >= 1f)
            {
                loadtext.text = "TOUCH SCREEN!";
            }
            if (Input.GetMouseButtonDown(0) && progressbar.value >= 1f && operation.progress >= 0.9f)
            {
                operation.allowSceneActivation = true;
            }
        }
    }
}