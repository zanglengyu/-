using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventConfg : MonoBehaviour {

    // Use this for initialization
    public GameObject [] m_allEventObj;
    public static EventConfg Ins = null;
    void Awake()
    {
        Ins = this;
        Debug.Log("AwakeAwakeAwakeAwakeAwake");
    }

	void Start ()
    {
        

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowEventObj(string name)
    {
        foreach (GameObject obj in m_allEventObj)
        {
            if (obj.name.Equals(name))
            {
                obj.SetActive(true);

            }
        }
    }
}
