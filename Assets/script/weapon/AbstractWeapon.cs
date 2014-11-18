using UnityEngine;
using System.Collections;

/**
 * 所有武器的基类
 */
public abstract class AbstractWeapon : MonoBehaviour {

    private GameObject arrow;
    protected Player player;

    public GameObject Arrow
    {
        set { arrow = value; }
        get { return arrow; }
    }
    private ArrowTemplet arrowTemplet;
    public ArrowTemplet ArrowTemplet
    {
        set { arrowTemplet = value; }
        get { return arrowTemplet; }
    }

    /**
     * 当前冷却时间
     */
    private float currentCoolDown;
    public float CurrentCoolDown
    {
        get { return currentCoolDown; }
        set { currentCoolDown = value; }
    }

    /**
     * 冷却时间
     */
    private float coolDown;
    public float CoolDown
    {
        get { return coolDown; }
        set { coolDown = value; }
    }


    private int needSp;
    public int NeedSp
    {
        set { needSp = value; }
        get { return needSp; }
    }

    /**
     * 开火
     */
    protected void fire()
    {

        Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       
        Vector3 a2bDirection = target - transform.position;//获得一条从弓箭向量尾指向鼠标的向量。

        float angle = Mathf.Rad2Deg * Mathf.Atan(a2bDirection.y / a2bDirection.x);

        transform.eulerAngles = new Vector3(0, 0, angle);
       
        if (currentCoolDown > 0)
        {
            currentCoolDown -= Time.deltaTime;
            return;
        }

        if (player.CurrentSp < needSp)
        {
            return;
        }


        doNormalAttack();
        currentCoolDown = coolDown;
        player.changeCurrentSp(-needSp);
        
    }

    protected abstract void doNormalAttack();

    public virtual void applyTemplet(WeaponTemplet templet)
    {
        coolDown = templet.CoolDown;
        needSp = templet.NeedSp;
        //print("coolDown=" + coolDown);
    }  
}
