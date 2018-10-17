using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour {

    private static TextMeshPro s_Text;
    public static float score;

    private void Awake()
    {
        s_Text = GetComponent<TextMeshPro>();
        score = 0;
        UpdateScore();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            score += 1000;
        UpdateScore();
    }

    static public void AddScore(float amount, float multi = 1)
    {
        score += (amount * multi)/3.6f;
        UpdateScore();  
    }
    private static void UpdateScore()
    {
        s_Text.text = "Score : " + Mathf.RoundToInt(score);
    }
}
