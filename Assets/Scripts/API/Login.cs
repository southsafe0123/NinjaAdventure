using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using static UnityEngine.Networking.UnityWebRequest;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Login : MonoBehaviour
{
    [SerializeField] private string ip;
    [SerializeField] private string port;

    [Header("Http or https")]
    [SerializeField] private string http;
    public bool useCustomIP;
    [SerializeField] private TMP_InputField usernameInputField;
    [SerializeField] private TMP_InputField passwordInputField;
    [SerializeField] private TextMeshProUGUI alertText;
    [SerializeField] private Button loginButton;
    public static string idGameInfor;
    public static bool isLogout;

    public void clickRegister()
    {
        SceneManager.LoadScene("Register_Scene");
    }

    public void OnloginClick()
    {
        if (!useCustomIP)
        {
            ip = "ninja-api.onrender.com";
            port = "";
            http = "https";
        }
        alertText.text = "Sign in...";
        loginButton.interactable = false;
        StartCoroutine(TryLogin());
    }
    private IEnumerator TryLogin()
    {


        string username = usernameInputField.text;
        string password = passwordInputField.text;
        if (username.Equals("") || password.Equals(""))
        {
            alertText.text = "Don't leave blank";
            loginButton.interactable = true;
        }
        else
        {
            WWWForm formData = new WWWForm();
            formData.AddField("email", username);
            formData.AddField("password", password);

            UnityWebRequest request = UnityWebRequest.Post($"{http}://{ip}:{port}/users/loginGame", formData);
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

                //save id infogame for putting data
                idGameInfor = gameAccount.gameInfor;

                //get data from idGameInfor
                string url = $"{http}://{ip}:{port}/users/gameInfo/{gameAccount.gameInfor}";
                UnityWebRequest request2 = UnityWebRequest.Get(url);
                yield return request2.SendWebRequest();

                Loaddata gameInfo = JsonUtility.FromJson<Loaddata>(request2.downloadHandler.text);
                Debug.Log(request2.downloadHandler.text);
                PlayerSave.SetStats(
                    gameInfo.Scene,
                    gameInfo.healthMax,
                    gameInfo.currentHealth,
                    gameInfo.shirukenNum,
                    gameInfo.shurikenDmg,
                    gameInfo.currentExp,
                    gameInfo.expRequire,
                    gameInfo.level
                    );
                GameSystem.LoadScene.LoadSceneNum(5);
                Debug.Log(gameAccount.gameInfor);
            }
            else if (request.result == UnityWebRequest.Result.ConnectionError)
            {

                alertText.text = "Lost connection";
                loginButton.interactable = true;
            }
            else
            {
                string jsonString = request.downloadHandler.text;
                ErrorResponse errorResponse = JsonUtility.FromJson<ErrorResponse>(jsonString);

                alertText.text = errorResponse.error;

                loginButton.interactable = true;
            }
        }



        yield return null;
    }
    public class ErrorResponse
    {
        public string error;
    }
}
