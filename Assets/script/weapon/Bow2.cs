using UnityEngine;
using System.Collections;

public class Bow2 : AbstractWeapon
{
    //private Player player = Player.getInstance();
    // Update is called once per frame
    
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            fire();
        }

    }

    protected override void doNormalAttack()
    {
        
        GameObject arrowObj = Instantiate(Arrow, transform.position, transform.rotation) as GameObject;
        AbstractArrow arrow = arrowObj.GetComponent<AbstractArrow>();
        arrow.applyTemplet(ArrowTemplet);
        //Instantiate(Arrow, transform.position, transform.rotation);
    }
}
