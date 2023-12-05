using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using static UnityEngine.Networking.UnityWebRequest;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Login : MonoBehaviour
{
    [SerializeField] private string authenticationEndpoint = "http://172.16.108.160:8686/users/loginGame";
    [SerializeField] private string authenticationEndpoint2 = "http://172.16.108.160:8686/users/gameInfo";
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
             WWWForm formData = new WWWForm();
            formData.AddField("email", username);
            formData.AddField("password", password);
            UnityWebRequest request = UnityWebRequest.Post(authenticationEndpoint,formData);
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
                string url = $"http://172.16.108.160:8686/users/gameInfo/{gameAccount.gameInfor}";
                UnityWebRequest request2 = UnityWebRequest.Get(url);
               yield return request2.SendWebRequest();
                alertText.text = "welcome..."+((gameAccount.role < 1 ) ?  "Admin": gameAccount.name);
                Loaddata gameInfo = JsonUtility.FromJson<Loaddata>(request2.downloadHandler.text);
                Debug.Log(request2.downloadHandler.text);
                PlayerHealth.PlayerMaxHeath = gameInfo.healthMax;
                PlayerHealth.PlayerCurrentHealth = gameInfo.currentHealth;
                PlayerStatus.s_Exp = gameInfo.currentExp;
                PlayerStatus.s_expRequire = gameInfo.expRequire;
                PlayerStatus.s_level = gameInfo.level;
                PlayerStatus.s_oldLevel = PlayerStatus.s_level;
                playerShooting.ShurikenPLayerHave = gameInfo.shirukenNum;
                shurikenBullet.s_shurikenDamage = gameInfo.shurikenDmg;
                LoadScene.scenePlayerIn = (int)gameInfo.Scene;

                GameObject.Find("LoadScene").GetComponent<LoadScene>().LoadSceneNum(5);
                Debug.Log(gameAccount.gameInfor); 
            } else if (request.result== UnityWebRequest.Result.ConnectionError) {

                alertText.text = "Kiểm tra kết nối...";
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
