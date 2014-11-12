using UnityEngine;
using System.Collections;

public class MonsterSpawn : MonoBehaviour
{
    public float xUnit = 0.3f;//x轴上的偏移,一波在某行出现多个怪，未避免重叠，x轴上做一定的偏移
    public float rowHeight = 0.9f;//行高
    public Vector2 origin = new Vector2(6f,-1.8f);//场景出怪的坐标原点，比如第四排就是坐标原点的y轴加上4个单位的rawHeight

    private MissionTemplet missionTemplet;

	// Use this for initialization
	void Start () {
        print("等待出怪");
        StartCoroutine( spawn() );
        
	}


    IEnumerator spawn()
    {
        //获取玩家当前的关卡模板
        missionTemplet = MissionTempletConfig.getInstance().get(Player.getInstance().CurrentMission);
        foreach (WaveTemplet wt in missionTemplet.Waves)
        {
            yield return new WaitForSeconds(wt.DelaySecond);
            spawnWave( wt );
        }
    }

    private void spawnWave(WaveTemplet wt)
    {
        int[] xOffset = new int[5];//记录各行怪物在x轴出现的次数
        foreach (MonsterWithPosition mp in wt.MonsterList)
        {
            MonsterTemplet t = mp.MonsterTemplet;
            print(t.Name + "(" + t.Id + ") : row=" + mp.Row + " y=" + origin.y + mp.Row * rowHeight + " hp=" + t.Hp);
            
            Vector3 pos = new Vector3(origin.x + xOffset[mp.Row] * xUnit,origin.y + mp.Row * rowHeight,0);
            xOffset[mp.Row] += 1;
            AbstractMonster monster = (Instantiate(Resources.Load(t.Prefab), pos, Quaternion.identity) as GameObject).GetComponent<AbstractMonster>();
            monster.applyTemplet(t);

            
        }
    }
}
