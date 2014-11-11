using UnityEngine;
using System.Collections;

public class MonsterSpawn : MonoBehaviour
{
    public float xUnit;//x轴上的偏移
    public float yUnit;//y轴上的哦偏移
    public Vector2 origin;//场景出怪的坐标原点，比如第四排就是坐标原点的y轴加上4个单位的yUnit

    private MissionTemplet missionTemplet;

	// Use this for initialization
	void Start () {
        StartCoroutine( spawn() );
        
	}


    IEnumerator spawn()
    {
        //获取玩家当前的关卡模板
        missionTemplet = MissionTempletConfig.getInstance().get(Player.getInstance().CurrentMission);
        foreach (WaveTemplet wt in missionTemplet.Waves)
        {
            spawnWave( wt );
            yield return new WaitForSeconds(wt.DelaySecond);
        }
    }

    private void spawnWave(WaveTemplet wt)
    {
        foreach (MonsterWithPosition mp in wt.MonsterList)
        {
            print(mp.MonsterTemplet.Id + ":" + mp.Position);
            
        }
    }
}
