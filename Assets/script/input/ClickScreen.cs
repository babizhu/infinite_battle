using UnityEngine;
using System.Collections;

public class ClickScreen : MonoBehaviour {
    /**
    * 上次选中的对象
    */
    private GameObject prevChoose;
    // Use this for initialization



    private static ClickScreen m_instance = null;

    private ClickScreen()
    {
    }

    public static ClickScreen getInstance()
    {
        if (m_instance == null)
        {
            m_instance = new ClickScreen();
        }
        return m_instance;
    }


    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) ) 
        {
            //你问我为什么会有vector3？因为ScreenToWorldPoint没有返回v2的重载！！！
            //当然，不同于3D，2D不会用ray，所以这里直接ScreenToWorldPoint（屏幕坐标转世界坐标），发出地为鼠标位置
            Vector3 v3 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //喜闻乐见的3转2
            Vector2 v2 = new Vector2(v3.x, v3.y);
            //创建hit信息集，你看看，都加了2D，参数信息是（发出射线的位置，发出射线的方向）
            //你问我为什么是Vector2.zero？我也想问为什么？别问我我是怎么知道的···
            RaycastHit2D hit = Physics2D.Raycast(v2, Vector2.zero);


            if (hit.collider != null)
            {
                //如果碰到些什么，嘿嘿···
                //print(hit.transform.name + " width is " + hit.transform.localScale.x);

                IClickEvent clickEvent = hit.transform.gameObject.GetComponent<IClickEvent>();
                //IClickEvent clickEvent = hit.transform.gameObject.GetComponent("IClickEvent") as IClickEvent;
                if (clickEvent != null)
                {
                   
                    if (clickEvent.isUnchoosePrevObject(prevChoose))
                    {
                        unChoose();
                    }

                    // bool isChoose = ;

                    if (clickEvent.click(prevChoose))
                    {
                        prevChoose = hit.transform.gameObject;
                    }

                }

            }
            else
            {
                //print("什么也没有碰到");
                unChoose();
            }

        }
        int fingerCount = 0;
        foreach (Touch touch in Input.touches) {
            if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
            {
                fingerCount++;
            }
            print("fingerCount=" + fingerCount);
            
        }
    }
    //void OnMouseDown()
    //{

    //    print("OnMouseDown");
    //    //  Application.LoadLevel("SomeLevel");
    //}

    private void unChoose()
    {
        if (prevChoose != null)
        {
            (prevChoose.GetComponent("IClickEvent") as IClickEvent).unClick();
            prevChoose = null;
        }
    }
}



//Vector3 wp = rendercamera.camera.ScreenToWorldPoint(Input.mousePosition);
//Vector2 touchPos = new Vector2(wp.x, wp.y);
//Collider2D h = Physics2D.OverlapPoint(v2);      
//RaycastHit2D[] hit = Physics2D.RaycastAll(v2, Vector2.zero);
//if( hit == null ){
//    return;
//}

//currentWeapon = findByHitArray(hit, "Weapon");
//if(currentWeapon!=null) {  
//    currentWeapon = h;

//    print (currentWeapon.name);
//    bool isShow = GameObject.Find("boder").GetComponent<Renderer>().enabled;
//    GameObject.Find("boder").GetComponent<Renderer>().enabled   = !isShow;
//    DoSomeThing();
//}else{
//    if( currentWeapon != null ){
//        print ("在田地上生成新武器");
//        Tian t = h.GetComponent<Tian>();
//        t.buildWeapon( currentWeapon.gameObject);
//        GameObject newWeapon=GameObject.FindWithTag(currentWeapon.name);  
//        GameObject newWeapon = Instantiate(currentWeapon, h.transform.localPosition, h.transform.rotation); 
//        h.gameObject.AddComponent();
//        newWeapon.


//    }
//foreach(RaycastHit2D h in hit){
//    print ( h.transform.gameObject.name);
//}	