using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgingEnemy : shootingEnemy {

    [Range(-5, 5)]
    public float swaySpeed, swayStregth;

    public override void Move()
    {
        SwayEffect();
    }
    public void SwayEffect()
    {
        rb2.velocity = new Vector2(-speed, Mathf.Sin(swayStregth * Time.time) * swaySpeed);
    }
}
