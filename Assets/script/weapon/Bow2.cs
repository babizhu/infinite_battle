using UnityEngine;
using System.Collections;

public class Bow2 : AbstractWeapon
{


    public GameObject arrow;

    void Awake()
    {        
        CurrentCoolDown = 0;
        CoolDown = 0.2f;
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            fire();
        }

    }

    private void doMagicAttack()
    {
        //Instantiate(arrow, transform.position, transform.rotation);
        //AudioSource.PlayClipAtPoint(hit, new Vector3());
    }



    protected override void doNormalAttack()
    {
        Instantiate(arrow, transform.position, transform.rotation);
    }
}
