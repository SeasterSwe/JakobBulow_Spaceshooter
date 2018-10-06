using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    [Range(0, 20)]
    public float bulletRange, fireRate, bulletSpeed;

    public string ShootButton = "Fire1";

    private float nextFire;
    public GameObject bullet;
    private Vector2 direction;

    public AudioClip laserSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = laserSound;
    }

    void Update()
    {
        if (Input.GetButton(ShootButton) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Fire();
            audioSource.Play();
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
