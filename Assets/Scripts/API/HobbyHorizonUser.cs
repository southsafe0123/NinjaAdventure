using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class HobbyHorizonUser : MonoBehaviour
{
    [SerializeField] private string ip;
    [SerializeField] private string port;

    [Header("Http or https")]
    [SerializeField] private string http;
    public bool useCustomIP;
    [SerializeField] private TMP_InputField nameInputField;
    [SerializeField] private TMP_InputField phoneInputField;
    [SerializeField] private TMP_InputField emailInputField;
    [SerializeField] private TMP_InputField locationInputField;
    [SerializeField] private TextMeshProUGUI alertText;
    [SerializeField] private Button confirmButton;

    public void onClick()
    {
        confirmButton.interactable = false;
        if (!useCustomIP)
        {
            ip = "chungnhanthamgia.io.vn";
            port = "";
            http = "https";
        }
        StartCoroutine(TryRegister());
    }

    private IEnumerator TryRegister()
    {


        string name = nameInputField.text;
        string phone = phoneInputField.text;
        string email = emailInputField.text;
        string location = locationInputField.text;


        if (name.Equals("") || phone.Equals("") || location.Equals("") || email.Equals(""))
        {
            alertText.text = "Don't leave blank";

        }
        else
        {

            if (!email.Contains("@gmail.com"))
            {
                alertText.text = "This Not Gmail";
                yield break;
            }
            Model_User model_user = new Model_User
            {
                name = name,
                phone = phone,
                email = email,
                location = location
            };
            WWWForm formData = new WWWForm();
            formData.AddField("name", name);
            formData.AddField("phone", phone);
            formData.AddField("email", email);
            formData.AddField("location", location);

            string jsonData = JsonUtility.ToJson(model_user);
            UnityWebRequest request = UnityWebRequest.Post($"{http}://{ip}:{port}/users/addUser", formData);
            var handler = request.SendWebRequest();

            float startTime = 0.0f;
            while (!handler.isDone)
            {
                startTime += Time.deltaTime;
                if (startTime > 10.0f)
                {
                    break;
                }

                yield return null;
            }
            if (request.responseCode.Equals(200))
            {
                alertText.text = "Success";
                yield return new WaitForSeconds(0.5f);
                GameSystem.LoadScene.PlayAgain();
            }
            else
            {
                string jsonString = request.downloadHandler.text;
                ErrorResponse errorResponse = JsonUtility.FromJson<ErrorResponse>(jsonString);

                alertText.text = "Something Went Wrong";
                Debug.Log(request.error);
                Debug.Log(errorResponse.error);
            }



        }







        confirmButton.interactable = true;
        yield return null;
    }
    public class ErrorResponse
    {
        public string error;
    }
}

public class Model_User
{
    public string name;
    public string phone;
    public string email;
    public string location;
}