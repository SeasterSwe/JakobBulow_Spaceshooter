using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    [Range(1, 10)]
    public int HP;

    private float health;
    private int maxHealth;
    private Color dmgColor = Color.white;
    private SpriteRenderer spriteRen;

    public ParticleSystem Explotion;
    private ParticleSystem ExplotionClone;

    public AudioClip ExplotionSound;
    private AudioSource audioSource;

    private bool canDie = true;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = ExplotionSound;

        spriteRen = gameObject.GetComponent<SpriteRenderer>();
        maxHealth = HP;
        health = HP;

    }


    void Update()
    {
        if (health <= 0)
            Death();
    }

    public void Death()
    {
        if (canDie)
        {
            audioSource.Play();
            Destroy(gameObject, audioSource.clip.length);
            ExplotionClone = Instantiate(Explotion, gameObject.transform.position, Explotion.transform.rotation);
            spriteRen.enabled = false;
            gameObject.GetComponent<Collider2D>().enabled = false;
            Destroy(ExplotionClone, 0.5f);

            canDie = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Bullet")
        {
            Destroy(coll.gameObject);
            health -= 1;
            dmgColor = Color.Lerp(Color.white, Color.red, 1f - (health / maxHealth));
            spriteRen.color = dmgColor;
        }
        if (gameObject.tag == "Player" && coll.tag == "Enemy")
        {
            Destroy(coll.gameObject);
            health -= 1;
            dmgColor = Color.Lerp(Color.white, Color.red, 1f - (health / maxHealth));
            spriteRen.color = dmgColor;
        }
    }

}
