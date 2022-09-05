using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons_Actions : MonoBehaviour
{
    [SerializeField] GameObject Slider;
    bool sliderTester = false;

        private void Start()
        {
        Slider.SetActive(false);
        }
        public void ExitButton()
        {
            Debug.Log("Exit");
            Application.Quit();

        }
        public void SettingsButton()
        {
            Debug.Log("Setting");

        }
        public void SoundButton()
        {
        SliderSetup();
        }

        public void SliderSetup()
        {

            if (sliderTester == true)
            {
                sliderTester = false;
            }
            else if (sliderTester == false)
            {
                sliderTester = true;
            }
            Slider.SetActive(sliderTester);
            return;
        }

    }

