using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour {

    public GameObject[] enemys;
    public float spawnRatePerS;

    public int level = 1;

    private float spawnRate;
    private float spawnColdown;

    private int spawnNumbMin, spawnNumMax;
    void Start ()
    {
        spawnNumbMin = 0;
        spawnNumMax = 2;
        spawnRate = spawnRatePerS;
	}
	
	void Update ()
    {
        spawnRate -= 0.1f * Time.deltaTime;
        if (spawnColdown <= 0)
        {
            Instantiate(enemys[Random.Range(spawnNumbMin, spawnNumMax)], spawnPoint(), Quaternion.Euler(0, 0, -90));
            spawnColdown = spawnRate / 60;
            if (Score.score >= 20)
            {
                spawnNumbMin = 1;
                spawnNumMax = 4;
            }
            if (Score.score >= 40)
            {
                spawnNumbMin = 4;
                spawnNumMax = 6;
            }
        }

        else
        {
            spawnColdown -= 0.1f * Time.deltaTime;
        }

	}

    private Vector3 spawnPoint()
    {
        return new Vector2(10, Random.Range(-4.3f, 4.3f));
    }
}
