using UnityEngine;
using System.Collections;

public class Monster1 : AbstractMonster {


    private Player player;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("player").GetComponent<Player>();
 
 //       SetPostion();
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
        
        
    }

    public override void attack()
    {
        // AudioSource.PlayClipAtPoint(hitTarget, new Vector3());

        Sound.getInstance().play(hit);

        player.defend(this);
        //Player.getInstance().addScore(3);
        Destroy(gameObject);

    }


}
