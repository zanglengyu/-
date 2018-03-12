using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour {

    // Use this for initialization

    public Animator m_anim;
    private int m_curMoveDir = 0;//0,1,2,3,4,分别代表待机，上下左右

    private string m_lastContidon = "";

    private float m_moveSpeed = 1.5f;

    private bool m_moveBegin = false;

    public CapsuleCollider2D m_myCollider;

    private bool m_touchUp;
    private bool m_touchDown;
    private bool m_touchLeft;
    private bool m_touchRight;

    private float m_hp = 0;
    private int m_gold;

    public Weapon [] m_weapons;

    private static Player m_instance = null;

    public static Player GetPlayerInstance()
    {
       return m_instance;
    }

    void Awake()
    {
        m_instance = this;
    }

    void Start()
    {
		
	}

    public void SetTouchDir(int dir, bool enable)
    {
        if (enable)
        {
            if (dir == 1)
            {
                ToUp();
            }
            else if (dir == 2)
            {
                ToDown();
            }
            else if (dir == 3)
            {
                ToLeft();
            }
            else if (dir == 4)
            {
                ToRight();
            }
        }
        else
        {
            ToKong(dir);
        }

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
            moveDir =  m_moveSpeed * Time.deltaTime;
            Vector3 v3 = new Vector3(0,0,0);
            Transform mapTran = MapManager.gInstance.gameObject.transform;
            bool mapMove = true;
            if (mapMove)
            {
                if (m_curMoveDir == 1)
                {
                    v3 = new Vector3(mapTran.localPosition.x, mapTran.localPosition.y - moveDir, mapTran.localPosition.z);
                }
                else if (m_curMoveDir == 2)
                {
                    v3 = new Vector3(mapTran.localPosition.x, mapTran.localPosition.y + moveDir, mapTran.localPosition.z);
                }
                else if (m_curMoveDir == 3)
                {
                    v3 = new Vector3(mapTran.localPosition.x + moveDir, mapTran.localPosition.y, mapTran.localPosition.z);
                }
                else if (m_curMoveDir == 4)
                {
                    v3 = new Vector3(mapTran.localPosition.x - moveDir, mapTran.localPosition.y, mapTran.localPosition.z);
                }
            }
            else
            {
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

            }
            Vector2 curV2 = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            Vector2 newV2 = new Vector2(v3.x, v3.y);
            if (mapMove)
            {
                newV2 = curV2;
            }
            else
            {
                
            }


            Vector2 newV2CheckPoint = newV2;
            Vector2 newV2CheckPoint1 = newV2;
            if (m_curMoveDir == 1)
            {
                //Debug.Log("BoxCollider2D = " + GetComponent<BoxCollider2D>().size.y);
                newV2.y += GetComponent<BoxCollider2D>().size.y / 2 + moveDir;
                newV2CheckPoint.y = newV2.y;
                newV2CheckPoint.x = newV2.x + GetComponent<BoxCollider2D>().size.x / 2;

                newV2CheckPoint1.y = newV2.y;
                newV2CheckPoint1.x = newV2.x - GetComponent<BoxCollider2D>().size.x / 2;
            }
            else if (m_curMoveDir == 2)
            {
                newV2.y = newV2.y - GetComponent<BoxCollider2D>().size.y / 2 - moveDir;
                newV2CheckPoint.y = newV2.y;
                newV2CheckPoint.x = newV2.x + GetComponent<BoxCollider2D>().size.x / 2;

                newV2CheckPoint1.y = newV2.y;
                newV2CheckPoint1.x = newV2.x - GetComponent<BoxCollider2D>().size.x / 2;
            }
            else if (m_curMoveDir == 3)
            {
                newV2.x = newV2.x - GetComponent<BoxCollider2D>().size.x / 2 - moveDir;
                newV2CheckPoint.x = newV2.x;
                newV2CheckPoint.y = newV2.y + GetComponent<BoxCollider2D>().size.y / 2;


                newV2CheckPoint1.x = newV2.x;
                newV2CheckPoint1.y = newV2.y - GetComponent<BoxCollider2D>().size.y / 2;
            }
            else if (m_curMoveDir == 4)
            {
                newV2.x += GetComponent<BoxCollider2D>().size.x / 2 + moveDir;
                newV2CheckPoint.x = newV2.x;
                newV2CheckPoint.y = newV2.y + GetComponent<BoxCollider2D>().size.y / 2;

                newV2CheckPoint1.x = newV2.x;
                newV2CheckPoint1.y = newV2.y - GetComponent<BoxCollider2D>().size.y / 2;
            }

            //Collider2D[] OverlapPointAll(Vector2 point, int layerMask);

            //Collider2D OverlapBox(Vector2 point, Vector2 size, float angle, int layerMask);
            Collider2D [] hit = Physics2D.OverlapPointAll(newV2);
       
            for (int i = 0; i != hit.Length; ++i)
            {

                if (hit[i].gameObject.layer == 9 || hit[i].gameObject.layer == 13 || hit[i].gameObject.layer==15)
                {

                    if (hit[i].gameObject.layer == 15)
                    {
                        //打开箱子
                        OpenBox(hit[i].gameObject);
                    }
                    return;
                }
                else if (hit[i].gameObject.layer == 10)
                {
                    Debug.Log("OnTriggerEnter2D hit npc");
                    NpcConfig nc = hit[i].gameObject.GetComponent<NpcConfig>();
                   
                    GameManager.Ins.m_juqingWindow.ShowJuqingById(nc.m_npcId);
                    return;
                }
                else if (hit[i].gameObject.layer == 11)
                {

                }
            }
            hit = Physics2D.OverlapPointAll(newV2CheckPoint);
            for (int i = 0; i != hit.Length; ++i)
            {

                if (hit[i].gameObject.layer == 9 || hit[i].gameObject.layer == 13 || hit[i].gameObject.layer == 15)
                {
                    Debug.Log("newV2CheckPoint .gameObject.layer");
                    if(hit[i].gameObject.layer == 15)
                    {
                        //打开箱子
                        OpenBox(hit[i].gameObject);
                    }
                    return;
                }
            }

            hit = Physics2D.OverlapPointAll(newV2CheckPoint1);
            for (int i = 0; i != hit.Length; ++i)
            {

                if (hit[i].gameObject.layer == 9 || hit[i].gameObject.layer == 13 || hit[i].gameObject.layer == 15)
                {
                    Debug.Log("newV2CheckPoint1 .gameObject.layer");

                    if (hit[i].gameObject.layer == 15)
                    {
                        //打开箱子
                        OpenBox(hit[i].gameObject);
                    }
                    return;
                }
            }
            if (mapMove)
            {
                MapManager.gInstance.transform.localPosition = new Vector3(v3.x, v3.y, v3.z);
            }
            else
            {
                gameObject.transform.localPosition = new Vector3(v3.x, v3.y, v3.z); 
            }

        }
    }


    public void OpenBox(GameObject gb)
    {
        Debug.Log("888888");
        Animator a = gb.GetComponent<Animator>();
        a.SetBool("play", true);
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
       
    }

    public bool PickUp(int id)
    {

        bool canPick = GameManager.Ins.m_uiControl.m_bagLayer.PickUp(id);
        return canPick;
    }

    public void Attack()
    {
        Debug.Log("m_curMoveDir = " + m_curMoveDir);
        for (int i = 0; i != 4; ++i)
        {
            if (i == m_curMoveDir-1)
            {
                Debug.Log("Attack");
                m_weapons[i].gameObject.SetActive(true);
            }
            else
            {
                m_weapons[i].gameObject.SetActive(false);
            }
        }
    }


    public void AddHp(float hp)
    {
        m_hp += hp;
        if (m_hp < 0)
        {
            //弹出死亡界面
        }
        else
        {
            GameManager.Ins.m_uiControl.UpdateHp(m_hp);
        }
    }

    public void Damage(float hp)
    {
        AddHp(-hp);
    }
}
