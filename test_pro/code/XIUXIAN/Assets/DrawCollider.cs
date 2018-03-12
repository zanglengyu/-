using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public int m_colorId = 0;
    public void OnDrawGizmos()
    {


#if UNITY_EDITOR
        
        //if (m_colorId == 0)
        //{
        //    Handles.color = new Color(Color.blue.r,Color.blue.g, Color.blue.b, 20);
           
        //}
        //else
        //{
        //    Handles.color = new Color(Color.green.r, Color.green.g, Color.green.b, 20);
            
        //}
        ////Handles.ArrowCap(0, transform.position, transform.rotation, transform.localScale.z);

        //BoxCollider2D bx = gameObject.GetComponent<BoxCollider2D>();

        //Vector3 leftTop = gameObject.transform.position + new Vector3(-bx.size.x/2, bx.size.y / 2, gameObject.transform.localPosition.z);
        //Vector3 rightTop = gameObject.transform.position + new Vector3(bx.size.x / 2, bx.size.y / 2, gameObject.transform.localPosition.z);
        //Vector3 leftDown = gameObject.transform.position + new Vector3(-bx.size.x / 2, -bx.size.y / 2, gameObject.transform.localPosition.z);
        //Vector3 rightDown = gameObject.transform.position + new Vector3(+bx.size.x / 2, -bx.size.y / 2, gameObject.transform.localPosition.z);
        //Vector3[] varray = new Vector3[5] { leftTop, rightTop, rightDown,leftDown, leftTop };

        //Handles.DrawAAConvexPolygon(varray);
        
#endif

    }

    public void OnDrawGizmosSelected()
    {
 
    }
}
