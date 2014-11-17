using UnityEngine;
using System.Collections;

public class MonsterSpawn : MonoBehaviour
{
   
    public float xUnit = 0.6f;//x轴上的偏移,一波在某行出现多个怪，未避免重叠，x轴上做一定的偏移
    public float rowHeight = 0.75f;//行高
    public Vector2 origin = new Vector2(6f,-1.55f);//场景出怪的坐标原点，比如第四排就是坐标原点的y轴加上4个单位的rawHeight
    

    private MissionTemplet missionTemplet;
    //敌人进攻的进度条
    private ScrollBar monsterBar;
    private Player player;

	// Use this for initialization
	void Start () {
        //print("等待出怪");
        monsterBar = GameObject.Find("monsterBar").GetComponent<ScrollBar>();
        player = GameObject.Find("player").GetComponent<Player>();
        StartCoroutine( spawn() );
        
	}


    IEnumerator spawn()
    {
        
        //获取玩家当前的关卡模板
        missionTemplet = MissionTempletConfig.getInstance().get(player.CurrentMission);
        int totalSecond = 0;
        //计算总共需要的秒数
        foreach (WaveTemplet wt in missionTemplet.Waves)
        {
            totalSecond += wt.DelaySecond;
            
        }
        monsterBar.CurrentValue = monsterBar.MaxValue = totalSecond;

        foreach (WaveTemplet wt in missionTemplet.Waves)
        {
            //print(totalSecond);
            //print( )
            yield return new WaitForSeconds(wt.DelaySecond);
            monsterBar.scroll(-wt.DelaySecond);
            spawnWave( wt );
        }
    }

    private void spawnWave(WaveTemplet wt)
    {
        int[] xOffset = new int[5];//记录各行怪物在x轴出现的次数
        foreach (MonsterWithPosition mp in wt.MonsterList)
        {
            MonsterTemplet t = mp.MonsterTemplet;
            //print(t.Name + "(" + t.Id + ") : row=" + mp.Row + " y=" + origin.y + mp.Row * rowHeight + " hp=" + t.Hp);
            
            Vector3 pos = new Vector3(origin.x + xOffset[mp.Row] * xUnit,origin.y + mp.Row * rowHeight,0);
            xOffset[mp.Row] += 1;
            AbstractMonster monster = (Instantiate(Resources.Load(t.Prefab), pos, Quaternion.identity) as GameObject).GetComponent<AbstractMonster>();
            monster.applyTemplet(t);

            
        }
    }
}
