using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins_Emission : MonoBehaviour
{
    ParticleSystem coinSystem;
    Random_Number randomScript;
    int emmisionScale;

    // Start is called before the first frame update
    void Start()
    {
        coinSystem = GetComponent<ParticleSystem>();
        randomScript = FindObjectOfType<Random_Number>();
        emmisionScale = randomScript.Getint("randomNum");
        SetEmmision();

    }

    public void SetEmmision()
    {
        var emmision = coinSystem.emission;
        emmision.rateOverTime =emmisionScale * 25f;
    }

}
