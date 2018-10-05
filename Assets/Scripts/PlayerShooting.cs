using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    [Range(0, 20)]
    public float bulletRange, fireRate, bulletSpeed;
    public int bulletDmg = 1;

    public string ShootButton = "Fire1";

    private float nextFire;
    public GameObject bullet;
    private Vector2 direction;

    void Update()
    {
        if (Input.GetButton(ShootButton) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Fire();
        }
    }

    private void Fire()
    {
        GameObject clone;
        clone = Instantiate(bullet, gameObject.transform.position, gameObject.transform.rotation);
        clone.GetComponent<Rigidbody2D>().velocity = (Vector2)transform.up   * bulletSpeed;
        Destroy(clone, bulletRange);
    }
}
