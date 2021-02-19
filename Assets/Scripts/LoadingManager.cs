using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour
{
    [SerializeField]
    private Text highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        int score = 0;
        if(PlayerPrefs.HasKey("high_score"))
        {
            score = PlayerPrefs.GetInt("high_score");
        }
        highScoreText.text = "High Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Arena");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
