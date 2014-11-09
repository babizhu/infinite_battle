using UnityEngine;
using System.Collections;

public class Monster1 : AbstractMonster {

    public float speedMin = 1;
    public float speedMax = 2;
    

	// Use this for initialization
	void Start () {
        Hp = 100;
        SetPostion();
	}
	
	// Update is called once per frame
	void Update () {
        float moveAmt = Speed * Time.deltaTime;
        transform.position -= Vector3.right * moveAmt;

        if (transform.position.x < -4.3f)
        {
            SetPostion();
            //Bow.Live--;;

            //if( Bow.Live == 0 ){
            //    Application.LoadLevel("Lose");
            //}

        }
	}
  

    public void SetPostion()
    {

        float y = Random.Range(-2.37f, 1.92f);

        transform.position = new Vector3(5.87f, y, 0);

        Speed = Random.Range(speedMin, speedMax);
        
    }



    public override void die()
    {
       // AudioSource.PlayClipAtPoint(hitTarget, new Vector3());

        Sound.getInstance().play(hit);
        SetPostion();
        Hp = 100;
        
    }
}
