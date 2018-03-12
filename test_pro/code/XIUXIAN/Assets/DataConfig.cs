using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

using System.IO;


public class DataConfig
{
    struct Juqing
    {
        public int id;
        public List<string> defaultJuqing;
        public List<string> activeJuqing;
        public string name;
    }
    struct LanguageConfig
    {
        
        public string chineseDes;
        public string englishDes;
    };
    private static DataConfig Ins = null;
    private Dictionary<int, Juqing> m_juqingConfig = new Dictionary<int, Juqing>();

    private Dictionary<int, string> m_itemConfigData = new Dictionary<int, string>();

    private Dictionary<string, LanguageConfig> m_languageConfig = new Dictionary<string, LanguageConfig>();

    public static DataConfig GetIns()
    {
        if (Ins == null)
        {
            Ins = new DataConfig();

            Ins.InitItemData(Ins.ResourceLoadXML("ItemData"));

            Ins.InitJuqing(Ins.ResourceLoadXML("Juqing"));
            Ins.InitLanguage(Ins.ResourceLoadXML("LanguageChinese"));
        }
        return Ins;
    }


    void InitJuqing(XmlNodeList xmlNodeList)
    {
        foreach (XmlElement xl1 in xmlNodeList)
        {
            Juqing jq = new Juqing();

            string id = ((XmlElement)xl1.ChildNodes[0]).GetAttribute("value");
            string name = ((XmlElement)xl1.ChildNodes[1]).GetAttribute("value");
            int idInt = int.Parse(id);
            jq.id = int.Parse(id);
            jq.name = name;
            jq.defaultJuqing = new List<string>();
            Debug.Log("InitJuqing count = " + xl1.ChildNodes[2].ChildNodes.Count);
            foreach (XmlElement xl2 in xl1.ChildNodes[2].ChildNodes)
            {

                string str = xl2.GetAttribute("value");
                jq.defaultJuqing.Add(str);
                Debug.Log("str = " + str);

            }

            jq.activeJuqing = new List<string>();
            foreach (XmlElement xl2 in xl1.ChildNodes[3].ChildNodes)
            {

                string str = xl2.GetAttribute("value");
                jq.activeJuqing.Add(str);
                Debug.Log("str = " + str);

            }

            m_juqingConfig.Add(idInt, jq);
        }

    }



    public void InitItemData(XmlNodeList xmlNodeList)
    {
        //遍历所有子节点
        foreach (XmlElement xl1 in xmlNodeList)
        {
            string id = ((XmlElement)xl1.ChildNodes[0]).GetAttribute("value");
            string v = ((XmlElement)xl1.ChildNodes[1]).GetAttribute("value");
            int idInt = int.Parse(id);

            Debug.Log("id = " + id + "item value = " + v);
            m_itemConfigData.Add(idInt, v);
        }
    }

    public void InitLanguage(XmlNodeList xmlNodeList)
    { 
        //遍历所有子节点
        foreach (XmlElement xl1 in xmlNodeList)
        {
            string key = ((XmlElement)xl1.ChildNodes[0]).Name;

            string valueChinese = ((XmlElement)xl1.ChildNodes[0]).GetAttribute("value");
            string valueEnglish = ((XmlElement)xl1.ChildNodes[1]).GetAttribute("value");
            LanguageConfig lc = new LanguageConfig();
            lc.chineseDes = valueChinese;
            lc.englishDes = valueEnglish;
            Debug.Log("key = " + key + "cd = " + lc.chineseDes);
            m_languageConfig.Add(key,lc);
        }

    }

    public List<string> GetJqList(int key)
    {
        if (m_juqingConfig.ContainsKey(key))
        {
            if (GetNpcActiveState(key) == 1)
            {
                return m_juqingConfig[key].activeJuqing;
            }
            else
            {
                return m_juqingConfig[key].defaultJuqing;
            }
        }
        else
        {
            return null;
        }
    }

    public XmlNodeList ResourceLoadXML(string filename)
    {
        Debug.Log("ResourceLoadXML");
        string data = Resources.Load(filename).ToString();
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(data);

        XmlNodeList rootNode = doc.SelectSingleNode("config").ChildNodes;

        return rootNode;
    }

    public int GetNpcActiveState(int npcId)
    {
  
       int savestate =  PlayerPrefs.GetInt("npcState"+ npcId,0);
        return savestate;
    }

    public void SetNpcActiveState(int npcId,int s)
    {
        PlayerPrefs.SetInt("npcState" + npcId, s);
        PlayerPrefs.Save();
    }

    public string GetDesByKey(string key)
    {
        string curLanguage = "chinese";
        if(m_languageConfig.ContainsKey(key))
        {
            if (curLanguage.Equals(curLanguage))
            {
                return m_languageConfig[key].chineseDes;
            }
            else
            {
                return m_languageConfig[key].englishDes;
            }
        }
        return "Default";
    }


}
