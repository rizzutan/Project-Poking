using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "Audio", menuName = "Audio", order = 1)]
public class Audio : ScriptableObject
{
    [Header("General")]
    public AudioClip clip;
    public float volume;
    public float pitchVariance;
    public bool loop;
    public bool isMusic;

    [Header("3D Sound")]
    public bool is3D;
    public float minDistance;
    public float maxDistance;

    [HideInInspector]
    public AudioSource source;

}
