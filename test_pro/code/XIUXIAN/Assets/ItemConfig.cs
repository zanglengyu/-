using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemConfig : MonoBehaviour {

    // Use this for initialization
    public int m_Id;
    public int m_withItemId;
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerEnter2D(Collider2D hit)
    {
        //捡东西
        if (m_withItemId >= 0)
        {
            if (hit.gameObject.layer == 8)
            {
                Debug.Log("888888");
                Animation a = gameObject.GetComponent<Animation>();
                a.Play();
            }
        }
        else
        {
            bool enable = Player.GetPlayerInstance().PickUp(m_Id);
            if (enable)
            {
                Debug.Log("OnTriggerEnter2D = hitId = " + m_Id);
                GameManager.Ins.m_uiControl.ShowPickUpEvent(m_Id,1);
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerExit2D(Collider2D hit)
    {
        
    }
}
