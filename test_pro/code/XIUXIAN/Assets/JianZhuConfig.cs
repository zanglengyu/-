using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class JianZhuConfig : MonoBehaviour {

    // Use this for initialization

    public GameObject m_jianzhuNei;
    public Color m_color;
     
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D hit)
    {
        m_jianzhuNei.SetActive(true);
        Tilemap []  tp = gameObject.GetComponents<Tilemap>();
        tp[0].color = new Color(0.2f, 0.2f, 0.2f, 0.5f);
        Vector3Int v3Int = new Vector3Int(0, -6, 0);
        tp[0].SetTile(v3Int, null);
    }

    void OnTriggerExit2D(Collider2D hit)
    {
        m_jianzhuNei.SetActive(false);
        Tilemap[] tp = gameObject.GetComponents<Tilemap>();
      //  tp[0].color = new Color(0.2f, 0.2f, 0.2f, 0.5f);
        tp[0].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        
}
}
