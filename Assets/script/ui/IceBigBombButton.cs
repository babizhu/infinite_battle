using UnityEngine;
using System.Collections;

public class IceBigBombButton : IClickEvent
{
    public GameObject iceBigBomb;
    
    public override bool click(GameObject prevChoose)
    {

        Instantiate(iceBigBomb);
        

        return false;
    }

    public override void unClick()
    {

    }

    public override bool isUnchoosePrevObject(GameObject prevChoose)
    {
        return false;
    }
}
