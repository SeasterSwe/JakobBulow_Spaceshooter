using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingEnemy : Enemy {

    public GameObject Bullet;

    [Range(0,10)]
    public float bulletRange, bulletSpeed, bulletDelay;

    public void Start ()
    {
        InvokeRepeating("Shoot", 0.5f, bulletDelay);
    }

    public virtual void Shoot()
    {
        GameObject enemyBullet;
        enemyBullet = Instantiate(Bullet, gameObject.transform.position, gameObject.transform.rotation);
        enemyBullet.GetComponent<Rigidbody2D>().velocity = transform.up * -bulletSpeed;
        Destroy(enemyBullet, bulletRange);      
    }
}
