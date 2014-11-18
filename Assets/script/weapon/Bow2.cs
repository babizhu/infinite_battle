using UnityEngine;
using System.Collections;

public class Bow2 : AbstractWeapon
{
    //private Player player = Player.getInstance();
    // Update is called once per frame

    public Transform arrowPositionObject;
    protected Vector3 arrowPosition;

    void Start(){
        player = GameObject.Find("player").GetComponent<Player>();
    }
    void FixedUpdate()
    {
        if (Input.GetButton("Fire1")/** && !ClickScreen.catchClickEvent**/ )
        {
           // print("FixedUpdate");
            fire();
        }

    }

    protected override void doNormalAttack()
    {
        
        if (arrowPositionObject != null)
        {
            arrowPosition = arrowPositionObject.parent.TransformPoint(arrowPositionObject.localPosition);
        }else{
            arrowPosition = transform.position;
        }


        GameObject arrowObj = Instantiate(Arrow, arrowPosition, transform.rotation) as GameObject;
        AbstractArrow arrow = arrowObj.GetComponent<AbstractArrow>();
        
        arrow.applyTemplet(ArrowTemplet);
        //Instantiate(Arrow, transform.position, transform.rotation);
    }
}
