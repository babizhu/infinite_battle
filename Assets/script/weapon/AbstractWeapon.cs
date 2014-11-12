using UnityEngine;
using System.Collections;

/**
 * 所有武器的基类
 */
public abstract class AbstractWeapon : MonoBehaviour {

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
     * 冷却时间，类似常量
     */
    private float coolDown;
    public float CoolDown
    {
        get { return coolDown; }
        set { coolDown = value; }
    }

	    
    /**
     * 开火
     */
    protected void fire()
    {

        Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (target.x < -4)
        {
            return;
        }

        Vector3 a2bDirection = target - transform.position;//获得一条从弓箭向量尾指向鼠标的向量。

        float angle = Mathf.Rad2Deg * Mathf.Atan(a2bDirection.y / a2bDirection.x);

        transform.eulerAngles = new Vector3(0, 0, angle);
        if (currentCoolDown > 0)
        {
            currentCoolDown -= Time.deltaTime;
            return;
        }

        if (currentCoolDown <= 0)
        {
            doNormalAttack();
            currentCoolDown = coolDown;
        }
    }

    protected abstract void doNormalAttack();

    
}
