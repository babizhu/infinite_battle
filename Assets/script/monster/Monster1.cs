using UnityEngine;
using System.Collections;

public class Monster1 : AbstractMonster {


    private Player player;
    private Material material;
    
    
	void Start () {
        material = gameObject.renderer.material;
        player = GameObject.Find("player").GetComponent<Player>();
        healthBar = GetComponentInChildren<HealthBar>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float moveAmt = Speed * Time.deltaTime;
        transform.position -= Vector3.right * moveAmt;

        if (transform.position.x < -3.7f)
        {
            attack();
            //Bow.Live--;;

            //if( Bow.Live == 0 ){
            //    Application.LoadLevel("Lose");
            //}

        }
	}

    //public void SetPostion()
    //{

    //    float y = Random.Range(-2.37f, 1.92f);

    //    transform.position = new Vector3(5.87f, y, 0);

    //    //Speed = Random.Range(speedMin, speedMax);

    //}



    public override void die()
    {
        
        Destroy(gameObject);
        Sound.getInstance().play(hit);
        player.addScore(3);
        monsterDestroy();
    }

    

    public override void attack()
    {
        // AudioSource.PlayClipAtPoint(hitTarget, new Vector3());
        
        Sound.getInstance().play(hit);

        player.defend(this);
        //Player.getInstance().addScore(3);
        Destroy(gameObject);
        monsterDestroy();
    }

    public override void defend(AbstractArrow arrow)
    {
        //print("Hp=" + Hp + " arrow.Attack=" + arrow.Attack);
        Hp -= arrow.Attack;
        //print("Hp="+ Hp);
        if (isDie())
        {
            die();
            
        }
        else
        {
            StartCoroutine(blink());
        }
        //print("enemy hp is " + monster.Hp);
    }


    /**
     * 受到攻击往后退一下，在一次射出三根黄金箭的 情况下，碰撞检测有些地方好像会失效
     */
    private IEnumerator blink()
    {

        //setHeathEnabled(true);
        //print(material.color);
        //float tempSpeed = Speed;
        material.color = Color.red;
        //Speed = 0;
        //Animator ani = GetComponent<Animator>();
        //ani.speed = 0;
        //Vector3 pos = transform.localPosition;
        //pos.x += 0.1f;
        //transform.localPosition = pos;
        yield return new WaitForSeconds(0.04f);
        //pos = transform.localPosition;
        //pos.x -= 0.1f;
        //transform.localPosition = pos;
        healthBar.updateHealthBar( (float)Hp/MaxHp);
        //ani.speed = 1;
        //gameObject.animation.Stop();
        //foreach (AnimationState anim in gameObject.animation)
        //{
        //    if (gameObject.animation.IsPlaying(anim.name))
        //    {
        //        print(anim.name);
        //    }
        //}
        
        material.color = Color.white;
        //Speed = tempSpeed;
        //yield return new WaitForSeconds(0.15f);
        //setHeathEnabled(false);
    }

    
}
