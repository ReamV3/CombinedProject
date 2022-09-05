using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine.UI;
using UnityEngine;


public class Random_Number : MonoBehaviour
{
    [SerializeField] bool checkForAwake = false;
    [SerializeField] bool RewardCheck = false;
    Text layerText;
    int randomNum=0;
    int numValue;
    int transformSpeed; //
    private void Awake()
    {
        layerText = GetComponent<Text>();
        if (checkForAwake)
        {
            GenerateRandomNumber();
            layerText.text = (randomNum * 10 + "X");
            Debug.Log("Random num: " + randomNum);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        // defining UI text to int + Random Number
        layerText = GetComponent<Text>();
        // onAwake -> RandomMultiplyer

        // Reward -> Set & X on other side
        if (RewardCheck)
        {
            SetRewardNumbers();
            Invoke("NumberMultiply", 5.8f);
        }
    }
    public void SetRewardNumbers()
    {
        numValue = int.Parse(layerText.text);
        if (numValue >= 1000)
        {
            layerText.text = numValue.ToString("0,0", CultureInfo.InvariantCulture);
        }
        layerText.text = ("X" + layerText.text);
    }
    
    public void GenerateRandomNumber()
    {
        randomNum = Random.Range(1, 9);
        SetInt("randomNum", randomNum);

    }
    public void SetInt(string KeyName, int Value)
    {
        PlayerPrefs.SetInt(KeyName, Value);
    }

    public int Getint(string KeyName)
    {
        return PlayerPrefs.GetInt(KeyName);
    }
    // Work on trigger event
    public void NumberMultiply()
    {
        if (numValue < 50)
        {
            transformSpeed = 10;
        }
        if (numValue >= 50 && numValue < 500)
        {
            transformSpeed = 100;
        }
        if (numValue >=500 && numValue<5000)
        {
            transformSpeed = 1000;
        }
        if (numValue >= 5000)
        {
            transformSpeed = 10000;
        }
        StartCoroutine(DelayTime(numValue * Getint("randomNum") * 10, transformSpeed));

    }

    IEnumerator DelayTime(int updatedCoinValue, int addValue)
    {
        while (numValue < updatedCoinValue)
        {
            numValue += addValue;
            layerText.text = numValue.ToString("0,0", CultureInfo.InvariantCulture);
            layerText.text = ("X" + layerText.text);
            yield return new WaitForSeconds(0.0001f);
        }
        if (numValue >= updatedCoinValue)
        {
            numValue = updatedCoinValue;
            layerText.text = numValue.ToString("0,0", CultureInfo.InvariantCulture);
            layerText.text = ("X" + layerText.text);

        }

    }




}
