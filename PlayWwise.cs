/// Script by Petr Yakyamsev

using UnityEngine;

public class PlayWwise : MonoBehaviour
{
    public string eventName;
    public bool looped;
    public float loopSec;
    
    void Start()
    {
        Play();

        if (looped)
        {
            InvokeRepeating("Play", loopSec, loopSec);
        }
    }
        
    void Play()
    {
        AkSoundEngine.PostEvent(eventName, gameObject);
    }
}
