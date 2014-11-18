using UnityEngine;
using System.Collections;

public class Bow3 : Bow2 {

    protected override void doNormalAttack()
    {

        if (arrowPositionObject != null)
        {
            arrowPosition = arrowPositionObject.parent.TransformPoint(arrowPositionObject.localPosition);
        }
        else
        {
            arrowPosition = transform.position;
        }

        for (int i = 0; i < 3; i++)
        {
            
            Vector3 v = transform.rotation.eulerAngles;
            v.z += (i - 1) * 5;

            GameObject arrowObj = Instantiate(Arrow, arrowPosition, Quaternion.Euler(v)  ) as GameObject;
            
            AbstractArrow arrow = arrowObj.GetComponent<AbstractArrow>();

            arrow.applyTemplet(ArrowTemplet);

        }
       
        //Instantiate(Arrow, transform.position, transform.rotation);
    }

    
}
