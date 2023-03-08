using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundImmediately : MonoBehaviour
{

    AudioController ac;
    [SerializeField] string soundName;
    [SerializeField] bool randomSound;

    // Start is called before the first frame update
    void Start()
    {
        ac = GetComponent<AudioController>();
        PlaySound(); 
    }

    void PlaySound()
    {
        if (randomSound)
        {
            ac.PlayRandomAudio();
        }
        else
        {
            ac.PlayAudio(soundName);
        }
    }
}
