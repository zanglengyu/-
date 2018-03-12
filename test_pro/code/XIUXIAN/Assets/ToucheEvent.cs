using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
 
 
using UnityEngine.Events;
using UnityEngine.EventSystems;
 
using UnityEngine.UI;
using DG.Tweening;
 
public class ToucheEvent : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    // Use this for initialization

    public int m_dirValue;
    public void Start()
    {
       
    }

    public void Update()
    {
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("鼠标按下");
        Player.GetPlayerInstance().SetTouchDir(m_dirValue,true);
        Image im = gameObject.GetComponent<Image>();
        im.color = new Color(0.0f, 0.0f, 0.0f, 0.5f);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Player.GetPlayerInstance().SetTouchDir(m_dirValue, false);
        Debug.Log("鼠标抬起");
        Image im = gameObject.GetComponent<Image>();
        im.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }
}