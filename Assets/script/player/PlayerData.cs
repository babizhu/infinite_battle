using UnityEngine;
using System.Collections;

public class PlayerData {
    private static PlayerData m_instance = null;

    /**
     */ 
    private int wallHp;
    /**
  * 当前已经通过的最大关卡，如为3，则可选择4关进行攻击
  */
    private int maxMission;

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

    private WeaponTemplet phyWeaponTemplet, magicWeaponTemplet;
    private ArrowTemplet phyArrowTemplet, magicArrowTemplet;



    private PlayerData()
    {
        init();
    }
    public static PlayerData getInstance()
    {
        if (m_instance == null)
        {
            m_instance = new PlayerData();
        }
        return m_instance;
    }

    public void init()
    {
 

        loadAll();

        phyWeaponTemplet = WeaponTempletConfig.getInstance().get(PhyWeaponId);
        magicWeaponTemplet = WeaponTempletConfig.getInstance().get(MagicWeaponId);
        phyArrowTemplet = ArrowTempletConfig.getInstance().get(PhyArrowId);
        magicArrowTemplet = ArrowTempletConfig.getInstance().get(MagicArrowId);


    }

    public int WallHp
    {
        set { wallHp = value; }
        get { return wallHp; }
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

    /**
     * 保存所有的玩家数据
     */
    private void saveAll()
    {
        PlayerPrefs.SetInt("currentMission", currentMission);
        PlayerPrefs.SetInt("maxMission", maxMission);
        PlayerPrefs.SetInt("phyArrowId", phyArrowId);
        PlayerPrefs.SetInt("phyWeaponId", phyWeaponId);
        PlayerPrefs.SetInt("magicArrowId", magicArrowId);
        PlayerPrefs.SetInt("magicWeaponId", magicWeaponId);

        PlayerPrefs.SetInt("wallHp", wallHp);
    }

    private void loadAll()
    {
        currentMission = PlayerPrefs.GetInt("currentMission", 1);
        maxMission = PlayerPrefs.GetInt("maxMission", 1);

        phyArrowId = PlayerPrefs.GetInt("phyArrowId", 1);
        phyWeaponId = PlayerPrefs.GetInt("phyWeaponId", 1);

        magicArrowId = PlayerPrefs.GetInt("magicArrowId", 3);
        magicWeaponId = PlayerPrefs.GetInt("magicWeaponId", 3);

        wallHp = PlayerPrefs.GetInt("wallHp", 100);
    }
}
