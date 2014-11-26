using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {
    private SpriteRenderer bar;
    private SpriteRenderer bg;
    private Vector3 healthScale;
    

    private bool isShow = false;

	// Use this for initialization
	void Start ()
    {
        bar = findChildByName("healthBar");
        healthScale = bar.transform.localScale;
       
        setHeathEnabled(isShow);
        //GetComponent<SpriteRenderer>().material.color = new Color(0, 0, 0, 0);
        
    }
	
    /**
     * 在子项中查找血条
     */
    private SpriteRenderer findChildByName(string name)
    {
        foreach (SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>())
        {            
            if (sr.name == name)
            {
                return sr;
            }
        }
        return null;
    }


    /**
     * 隐藏或者显示血条相关组件
     */
    private void setHeathEnabled(bool enabled)
    {
        //enabled = true;
        foreach (SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>())
        {
            sr.enabled = enabled;
        }
    }

    /**
     * 更新怪物头上的血条，本来可以做成一个由根据血量的多少由绿变红，但是视觉效果不太好，暂放弃
     * //healthBar.material.color = Color.Lerp(Color.green, Color.red, 1 - Hp * 0.01f);
     */
    public void updateHealthBar( float rate)
    {
        // Set the health bar's colour to proportion of the way between green and red based on the player's health.
        //healthBar.material.color = Color.Lerp(Color.green, Color.red, 1 - Hp * 0.01f);
        //healthBar.material.color = Color.blue;

        // Set the scale of the health bar to be proportional to the player's health.
        bar.transform.localScale = new Vector3(healthScale.x * rate, 1, 1);
        
        StartCoroutine(waitAndHide());
    }

    IEnumerator waitAndHide()
    {
        setHeathEnabled(true);
        yield return new WaitForSeconds(0.2f);
        setHeathEnabled(false);

    }
}
