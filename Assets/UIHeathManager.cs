﻿using System;
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
        heartPosTemp = new Vector2(0,0);
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
            GetObjHeathList();
            clearHeathUI();
            updateHeathUI();
            lostHeathUI();
        }
    } 

    void lostHeathUI()
    {
        //lấy danh sách
        GetObjHeathList();
        //for và chạy animator mất máu
        for (int i = objHeathList.Count; i >0 ; i--)
        {
            if (i > PlayerHealth.PlayerCurrentHealth)
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

        heartPosTemp.x = 0;
        objHeathList.Clear();
    }

    void updateHeathUI()
    {
        for (int i = 0; i < PlayerHealth.PlayerMaxHeath; i++)
        {
            var obj = Instantiate(prefHeart, heartPos.transform.position, Quaternion.identity);
            obj.transform.SetParent(heartPos.transform,false);
            obj.transform.localPosition = heartPosTemp;
            heartPosTemp.x += nextHeartPosX;
        }
    }
}
