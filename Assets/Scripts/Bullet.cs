using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [Range(0,20)]
    public float bulletSpeed;
    private Rigidbody2D bullet;

    private void Start()
    {
        bullet = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update ()
    {
        bullet.velocity = (Vector2)transform.forward * bulletSpeed;
    }
}
