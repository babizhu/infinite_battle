using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;

public class MissionTempletConfig {
    /**
     * 配置文件名
     */
    private const string fileName = "/mission.xml";
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

    private Dictionary<int, MissionTemplet> data = new Dictionary<int, MissionTemplet>();
    private static MissionTempletConfig m_instance = null;

    private MissionTempletConfig()
    {
        init();
    }
    public static MissionTempletConfig getInstance()
    {
        if (m_instance == null)
        {
            m_instance = new MissionTempletConfig();
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
        XmlNodeList nodeList = xmlDoc.SelectSingleNode("missions").ChildNodes;


        //遍历每一个节点，拿节点的属性以及节点的内容
        foreach (XmlElement xe in nodeList)
        {
            MissionTemplet t = new MissionTemplet();
            //Debug.Log(xe.Name);
            foreach (XmlNode x1 in xe.ChildNodes)
            {
                //Debug.Log(x1.Name);
                if (x1.Name == "name") t.Name = x1.InnerText;
                else if (x1.Name == "id") t.Id = int.Parse(x1.InnerText);
                else if (x1.Name == "wave") t.Waves.Add(parseWave(x1));
            }
            //Debug.Log(t.ToString());
            data.Add(t.Id, t);
            


        }

    }

    private WaveTemplet parseWave(XmlNode x1)
    {
        
        WaveTemplet waveTemplet = new WaveTemplet();
        //Debug.Log("x1.ChildNodes="+x1.ChildNodes.Count);
        foreach (XmlNode x in x1.ChildNodes)
        {
            //Debug.Log(x.Name);
            if (x.Name == "delaySecond") waveTemplet.DelaySecond = int.Parse(x.InnerText);
            else if (x.Name == "monster")
            {
                string[] arr = x.InnerText.Split(',');
                int monsterId = int.Parse(arr[0]);
                int position = int.Parse(arr[1]);
                float xOffset = float.Parse(arr[2]);
                MonsterWithPosition mwp = new MonsterWithPosition();
                mwp.MonsterTemplet = MonsterTempletConfig.getInstance().get(monsterId);
                mwp.Row = position;
                mwp.XOffset = xOffset;
                waveTemplet.MonsterList.Add(mwp);
                
            }
        }
        
        return waveTemplet;
    }



    public MissionTemplet get(int id)
    {
        
        return data[id];
    }

}
