using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class Destory_Block : MonoBehaviour
{
    [SerializeField] Create_Board_GUI board;
    [SerializeField] public Button pathButton;
    [SerializeField] public Button destoryButton;
    [SerializeField] public Button restartButton;
    [SerializeField] public Slider silderSize;
    [SerializeField] public Slider silderPath;
    [SerializeField] Random_Creator randomCreator;
    [SerializeField] float duration=6f;
    [SerializeField] Material shaderMaterial;
    [SerializeField] GameObject prefabParticals;

    public SceneLoader sceneLoader;
    [SerializeField] DontDestoryScript dontDestoryScript;

    public  int currentScene;
    public int speed = 4;
    public bool destroyOn = false;
    [SerializeField] public float shaderFade;
    [SerializeField] public float tempValue;

    public RectTransform parRect;

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
        sceneLoader = FindObjectOfType<SceneLoader>();
        dontDestoryScript = FindObjectOfType<DontDestoryScript>();
        thisGO = GetComponent<GameObject>();
        randomCreator = FindObjectOfType<Random_Creator>();

    }

    // Update is called once per frame
    public void DestoryBlock()
    {

        if (randomCreator.temp == 1)
        {
            randomCreator.ErrorPathMessage();
            return;
        }


        switch (Mathf.Sqrt(board.metrixSize))
        {
            case 3:
                tempValue = 125f; // refrence for TempValue within Shader
                startSizeValue = 55;
                shapeRadius = 50;
                break;
            case 4:
                tempValue = 100f;
                startSizeValue = 50;
                shapeRadius = 40;
                break;
            case 5:
                tempValue = 75f;
                startSizeValue = 35;
                shapeRadius = 25;
                break;
            case 6:
                tempValue = 50f;
                startSizeValue = 30;
                shapeRadius = 20;
                break;
            case 7:
                tempValue = 35f;
                startSizeValue = 25;
                shapeRadius = 15;
                break;

        }
       // Debug.Log("metrixSize:" + board.metrixSize + " tempValue:" + tempValue);

        //minBlockSize = board.metrixUI[0,0].transform.localScale;
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
                    shaderMat.SetFloat("_Temp_Value", tempValue*2.5f);
                    //shaderMat.SetVector("_Offset", new Vector2(UnityEngine.Random.Range(0, 100f), UnityEngine.Random.Range(0, 100f)));
                    ///// 
                    thisGO = board.metrixUI[i, j];
                    Instantiate(prefabParticals, board.metrixUI[i, j].transform.position, Quaternion.identity).transform.SetParent(thisGO.transform);

                    parRect = prefabParticals.GetComponent<RectTransform>();
                    parRect.localScale = new Vector3(1/268.8f, 1 / 268.8f, 1 / 268.8f);
                    parRect.sizeDelta = new Vector2(1f, 1f);

                    particals = prefabParticals.GetComponent<ParticleSystem>(); 
                    var particalsSpeed = particals.main;
                    particalsSpeed.startSpeed = 5f;
                    var mainParticalsSize = particals.main;
                    mainParticalsSize.startSize = startSizeValue/25f;
                    var parti = particals.shape;
                    parti.radius = shapeRadius/15f;
                    var particalEmission = particals.emission;
                    particalEmission.rateOverTime = 70;
                    

                    particals.GetComponent<ParticleSystemRenderer>().sortingOrder = 1;



                    /////

                    StartCoroutine(DelayTime(2f, duration, i, j)); // shader lerp delay

                }
            }
        }

        pathButton.interactable = false;
        destoryButton.interactable = false;
        restartButton.interactable = false;
        silderPath.interactable = false;
        silderSize.interactable = false;

        destroyOn = true;

        StartCoroutine(DelayTimeScene(1.4f)); // time to new scene to reload



    }

    IEnumerator DelayTime(float fade, float time, int x, int y)
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

    //public void DestroyPar()
    //{
    //    for (int i = 0; i < randomCreator.metrixSize; i++)
    //    {
    //        for (int j = 0; j < randomCreator.metrixSize; j++)
    //        {
    //            if (randomCreator.checkMatrix[i, j])
    //            {
    //                GameObject.Destroy(board.metrixUI[i, j]);

    //            }
    //        }
    //    }
    //}

    IEnumerator DelayTimeScene(float time)
    {
        yield return new WaitForSeconds(time);
        LoadPopupWindow();
    }

    public void LoadPopupWindow()
    {
       // sceneLoader.EnableAnimScene2();
        sceneLoader.AddSceneTwo();
    }


}
