using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public float level;
    public float expRequire;
    public float nextLevelExpRequire;
    public float expPickUpVariable;

    public static float s_expPickUpVariable;
    public static float s_Exp = 0;
    public static float s_level;
    public static float s_oldLevel;

    private void Start()
    {
        //cho chỉ số chỉnh được vào static
        s_oldLevel = level;
        s_level = level;
        s_expPickUpVariable = expPickUpVariable;
    }
    void Update()
    {
        checkLevel();
    }

    void checkLevel()
    {
        if (s_Exp >= expRequire)
        {
            s_level++;
            s_Exp = 0;
            expRequire += nextLevelExpRequire;
            expUpdate();

            Debug.Log("LevelUp");
        }
    }
    public static bool IsLevelUp()
    {
        if (s_oldLevel != s_level)
        {
            return true;
        }

        return false;
    }

    public static void UpdateCheckLevel()
    {
        s_oldLevel = s_level;
    }
    public static void expUpdate()
    {
        s_Exp += s_expPickUpVariable;
    }
}
