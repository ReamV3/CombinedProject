using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enable_Canvas : MonoBehaviour
{
    [SerializeField] GameObject canvasGO;

    // Start is called before the first frame update

    public void CanvasEnable()
    {
        canvasGO.SetActive(true);
    }
}
