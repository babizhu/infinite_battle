using UnityEngine;
using System.Collections;

public abstract class AbstractMonster : MonoBehaviour
{
    //当前所有的敌人
    public static int MONSTER_COUNT;
    /**
     * 被命中后发出的声音
     */
    public AudioClip hit;
    private float speed;
    private int attackDamage;
    protected HealthBar healthBar;

   		// The local scale of the health bar initially (with full health).

    protected Scene scene;
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

    private int maxHp;
    public int MaxHp
    {
        get { return maxHp; }
        set { maxHp = value; }
    }

    /**
     * 一个怪兽消失了，不管是被打死，还是成功进入了墙壁
     *
     * 如果本关卡内所有的怪物都死完了，则返回真（true）
     */
     
    public void monsterDestroy()
    {
        MONSTER_COUNT -= 1;
        
       
    }

       
    /**
     * 怪兽死亡
     */
    abstract public void die();

    /**
     * 到达城墙后，开始攻击
     * 
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
        maxHp = hp;
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


    /**
     * 被攻击的时候调用的函数
     */
    public abstract void defend(AbstractArrow arrow1);


    
}
	
