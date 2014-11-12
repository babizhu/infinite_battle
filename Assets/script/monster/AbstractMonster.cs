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

    /**
     * 到达城墙后，开始攻击
     */
    abstract public void attack();
    /**
     * 应用模板数据
     */
    public void applyTemplet(MonsterTemplet templet)
    {
        Speed = templet.Speed;
        Hp = templet.Hp;
    }

    public bool isDie()
    {
        return hp <= 0;
    }
}
	
