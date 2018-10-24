using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroySoundObject : MonoBehaviour {

    private AudioSource boi;
    public AudioClip boi2;
    private void Start()
    {
        boi = GetComponent<AudioSource>();
        boi.clip = boi2;
        boi.Play();
        Destroy(gameObject, boi.clip.length);
    }
}
