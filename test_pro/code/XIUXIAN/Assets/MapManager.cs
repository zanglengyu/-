using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour {

    // Use this for initialization
    public static MapManager gInstance = null;

    void  Awake()
    {
        gInstance = this;
    }
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
