using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class MonsterWithPosition
{
    private MonsterTemplet monsterTemplet;
    private int position;

    public MonsterTemplet MonsterTemplet
    {
        set { monsterTemplet = value; }
        get { return monsterTemplet; }
    }
    public int Position
    {
        set { position = value; }
        get { return position; }
    }

    public override string ToString()
    {
        string result = "MonsterTemplet=" + MonsterTemplet.Id + ",position=" + position;
        return result;
    }
}
