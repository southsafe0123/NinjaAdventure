using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public float level;
    public float expRequire;
    public float nextLevelExpRequire;
    public float expPickUpVariable;
    private static float s_Exp=0;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        checkLevel();
    }

    void checkLevel()
    {
        if (s_Exp >= expRequire)
        {
            level++;
            s_Exp = 0;
            expRequire += nextLevelExpRequire; 

            //TODO: hiện thông báo level up
            Debug.Log("LevelUp");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Exp"))
        { 
            s_Exp+=expPickUpVariable;
        }
    }
}
