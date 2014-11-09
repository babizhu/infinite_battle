using UnityEngine;
using System.Collections;

public class Arrow1 : MonoBehaviour
{
    public AudioClip fire;
    public float speed = 20;

    private Vector3 target;
    float angle;

    public int attackDamage = 1;

    public static int miss = 0;

    void Awake()
    {
        
    }
    // Use this for initialization
    void Start()
    {
        angle = (transform.eulerAngles.z) * Mathf.Deg2Rad;
        float x = 100 * Mathf.Cos(angle);
        float y = 100 * Mathf.Sin(angle);
        target = new Vector3(x, y, 0);
        Sound.getInstance().play( fire );
    }


    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);

        if (transform.position.x > 20)
        {
            Destroy(gameObject);
        }

        //localPos.y = transformY - (height * sprite.ClipRect.y);
        //sprite.transform.localPosition = localPos;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {

        
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        print(coll.name);
        if (coll.tag == "monster")
        {

            Destroy(gameObject);
            //other.gameObject.GetComponent<IMonster>;
            
            AbstractMonster monster = coll.GetComponent<AbstractMonster>();

            monster.Hp -= attackDamage;
            if (monster.Hp <= 0)
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
