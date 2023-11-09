using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShurikenManager : MonoBehaviour
{
    public List<GameObject> objShurikenList;
    public GameObject prefShuriken;
    public GameObject shurikenPos;
    private float shurikenTemp;
    private Vector2 shurikenPosTemp;
    public float nextHeartPosX;
    // Start is called before the first frame update
    void Start()
    {
        shurikenTemp = PlayerShooting.ShurikenPLayerHave;
        updateShurikenUI();
    }

    // Update is called once per frame
    void Update()
    {
        if(shurikenTemp != PlayerShooting.ShurikenPLayerHave)
        {
            shurikenTemp = PlayerShooting.ShurikenPLayerHave;
            GetObjShurikenList();
            clearShurikenUI();
            updateShurikenUI();
        }


    }

    void GetObjShurikenList()
    {
        objShurikenList.Clear();

        foreach (Transform obj in transform.GetChild(0).transform)
        {
            objShurikenList.Add(obj.gameObject);
        }
    }
    private void clearShurikenUI()
    {

        for (int i = 0; i < objShurikenList.Count; i++)
        {
            Destroy(objShurikenList[i]);
        }

        objShurikenList.Clear();
    }

    private void updateShurikenUI()
    {
        for (int i = 0; i < PlayerShooting.ShurikenPLayerHave; i++)
        {
            var obj = Instantiate(prefShuriken, Vector3.zero, Quaternion.identity);
            obj.transform.SetParent(shurikenPos.transform, false);
            obj.transform.localPosition = shurikenPosTemp;
            shurikenPosTemp.x += nextHeartPosX;
        }

        shurikenPosTemp.x = shurikenPos.transform.position.x;
    }
}
