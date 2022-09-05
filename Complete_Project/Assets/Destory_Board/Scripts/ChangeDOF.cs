using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering; // volume
using UnityEngine.Rendering.Universal; // dof

public class ChangeDOF : MonoBehaviour
{
    //PP
   // public VolumeProfile fxVolume;
    public DepthOfField dof;

    // Start is called before the first frame update

    private void Start()
    {
        dof = FindObjectOfType<DepthOfField>();
        RestDOF();
    }

    public void ChangeDOFValue()
    {
        Debug.Log("0.1f");

        dof.focusDistance.value = 0.1f;
    }
    public void RestDOF()
    {
        Debug.Log("10f");
        dof.focusDistance.value = 10f;
    }

}
