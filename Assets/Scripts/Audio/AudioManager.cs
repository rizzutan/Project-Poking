using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public float masterVolume;
    public float masterSFXVolume;
    public float masterMusicVolume;

    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public float getSFXVolume()
    {
        return Mathf.Min(masterVolume * masterSFXVolume, 1f);
    }

    public float getMusicVolume()
    {
        return Mathf.Min(masterVolume * masterMusicVolume, 1f);
    }
}
