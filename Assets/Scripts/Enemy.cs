using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour {

    [Range(0,10)]
    public float speed;
    protected Rigidbody2D rb2;

	void Start ()
    {
        rb2 = gameObject.GetComponent<Rigidbody2D>();
	}

	void Update ()
    {
        move();
    }

    public virtual void move()
    {
        rb2.velocity = new Vector2(-speed, 0);
    }
}
