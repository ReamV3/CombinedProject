using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestoryBoard_Reload : MonoBehaviour
{
    public void MoveGameObject1()
    {
        SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetSceneByBuildIndex(1));

    }
    public void MoveGameObject2()
    {
        SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetSceneByBuildIndex(2));
        //change camera to camera 1
    }
}

