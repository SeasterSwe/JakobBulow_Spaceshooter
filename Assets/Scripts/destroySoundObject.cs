﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroySoundObject : MonoBehaviour {

    private AudioSource boi;
    public AudioClip boi2;
    private void Awake()
    {
        boi = GetComponent<AudioSource>();
        boi.clip = boi2;
        Destroy(gameObject, boi.clip.length);
    }
}
