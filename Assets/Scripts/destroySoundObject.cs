using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroySoundObject : MonoBehaviour {

    private void Awake()
    {   
        //byta ut 5f till typ "Audio.Lenght
        Destroy(gameObject, 5f);
    }
}
