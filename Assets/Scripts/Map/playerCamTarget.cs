using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCamTarget : MonoBehaviour
{
    public Transform target;
    public Transform target2;
    public Vector3 _lockCam;
    public bool trigger;
    public float camspeed;
    // Update is called once per frame
    private void Start()
    {
        
    }
    void FixedUpdate()
    {
        lockCam();

        GameObject gameObject = GameObject.Find("player");
        Transform player = gameObject.transform;

        if (MapPointTriggerIn.triggerPlayerIn)
        {
            lockCamMap1(player);
            target = null;
        }
        else
        {
            target = player;
        }
         
        if (MapPointTriggerIn2.triggerPlayerIn)
        {
            lockCamMap2(player);
            target = null;
        }
        else if (!MapPointTriggerIn2.triggerPlayerIn && target == null)
        {
            target2 = player;
        }

        //if (MapPointTriggerIn3.triggerPlayerIn)
        //{
        //    lockCamMap3(player);
        //    target = null;
        //    target2 = player;
        //}
        //else if (!MapPointTriggerIn3.triggerPlayerIn && target == null && target2 == null)
        //{
        //    target2 = player;
        //}

    }

    void lockCam()
    {
        if (target != null)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, camspeed * Time.deltaTime);

            float clampedX = Mathf.Clamp(transform.position.x, 0, 0);
            float clampedY = Mathf.Clamp(transform.position.y, -18.01f, 0);
            transform.position = new Vector3(clampedX, clampedY, transform.position.z);
        }
    }

    void lockCamMap1(Transform player)
    {
        _lockCam = MapPointTriggerIn._lockCam;
        transform.position = Vector3.Lerp(transform.position, _lockCam, 0.05f);
    }

    void lockCamMap2(Transform player)
    {
        _lockCam = MapPointTriggerIn2._lockCam;
        transform.position = Vector3.Lerp(transform.position, _lockCam, 0.05f);
    }

    //void lockCamMap3(Transform player)
    //{
    //    _lockCam = MapPointTriggerIn3._lockCam;
    //    transform.position = Vector3.Lerp(transform.position, _lockCam, 0.05f);
    //}
}
