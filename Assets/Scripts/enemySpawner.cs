using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour {

    public GameObject[] enemys;
    //public float yPos;
    public float spawnRatePerS;

    public int level = 1;

    private float spawnRate;
    private float spawnColdown;

    void Start ()
    {
        spawnRate = spawnRatePerS;
	}
	
	void Update ()
    {
        spawnRate -= 0.1f * Time.deltaTime;
        if (spawnColdown <= 0)
        {
            if (level == 1)
            {
                Instantiate(enemys[Random.Range(0, 1)], PointOutSideScreen(), Quaternion.Euler(0, 0, -90));
                spawnColdown = spawnRate / 60;
            }         
        }
        else
        {
            spawnColdown -= 0.1f * Time.deltaTime;
        }

	}

    private Vector3 PointOutSideScreen()
    {
        float size = Camera.main.orthographicSize;
        size *= Camera.main.aspect;
        size -= 1f;
        return new Vector2(1f, Random.Range(-1f, 1f)).normalized * size;
    }
}
