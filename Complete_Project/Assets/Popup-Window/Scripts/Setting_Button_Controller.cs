using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Setting_Button_Controller : MonoBehaviour
{
    [SerializeField] Sprite[] images = new Sprite[2];
    [SerializeField] GameObject UISet;
    [SerializeField] Button continueButton;
    [SerializeField] Button exitButton;
    [SerializeField] Button soundButton;

    Animator UIAnimator;
    Image buttonImage;
    bool clickedButton = false;
    // Start is called before the first frame update
    void Start()
    {
        continueButton.interactable = true;
        exitButton.interactable = true;
        soundButton.interactable = true;
        UIAnimator = UISet.GetComponent<Animator>();
        buttonImage = GetComponent<Image>();
        buttonImage.sprite = images[0];
    }

    // Update is called once per frame

    public void SettingClick()
    {
        if(!clickedButton)
        {
            buttonImage.sprite = images[1];
            clickedButton = true;
            UIAnimator.SetBool("Setting", true);
            // unable click other buttons
            continueButton.interactable = false;
            exitButton.interactable = false;
            soundButton.interactable = false;
        }
        else if (clickedButton)
        {
            buttonImage.sprite = images[0];
            UIAnimator.SetBool("Setting",false);
            clickedButton = false;
            // rest buttons
            continueButton.interactable = true;
            exitButton.interactable = true;
            soundButton.interactable = true;
        }

       
        


    }    
}
