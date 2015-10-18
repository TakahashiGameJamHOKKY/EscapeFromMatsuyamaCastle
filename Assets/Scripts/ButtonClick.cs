using UnityEngine;
using System.Collections;

public class ButtonClick : MonoBehaviour {

    public GameObject camera;

    public void ButtonPush()
    {

        //Debug.Log("Button Push !!");

        CameraCtrl camCtrl = camera.GetComponent<CameraCtrl>();

        //Debug.Log("Button Push !!");

        if (camCtrl.quoter)
        {
            camCtrl.quoter = false;
        }
        else
        {
            camCtrl.quoter = true;
        }
    }
}
