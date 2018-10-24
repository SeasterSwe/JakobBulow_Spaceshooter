using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour {

    [Range(0,16)]
    public float speed, speedX;

    private GameObject Player;
    private Rigidbody2D rb2;

	void Start ()
    {
        if (Player == null)
            Player = GameObject.FindGameObjectWithTag("Player");
        rb2 = Player.GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
        float speedY = Input.GetAxis("Vertical") * speed;
        rb2.velocity = new Vector2(speedX, speedY);       
	}
}
