using UnityEngine;
using System.Collections;

public abstract class AbstractMonster : MonoBehaviour
{

    /**
     * 被命中后发出的声音
     */
    public AudioClip hit;
    private float speed;
    public float Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;
        }
    }
    /**
     * 怪物的当前血量
     */
    private int hp;
    public int Hp  // read-write instance property
    {
        get
        {
            return hp;
        }
        set
        {
            hp = value;
        }
    }


    // Use this for initialization
    void Start()
    {

       
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }


    abstract public void die();
}
	
