using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public Audio[] audioObjects;


    // Start is called before the first frame update
    void Awake()
    {
        float sfxVolume = GameObject.FindObjectOfType<AudioManager>().getSFXVolume();
        float musicVolume = GameObject.FindObjectOfType<AudioManager>().getMusicVolume();

        for(int i = 0; i < audioObjects.Length; i++)
        {
            string name = audioObjects[i].name;
            audioObjects[i] = Object.Instantiate(audioObjects[i]);
            audioObjects[i].name = name;
        }

        foreach (Audio a in audioObjects)
        {
            a.source = gameObject.AddComponent<AudioSource>();
            a.source.clip = a.clip;
            a.source.loop = a.loop;
            if (a.isMusic)
            {
                a.source.volume = a.volume * musicVolume;
            } else
            {
                a.source.volume = a.volume * sfxVolume;
            }

            if (a.is3D)
            {
                a.source.spatialBlend = 1f;
                a.source.rolloffMode = AudioRolloffMode.Linear;
                a.source.minDistance = a.minDistance;
                a.source.maxDistance = a.maxDistance;
            }
            
        }
    }
    public void PlayAudio(string name)
    {
        Audio a = null;

        foreach (Audio aFound in audioObjects)
        {
            //print(aFound.name);
            if (aFound.name == name)
            {
                a = aFound;
            }
        }

        if (a == null)
        {
            Debug.LogWarning("Audio: " + a + " not found!");
            return;
        }
        if (a.pitchVariance != 0)
        {
            a.source.pitch = 1 + UnityEngine.Random.Range(-a.pitchVariance, a.pitchVariance);
        } else
        {
            a.source.pitch = 1;
        }
        //print(a.source.clip.name);
        a.source.Play();
    }

    public void StopAudio(string name)
    {
        Audio a = null;

        foreach (Audio aFound in audioObjects)
        {
            //print(aFound.name);
            if (aFound.name == name)
            {
                a = aFound;
            }
        }

        if (a == null)
        {
            Debug.LogWarning("Audio: " + name + " not found!");
            return;
        }
        //print("STOP AUDIO: " + a.source.clip.name);
        a.source.Stop();
    }

    public bool IsPlaying(string name)
    {
        Audio a = null;

        foreach (Audio aFound in audioObjects)
        {
            //print(aFound.name);
            if (aFound.name == name)
            {
                a = aFound;
            }
        }

        if (a == null)
        {
            Debug.LogWarning("Audio: " + name + " not found!");
            return false;
        }

        return a.source.isPlaying;
    }
}
