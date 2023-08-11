using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using TMPro;

public class Food : MonoBehaviour
{
    public BoxCollider2D gridArea;
    public TMP_Text scoreText;
    public TMP_Text scoreText2;
    public TMP_Text highScore;

    private int score;
    private int highscore;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Highscore")) {
            highscore = PlayerPrefs.GetInt("Highscore");
        } else {
            PlayerPrefs.SetInt("Highscore", highscore);
        }
        RandomizePosition();
    }

    private void Update()
    {
        if (score > highscore) {
            highscore = score;
            PlayerPrefs.SetInt("Highscore", highscore);
        }
        highScore.text = "Highscore: " + highscore.ToString();
        scoreText.text = score.ToString();
        scoreText2.text = "Score: " + score.ToString();
    }

    private void RandomizePosition()
    {
        Bounds bounds = this.gridArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") {
            score++;
            RandomizePosition();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
