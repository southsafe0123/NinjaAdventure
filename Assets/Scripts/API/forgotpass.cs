using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
public class forgotpass : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private string ip;
    [SerializeField] private string port;

    [Header("Http or https")]
    [SerializeField] private string http;
    public bool useCustomIP;

    [SerializeField] private TMP_InputField usernameInputField;
    [SerializeField] private TextMeshProUGUI alertText;
    public void onClick()
    {
        if (!useCustomIP)
        {
            ip = "ninja-api.onrender.com";
            port = "";
            http = "https";
        }

        StartCoroutine(Forgot());
    }

    // Update is called once per frame
   public IEnumerator Forgot()
    {
        string email = usernameInputField.text;
        WWWForm form = new WWWForm();
        form.AddField("email", email);
        UnityWebRequest request = UnityWebRequest.Post($"{http}://{ip}:{port}/users/forgot-password", form);
       
        yield return request.SendWebRequest();
       
        if (request.result == UnityWebRequest.Result.Success)
        {
            alertText.text = "Done... Check your mail box to confirm...";
          
        }
        else if (request.result == UnityWebRequest.Result.ConnectionError)
        {
            alertText.text = "Lost connection";
        }
        else
        {

            alertText.text = request.downloadHandler.text;
            Debug.Log(request.downloadHandler.text);
        }

    }
    public class ErrorResponse
    {
        public string error;
    }
}
