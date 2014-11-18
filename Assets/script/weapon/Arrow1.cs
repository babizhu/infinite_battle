using UnityEngine;
using System.Collections;

public class Arrow1 : AbstractArrow
{
   
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
        if (coll.tag == "monster")
        {

            Destroy(gameObject);
            //other.gameObject.GetComponent<IMonster>;

            AbstractMonster monster = coll.GetComponent<AbstractMonster>();
            monster.defend(this);
            
        }
    }

}
