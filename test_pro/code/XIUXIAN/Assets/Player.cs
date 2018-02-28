using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    // Use this for initialization

    public Animator m_anim;
    private int m_curMoveDir = 0;//0,1,2,3,4,分别代表待机，上下左右

    private string m_lastContidon = "";

    private float m_moveSpeed = 2f;

    private bool m_moveBegin = false;

    public CapsuleCollider2D m_myCollider;
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.W))
        {
            int endMoveDir = 0;
            if (Input.GetKeyUp(KeyCode.D))
            {
                endMoveDir = 4;
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                endMoveDir = 3;
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                endMoveDir = 2;
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                endMoveDir = 1;
            }
            ToKong(endMoveDir);
            
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            ToUp();
            return;
            
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            ToDown();
            return;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            ToLeft();
            return;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            ToRight();
            return;
        }

      

        float moveDir = 0;
        if (m_moveBegin)
        {
            moveDir = m_moveSpeed * Time.deltaTime;
            Vector3 v3 = new Vector3(0,0,0);
            if (m_curMoveDir == 1)
            {


                v3 = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y + moveDir, gameObject.transform.localPosition.z);
            }
            else if (m_curMoveDir == 2)
            {
                v3 = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y - moveDir, gameObject.transform.localPosition.z);
            }
            else if (m_curMoveDir == 3)
            {
                v3 = new Vector3(gameObject.transform.localPosition.x - moveDir, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);
            }
            else if (m_curMoveDir == 4)
            {
                v3 = new Vector3(gameObject.transform.localPosition.x + moveDir, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);
            }

            Vector2 curV2 = new Vector2(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y);
            Vector2 newV2 = new Vector2(v3.x, v3.y);

            if (m_curMoveDir == 1)
            {
                newV2.y += GetComponent<BoxCollider2D>().size.y / 2;
            }
            else if (m_curMoveDir == 2)
            {
                newV2.y -= GetComponent<BoxCollider2D>().size.y / 2;
            }
            else if (m_curMoveDir == 3)
            {
                newV2.x -= GetComponent<BoxCollider2D>().size.x / 2;
            }
            else if (m_curMoveDir == 4)
            {
                newV2.x += GetComponent<BoxCollider2D>().size.x / 2;
            }
            //Collider2D[] OverlapPointAll(Vector2 point, int layerMask);
            Collider2D [] hit = Physics2D.OverlapPointAll(newV2);
            for (int i = 0; i != hit.Length; ++i)
            {
                Debug.Log(hit[i].gameObject.layer);
                if (hit[i].gameObject.layer == 9)
                {
                    Debug.Log("hit[i].gameObject.layer");
                    return;
                }
            }
            

            {
                gameObject.transform.localPosition = new Vector3(v3.x, v3.y, v3.z); ;
            }
        }
    }


    public void ToLeft()
    {
        string[] ay = { "ktl","utl","dtl","","rtl"};
        if (m_curMoveDir != 3)
        {
            
            m_anim.SetBool(ay[m_curMoveDir], true);
            if (!m_lastContidon.Equals(""))
            {
               
                m_anim.SetBool(m_lastContidon, false);
            }
             
            m_lastContidon = ay[m_curMoveDir];
            
            m_curMoveDir = 3;
             
        }
        MoveStart(true);

    }
    public void ToRight()
    {
        string[] ay = { "ktr", "utr", "dtr", "ltr", "rtr" };
        if (m_curMoveDir != 4)
        {
           
            m_anim.SetBool(ay[m_curMoveDir], true);
            if (!m_lastContidon.Equals(""))
            {
               
                m_anim.SetBool(m_lastContidon, false);
            }
            m_lastContidon = ay[m_curMoveDir];
            
            m_curMoveDir = 4;
        }
        MoveStart(true);
    }
    public void ToUp()
    {
        string[] ay = { "ktu", "utu", "dtu", "ltu", "rtu" };
        if (m_curMoveDir != 1)
        {
           
            m_anim.SetBool(ay[m_curMoveDir], true);
            if (!m_lastContidon.Equals(""))
            {
                
                m_anim.SetBool(m_lastContidon, false);
            }
            m_lastContidon = ay[m_curMoveDir];
            
            m_curMoveDir = 1;
        }
        MoveStart(true);
    }

    public void MoveStart(bool start)
    {
        m_moveBegin = start;
    }
    public void ToDown()
    {
        string[] ay = { "ktd", "utd", "dtd", "ltd", "rtd" };
        if (m_curMoveDir != 2)
        {
           
            m_anim.SetBool(ay[m_curMoveDir], true);
            if (!m_lastContidon.Equals(""))
            {
               
                m_anim.SetBool(m_lastContidon, false);
            }
            m_lastContidon = ay[m_curMoveDir];
           
            m_curMoveDir = 2;
        }
        MoveStart(true);
    }
    public void ToKong(int lastDir)
    {
      
        string[] ay = { "ktK", "utk", "dtk", "ltk", "rtk" };
        if (m_curMoveDir != 0)
        {
           // Debug.Log("ToKong = m_curMoveDir " + ay[m_curMoveDir]);
            //m_anim.SetBool(ay[m_curMoveDir], true);
            if (!m_lastContidon.Equals(""))
            {

                m_anim.SetBool(m_lastContidon, false);
            }
            m_lastContidon = ay[m_curMoveDir];
            m_anim.SetBool(m_lastContidon, false);

           
            //m_curMoveDir = 0;
        }
        if (lastDir == m_curMoveDir)
        {
            MoveStart(false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter hit");
    }
    void OnTriggerEnter2D(Collider2D hit)
    {
        Debug.Log("OnTriggerEnter2D hit");
    }
}
