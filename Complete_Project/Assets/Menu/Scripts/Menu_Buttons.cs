using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Menu_Buttons : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] Animator canvasAnimator;
    [SerializeField] Animator buttonAnimator;
    [SerializeField] TextMeshProUGUI buttonText;

    // Start is called before the first frame update
    public void ButtonClicked()
    {
        canvasAnimator.SetTrigger("StartClick");
    }
    public void DestroyClicked()
    {
        canvasAnimator.SetTrigger("Destroy");
    }

    public void InsideButton()
    {
        buttonAnimator.SetBool("Hover(IN)", true);
    }
    public void OutsideButton()
    {
        buttonAnimator.SetBool("Hover(IN)", false);
    }
    public void Quit()
    {
        Application.Quit();
    }

}
