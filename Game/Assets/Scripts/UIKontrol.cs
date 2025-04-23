using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class UIKontrol : MonoBehaviour
{
    [SerializeField] GameObject oyunBittiText;

    [SerializeField] GameObject oyunAdiText;

    [SerializeField] GameObject oynaButonu;


    [SerializeField] TMP_InputField usernameInput;
    [SerializeField] Button login;
    [SerializeField] Text puanText;
    [SerializeField] Text[] usernameUI;


    [SerializeField] GameObject EndInformationPanel;
    [SerializeField] Text scoreEnd;
    int scoresave;
    [SerializeField] Button saveGameButton;

    // When press this button save score and player name backend
    private string playerName;
    int score = 0;

    OyunKontrol oyunKontrol;

    void Start()
    {
        oyunBittiText.gameObject.SetActive(false);
        puanText.gameObject.SetActive(false);
        usernameInput.gameObject.SetActive(true);
        oynaButonu.gameObject.SetActive(false);
        usernameUI[0].gameObject.SetActive(true);
        EndInformationPanel.SetActive(false);
        oyunKontrol = Camera.main.GetComponent<OyunKontrol>();
    }

    public void OyunBasladý()
    {
        EndInformationPanel.gameObject.SetActive(false);
        oyunAdiText.gameObject.SetActive(false);
        oynaButonu.gameObject.SetActive(false);
        puanText.gameObject.SetActive(true);
        PuanGuncelle();
        oyunBittiText.gameObject.SetActive(false);
    }

    public void OyunBitti()
    {
        oyunKontrol.SonTemizleyici();
        oyunBittiText.gameObject.SetActive(true);
        oynaButonu.gameObject.SetActive(true);
        EndInformationPanel.gameObject.SetActive(true);
        scoresave = score;
        scoreEnd.text = "Score: " + score;
        usernameUI[1].text = "Username: " + playerName;
        score = 0;

    }

    public void PuanGuncelle()
    {

        puanText.text = "PUAN: " + score;

    }

    public void asteroidPuanEkle(GameObject asteroid)
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

            default:
                break;
        }
        PuanGuncelle();

    }

    //When player press login button is it work.
    public void SetPlayerName()
    {
        playerName = usernameInput.text;
        Debug.Log("Player: " + playerName);

        if (!string.IsNullOrEmpty(playerName))
        {

            usernameInput.gameObject.SetActive(false);
            usernameUI[0].text = "Username: " + playerName;
            login.gameObject.SetActive(false);
            oynaButonu.gameObject.SetActive(true);

        }
        else
        {

            Debug.Log("Please enter a username");

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

            Debug.LogWarning("username is empty.");

        }

    }

    IEnumerator PostScore(string playerName, int score)
    {
        string jsonData = JsonUtility.ToJson(new ScoreData(playerName, score));
        UnityWebRequest request = new UnityWebRequest("http://localhost:8000/score", "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
            Debug.Log("Score sends.");
        else
            Debug.LogError("Error: " + request.error);


    }


    [System.Serializable]
    public class ScoreData
    {
        public string player_name;
        public int score;

        public ScoreData(string name, int score)
        {
            this.player_name = name;
            this.score = score;
        }
    }


}