using UnityEngine;
using System.Collections;

public class Player {

    private ScoreManager scoreManager;
    /**
     * 当前关卡
     */
    private int currentMission;
    public int CurrentMission
    {
        get { return currentMission; }
        set { currentMission = value; }
    }
    /**
     * 当前已经通过的最大关卡，如为3，则可选择4关进行攻击
     */
    private int maxMission;
    public int MaxMission{
        get { return maxMission; }
        set { maxMission = value; }
    }
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
