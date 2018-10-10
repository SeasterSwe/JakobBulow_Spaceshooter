using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgingEnemy : shootingEnemy {

    [Range(-5, 5)]
    public float swaySpeed, swayStregth;

    private bool sPos = true;
    public override void Move()
    {
        SwayEffect();
    }
    public void SwayEffect()
    {
        while (sPos)
        {        
            if (gameObject.transform.position.y >= 0)
                swaySpeed = -swaySpeed;
            
            sPos = false;
        }
        rb2.velocity = new Vector2(-speed, Mathf.Sin(swayStregth * Time.time) * swaySpeed);
    }
}
