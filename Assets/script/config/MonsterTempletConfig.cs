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
    string filepath = Application.dataPath + "/StreamingAssets" + fileName;
#elif UNITY_IPHONE
        string filepath = Application.dataPath +"/Raw"+fileName;
#elif UNITY_ANDROID
       string filepath= "jar:file://" + Application.dataPath + "!/assets" + fileName;

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
        if (File.Exists(filepath))
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filepath);
            XmlNodeList nodeList = xmlDoc.SelectSingleNode("monsters").ChildNodes;
            //遍历每一个节点，拿节点的属性以及节点的内容
            foreach (XmlElement xe in nodeList)
            {
                MonsterTemplet t = new MonsterTemplet();
                
                foreach (XmlElement x1 in xe.ChildNodes)
                {
                    if (x1.Name == "name") t.Name = x1.InnerText;
                    else if (x1.Name == "hp") t.Hp = int.Parse(x1.InnerText);
                    else if (x1.Name == "id") t.Id = int.Parse(x1.InnerText);
                }
                data.Add(t.Id, t);
                
            }
            
        }

    }


    public MonsterTemplet get(int id)
    {
        return data[id];
    }


}
