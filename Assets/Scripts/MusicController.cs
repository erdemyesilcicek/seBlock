using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    static MusicController musicManager = null;
    private void Awake()
    {
        if(musicManager != null)
        {
            Debug.Log(GetInstanceID());
            Destroy(gameObject);
        }
        else
        {
            musicManager = this;
            Debug.Log(musicManager.GetInstanceID());
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }
}