using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [Range(1, 10)]
    public int startHP;

    private float health;
    private int maxHealth;
    private Color dmgColor = Color.white;
    private SpriteRenderer spriteRen;

    public ParticleSystem Explotion;
    private ParticleSystem ExplotionClone;

    public GameObject explotionSound;
    public GameObject hitSound;
    public GameObject hitFlash;

    private bool canDie = true;

    void Awake()
    {
        spriteRen = gameObject.GetComponent<SpriteRenderer>();
        maxHealth = startHP;
        health = startHP;
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
            ExplotionClone = Instantiate(Explotion, gameObject.transform.position, Explotion.transform.rotation);
            Destroy(ExplotionClone.gameObject, 0.5f);
            Instantiate(explotionSound);
            Destroy(gameObject);
            Score.AddScore(maxHealth, 12);
            canDie = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Bullet")
        {
            health -= 1;
            Destroy(coll.gameObject);
            InstaSoundHit(hitSound);
            dmgColor = Color.Lerp(Color.white, Color.red, 1f - (health / maxHealth));
            spriteRen.color = dmgColor;
        }

        else if (gameObject.tag == "Player" && coll.tag == "Enemy")
        {
            ExplotionClone = Instantiate(Explotion, gameObject.transform.position, Explotion.transform.rotation);
            Destroy(ExplotionClone, 0.5f);

            InstaSoundHit(hitSound);
            health -= 1;
            dmgColor = Color.Lerp(Color.white, Color.red, 1f - (health / maxHealth));
            spriteRen.color = dmgColor;
        }
    }
    private void InstaSoundHit(GameObject sound)
    {
        if (health > 0)
            Instantiate(sound);
    }
}


