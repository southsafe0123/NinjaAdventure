using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using static UnityEngine.Networking.UnityWebRequest;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Login : MonoBehaviour
{
    [SerializeField] private string authenticationEndpoint = "http://192.168.68.125:8686/users/loginGame";
    [SerializeField] private TMP_InputField usernameInputField;
    [SerializeField] private TMP_InputField passwordInputField;
    [SerializeField] private TextMeshProUGUI alertText;
    [SerializeField] private Button loginButton;

    public void clickRegister() {
        SceneManager.LoadScene("Register_Scene");
    }

    public void OnloginClick() {

        alertText.text = "Sign in...";
        loginButton.interactable = false;
        StartCoroutine(TryLogin());
    }
    private IEnumerator TryLogin() {


        string username = usernameInputField.text;
        string password = passwordInputField.text;
        if (username.Equals("") || password.Equals("")) {
            alertText.text = "Không để trống...";
            loginButton.interactable = true;
        }
        else {
            UnityWebRequest request = UnityWebRequest.Get($"{authenticationEndpoint}?email={username}&password={password}");
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

                loginButton.interactable = false;
                GameAccount gameAccount = JsonUtility.FromJson<GameAccount>(request.downloadHandler.text);

                alertText.text = "welcome..."+((gameAccount.role < 1 ) ? gameAccount.name : "Admin");
                 
                Debug.Log(request.downloadHandler.text);
            } else if (request.result== UnityWebRequest.Result.ConnectionError) {

                alertText.text = "Kiểm tra kết nối...";
                loginButton.interactable = true;
            }
            else
            {
                alertText.text = "Kiểm tra tài khoản hoặc mật khẩu...";
                loginButton.interactable = true;
            }
        }



        yield return null;
    }
}
