using UnityEngine;
using System.Collections;

public class WeaponTemplet
{
    private int id;
    private float coolDown;
    private string name;
    private string prefab;
    private Vector3 position = new Vector3();    
    private int needSp;


    public int Id
    {
        set { id = value; }
        get { return id; }
    }
    public float CoolDown
    {
        get { return coolDown; }
        set { coolDown = value; }
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
   
    public Vector3 Position{
        set { position = value; }
        get { return position; }
    }
    
    public int NeedSp
    {
        set { needSp = value; }
        get { return needSp; }
    }
}
