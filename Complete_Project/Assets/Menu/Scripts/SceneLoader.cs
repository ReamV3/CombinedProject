using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    Camera mainCamera;
    [SerializeField] float speedRate = 0.5f;
    [SerializeField] GameObject dontDestory;
    [SerializeField] Animator gOAnimator;
    [SerializeField] Enable_Canvas enableCanvas;

    private void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
    }


    // Start is called before the first frame update
    public void StartGame()
    {
        Mathf.Lerp(mainCamera.transform.localPosition.y, 0f, Time.deltaTime*speedRate);
        int currentScene;
        currentScene = SceneManager.GetActiveScene().buildIndex;
        if (currentScene != 1)
        {
            SceneManager.LoadScene(1);
            
        }
        else return;
    }


    public void AddSceneTwo()
    {

        enableCanvas.CanvasEnable();
        int currentScene;
        currentScene = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(currentScene);
        if (currentScene != 2)
        {
            SceneManager.LoadScene(2, LoadSceneMode.Additive);
        }
        else return;
    }
  

    public void About()
    {
        int currentScene;
        currentScene = SceneManager.GetActiveScene().buildIndex;
        if (currentScene != 3)
        {
            SceneManager.LoadScene(3, LoadSceneMode.Additive);
        }
        else return;
    }

    public void QuitApp()
    {
        Application.Quit();
    }


}
