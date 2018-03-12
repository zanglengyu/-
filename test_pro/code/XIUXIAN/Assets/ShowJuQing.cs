using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowJuQing : MonoBehaviour {

    // Use this for initialization
    public Image m_headNpc;
    public Image m_headPlayer;
    public Text m_juqing;
    private int m_index = 0;
    private List<string> m_curJuqingList = null;
    public int m_curNpcId;
    void Start ()
    {
        m_curNpcId = 0;


    }
	
	// Update is called once per frame
	void Update () {
		
	}

   
  
    public void ShowJuqingById(int id)
    {
        m_curNpcId = id;
        gameObject.SetActive(true);
        m_index = 0;
        m_curJuqingList = null;
        List<string> juList = DataConfig.GetIns().GetJqList(id);
        if(juList != null)
        {
            m_curJuqingList = juList;
            string s = m_curJuqingList[m_index];
            m_juqing.text = s;
        }
    }

    public void NextDes()
    {
        m_index++;
        if (m_index >= m_curJuqingList.Count)
        {
            JuqingEnd();
        }
        else
        {
            string s = m_curJuqingList[m_index];
            m_juqing.text = s;
        }
    }

    public void JuqingEnd()
    {
        gameObject.SetActive(false);
        string name = PlayerPrefs.GetString("name", "");
        int state = DataConfig.GetIns().GetNpcActiveState(5);
        Debug.Log("name = " + name + "state = " + state);
        if (m_curNpcId == 5 && name.Equals("") && state == 1)
        {
            GameManager.Ins.m_uiControl.ShowSetName();
        }
        else if (m_curNpcId == 2)
        {
            DataConfig.GetIns().SetNpcActiveState(5, 1);

        }
        else if (m_curNpcId == 1)
        {
            int state1 = DataConfig.GetIns().GetNpcActiveState(1);
            if (state1 == 1)
            {
                DataConfig.GetIns().SetNpcActiveState(2, 1);
            }
        }
        else if (m_curNpcId == 0)
        {
            int state1 = DataConfig.GetIns().GetNpcActiveState(0);
            if (state1 == 1)
            {
                //显示一把剑
                EventConfg.Ins.ShowEventObj("baojian");
            }
        }
    }
}
