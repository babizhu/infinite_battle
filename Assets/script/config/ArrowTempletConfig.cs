using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;

public class ArrowTempletConfig {
    /**
     * 配置文件名
     */
    private const string fileName = "/arrow.xml";
#if UNITY_EDITOR
    
    string filePath = "file://" + UnityEngine.Application.streamingAssetsPath + fileName;
#elif UNITY_IPHONE
        string filePath = Application.dataPath +"/Raw"+fileName;
#elif UNITY_ANDROID
       //string filePath= "jar:file://" + Application.dataPath + "!/assets" + fileName;
    string filePath = Application.streamingAssetsPath + fileName;
#else
    string filePath = "file://" + UnityEngine.Application.streamingAssetsPath + fileName;
#endif

    private Dictionary<int, ArrowTemplet> data = new Dictionary<int, ArrowTemplet>();
    private static ArrowTempletConfig m_instance = null;

    private ArrowTempletConfig()
    {
        init();
    }
    public static ArrowTempletConfig getInstance()
    {
        if (m_instance == null)
        {
            m_instance = new ArrowTempletConfig();
        }
        return m_instance;
    }

    public void init()
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
        XmlNodeList nodeList = xmlDoc.SelectSingleNode("arrows").ChildNodes;


        //遍历每一个节点，拿节点的属性以及节点的内容
        foreach (XmlNode xe in nodeList)
        {

            ArrowTemplet t = new ArrowTemplet();
            
            //Debug.Log(xe.Name);
            foreach (XmlNode x1 in xe.ChildNodes)
            {
                //Debug.Log(x1.Name);
                if (x1.Name == "name") t.Name = x1.InnerText.Trim();
                else if (x1.Name == "id") t.Id = int.Parse(x1.InnerText);
                
                else if (x1.Name == "attack") t.Attack = int.Parse(x1.InnerText);
                else if (x1.Name == "speed") t.Speed = int.Parse(x1.InnerText);
                else if (x1.Name == "prefab") t.Prefab = x1.InnerText.Trim();
                //else if (x1.Name == "offsetPositionX") position.x = float.Parse(x1.InnerText);
                //else if (x1.Name == "offsetPositionY") position.y = float.Parse(x1.InnerText);               
                
            }
            //t.OffsetPosition = position;
            //Debug.Log(t.ToString());
            data.Add(t.Id, t);
            


        }

    }




    public ArrowTemplet get(int id)
    {
        
        return data[id];
    }
	
}
