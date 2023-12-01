using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using static UnityEngine.Networking.UnityWebRequest;

public class Login : MonoBehaviour
{
    [SerializeField] private string authenticationEndpoint = "http://192.168.68.125:8686/users/loginGame";
    [SerializeField] private TMP_InputField usernameInputField;
    [SerializeField] private TMP_InputField passwordInputField;

    public void OnloginClick() {
        StartCoroutine(TryLogin());
    }
    private IEnumerator TryLogin() {
        string username = usernameInputField.text;
        string password = passwordInputField.text;
        
        UnityWebRequest request =  UnityWebRequest.Get($"{authenticationEndpoint}?email={username}&password={password}");
        var handler = request.SendWebRequest();
       
        float startTime = 0.0f;
        while (!handler.isDone) {
            startTime += Time.deltaTime;
            if (startTime > 10.0f) {
                break;
            }
            
            yield return null;
        }
        
        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log(request.downloadHandler.text);
        }
        else
        {
            Debug.Log(request.result);
        }


        yield return null;
    }
}
