using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    [Range(1, 5)]
    public int playerHP, enemyHP;

    private float health;
    private int maxHealth;
    private Color dmgColor = Color.white;
    private SpriteRenderer spriteRen;

    void Awake ()
    {

        spriteRen = gameObject.GetComponent<SpriteRenderer>();

        if (gameObject.tag == "Player")
        {
            maxHealth = playerHP;
            health = playerHP;
        }

        if (gameObject.tag == "Enemy")
        {
            maxHealth = enemyHP;
            health = enemyHP;
        }
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
    }

}
