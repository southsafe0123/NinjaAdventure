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
    public float nextShuriPosX;
    // Start is called before the first frame update
    void Start()
    {
        shurikenPosTemp = new Vector2(0, 0);
        shurikenTemp = playerShooting.ShurikenPLayerHave;
        updateShurikenUI();
    }

    // Update is called once per frame
    void Update()
    {
        if(shurikenTemp != playerShooting.ShurikenPLayerHave)
        {
            shurikenTemp = playerShooting.ShurikenPLayerHave;
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
        shurikenPosTemp.x = 0;
        objShurikenList.Clear();
    }

    private void updateShurikenUI()
    {
        for (int i = 0; i < playerShooting.ShurikenPLayerHave; i++)
        {
            var obj = Instantiate(prefShuriken, shurikenPos.transform.position, Quaternion.identity);
            obj.transform.SetParent(shurikenPos.transform, false);
            obj.transform.localPosition = shurikenPosTemp;
            shurikenPosTemp.x += nextShuriPosX;
        }

    }
}
