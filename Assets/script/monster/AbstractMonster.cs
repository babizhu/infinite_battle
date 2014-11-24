using UnityEngine;
using System.Collections;

public abstract class AbstractMonster : MonoBehaviour
{
    //当前所有的敌人
    public static int count;
    /**
     * 被命中后发出的声音
     */
    public AudioClip hit;
    private float speed;
    private int attackDamage;

    protected GameObject health;
    protected SpriteRenderer healthBar;
    protected Vector3 healthScale;				// The local scale of the health bar initially (with full health).
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
     
    public bool monsterDestroy()
    {
        count -= 1;
        if (count == 0)
        {
            return true;
            
        }
        return false;

       
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


    /**
     * 更新怪物头上的血条，本来可以做成一个由根据血量的多少由绿变红，但是视觉效果不太好，暂放弃
     * //healthBar.material.color = Color.Lerp(Color.green, Color.red, 1 - Hp * 0.01f);
     */
    public void updateHealthBar()
    {
        // Set the health bar's colour to proportion of the way between green and red based on the player's health.
       //healthBar.material.color = Color.Lerp(Color.green, Color.red, 1 - Hp * 0.01f);
        //healthBar.material.color = Color.blue;

        // Set the scale of the health bar to be proportional to the player's health.
        healthBar.transform.localScale = new Vector3(healthScale.x * (float)Hp/maxHp, 1, 1);

    }
}
	
