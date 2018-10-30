using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour {

    public TextMeshPro surviedForText;
    public TextMeshPro gameOver;
    public GameObject gameOverSound;
    private GameObject Player;
    private bool check = true;

    void Start ()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update ()
    {
        if (check && Player == null)
        {
            float endScore = Score.score;

            Instantiate(gameOverSound);

            gameOver.color = Color.red;
            gameOver.transform.position = new Vector2(gameOver.transform.position.x, 0);
            gameOver.text = "Game Over!! Your Score Equals: " + Mathf.Round(endScore);
            surviedForText.text  = "You survied for " + Mathf.Round(Time.timeSinceLevelLoad) + "S";
            Invoke("changeScene", 3f);
            check = false;
        }
    }
    public void changeScene()
    {
        SceneManager.LoadScene("Level1");
    }
}
