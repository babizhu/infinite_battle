using UnityEngine;
using System.Collections;

public class ArrowTemplet
{
    private int id;
    private int attack;
    private string name;
    private float speed;
    private string prefab;
    private Vector3 offsetPosition = new Vector3();    
    

    public int Id
    {
        set { id = value; }
        get { return id; }
    }
    public int Attack
    {
        get { return attack; }
        set { attack = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    public string Prefab
    {
        set { prefab = value; }
        get { return prefab; }
    }
   
    public Vector3 OffsetPosition{
        set { offsetPosition = value; }
        get { return offsetPosition; }
    }
    
}
