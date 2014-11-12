using UnityEngine;
using System.Collections;

public class Monster1 : AbstractMonster {

 

	// Use this for initialization
	void Start () {
 
 //       SetPostion();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float moveAmt = Speed * Time.deltaTime;
        transform.position -= Vector3.right * moveAmt;

        if (transform.position.x < -4.3f)
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
        Sound.getInstance().play(hit);      
        Player.getInstance().addScore(3);
        Destroy(gameObject);
        
    }

    public override void attack()
    {
        // AudioSource.PlayClipAtPoint(hitTarget, new Vector3());

        Sound.getInstance().play(hit);

        Player.getInstance().beAttacked(this);
        Player.getInstance().addScore(3);
        Destroy(gameObject);

    }


}
