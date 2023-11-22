using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLoadData : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Canvas canvas = GameObject.Find("UIPlayer").GetComponent<Canvas>();
        Camera cam = gameObject.GetComponent<Camera>();
        canvas.worldCamera = cam;
        PlayerMovement.mainCamera = gameObject.GetComponent<Camera>();
    }


}
