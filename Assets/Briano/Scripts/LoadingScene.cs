using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    private AsyncOperation async;
    public Slider slider;
    private bool ready = false;
    public float time;

    void Start()
    {
        Time.timeScale = 1;
        //time = 0;
        async = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        async.allowSceneActivation = false;
        Invoke("Activate", 2);
    }

    void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void Update()
    {
        time += Time.deltaTime;
        if (!async.isDone)
        {
            float progress = Mathf.Clamp01(async.progress / .9f);
            slider.value = progress;
        }
        /*if (time >= 2)
        {
            ready = true;
        }*/
        if (async.progress >= 0.89f && ready)
        {
            async.allowSceneActivation = true;
        }
    }

    public void Activate()
    {
        ready = true;
        //async.allowSceneActivation = true;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
