using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgingEnemy : shootingEnemy {

    [Range(-5, 5)]
    public float swaySpeed, swayStregth;
    private float swayCorrection;

    private bool checkPos = true;
    public override void Move()
    {
        SwayEffect();
    }
    public void SwayEffect()
    {
        //dividerA Y pos, med 2, +- beroende på pos ist!!
        if (checkPos)
        {
            swayCorrection = swayStregth / 2;
            if (gameObject.transform.position.y >= 0)
                swayCorrection = -swayCorrection;

            transform.position = new Vector2(transform.position.x, transform.position.y + swayCorrection); //Curv Fix
            swayStregth = swayStregth * GetPositiveOrNegative(); //Random upp eller ner

            checkPos = false;
        }
        rb2.velocity = new Vector2(-speed, Mathf.Sin(swaySpeed * Time.time) *swayStregth);
    }

    public int GetPositiveOrNegative()
    {

        return (int) ( Mathf.Sign(Random.Range(-1f, 1f)) ) ;
    }
}
