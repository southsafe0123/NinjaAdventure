using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class storyManager : MonoBehaviour
{

    public void endScene()
    {
        LoadScene.scenePlayerIn = 1;
        GameObject.Find("LoadScene").GetComponent<LoadScene>().LoadSceneNum(5);
    }
}
