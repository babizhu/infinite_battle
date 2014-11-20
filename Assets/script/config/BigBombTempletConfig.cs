using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;

public class BigBombTempletConfig {
    /**
     * 配置文件名
     */
    private const string fileName = "/bigBomb.xml";
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

    private Dictionary<int, BigBombTemplet> data = new Dictionary<int, BigBombTemplet>();
    private static BigBombTempletConfig m_instance = null;

    private BigBombTempletConfig()
    {
        init();
    }
    public static BigBombTempletConfig getInstance()
    {
        if (m_instance == null)
        {
            m_instance = new BigBombTempletConfig();
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
        XmlNodeList nodeList = xmlDoc.SelectSingleNode("weapons").ChildNodes;


        //遍历每一个节点，拿节点的属性以及节点的内容
        foreach (XmlNode xe in nodeList)
        {

            BigBombTemplet t = new BigBombTemplet();
            
            //Debug.Log(xe.Name);
            foreach (XmlNode x1 in xe.ChildNodes)
            {
                //Debug.Log(x1.Name);
                if (x1.Name == "name") t.Name = x1.InnerText.Trim();
                else if (x1.Name == "id") t.Id = int.Parse(x1.InnerText);               
                else if (x1.Name == "prefab") t.Prefab = x1.InnerText.Trim();
                else if (x1.Name == "arg") t.Arg = x1.InnerText;
                
                else if (x1.Name == "needSp") t.NeedSp = int.Parse(x1.InnerText);
            
                
            }
            
            //Debug.Log(t.ToString());
            data.Add(t.Id, t);
            


        }

    }




    public BigBombTemplet get(int id)
    {
        
        return data[id];
    }
	
}
