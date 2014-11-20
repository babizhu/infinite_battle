using UnityEngine;
using System.Collections;

/**
 * 冰封所有的怪
 */
public class IceBigBomb : AbstractBigBomb {

    /**
     * 冰冻时间
     */
    private static float iceSecond = 2f;
	// Use this for initialization
	void Start () {

        StartCoroutine(fire());
	}

    private IEnumerator fire()
    {
        Collider2D[] collidedObj = Physics2D.OverlapAreaAll( pointA,pointB);
        float[] speed = new float[collidedObj.Length];
        //print(collidedObj.Length);
        int i = 0;
        foreach (Collider2D collider in collidedObj)
        {
            if (collider.CompareTag("monster"))
            {
                AbstractMonster monster = collider.GetComponent<AbstractMonster>();
                speed[i++] = monster.Speed;
                print("monster.Speed=" + monster.Speed);
                monster.Speed = 0;
            }
        }

        
        yield return new WaitForSeconds(iceSecond);

        i = 0;
        
        //恢复怪物的原始速度
        foreach (Collider2D collider in collidedObj)
        {
            if (collider != null && collider.CompareTag("monster"))
            {
                AbstractMonster monster = collider.GetComponent<AbstractMonster>();
                //= monster.Speed;
                monster.Speed =  speed[i++];
                
            }
        }
        Destroy(gameObject);

    }
	

}
