using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Volume_Controller : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] AudioSource audioSourceGameObject;

    private void Awake()
    {
        volumeSlider = GameObject.Find("Slider").GetComponent<Slider>();
        volumeSlider.value = 0.5f;
        audioSourceGameObject = GetComponent<AudioSource>();
    }
    void Update()
    {
        audioSourceGameObject.volume = volumeSlider.value;
    }
}
