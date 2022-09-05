using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slider_Control : MonoBehaviour
{
    Slider slider;
    [SerializeField] Create_Board_GUI board;
    [SerializeField] Text sliderText;

    // Start is called before the first frame update
    void Start()
    {
        board = FindObjectOfType<Create_Board_GUI>();
        slider = gameObject.GetComponent<Slider>();
        //slider.value = metrix size;


    }

    // Update is called once per frame
    void Update()
    {
        switch (slider.value)
        {
            case 0:
                board.metrixSize = 9;
                sliderText.text = ("3x3");
                break;
            case 1:
                board.metrixSize = 16;
                sliderText.text = ("4x4");
                break;
            case 2:
                board.metrixSize = 25;
                sliderText.text = ("5x5");
                break;
            case 3:
                board.metrixSize = 36;
                sliderText.text = ("6x6");
                break;
            case 4:
                board.metrixSize = 49;
                sliderText.text = ("7x7");
                break;


        }
    }
}
