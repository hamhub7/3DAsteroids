using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject CompletePanel;

    [SerializeField]
    private GameObject spherePrefab;

    [SerializeField]
    public GameObject player;

    [SerializeField]
    public float sphereSpeed = 1f;

    [SerializeField]
    private float spawnTime = 2f;

    [SerializeField]
    private Text scoreText;

    public int score = 0;

    private float elapsedTime = 0f;

    public bool isGamer = true;

    // Start is called before the first frame update
    void Start()
    {
        CompletePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        if(elapsedTime > spawnTime)
        {
            elapsedTime = 0;

            if (isGamer)
            {
                SpawnSphere();
            }
        }

        scoreText.text = "Score: " + score;
    }

    private void SpawnSphere()
    {
        float coord1 = Random.Range(-250f, 250f);
        float coord2 = Random.Range(-250f, 250f);

        Vector3 pos = Vector3.zero;
        switch(Random.Range(0, 5))
        {
            case 0: // Top
                pos = new Vector3(coord1, 275, coord2);
                break;
            case 1: // Bottom
                pos = new Vector3(coord1, -275, coord2);
                break;
            case 2: // Front
                pos = new Vector3(coord1, coord2, 275);
                break;
            case 3: // Back
                pos = new Vector3(coord1, coord2, -275);
                break;
            case 4: // Left
                pos = new Vector3(-275, coord1, coord2);
                break;
            case 5: // Right
                pos = new Vector3(275, coord1, coord2);
                break;
        }

        GameObject sphere = Instantiate(spherePrefab, pos, Quaternion.identity);
        sphere.GetComponent<AsteroidScript>().size = 3;
        sphere.GetComponent<Rigidbody>().velocity = sphereSpeed * (player.transform.position - sphere.transform.position).normalized;
    }

    public void EndGame()
    {
        if(PlayerPrefs.HasKey("high_score"))
        {
            int highScore = PlayerPrefs.GetInt("high_score");
            if(score > highScore)
            {
                PlayerPrefs.SetInt("high_score", score);
            }
            else
            {
                PlayerPrefs.SetInt("high_score", score);
            }
        }

        isGamer = false;
        CompletePanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Arena");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
