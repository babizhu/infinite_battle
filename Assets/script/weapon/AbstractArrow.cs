using UnityEngine;
using System.Collections;

public abstract class AbstractArrow : MonoBehaviour {

    public AudioClip fire;

    private float speed;
    private int attack;

    private Vector3 target = new Vector3();
    private float angle;
    //炮弹的出生地点，考虑到有些武器的炮管比较长
    private Vector3 offsetPosition = new Vector3();

    public float Speed{
        get{return speed;}
        set{ speed=value;}
    }

    public int Attack{
        set{attack=value;}
        get{return attack;}
    }

    protected void init()
    {
        angle = (transform.eulerAngles.z) * Mathf.Deg2Rad;
        float x = Mathf.Cos(angle);
        float y = Mathf.Sin(angle);
        target.x = 100 *x;
        target.y = 100* y;
        print("offsetPosition.x=" + offsetPosition.x);
        Sound.getInstance().play(fire);
    }

    protected void fly()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);

        if (transform.position.x > 6)
        {
            Destroy(gameObject);
        }
    }

    protected abstract void doAttack(Collider2D coll);
    public virtual void applyTemplet(ArrowTemplet templet)
    {
        speed = templet.Speed;
        attack = templet.Attack;
        offsetPosition = templet.OffsetPosition;
    }  
}
