using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHeathManager : MonoBehaviour
{
    private List<GameObject> objHeathList;
    public GameObject prefHeart;
    public GameObject heartPos;
    private Vector2 heartPosTemp;
    public float nextHeartPosX;
    private float maxHeathTemp;
    private float currentHeathTemp;

    void Start()
    {
        maxHeathTemp = PlayerHealth.PlayerMaxHeath;
        heartPosTemp = heartPos.transform.position;
        currentHeathTemp = PlayerHealth.PlayerCurrentHealth;
        updateHeathUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (maxHeathTemp != PlayerHealth.PlayerMaxHeath)
        {
            maxHeathTemp = PlayerHealth.PlayerMaxHeath;
            GetObjHeathList();
            clearHeathUI();
            updateHeathUI();
        }

        if (currentHeathTemp != PlayerHealth.PlayerCurrentHealth)
        {
            currentHeathTemp = PlayerHealth.PlayerCurrentHealth;
            lostHeathUI();
        }
    } 

    void lostHeathUI()
    {
        //lấy danh sách
        GetObjHeathList();
        //for và chạy animator mất máu

        for (int i = 0; i < objHeathList.Count; i++)
        {
            if (i > PlayerHealth.PlayerCurrentHealth-1)
            {
                objHeathList[i].transform.GetChild(0).GetComponent<Animator>().Play("HeathLost");
            }
        }
    }

    void GetObjHeathList()
    {
        objHeathList.Clear();

        foreach (Transform obj in transform.GetChild(0).transform)
        {
            objHeathList.Add(obj.gameObject);
        }
    }

    private void clearHeathUI()
    {

        for (int i = 1; i < objHeathList.Count; i++)
        {
            Destroy(objHeathList[i]);
        }

        objHeathList.Clear();
    }

    void updateHeathUI()
    {
        for (int i = 0; i < PlayerHealth.PlayerMaxHeath; i++)
        {
            var obj = Instantiate(prefHeart, Vector3.zero, Quaternion.identity);
            obj.transform.SetParent(heartPos.transform, false);
            obj.transform.localPosition = heartPosTemp;
            heartPosTemp.x += nextHeartPosX;
        }

        heartPosTemp.x = heartPos.transform.position.x;
    }
}
