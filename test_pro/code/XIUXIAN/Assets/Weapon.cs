using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void PrintEvent(string s)
    {
        //public static int OverlapCollider(Collider2D collider, ContactFilter2D contactFilter, Collider2D[] results);

        BoxCollider2D c2d = gameObject.GetComponent<BoxCollider2D>();
        Collider2D[] hit = new Collider2D[10];
        ContactFilter2D cf = new ContactFilter2D();
        cf.layerMask = 13;
            Physics2D.OverlapCollider(c2d, cf, hit);

        for (int i = 0; i != hit.Length; ++i)
        {

            if (hit[i] != null && hit[i].gameObject.layer == 13)
            {
                Debug.Log("PrintEvent: " + s + " called at: " + Time.time);
                Destroy(hit[i].gameObject);
            }
        }
        gameObject.SetActive(false);
    }
}
