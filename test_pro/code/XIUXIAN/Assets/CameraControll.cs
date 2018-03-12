using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;//引入DoTween命名空间
public class CameraControll : MonoBehaviour
{

    // Use this for initialization
    Vector2 m_curworldMousePosition;
    Vector2 m_firstTouchMousePos;
    float maxX = 1;
    float maxY = 0;
    float minX = 0;
    float minY = 0;
    void Start ()
    {
        
        SetBasicValues();

        Vector3 maxPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, -10));
        Vector3 minPos = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, -10));
        Debug.Log("maxPos = " + maxPos);
        Debug.Log("minPos = " + minPos);
        maxX = 0.275f;
        minX = -0.27f;
        maxY = 5f;
        minY = -5f;
    }
    private Vector2 m_initPos;
    private Vector2 m_curTouchePoint;
    private Vector3 m_offset;
    private bool isTouching = false;
    // Update is called once per frame

    void FixedUpdate()
    {
        
    }

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            m_firstTouchMousePos = Input.mousePosition;

            Vector3 screenSpace = Camera.main.WorldToScreenPoint(transform.position);//三维物体坐标转屏幕坐标
            Debug.Log("screenSpace z "  + screenSpace);
            m_offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
            //Debug.Log("offset = " + m_offset);
            isTouching = true;
            m_initPos = Input.mousePosition;
            Debug.Log("m_initPos.x" + Input.mousePosition.x);
            m_curTouchePoint = m_initPos;
        }
        if (Input.GetMouseButtonUp(0))
        {

            isTouching = false;
        }

        
            
            // Vector2 centerPos = m_firstTouchMousePos - new Vector2(Screen.width/2, Screen.height/ 2);
            //Debug.Log("pos x = " + centerPos.x + "y = " + centerPos.y);
            //gameObject.transform.DOMove(centerPos, 1, false);
 
#if UNITY_STANDALONE || UNITY_EDITOR
    m_curTouchePoint = Input.mousePosition;
#elif UNITY_ANDROID || UNITY_IOS
        //if (Input.touchCount > 0) {
        //    Touch touch = Input.GetTouch(0);
        //    worldMousePosition = touch.position;
        //}
#endif



        if (isTouching)
        {     //得到现在鼠标的2维坐标系位置

            Vector3 screenSpace = Camera.main.WorldToScreenPoint(transform.position);//三维物体坐标转屏幕坐标
            //Debug.Log("screenSpace z " + screenSpace);
            Vector3 curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
            //将当前鼠标的2维位置转换成3维位置，再加上鼠标的移动量
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + m_offset;
            //curPosition就是物体应该的移动向量赋给transform的position属性
            // transform.position = curPosition

            //m_curTouchePoint = Input.mousePosition;
            //Vector2 byV2 = m_curTouchePoint - m_initPos;
            //Debug.Log("m_initPos x = " + m_initPos.x + "m_initPos y=" + m_initPos.y);
            //Debug.Log("cur pos x = "+ m_curTouchePoint.x+ "cur pos y="+ m_curTouchePoint.y);
            //if (byV2.sqrMagnitude < 4)
            //{

            //    return;
            //}
            //Debug.Log("byV2 x = " + byV2.x + "byV2 y=" + byV2.y);
            //m_initPos = m_curTouchePoint;
            //Vector3 v3 = curPosition - transform.position;

            Vector3 newPos = curPosition;// transform.position - v3;

            if (newPos.x > maxX)
            {
                newPos.x = maxX;
            }
            if (newPos.x < minX)
            {
                newPos.x = minX;
            }
            if (newPos.y > maxY)
            {
                newPos.y = maxY;
            }
            if (newPos.y < minY)
            {
                newPos.y = minY;
            }
         
            transform.position = newPos;
            //transform.DOMove(newPos,0.02f,true);

            m_offset = newPos - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
        }

    }

  
    private float width;
    private float height;

    void SetBasicValues()
    {

        float leftBorder;
        float rightBorder;
        float topBorder;
        float downBorder;
        //the up right corner
        Vector3 cornerPos = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, Mathf.Abs(Camera.main.transform.position.z)));

        leftBorder = Camera.main.transform.position.x - (cornerPos.x - Camera.main.transform.position.x);
        rightBorder = cornerPos.x;
        topBorder = cornerPos.y;
        downBorder = Camera.main.transform.position.y - (cornerPos.y - Camera.main.transform.position.y);

        width = rightBorder - leftBorder;
        height = topBorder - downBorder;
        Debug.Log("width =" + width + "height = " + height);
    }

}
