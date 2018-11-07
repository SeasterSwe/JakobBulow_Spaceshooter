using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour {

    public GameObject lvlUpClingSound;
    public GameObject lvlUpEffect;
    public GameObject lvlUpSound;
    //public GameObject speedEffect;

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
                BakrundScroller.scalar = 4f;
                lvlUp(lvlUpEffect, lvlUpClingSound, lvlUpSound);
                spawnNumbMin = 4;
                spawnNumMax = 6;
                doOnce2 = false;
            }
            else if (Score.score >= 40 && doOnce)
            {
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                BakrundScroller.scalar = 2f;
                lvlUp(lvlUpSound, lvlUpClingSound, lvlUpEffect);
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
    public void lvlUp(GameObject Sound, GameObject Cling, GameObject Effect)
    {
        GameObject effectClone = Instantiate(Effect, gameObject.transform.position, Effect.transform.rotation);
        Instantiate(Sound);
        Instantiate(Cling);
        Destroy(effectClone.gameObject, 1.8f);
    }

    private Vector3 spawnPoint()
    {
        return new Vector2(10, Random.Range(-4.3f, 4.3f));
    }
}
