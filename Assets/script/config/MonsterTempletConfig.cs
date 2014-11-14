using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;

public class MonsterTempletConfig
{
    /**
     * 配置文件名
     */
    private const string fileName = "/monster.xml";
#if UNITY_EDITOR
    //string filePath = Application.dataPath + "/StreamingAssets" + fileName;
    string filePath = "file://" + UnityEngine.Application.streamingAssetsPath + fileName;
#elif UNITY_IPHONE
        string filePath = Application.dataPath +"/Raw"+fileName;
#elif UNITY_ANDROID
       //string filePath= "jar:file://" + Application.dataPath + "!/assets" + fileName;
    string filePath = Application.streamingAssetsPath + fileName;
#else
string filePath = "file://" + UnityEngine.Application.streamingAssetsPath + fileName;
#endif

    private Dictionary<int, MonsterTemplet> data = new Dictionary<int, MonsterTemplet>();
    private static MonsterTempletConfig m_instance = null;

    private MonsterTempletConfig()
    {
        init();
    }
    public static MonsterTempletConfig getInstance()
    {
        if (m_instance == null)
        {
            m_instance = new MonsterTempletConfig();
        }
        return m_instance;
    }

    private void init()
    {
        WWW www = new WWW(filePath);
        while (!www.isDone) { }
        //yield return www;
        //all = www.text;
        //Debug.Log("xml文件的内容为:" + www.text);
        parseXml(www);


    }
    private void parseXml(WWW file)
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(file.text);
        XmlNodeList nodeList = xmlDoc.SelectSingleNode("monsters").ChildNodes;


        //遍历每一个节点，拿节点的属性以及节点的内容
        foreach (XmlElement xe in nodeList)
        {
            MonsterTemplet t = new MonsterTemplet();

            foreach (XmlElement x1 in xe.ChildNodes)
            {
                if (x1.Name == "name") t.Name = x1.InnerText.Trim();
                else if (x1.Name == "hp") t.Hp = int.Parse(x1.InnerText);
                else if (x1.Name == "id") t.Id = int.Parse(x1.InnerText);
                else if (x1.Name == "attackDamage") t.AttackDamage = int.Parse(x1.InnerText);
                else if (x1.Name == "speed") t.Speed = float.Parse(x1.InnerText);
                else if (x1.Name == "prefab") t.Prefab = x1.InnerText.Trim(); ;
            }
            data.Add(t.Id, t);

        }

    }

    public MonsterTemplet get(int id)
    {
        return data[id];
    }


}