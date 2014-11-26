using UnityEngine;
using System.Collections;

/**
 * 千万要注意，必须根据滚动条滚动的方向来设置Body物体的质心，HEAD也需要同一质心
 * 以血条为例，通常减血是从右向左，那么血条Body的质心就应该是左上
 * 
 */
public class ScrollBar : MonoBehaviour
{
    public GameObject Head;
    public GameObject Body;
    /**
     * 用来和外界通信的最大值，比如最大血量为100，那么此处就为100
     */
    public int MaxValue;
    /**
     * 用来和外界通信的当前值，比如魔法条最大值为100，但是当前值通常为0
     */
    public int CurrentValue;
    /**
     * 需要最大放大倍数，作为缩小的依据，此值和currentValue一样，没有办法通过程序获取，
     * 比如魔法条，初始化的时候，最大值为100，当前值为0，此时魔法条的最大方法倍数就无法直接获取
     */
    public float MaxScaleX;

    //head物体需要移动的最大宽度,同上，注意是宽度不是位置坐标！！！
    public float MaxBarWidth = 2.26f;

    //动画播放的帧数,可以用此参数控制动画速度
    public int MaxFrame = 100;

    private Transform bodyTransform, headTransform;
    private Vector3 bodyCurrentScale;
    private Vector3 headCurrentPosition;

   
    //确保协同函数不会被重入，导致数据出问题
    private bool enter = true;


    void Start()
    {

        bodyTransform = Body.transform;
        bodyCurrentScale = bodyTransform.localScale;

        headTransform = Head.transform;
        //int direction = 1;
        if (MaxBarWidth == 0)
        {
          //  direction = -1;
            MaxBarWidth = headTransform.localPosition.x - bodyTransform.localPosition.x;
        }
        headCurrentPosition = headTransform.localPosition;

        //scroll(40*direction);
        //scroll(20 * direction);
        //scroll(10 * direction);
        //scroll(30 * direction);
        //scroll(20 * direction);

    }

    public void scroll(int changeValue)
    {        
        StartCoroutine(doScroll(changeValue));
        //doScroll1(changeValue);
    }

    //private void doScroll1(int changeValue)
    //{
        
    //    CurrentValue += changeValue;
    //    CurrentValue = Mathf.Max(CurrentValue, 0);
    //    CurrentValue = Mathf.Min(CurrentValue, MaxValue);
        

    //    float rate = (float)CurrentValue / MaxValue;
    //    float to = MaxScaleX * rate;
    //    float from = bodyTransform.localScale.x;
    //    bodyTransform.localScale = new Vector3( MaxScaleX * (float) CurrentValue / MaxValue, 1, 1);
    //    //bodyCurrentScale.transform.localScale = new Vector3(healthScale.x * (float)Hp / maxHp, 1, 1);
    //}

    private IEnumerator doScroll(int changeValue)
    {
        while (!enter)
        {
            yield return null;
        }
        enter = false;
        //yield return new WaitForSeconds(2);
        CurrentValue += changeValue;
        CurrentValue = Mathf.Max(CurrentValue, 0);
        CurrentValue = Mathf.Min(CurrentValue, MaxValue);
        int frameCount = (int)(Mathf.Abs(changeValue) / (float)MaxValue * MaxFrame);
       
        float rate = (float)CurrentValue / MaxValue;
        float to = MaxScaleX * rate;
        float from = bodyTransform.localScale.x;
        float step = (to - from) / frameCount;


        to = bodyTransform.localPosition.x + MaxBarWidth * rate;
        from = headTransform.localPosition.x;
        float stepPositon = (from - to) / frameCount;
        //print("to=" + to + " from=" + from + " stepPositon=" + stepPositon + "rate=" + rate);

        for (int i = 0; i < frameCount; i++)
        {
            headCurrentPosition.x -= stepPositon;
            headTransform.localPosition = headCurrentPosition;
            bodyCurrentScale.x += step;
            bodyTransform.localScale = bodyCurrentScale;
            yield return new WaitForEndOfFrame();
        }

        enter = true;
    }

    //public void move(int changeValue)
    //{
    //    currentValue += changeValue;
    //    float rate = (float)currentValue / MaxValue;
    //    currentScale.x = maxScaleX * rate;
    //    Body.transform.localScale = currentScale;
    //}
}
