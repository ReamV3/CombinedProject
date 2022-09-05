using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Path_Steps_Slider : MonoBehaviour
{
    [SerializeField] Create_Board_GUI board;
    [SerializeField] Text pathText;
    [SerializeField] public int pathSize;

    Slider pathSlider;


    int sizeLimit;



    // Start is called before the first frame update
    void Start()
    {
        board = FindObjectOfType<Create_Board_GUI>();
        pathSlider = GetComponent<Slider>();    
    }

    // Update is called once per frame
    void Update()
    {
        sizeLimit = board.metrixSize - 1;
        pathSlider.maxValue = sizeLimit;
        pathSlider.minValue = 1;
        pathSlider.wholeNumbers = true;
        pathSize = (int)(pathSlider.value); // pathSizeValue;

        pathText.text = pathSize.ToString();

    }
}
