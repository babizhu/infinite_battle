using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class MonsterWithPosition
{
    private MonsterTemplet monsterTemplet;
    private int row;
    private float xOffset;

    public MonsterTemplet MonsterTemplet
    {
        set { monsterTemplet = value; }
        get { return monsterTemplet; }
    }
    public int Row
    {
        set { row = value; }
        get { return row; }
    }

    public override string ToString()
    {
        string result = "MonsterTemplet=" + MonsterTemplet.Id + ",row=" + row + ",xOffset=" + XOffset;
        return result;
    }

    public float XOffset {
        set { xOffset = value; }
        get { return xOffset; }
    }
}
