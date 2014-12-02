using UnityEngine;
using System.Collections;

/**
 * 冰封所有的怪
 */
public class IceBigBomb : AbstractBigBomb {

    //public GameObject animator;
    /**
     * 冰冻时间
     */
    private static float iceSecond = 2f;
    private float[] speed;
    private Collider2D[] collidedObj;

    private Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        fire();
	}

    private void fire()
    {
        //GameObject animationObj =  as GameObject;
        //Destroy(Instantiate(animator), 0.6f);
        anim.Play("iceBigBomb");
        collidedObj = Physics2D.OverlapAreaAll( pointA,pointB);
        speed = new float[collidedObj.Length];
        //print(collidedObj.Length);
        int i = 0;
        foreach (Collider2D collider in collidedObj)
        {
            if (collider.CompareTag("monster"))
            {
                AbstractMonster monster = collider.GetComponent<AbstractMonster>();
                speed[i++] = monster.Speed;
                //print("monster.Speed=" + monster.Speed);
                monster.Speed = 0;
            }
        }

        
        //yield return new WaitForSeconds(iceSecond);

        //i = 0;
        //抖动屏幕
        CameraShake shake = Camera.main.camera.GetComponent<CameraShake>();
        shake.shake();

        //恢复怪物的原始速度
       
        Invoke("resetEffect", iceSecond);
    }

    void resetEffect()
    {
        int i = 0;
        foreach (Collider2D collider in collidedObj)
        {
            if (collider != null && collider.CompareTag("monster"))
            {
                AbstractMonster monster = collider.GetComponent<AbstractMonster>();
                //= monster.Speed;
                monster.Speed = speed[i++];

            }
        }
        Destroy(gameObject);

    }
	

}
