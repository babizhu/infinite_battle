using UnityEngine;
using System.Collections;

public class BigBombTemplet {

    private int id;
    //private float coolDown;
    private string name;
    private string prefab;
    //private Vector3 position = new Vector3();    
    private int needSp;
    private string arg;


    public int Id
    {
        set { id = value; }
        get { return id; }
    }
    public string Arg
    {
        get { return arg; }
        set { arg = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Prefab
    {
        set { prefab = value; }
        get { return prefab; }
    }
   
    public int NeedSp
    {
        set { needSp = value; }
        get { return needSp; }
    }
}


