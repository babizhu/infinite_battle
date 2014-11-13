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

            monster.Hp -= Attack;

            if (monster.isDie())
            {
                monster.die();
                //Bow.Score += 10;
                //Bow.Sp += 1;
                //if (Bow.Score == 300)
                //{
                //    Instantiate(Resources.Load("Monster5"), new Vector3(), Quaternion.identity);
                //    Bow.FindBoss = true;
                //}
                //enemy.die(true);
                //if (Bow.Score % 50 == 0)
                //{
                //    GameObject g = Instantiate(Resources.Load("Monster1"), new Vector3(), Quaternion.identity) as GameObject;
                //    Debug.Log("g.GetType() is " + g.GetType());
                //    Monster1 m = g.GetComponent<Monster1>();
                //    //m.hp = 100;
                //}
            }
            //print("enemy hp is " + monster.Hp);
        }
    }

}
