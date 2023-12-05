using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CameraLoadData))]
public class VerticalCamera : MonoBehaviour
{
    public GameObject playerTarget;

    public Vector2 limitPosMin;
    public Vector2 limitPosMax;
    public enum CamMove
    {
        horizontal,
        vertical,
    }

    public CamMove camMove;
    public float camspeed;

    private Vector3 newPos;

    private void Start()
    {
        playerTarget = GameObject.Find("player");
    }

    private void FixedUpdate()
    {

        switch (camMove)
        {
            case CamMove.horizontal:
                LockVertical();
                break;
            case CamMove.vertical:
                LockHorizontal();
                break;
        }
    }

    private void LockHorizontal()
    {
        limitPosMin.x = 0;
        limitPosMax.x = 0;

        newPos = new Vector3(0, playerTarget.transform.position.y, -10);

        if (playerTarget.transform.position.y > limitPosMax.y)
        {
            newPos = new Vector3(0, limitPosMax.y, -10);
        }
        if (playerTarget.transform.position.y < limitPosMin.y)
        {
            newPos = new Vector3(0, limitPosMin.y, -10);
        }

        transform.position = Vector3.Lerp(transform.position, newPos, camspeed * Time.deltaTime);

    }

    private void LockVertical()
    {
        limitPosMin.y = 0;
        limitPosMax.y = 0;

        newPos = new Vector3(playerTarget.transform.position.x, 0, -10);

        if (playerTarget.transform.position.x > limitPosMax.x)
        {
            newPos = new Vector3(limitPosMax.x, 0, -10);
        }
        if (playerTarget.transform.position.x < limitPosMin.x)
        {
            newPos = new Vector3(limitPosMin.x, 0, -10);
        }

        transform.position = Vector3.Lerp(transform.position, newPos, camspeed * Time.deltaTime);



    }
    //public Transform target;
    //public Transform target2;
    //public Vector3 _lockCam;
    //public bool trigger;
    //public float camspeed;
    //public GameObject enableLoadscene;
    //private Transform player;
    //// Update is called once per frame
    //private void Start()
    //{
    //    target = GameObject.Find("player").transform;
    //    enableLoadscene.SetActive(true);
    //}
    //private void Update()
    //{
    //    player = GameObject.Find("player").transform;
    //}
    //void FixedUpdate()
    //{
    //    lockCam();

    //    if (MapPointTriggerIn.triggerPlayerIn)
    //    {
    //        lockCamMap1(player);
    //        target = null;
    //    }
    //    else
    //    {
    //        target = player;
    //    }

    //    if (MapPointTriggerIn2.triggerPlayerIn)
    //    {
    //        lockCamMap2(player);
    //        target = null;
    //    }
    //    else if (!MapPointTriggerIn2.triggerPlayerIn && target == null)
    //    {
    //        target2 = player;
    //    }

    //    //if (MapPointTriggerIn3.triggerPlayerIn)
    //    //{
    //    //    lockCamMap3(player);
    //    //    target = null;
    //    //    target2 = player;
    //    //}
    //    //else if (!MapPointTriggerIn3.triggerPlayerIn && target == null && target2 == null)
    //    //{
    //    //    target2 = player;
    //    //}

    //}

    //void lockCam()
    //{
    //    if (target != null)
    //    {
    //        Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
    //        transform.position = Vector3.Lerp(transform.position, targetPosition, camspeed * Time.deltaTime);

    //        float clampedX = Mathf.Clamp(transform.position.x, 0, 0);
    //        float clampedY = Mathf.Clamp(transform.position.y, -18.01f, 0);
    //        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    //    }
    //}

    //void lockCamMap1(Transform player)
    //{
    //    _lockCam = MapPointTriggerIn._lockCam;
    //    transform.position = Vector3.Lerp(transform.position, _lockCam, 0.05f);
    //}

    //void lockCamMap2(Transform player)
    //{
    //    _lockCam = MapPointTriggerIn2._lockCam;
    //    transform.position = Vector3.Lerp(transform.position, _lockCam, 0.05f);
    //}

    ////void lockCamMap3(Transform player)
    ////{
    ////    _lockCam = MapPointTriggerIn3._lockCam;
    ////    transform.position = Vector3.Lerp(transform.position, _lockCam, 0.05f);
    ////}
}
