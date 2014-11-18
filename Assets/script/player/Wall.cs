using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {
    public GameObject HpBar;
    private int hp =100;
    private ScrollBar bar;

	// Use this for initialization
	void Start () {
        bar = HpBar.GetComponent<ScrollBar>();
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
        
        bar.scroll(-damage);
        if (hp <= 0)
        {
            Application.LoadLevel("dead");
            print("你死了");
        }
    }
}
