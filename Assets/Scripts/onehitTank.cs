﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onehitTank : Enemy {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(collision.gameObject, 0.1f); //Behövdes lite delay
        }
    }
}
