using UnityEngine;
using System.Collections;

/**
 * 记分牌管理程序
 */
public class ScoreManager :MonoBehaviour{
    public GameObject ge;
    public GameObject shi;
    public GameObject bai;
    public GameObject qian;

    private SpriteRenderer geRenderer;
    private SpriteRenderer shiRenderer;
    private SpriteRenderer baiRenderer;
    private SpriteRenderer qianRenderer;


    public Sprite[] numSprites;

    

    void Start()
    {
        geRenderer = ge.GetComponent<SpriteRenderer>();
        shiRenderer = shi.GetComponent<SpriteRenderer>();
        baiRenderer = bai.GetComponent<SpriteRenderer>();
        qianRenderer = qian.GetComponent<SpriteRenderer>();
        //setScore(1965);
    }


    public void setScore( int score ){
        setNumber(geRenderer, score % 10);
        setNumber(shiRenderer, score % 100 / 10);
        setNumber(baiRenderer, score % 1000 / 100);
        setNumber(qianRenderer, score / 1000);
    }

    /**
     * 设置具体数字
     */
    private void setNumber(SpriteRenderer renderer, int number)
    {

        renderer.sprite = numSprites[number];
        //gameObject.renderer.
    }

    //private void setNumber(GameObject gameObject, int number)
    //{
    //    SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
    //    renderer.sprite = numSprites[number];
    //    //gameObject.renderer.
    //}
}
