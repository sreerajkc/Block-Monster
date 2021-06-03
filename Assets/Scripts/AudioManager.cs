using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [HideInInspector]public static AudioManager instance;
    public AudioSource audioSource;
    public AudioClip pop,monsterLaugh; 
    private void Awake() 
    {
        instance=this;
        audioSource=GetComponent<AudioSource>();
        DontDestroyOnLoad(this);
    }

}
