using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;

public class Random_Creator : MonoBehaviour
{
    public int i, j, u, d, l, r;
    public float metrixSizef;
    public int metrixSize;
    public int temp = 0; 
    public bool startCheck=false;
    [SerializeField] Create_Board_GUI board;
    [SerializeField] Path_Steps_Slider pathSteps;
    [SerializeField] Destory_Block destoryBlock;
    [SerializeField] public bool[,] checkMatrix;
    [SerializeField] int pathSize;
    [SerializeField] Text outPutMessage;

    Image blockImage;


    // Start is called before the first frame update
    private void Start()
    {
        board = FindObjectOfType<Create_Board_GUI>();
        pathSteps = FindObjectOfType<Path_Steps_Slider>();
        destoryBlock = FindObjectOfType<Destory_Block>();
        destoryBlock.destoryButton.interactable = false ;

    }
    private void Update()
    {
        metrixSizef = Mathf.Sqrt(board.metrixSize);
        metrixSize = (int)metrixSizef;
        pathSize = pathSteps.pathSize;
    }

    public void SetPath()
    {

        temp = 0;
        destoryBlock.destoryButton.interactable = false;
        checkMatrix = new bool[metrixSize, metrixSize];
        r = 0; l = 0; u = 0; d = 0;
        for (int p = metrixSize - 1; p >= 0; p--)
        {
            for (int h = 0; h < metrixSize; h++)
            {
                checkMatrix[p, h] = false;
                //blockImage = board.metrixUI[p, h].GetComponent<Image>();
                //if (blockImage.sprite == board.blockSprite[5])
                //{
                //    checkMatrix[p, h] = true;
                //    continue;
                //}
                board.blockImageChanger(p, h, 4);

            }
        }


        // create arr of path cordinates
        // starting point [i,j]
        if (!startCheck) { SetStartPoint(i, j, false); }
        else if (startCheck) { board.blockImageChanger(i, j, 5); }
        checkMatrix[i, j] = true;
        pathSize--;
        Debug.Log("(" + i + "," + j + ")");

        do
        {

            int steps = UnityEngine.Random.Range(0, 4);

            if ((d == 1 || u == 1) && (l == 1 || r == 1)) // corner
            {
                if (((i - 1 < 0) || (i + 1 >= metrixSize)) && ((j - 1 < 0) || (j + 1 >= metrixSize)))
                {
                    board.blockImageChanger(i, j, 7);
                    Debug.Log("No Valid Step, Partly Path - Corner");
                    outPutMessage.text = "No Valid Step, Partly Path - Corner";
                    temp = 1;
                    break;
                }
            }

            if ((d == 1 && u == 1 && r == 1) || (d == 1 && u == 1 && l == 1) ||
                (d == 1 && r == 1 && l == 1) || (u == 1 && r == 1 && l == 1)) // edge
            {
                if ((i - 1 < 0) || (i + 1 >= metrixSize) || (j - 1 < 0) || (j + 1 >= metrixSize))
                {
                    board.blockImageChanger(i, j, 7);
                    Debug.Log("No Valid Step, Partly Path - Edge");
                    outPutMessage.text = "No Valid Step, Partly Path - Edge";
                    temp = 1;
                    break;
                }
            }

            if (d == 1 && u == 1 && r == 1 && l == 1) // middle
            {
                board.blockImageChanger(i, j, 7);
                Debug.Log("No Valid Step, Partly Path - Middle");
                outPutMessage.text = "No Valid Step, Partly Path - Middle";
                temp = 1;
                break;
            }

            if (steps == 0 && i + 1 < metrixSize) // down
            {
                if (checkMatrix[i + 1, j]) { d = 1; continue; }
                else
                {
                    i++;
                    board.blockImageChanger(i, j, 1);
                    r = 0; l = 0; u = 0; d = 0;
                    checkMatrix[i, j] = true;
                    pathSize--;
                    Debug.Log("(" + i + "," + j + ")");

                }
            }
            else if (steps == 1 && i - 1 >= 0) // up
            {
                if (checkMatrix[i - 1, j]) { u = 1; continue; }
                else
                {
                    i--;
                    board.blockImageChanger(i, j, 0);
                    r = 0; l = 0; u = 0; d = 0;
                    checkMatrix[i, j] = true;
                    pathSize--;
                    Debug.Log("(" + i + "," + j + ")");

                }
            }
            else if (steps == 2 && j + 1 < metrixSize) // right
            {
                if (checkMatrix[i, j + 1]) { r = 1; continue; }
                else
                {
                    j++;
                    board.blockImageChanger(i, j, 2);
                    r = 0; l = 0; u = 0; d = 0;
                    checkMatrix[i, j] = true;
                    pathSize--;
                    Debug.Log("(" + i + "," + j + ")");

                }
            }
            else if (steps == 3 && j - 1 >= 0) // left
            {
                if (checkMatrix[i, j - 1]) { l = 1; continue; }
                else
                {
                    j--;
                    board.blockImageChanger(i, j, 3);
                    r = 0; l = 0; u = 0; d = 0;
                    checkMatrix[i, j] = true;
                    pathSize--;
                    Debug.Log("(" + i + "," + j + ")");
                }
            }


        } while (pathSize + 1 > 0); // while for path - with (pathSize) numbers of steps



        if (temp == 0)
        {
            board.blockImageChanger(i, j, 6);
            outPutMessage.text = "Successfull Path - All Steps Completed";
            Debug.Log("Successfull Path - All Steps Completed");
            destoryBlock.destoryButton.interactable = true;
        }

    }

    public void SetStartPoint(int x, int y, bool been)
    {
        if (been)
        {
            for (int p = metrixSize - 1; p >= 0; p--)
            {
                for (int h = 0; h < metrixSize; h++)
                {
                    board.blockImageChanger(h, p, 4);
                }
            }
            //  i = UnityEngine.Random.Range(0, metrixSize - 1);
            //  j = UnityEngine.Random.Range(0, metrixSize - 1);
            board.blockImageChanger(x, y, 5);
            startCheck = true;
            i = x;
            j = y;
            return;

        }
        else if (!been)
        {
            i = UnityEngine.Random.Range(0, metrixSize - 1);
            j = UnityEngine.Random.Range(0, metrixSize - 1);
            board.blockImageChanger(i, j, 5);
            return;
        }

    }

    public void ErrorPathMessage()
    {
        outPutMessage.text = "Path wasn't completed try agaian!";
    }

    public void RestBoard()
    {
        outPutMessage.text = "Clear";
        for (int i = metrixSize - 1; i >= 0; i--)
        {
            for (int j = 0; j < metrixSize; j++)
            {
                checkMatrix[i, j] = false;
                board.blockImageChanger(i, j, 4);
                blockImage = board.metrixUI[i, j].GetComponent<Image>();
                board.metrixUI[i, j].GetComponent<Image>().material = null;


            }
        }
        startCheck = false;
        destoryBlock.pathButton.interactable = true;
        destoryBlock.destoryButton.interactable = false;
        destoryBlock.destroyOn = false;
        
    }
}

