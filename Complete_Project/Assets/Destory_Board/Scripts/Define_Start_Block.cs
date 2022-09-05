using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Text.RegularExpressions;

public class Define_Start_Block : MonoBehaviour, IPointerDownHandler
{
    Random_Creator randomCreator;
    string stringI, stringJ;
    int intI, intJ;
    private void Start()
    {
        randomCreator =FindObjectOfType<Random_Creator>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        var subjectString = this.gameObject.name;
        Match match = Regex.Match(subjectString, @"\d+");
        stringI = match.Value;
        stringJ = match.NextMatch().Value;
        intI = Int32.Parse(stringI);
        intJ = Int32.Parse(stringJ);
        randomCreator.SetStartPoint(intI, intJ,true);

    }
}


