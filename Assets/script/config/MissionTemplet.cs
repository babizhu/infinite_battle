using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class MissionTemplet {
    private int id;    
    private string name;
    private List<WaveTemplet> waves = new List<WaveTemplet>();



    public int Id
    {
        set { id = value; }
        get { return id; }
    }

    public string Name
    {
        set { name = value; }
        get { return name; }
    }

    public List<WaveTemplet> Waves{
        get{return waves;}
    }

    public override string ToString()
    {
        string result = "[id=" + id +",name="+name+",waves[";
        foreach (WaveTemplet templet in waves)
        {
            result += templet.ToString()+",";
        }
        
        result += "]";

        result += "]";
        return result;
    }
}
	

