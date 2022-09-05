using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Sound_Button_Controller : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] Sprite[] images = new Sprite[2];
    Image buttonImage;

    private void Awake()
    {
        volumeSlider = GameObject.Find("Slider").GetComponent<Slider>();
        buttonImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (volumeSlider.value == 0)
        {
            buttonImage.sprite = images[1];
        }
        else
        {
            buttonImage.sprite = images[0];
        }

    }
}
