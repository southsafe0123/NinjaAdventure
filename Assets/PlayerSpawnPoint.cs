using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnPoint : MonoBehaviour
{
    private GameObject character;
    private void Start()
    {
        character = GameObject.Find("player");
        character.transform.position = transform.position;
    }
}
