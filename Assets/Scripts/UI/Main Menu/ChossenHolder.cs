using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChossenHolder : MonoBehaviour
{
    public GameObject FlagPlay;
    public GameObject FlagOption;
    public GameObject FlagQuit;
    public Text TextPlay;
    public Text TextOption;
    public Text TextQuit;

    public void DisplayChossenPlay()
    {
        FlagPlay.SetActive(true);
        TextPlay.color = Color.white;
    }
    public void UnDisplayChossenPlay()
    {
        FlagPlay.SetActive(false);
        TextPlay.color = Color.black;
    }

    public void DisplayChossenOption()
    {
        FlagOption.SetActive(true);
        TextOption.color = Color.white;
    }
    public void UnDisplayChossenOption()
    {
        FlagOption.SetActive(false);
        TextOption.color = Color.black;
    }

    public void DisplayChossenQuit()
    {
        FlagQuit.SetActive(true);
        TextQuit.color = Color.white;
    }
    public void UnDisplayChossenQuit()
    {
        FlagQuit.SetActive(false);
        TextQuit.color = Color.black;
    }
}
