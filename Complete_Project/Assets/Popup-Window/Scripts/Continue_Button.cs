using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Continue_Button : MonoBehaviour
{
    [SerializeField] Sprite[] images = new Sprite[2];
    Image buttonImage;
    [SerializeField] Button currentButton;
    // Start is called before the first frame update
    void Start()
    {
        buttonImage = GetComponent<Image>();
        currentButton = GetComponent<Button>();
    }

    // Update is called once per frame
    public void InsideButton()
    {
        Debug.Log("In");
        buttonImage.sprite = images[1];
    }
    public void OutsideButton()
    {

        Debug.Log("Out");
        buttonImage.sprite = images[0];
    }
    public void restartScene()
    {
        Scene popUpScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(1);
        SceneManager.LoadScene(2,LoadSceneMode.Additive);
    }
}
