using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgingEnemy : Enemy {

    private float startPos;
    [Range(0, 5)]
    public float swaySpeed, swayStregth;

    private void Awake()
    {
        startPos = transform.position.y;
    }

    public override void Move()
    {
        //Fixa rb2 här och så att den ej åker uppåt
        rb2 = GetComponent<Rigidbody2D>();
        rb2.velocity = new Vector2(-speed, startPos + Mathf.Sin(swayStregth * Time.time) * swaySpeed);
    }
}
