using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onInvisSpawn : MonoBehaviour
{
    BoxCollider2D box;
    public float timeInvis;
    MonsterBehavior monsterBehavior;
    // Start is called before the first frame update
    void Start()
    {
        monsterBehavior = GetComponent<MonsterBehavior>();
        box = GetComponent<BoxCollider2D>();
        StartCoroutine(delayInvis());
    }
    IEnumerator delayInvis()
    {
        monsterBehavior.enabled = false;
        yield return new WaitForSeconds(timeInvis);
        monsterBehavior.enabled = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
