using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZhangAi : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.layer == 14)
        {
            Animation a = gameObject.GetComponent<Animation>();
            a.Play();
        }
    }

}
