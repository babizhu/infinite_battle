using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



public class WaveTemplet
{
    /**
     * 怪物出来的延迟秒数
     */
    private int delaySecond;
    private List<MonsterWithPosition> monsterList = new List<MonsterWithPosition>();


    public int DelaySecond
    {
        get { return delaySecond; }
        set { delaySecond = value; }
    }

    public List<MonsterWithPosition> MonsterList
    {
        set { monsterList = value; }
        get { return monsterList; }
    }
    public override string ToString()
    {
        string result = "[delaySecond=" + delaySecond + ",monsterList=[";
        foreach (MonsterWithPosition mwp in monsterList)
        {
            result += mwp.ToString()+",";
        }
        result += "]";

        result += "]";
        return result;
    }
}

