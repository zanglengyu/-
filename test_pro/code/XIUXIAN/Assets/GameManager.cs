using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{

    public static GameManager Ins = null;
    // Use this for initialization
    public UIControl m_uiControl;

    void Awake()
    {
        Ins = this;
        DataConfig.GetIns();
    }

    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public ShowJuQing m_juqingWindow;


}
