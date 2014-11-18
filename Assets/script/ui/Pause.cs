using UnityEngine;
using System.Collections;

public class Pause : IClickEvent
{

    public static int timeScale =1;
    public override bool click(GameObject prevChoose)
    {
        if (timeScale == 0)
        {
            timeScale = 1;

        }
        else
        {
            timeScale = 0;
        }
        Time.timeScale = timeScale;
        
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
