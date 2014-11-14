using UnityEngine;
using System.Collections;

public abstract class AbstractMonster : MonoBehaviour
{

    /**
     * 被命中后发出的声音
     */
    public AudioClip hit;
    private float speed;
    private int attackDamage;
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

       
    abstract public void die();

    /**
     * 到达城墙后，开始攻击
     */
    abstract public void attack();
    /**
     * 应用模板数据
     */
    public virtual void applyTemplet(MonsterTemplet templet)
    {
        Speed = templet.Speed;
        Hp = templet.Hp;
        AttackDamage = templet.AttackDamage;
    }

    public bool isDie()
    {
        return hp <= 0;
    }

    public int AttackDamage
    {
        set { attackDamage = value; }
        get { return attackDamage; }
    }
}
	
