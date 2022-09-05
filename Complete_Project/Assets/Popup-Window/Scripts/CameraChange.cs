using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    [SerializeField] Camera cam1;
    [SerializeField] GameObject cam2;
    [SerializeField] Camera worldCamera;

    [SerializeField] Canvas myCanvas;


    private void Start()
    {
        cam1 = GameObject.Find("Main Camera").GetComponent<Camera>();
        cam2 = GameObject.Find("Main Camera2");
        myCanvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        myCanvas.worldCamera = cam1;
        myCanvas.renderMode = RenderMode.ScreenSpaceCamera;
        myCanvas.sortingOrder = 35;
        cam2.SetActive(false);

    }

}
