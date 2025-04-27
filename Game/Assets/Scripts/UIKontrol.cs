using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class UIKontrol : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private GameObject oyunBittiText;
    [SerializeField] private GameObject oyunAdiText;
    [SerializeField] private GameObject oynaButonu;
    [SerializeField] private TMP_InputField usernameInput;
    [SerializeField] private Button loginButton;
    [SerializeField] private Text puanText;
    [SerializeField] private Text[] usernameUI;
    [SerializeField] private GameObject EndInformationPanel;
    [SerializeField] private Text scoreEnd;
    [SerializeField] private Button saveGameButton;

    [Header("Error Panel")]
    [SerializeField] private GameObject errorPanel;
    [SerializeField] private Text errorMessageText;
    [SerializeField] private float errorDisplayDuration = 2.5f;

    private Coroutine errorCoroutine;

    private string playerName;
    private int score = 0;
    private int scoresave = 0;
    private OyunKontrol oyunKontrol;

    private void Start()
    {
        oyunBittiText.SetActive(false);
        puanText.gameObject.SetActive(false);
        usernameInput.gameObject.SetActive(true);
        oynaButonu.SetActive(false);
        usernameUI[0].gameObject.SetActive(true);
        EndInformationPanel.SetActive(false);
        errorPanel.SetActive(false);

        oyunKontrol = Camera.main.GetComponent<OyunKontrol>();
    }

    public void OyunBasladi()
    {
        EndInformationPanel.SetActive(false);
        oyunAdiText.SetActive(false);
        oynaButonu.SetActive(false);
        puanText.gameObject.SetActive(true);
        oyunBittiText.SetActive(false);
        UpdateScoreText();
    }

    public void OyunBitti()
    {
        oyunKontrol.SonTemizleyici();
        oyunBittiText.SetActive(true);
        oynaButonu.SetActive(true);
        EndInformationPanel.SetActive(true);

        scoresave = score;
        scoreEnd.text = "Score: " + score;
        usernameUI[1].text = "Username: " + playerName;

        score = 0;
    }

    private void UpdateScoreText()
    {
        puanText.text = "PUAN: " + score;
    }

    public void AsteroidPuanEkle(GameObject asteroid)
    {
        if (asteroid.gameObject.name.Length > 8)
        {
            switch (asteroid.gameObject.name[8])
            {
                case '1':
                    score += 5;
                    break;
                case '2':
                    score += 10;
                    break;
                case '3':
                    score += 15;
                    break;
            }
            UpdateScoreText();
        }
    }

    public void TryLogin()
    {
        string tempUsername = usernameInput.text.Trim();

        if (string.IsNullOrEmpty(tempUsername))
        {
            ShowError("Please enter a username!");
            return;
        }

        StartCoroutine(CheckUsername(tempUsername, (exists) =>
        {
            if (exists)
            {
                ShowError("This username is already taken!");
            }
            else
            {
                playerName = tempUsername;

                usernameInput.gameObject.SetActive(false);
                usernameUI[0].text = "Username: " + playerName;
                loginButton.gameObject.SetActive(false);
                oynaButonu.SetActive(true);
            }
        }));
    }

    private IEnumerator CheckUsername(string playerNameToCheck, System.Action<bool> callback)
    {
        UnityWebRequest request = UnityWebRequest.Get("http://localhost:8000/check-username/" + playerNameToCheck);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            var response = JsonUtility.FromJson<UsernameCheckResponse>(request.downloadHandler.text);
            callback(response.exists);
        }
        else
        {
            Debug.LogError("Server error: " + request.error);
            ShowError("Connection error. Please try again.");
        }
    }

    public void SendScore()
    {
        if (!string.IsNullOrEmpty(playerName))
        {
            StartCoroutine(PostScore(playerName, scoresave));
        }
        else
        {
            ShowError("Username is empty. Cannot send score!");
        }
    }

    private IEnumerator PostScore(string playerName, int score)
    {
        string jsonData = JsonUtility.ToJson(new ScoreData(playerName, score));
        UnityWebRequest request = new UnityWebRequest("http://localhost:8000/score", "POST");

        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Score successfully sent.");
        }
        else
        {
            ShowError("Failed to send score: " + request.error);
        }
    }

    private void ShowError(string message)
    {
        if (errorCoroutine != null)
        {
            StopCoroutine(errorCoroutine);
        }
        errorCoroutine = StartCoroutine(ShowErrorCoroutine(message));
    }

    private IEnumerator ShowErrorCoroutine(string message)
    {
        errorMessageText.text = message;
        errorPanel.SetActive(true);

        yield return new WaitForSeconds(errorDisplayDuration);

        errorPanel.SetActive(false);
    }

    [System.Serializable]
    private class UsernameCheckResponse
    {
        public bool exists;
    }

    [System.Serializable]
    private class ScoreData
    {
        public string player_name;
        public int score;

        public ScoreData(string name, int score)
        {
            player_name = name;
            this.score = score;
        }
    }
}
