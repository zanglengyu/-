using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baoxiang : MonoBehaviour {

    // Use this for initialization
    public int m_withItemId;
    public int m_itemCount;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.layer == 8)
        {
            Debug.Log("888888");
            Animator a = gameObject.GetComponent<Animator>();
            a.SetBool("play",true);
        }
    }

    public void OpenBox()
    {
        gameObject.SetActive(false);
        GameManager.Ins.m_uiControl.m_bagLayer.PickUp(m_withItemId);
    }
}
