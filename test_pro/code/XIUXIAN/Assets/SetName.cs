using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetName : MonoBehaviour
{

    // Use this for initialization
    public Text m_textValue;
    private int m_maxCout;
    private Button[] m_buttons = null;
    private string[] m_values = 
    {
        "风","凯","琪","乐","清","恒",
        "云","牧","德","项","雨","江",
        "月","雪","花","羽","鹏","天",

        "龙","叶","辉","飞","华","凌",
        "双","美","墨","芹","苗","成",
        "艳","雷","星","超","明","恩",

        "梦","泽","西","江","凤","剑",
        "梅","兰","竹","菊","乾","侠",
        "秀","夜","寒","凡","小","义",
        "大","魔","王","菲","秋","敏",

        "海","悦","喜"
    };
	void Start () {
        m_buttons = gameObject.GetComponentsInChildren<Button>();
        InitText();
        m_textValue.text = "";
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void InitText()
    {
        for (int i = 0; i != 63; ++i)
        {
           //m_buttons[i].GetComponentInChildren<Text>().text.
            m_buttons[i].GetComponentInChildren<Text>().text = m_values[i];
           
        }
    }
    public void TaskOnClick(int i)
    {  
        if (m_values[i] != m_buttons[i].GetComponentInChildren<Text>().text)
        {
            Debug.LogError("error");
        }
       
       
        if (m_maxCout >= 6)
        {

        }
        else
        {
            m_textValue.text += m_values[i];
            m_maxCout++;

            Debug.Log(" m_textValue.text.cout = " + m_textValue.text.Length);
        }
    }

    public void Ok()
    {
        if (m_textValue.text.Equals(""))
        {
            return;
        }
        PlayerPrefs.SetString("name", m_textValue.text);
        PlayerPrefs.Save();
        gameObject.SetActive(false);
        GameManager.Ins.m_uiControl.SetMoveEnable(true);
        DataConfig.GetIns().SetNpcActiveState(0,1);
        DataConfig.GetIns().SetNpcActiveState(1, 1);
       
    }

    public void Cancel()
    {
        m_textValue.text = "";
    }
    
}
