using UnityEngine;
using System.Collections;

public class Player {

    private ScoreManager scoreManager;
    /**
     * 玩家得分
     */
    private int score;
    public int Score
    {
        set { score = value; }
        get { return score; }
    }

    private static Player m_instance = null;

    private Player()
    {
        scoreManager = GameObject.Find("score").GetComponent<ScoreManager>();
    }

    public static Player getInstance()
    {
        if (m_instance == null)
        {
            m_instance = new Player();
        }
        return m_instance;
    }

    public void addScore( int addScore ){
        this.score += addScore;
        scoreManager.setScore(score);
    }
}
