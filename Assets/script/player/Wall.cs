using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {
    public GameObject HpBar;
    private int hp;
    private ScrollBar bar;

	// Use this for initialization
	void Start () {
        bar = HpBar.GetComponent<ScrollBar>();
        hp = PlayerData.getInstance().WallHp;
        
        //hp = 1000;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public int Hp
    {
        set { hp = value; }
        get { return hp; }
    }



    public void defend( AbstractMonster monster )
    {
        int damage = monster.AttackDamage;
        //print(hp);
        hp -= damage;

        //print("damage=" + damage + " hp=" + hp);
        
        bar.scroll(-damage);
        if (hp <= 0)
        {
            StartCoroutine(loadLoseScene());
        }
    }

    /**
     * 切换失败场景，好像无需延时
     */
    private IEnumerator loadLoseScene()
    {
        //print(1111111111);
        yield return new WaitForSeconds(0.1f);
        Application.LoadLevel("lose");
        //print(222222222222);
    }
}
