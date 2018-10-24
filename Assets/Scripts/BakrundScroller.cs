using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakrundScroller : MonoBehaviour {

    static public float scalar = 1f;
    private Material mat;

	void Start ()
    {
        mat = GetComponent<Renderer>().material;    
	}
	void Update ()
    {
        if (scalar < 1.1f)
            scalar = Time.time * 0.5f;

        mat.mainTextureOffset = new Vector2(Time.time*scalar, 0);		
	}
}
