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

    void Awake ()
    {

        spriteRen = gameObject.GetComponent<SpriteRenderer>();
        maxHealth = HP;
        health = HP;
             
	}
	
	
	void Update ()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            //Boomeffect och sound
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
