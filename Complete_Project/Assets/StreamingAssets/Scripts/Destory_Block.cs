using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destory_Block : MonoBehaviour
{
    [SerializeField] Create_Board_GUI board;
    [SerializeField] public Button pathButton;
    [SerializeField] public Button destoryButton;
    [SerializeField] Random_Creator randomCreator;
    [SerializeField] float duration=5.5f;
    [SerializeField] Material shaderMaterial;
    [SerializeField] GameObject prefabParticals;

    public int speed = 4;
    public bool destroyOn = false;
    [SerializeField] public float shaderFade;
    [SerializeField] public float tempValue;


    Material shaderMat;
    ParticleSystem particals;
    GameObject newParticals;
    GameObject thisGO;
    Vector3 minBlockSize;
    Image blockImage;
    Color color;
    int startSizeValue;
    int shapeRadius;

    // Start is called before the first frame update
    void Start()
    {
        board = FindObjectOfType<Create_Board_GUI>();
        thisGO = GetComponent<GameObject>();
        randomCreator = FindObjectOfType<Random_Creator>();

    }

    // Update is called once per frame
    public void DestoryBlock()
    {
        switch (Mathf.Sqrt(board.metrixSize))
        {
            case 3:
                tempValue = 125f; // refrence for TempValue within Shader
                startSizeValue = 60;
                shapeRadius = 55;
                break;
            case 4:
                tempValue = 100f;
                startSizeValue = 50;
                shapeRadius = 45;
                break;
            case 5:
                tempValue = 75f;
                startSizeValue = 40;
                shapeRadius = 30;
                break;
            case 6:
                tempValue = 50f;
                startSizeValue = 35;
                shapeRadius = 25;
                break;
            case 7:
                startSizeValue = 30;
                tempValue = 35f;
                shapeRadius = 18;
                break;

        }
        Debug.Log("metrixSize:" + board.metrixSize + " tempValue:" + tempValue);

        minBlockSize = board.metrixUI[0,0].transform.localScale;
        for (int i = 0; i < randomCreator.metrixSize; i++)
        {
            for (int j = 0; j < randomCreator.metrixSize; j++)
            {
                if(randomCreator.checkMatrix[i,j])
                {

                    // var rectTran = board.metrixUI[i, j].GetComponent<RectTransform>();
                    // rectTran.localScale = new Vector3(0.1f, 0.1f, 1f);

                    //blockImage = board.metrixUI[i, j].GetComponent<Image>();
                    board.metrixUI[i, j].GetComponent<Image>().material = shaderMaterial;
                    shaderMat = board.metrixUI[i, j].GetComponent<Image>().material;
                    shaderMat.SetFloat("_Fade", 1.5f);
                    shaderMat.SetFloat("_Temp_Value", tempValue);
                    //shaderMat.SetVector("_Offset", new Vector2(UnityEngine.Random.Range(0, 100f), UnityEngine.Random.Range(0, 100f)));
                    ///// 
                    thisGO = board.metrixUI[i, j];
                    Instantiate(prefabParticals, board.metrixUI[i, j].transform.position, Quaternion.identity).transform.SetParent(thisGO.transform);
                    particals=prefabParticals.GetComponent<ParticleSystem>();
                    var mainParticalsSize = particals.main;
                    mainParticalsSize.startSize = startSizeValue;
                    var mainShapeSize = particals.shape;
                    mainShapeSize.radius = shapeRadius;
                    


                    /////

                    StartCoroutine(DelayTime(1.5f, duration, i, j));

                }
            }
        }

        pathButton.interactable = false;
        destoryButton.interactable = false;
        destroyOn = true;

        
            
    }
     IEnumerator DelayTime(float fade, float time,int x, int y)
    {
        float t = 0.0f;
        float rate;
        rate = (1f / time) * speed;
        while (t < 1.0f)
        {
            t += Time.deltaTime * rate;
            board.metrixUI[x, y].GetComponent<Image>().material.SetFloat("_Fade", Mathf.Lerp(fade, 0.01f, t));
            yield return null;
        }     
    }

}
