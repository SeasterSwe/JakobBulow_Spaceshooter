using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour {

    [Range(0,10)]
    public float speed;
    protected Rigidbody2D rb2;

    void Awake()
    {
        rb2 = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update ()
    {
        Move();
    }

    public virtual void Move()
    {
        rb2.velocity = new Vector2(-speed, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            Destroy(gameObject);
    }
}
