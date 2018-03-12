using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    public BagLayer m_bagLayer;
    public Text m_textHp;
    public Text m_textGold;
    public Text m_name;
    public SetName m_setNameLayer;

    public GameObject m_controlObj;

    public Text m_textDes;
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}


    public void ShowBag()
    {
        bool visible = m_bagLayer.gameObject.activeSelf;
        Debug.Log("visible = " + visible);
        m_bagLayer.gameObject.SetActive(!visible);
    }

    public void Attack()
    {
        Player.GetPlayerInstance().Attack();
    }

    public void UpdateHp(float hp)
    {
        m_textHp.text = "" + hp;
    }

    public void UpdateGold(float gold)
    {
        m_textGold.text = "" + gold;
    }

    public void ShowSetName()
    {
        SetMoveEnable(false);

        m_setNameLayer.gameObject.SetActive(true);

        
    }

    public void SetMoveEnable(bool enale)
    {
        m_controlObj.SetActive(enale);
    }

    public void ShowPickUpEvent(int itemId,int count)
    {
        string des = DataConfig.GetIns().GetDesByKey("YOUGET");
       
        itemId = 2;
        if (itemId == 0)
        {
            m_textDes.text = des;
        }
        else if (itemId == 1)
        {
            m_textDes.text = des;
        }
        else if(itemId == 2)
        {
            string des1 = DataConfig.GetIns().GetDesByKey("GETGOLD");
            des1 =  string.Format(des1, 50);
            m_textDes.text = des1;
        }
    }

    
}
