using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Button btnPlay;
    private void Awake()
    {
        btnPlay.onClick.AddListener(() =>
        {
            GameSystem.LoadScene.loadNextScene();
        });
    }
}