using UnityEngine;
using System.Collections;

public class Player:MonoBehaviour
{

    private ScoreManager scoreManager;
    private Wall wall;
    
    /**
     * 当前关卡
     */
    private int currentMission;    

    /**
     * 当前的物攻武器id
     */
    private int phyWeaponId;

    /**
     * 当前的物攻箭矢id
     */
    private int phyArrowId;

    /**
     * 当前的魔攻武器id
     */
    private int magicWeaponId;

    /**
     * 当前的魔攻子弹id
     */
    private int magicArrowId;

    /**
     * 当前已经通过的最大关卡，如为3，则可选择4关进行攻击
     */
    private int maxMission;
   
    /**
     * 玩家得分
     */
    private int score;

    private WeaponTemplet phyWeaponTemplet, magicWeaponTemplet;
    private ArrowTemplet phyArrowTemplet, magicArrowTemplet;

    void Awake()
    {        
        currentMission = 1;
       
        phyArrowId = 1;
        phyWeaponId = 1;

        magicArrowId = 2;
        magicWeaponId = 2;

        phyWeaponTemplet = WeaponTempletConfig.getInstance().get(PhyWeaponId);
        magicWeaponTemplet = WeaponTempletConfig.getInstance().get(MagicWeaponId);
        phyArrowTemplet = ArrowTempletConfig.getInstance().get(PhyArrowId);
        magicArrowTemplet = ArrowTempletConfig.getInstance().get(MagicArrowId);

        print("Player.Awake()");
    }

    void Start()
    {
        scoreManager = GameObject.Find("score").GetComponent<ScoreManager>();
        wall = GameObject.Find("wall").GetComponent<Wall>();
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



    public ArrowTemplet MagicArrowTemplet
    {
        set { magicArrowTemplet = value; }
        get { return magicArrowTemplet; }
    }
    public ArrowTemplet PhyArrowTemplet
    {
        set { phyArrowTemplet = value; }
        get { return phyArrowTemplet; }
    }

    public WeaponTemplet PhyWeaponTemplet
    {
        set { phyWeaponTemplet = value; }
        get { return phyWeaponTemplet; }
    }

    public WeaponTemplet MagicWeaponTemplet
    {
        set { magicWeaponTemplet = value; }
        get { return magicWeaponTemplet; }
    }

    public int Score
    {
        set { score = value; }
        get { return score; }
    }

    public int MaxMission
    {
        get { return maxMission; }
        set { maxMission = value; }
    }


    public int CurrentMission
    {
        get { return currentMission; }
        set { currentMission = value; }
    }
    public int PhyWeaponId
    {
        get { return phyWeaponId; }
        set { phyWeaponId = value; }
    }

    public int PhyArrowId
    {
        get { return phyArrowId; }
        set { phyArrowId = value; }
    }

    public int MagicWeaponId
    {
        get { return magicWeaponId; }
        set { magicWeaponId = value; }
    }

    public int MagicArrowId
    {
        get { return magicArrowId; }
        set { magicArrowId = value; }
    }
}
