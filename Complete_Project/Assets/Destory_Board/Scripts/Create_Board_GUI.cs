using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Create_Board_GUI : MonoBehaviour
{
    public GameObject thisObject;
    public GridLayoutGroup gridBoard;
    public Rigidbody2D rigidbody2d;
    public BoxCollider2D boxcollider;
    [SerializeField] public Destory_Block destoryBlock;
    public Image blockImage;
    [SerializeField] public Sprite[] blockSprite = new Sprite[9];
    [SerializeField] public GameObject[,] metrixUI;
    public RectTransform rect;

    public float metrixSizef;
    public int metrixSize = 9;

    void Start()
    {
        //blockSprite[0].name = "UP-Block";
        //blockSprite[1].name = "DOWN-Block";
        //blockSprite[2].name = "RIGHT-Block";
        //blockSprite[3].name = "LEFT-Block";
        //blockSprite[4].name = "Basic-Block";
        //blockSprite[5].name = "Start-Block";
        //blockSprite[6].name = "End-Block";
        thisObject = this.gameObject;
        gridBoard = GetComponent<GridLayoutGroup>();
        destoryBlock = GetComponent<Destory_Block>();
        CreateBoard();
    }

    // Update is called once per frame
    void Update()
    {
       if(!destoryBlock.destroyOn)
        { 
        switch (metrixSize) // scale - row number - spacing 
        {
            case 9:
                SizeChecker();
                gridBoard.cellSize = new Vector2(140f, 140f);
                gridBoard.spacing = new Vector2(40f, 40f);
                ChangeColliderSize(140,3);
                gridBoard.constraintCount = 3;
                break;

            case 16:
                SizeChecker();
                gridBoard.cellSize = new Vector2(110f, 110f);
                gridBoard.spacing = new Vector2(20f, 20f);
                ChangeColliderSize(110,4);
                gridBoard.constraintCount = 4;
                break;

            case 25:
                SizeChecker();
                gridBoard.cellSize = new Vector2(90f, 90f);
                gridBoard.spacing = new Vector2(15f, 15f);
                ChangeColliderSize(90,5);
                gridBoard.constraintCount = 5;
                break;

            case 36:
                SizeChecker();
                gridBoard.cellSize = new Vector2(75f, 75f);
                gridBoard.spacing = new Vector2(10f, 10f);
                ChangeColliderSize(75,6);
                gridBoard.constraintCount = 6;
                break;

            case 49:
                SizeChecker();
                gridBoard.cellSize = new Vector2(65f, 65f);
                gridBoard.spacing = new Vector2(8f, 8f);
                ChangeColliderSize(65,7);
                gridBoard.constraintCount = 7;
                break;
        }
        }
    }

    public void CreateBoard()
    {
        metrixSizef = Mathf.Sqrt(metrixSize);
        metrixSize = (int)metrixSizef;
        metrixUI = new GameObject[metrixSize, metrixSize];
        for (int i = metrixSize - 1; i >= 0; i--)
        {
            for (int j = 0; j < metrixSize; j++)
            {
                metrixUI[i, j] = new GameObject();
                metrixUI[i, j].name = "block [" + i + "," + j + "]";
                blockImage = metrixUI[i, j].AddComponent<Image>();
                rigidbody2d = metrixUI[i, j].AddComponent<Rigidbody2D>();
                boxcollider = metrixUI[i, j].AddComponent<BoxCollider2D>();
                metrixUI[i, j].AddComponent<Define_Start_Block>();
                rigidbody2d.simulated = false;
                blockImage.sprite = blockSprite[4];
                metrixUI[i, j].transform.SetParent(thisObject.transform);
                rect = metrixUI[i, j].GetComponent<RectTransform>();
                rect.localScale = new Vector3(1f, 1f, 1f);
                rect.localPosition = new Vector3(0f, 0f, 0f);
            }
        }

    }

    public void blockImageChanger(int ir, int jr, int caseImage)
    {
        blockImage = metrixUI[ir, jr].GetComponent<Image>();
        blockImage.sprite = blockSprite[caseImage];

    }
    public void SizeChecker()
    {
        if (thisObject.transform.childCount != metrixSize)
        {
            Destorier();
            CreateBoard();

        }
    }
    public void Destorier()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    public void ChangeColliderSize(int boxSize, int metrixS)
    {
        for (int x = metrixS - 1; x >= 0; x--)
        {
            for (int y  = 0; y < metrixS; y++)
            {
                boxcollider = metrixUI[x, y].GetComponent<BoxCollider2D>();
                boxcollider.size = new Vector2(boxSize, boxSize);

            }
        }
    }
}
