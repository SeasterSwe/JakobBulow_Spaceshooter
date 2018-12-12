using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroySoundObject : MonoBehaviour {

    private AudioSource source;
    public AudioClip clipToPlay;
    private void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = clipToPlay;
        source.Play();
        Destroy(gameObject, source.clip.length);
    }
}
