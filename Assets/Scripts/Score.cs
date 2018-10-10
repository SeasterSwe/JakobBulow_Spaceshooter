using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour {

    private static TextMeshPro s_Text;
    private static float score;

    private void Awake()
    {
        s_Text = GetComponent<TextMeshPro>();
        score = 0;
        UpdateScore();
    }

    static public void AddScore(float amount, float multi = 1)
    {
        score += (amount * multi)/3.6f;
        UpdateScore();  
    }
    private static void UpdateScore()
    {
        s_Text.text = "Score : " + Mathf.Round(score * 100)/100;
    }
}
