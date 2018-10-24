using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour {

    public GameObject lvlUp;
    public GameObject[] enemys;
    public float spawnRatePerS;

    public int level = 1;

    private float spawnRate;
    private float spawnColdown;

    private float spawnDelay;
    private float waitSeconds;

    private int spawnNumbMin, spawnNumMax;

    bool doOnce = true;
    bool doOnce2 = true;
    void Start ()
    {
        waitSeconds = 1.2f;
        spawnNumbMin = 0;
        spawnNumMax = 2;
        spawnRate = spawnRatePerS;
	}
	
	void Update ()
    {
        if(spawnDelay < waitSeconds)
            spawnDelay = Time.time *0.5f;
        spawnRate -= 0.1f * Time.deltaTime;
        if (spawnColdown <= 0 && waitSeconds < spawnDelay)
        {
            Instantiate(enemys[Random.Range(spawnNumbMin, spawnNumMax)], spawnPoint(), Quaternion.Euler(0, 0, -90));
            spawnColdown = spawnRate / 60;

            if (Score.score >= 120 && doOnce2)
            {
                //BakrundScroller.scalar = 2f;
                Instantiate(lvlUp);
                spawnNumbMin = 4;
                spawnNumMax = 6;
                doOnce2 = false;
            }
            if (Score.score >= 40 && doOnce)
            {
                //BakrundScroller.scalar = 1.5f;
                Instantiate(lvlUp);
                spawnNumbMin = 1;
                spawnNumMax = 4;
                doOnce = false;
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
