using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class storyManager : MonoBehaviour
{
    public void endScene()
    {
        GameSystem.LoadScene.scenePlayerIn = 1;
        GameSystem.LoadScene.LoadSceneNum(1);
    }
}
