using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCamTarget : MonoBehaviour
{ 
    public Transform target;
    public Vector3 _lockCam;
    public bool trigger;
    public float camspeed;
    public bool istriggerPlayerIn;
    // Update is called once per frame
    private void Start()
    {
        _lockCam = new Vector3(0, -8.69f, -10);
    }
    void FixedUpdate()
    {
        lockCam();

        GameObject gameObject = GameObject.Find("player");
        Transform player = gameObject.transform; 

        if (MapPointTriggerIn.triggerPlayerIn)
        {
            transform.position = Vector3.Lerp(transform.position, _lockCam, 0.05f);
            target = null;
            istriggerPlayerIn = false; 
        }

        if(MapPointTriggerIn.triggerPlayerIn == false && !istriggerPlayerIn)
        {
            target = player;
            istriggerPlayerIn = true;
            StartCoroutine(caigido());
        }

        Debug.Log(MapPointTriggerIn.triggerPlayerIn);
    }

    void lockCam()
    {
        if (target != null)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, camspeed * Time.deltaTime);

            float clampedX = Mathf.Clamp(transform.position.x, 0, 0);
            float clampedY = Mathf.Clamp(transform.position.y, -18.03f, 0);
            transform.position = new Vector3(clampedX, clampedY, transform.position.z);
        }
    }

    IEnumerator caigido()
    {
        yield return new WaitForSeconds(0.5f);
        _lockCam = new Vector3(0, -17.68f, -10);
        yield return null;
    }
}
