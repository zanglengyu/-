using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BagLayer : MonoBehaviour {

    // Use this for initialization
    public int [] m_itemId = new int[6];
    public int [] m_itemCount = new int[6];
    public Text[] m_countTexts = new Text[6];
    public Image[] m_itemImages = new Image[6];

    public Sprite[] m_allItems;
    void Start ()
    {
        UpdateBag();

    }
	
	// Update is called once per frame
	void Update ()
    {


    }

    public void ShowItemDes(int itemPosIndex)
    {
        //
        int itemId = m_itemId[itemPosIndex];
        if (itemId < 0)
        {
            Debug.Log("cur null item");
        }
    }

    public bool PickUp(int id)
    {
        bool pickItem = false;
        for (int i = 0; i != 6; ++i)
        {
            if (m_itemId[i] == id)
            {
                m_itemCount[i]++;
                pickItem = true;
            }
            else if (m_itemId[i] == -1)
            {
                m_itemCount[i] = 1;
                m_itemId[i] = id;
                pickItem = true;
                break;
            }
        }
        UpdateBag();
        return pickItem;
    }

    public void UpdateBag()
    {
        for (int i = 0; i != m_itemId.Length; ++i)
        {
            if (m_itemId[i] != -1)
            {
                int id = m_itemId[i]; ;
                m_itemImages[i].sprite = m_allItems[id];
                m_countTexts[i].text = "" + m_itemCount[i];
                m_itemImages[i].gameObject.SetActive(true);
                m_countTexts[i].gameObject.SetActive(true);
            }
            else
            {
                m_itemImages[i].sprite = null;
                m_itemImages[i].gameObject.SetActive(false);
                m_countTexts[i].gameObject.SetActive(false);
            }
        }

    }
}
