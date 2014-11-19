using UnityEngine;
using System.Collections;

public class Player:MonoBehaviour
{
    private ScoreManager scoreManager;
    private Wall wall;
    private int currentSp;
    private ScrollBar spBar;  
    /**
     * 玩家得分
     */
    private int score;

    void Start()
    {
        scoreManager = GameObject.Find("score").GetComponent<ScoreManager>();
        wall = GameObject.Find("wall").GetComponent<Wall>();
        spBar = GameObject.Find("sp").GetComponent<ScrollBar>();
        InvokeRepeating("changeCurrentSp", 1, 0.1f);
    }

    private void changeCurrentSp( ){
        changeCurrentSp(3);
    }
    public void changeCurrentSp( int changeValue )
    {
        currentSp += changeValue;
        spBar.scroll(changeValue);
    }

    public void addScore( int addScore ){
        this.score += addScore;
        scoreManager.setScore(score);
    }

    /**
     * 受到了攻击
     */
    public void defend(AbstractMonster monster)
    {
        //Debug.Log("城墙防御受到了" + monster.name + "的攻击");
        wall.defend( monster);
    }


    public int CurrentSp
    {
        set { currentSp = value; }
        get { return currentSp; }
    }

    public int Score
    {
        set { score = value; }
        get { return score; }
    }
    
}
