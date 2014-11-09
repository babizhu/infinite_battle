using UnityEngine;
using System.Collections;

/**
 * 控制整个游戏的声音系统
 */
public class Sound {

    /**
     * 游戏是否静音
     */
    private bool isSilence;
    public bool Silence
    {
        get { return isSilence; }
        set { isSilence = value; }
    }
    
    
    private static Sound m_instance = null;

    private Sound()
    {
    }

    public static Sound getInstance()
    {
        if (m_instance == null)
        {
            m_instance = new Sound();
        }
        return m_instance;
    }
  



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /**
     * 播放声音
     */ 
    public void play(AudioClip clip)
    {
        if (!Silence && clip != null )
        {
            AudioSource.PlayClipAtPoint(clip, new Vector3());
        } 
    }
}
