using UnityEngine;
using System.Collections;

public class MagicBomb : AbstractArrow
{
    public GameObject BombExplosion;
    void Awake()
    {
        init();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        fly();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {


    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        doAttack(coll);

    }
    protected override void doAttack(Collider2D coll)
    {
        if (coll.CompareTag("monster"))
        {

            Destroy(gameObject);
            GameObject explosion = Instantiate(BombExplosion, transform.localPosition, Quaternion.identity) as GameObject;
            Destroy(explosion, 0.6f);
            Collider2D[] collidedObj = Physics2D.OverlapCircleAll(transform.position, 1);
            
            //print(collidedObj.Length);
            foreach (Collider2D collider in collidedObj)
            {
                if (collider.CompareTag("monster"))
                {
                    AbstractMonster monster = collider.GetComponent<AbstractMonster>();
                    monster.defend(this);
                }
            }
          
        }
    }

}
