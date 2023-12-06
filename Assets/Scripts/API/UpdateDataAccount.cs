using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Networking;

public class UpdateDataAccount : MonoBehaviour
{
    public string ip;
    public string port;
    public void FetchData()
    {
        if (Login.idGameInfor != null)
        {
            StartCoroutine(BeginFetch());
        }
        
    }

    public void Logout()
    {
        Login.isLogout = true;
    }

    IEnumerator BeginFetch()
    {
        
        var Scene = (int)PlayerSave.GetValue(PlayerSave.ValueType.scene);
        var healthMax = (int)PlayerSave.GetValue(PlayerSave.ValueType.maxHealth);
        var currentHealth = (int)PlayerSave.GetValue(PlayerSave.ValueType.currentHealth);
        var shurikenDmg = (int)PlayerSave.GetValue(PlayerSave.ValueType.shurikenDmg);
        var shirukenNum = (int)PlayerSave.GetValue(PlayerSave.ValueType.shurikenNum);
        var currentExp = (int)PlayerSave.GetValue(PlayerSave.ValueType.currentExp);
        var level = (int)PlayerSave.GetValue(PlayerSave.ValueType.level);
        var expRequire = (int)PlayerSave.GetValue(PlayerSave.ValueType.maxExp);
        
        Loaddata loaddata = new Loaddata(Login.idGameInfor,Scene,healthMax,currentHealth,shurikenDmg,shirukenNum,currentExp,level,expRequire);

        string jsonData = JsonUtility.ToJson(loaddata);
        Debug.Log(jsonData);

        UnityWebRequest request = UnityWebRequest.Put($"http://{ip}:{port}/users/upDate/{Login.idGameInfor}",jsonData);

        request.SetRequestHeader("Content-Type", "application/json");
            
        yield return request.SendWebRequest();
        Debug.Log(Login.idGameInfor);
        if(request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("success");
            if (Login.isLogout)
            {
                Login.isLogout = false;
            }
        }
        else
        {
            Debug.Log("something wrong, check api");
            if (Login.isLogout)
            {
                Login.isLogout = false;
            }
        }
    }
}
