using UnityEngine;

public class ChangeScenePos : MonoBehaviour
{
    public int sceneIndex;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameSystem.LoadScene.LoadSceneNum(sceneIndex);
        }
    }
}