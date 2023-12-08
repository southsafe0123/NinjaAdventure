﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static System.Net.WebRequestMethods;

public class Register : MonoBehaviour
{

    [SerializeField] private string ip;
    [SerializeField] private string port;

    [Header("Http or https")]
    [SerializeField] private string http;
    public bool useCustomIP;
    [SerializeField] private TMP_InputField emailInputField;
    [SerializeField] private TMP_InputField nameInputField;
    [SerializeField] private TMP_InputField passwordInputField;
    [SerializeField] private TMP_InputField repasswordInputField;
    [SerializeField] private TextMeshProUGUI alertText;
    [SerializeField] private Button registerButton;
   
    public void onClick() {
        // registerButton.interactable = false;
        if (!useCustomIP)
        {
            ip = "ninja-api.onrender.com";
            port = "";
            http = "https";
        }
        StartCoroutine(TryRegister());
    }

    private IEnumerator TryRegister()
    {


        string email = emailInputField.text;
        string name= nameInputField.text;
        string password = passwordInputField.text;
        string repassword = repasswordInputField.text;
        

        if (email.Equals("") || name.Equals("") || repassword.Equals("") || password.Equals(""))
        {
            alertText.text = "Don't leave blank";

        }
        else {
            if (password != repassword)
            {
                alertText.text = "Check Password Again";
                yield break;
            }
            if (!email.Contains("@gmail.com"))
            {
                alertText.text = "This Not Gmail";
                yield break;
            }
            Model_Register model_Register = new Model_Register
            {
                email = email,
                name = name,
                password = password,
                role = 1
            };
            WWWForm formData = new WWWForm();
            formData.AddField("email", email);
            formData.AddField("name", name);
            formData.AddField("password", password);
            formData.AddField("role", 1);
           
            string jsonData = JsonUtility.ToJson(model_Register);
            UnityWebRequest request = UnityWebRequest.Post($"{http}://{ip}:{port}/users/register",formData);
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
            if (request.result == UnityWebRequest.Result.Success)
            {

                alertText.text = "Register Success";
              
            }
            else {
                string jsonString = request.downloadHandler.text;
                ErrorResponse errorResponse = JsonUtility.FromJson<ErrorResponse>(jsonString);
                
                alertText.text = errorResponse.error;
                Debug.Log(request.error);
                Debug.Log(errorResponse.error);
            }
           
            
            
        }

       

         
           



        yield return null;
    }
    public class ErrorResponse {
       public string error;
    }

}
