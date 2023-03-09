using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flipGravityPoke : MonoBehaviour
{ 
    AudioController ac;
    [SerializeField] string soundName;
    [SerializeField] bool randomSound;

    // Start is called before the first frame update
    void Start()
    {
        ac = GetComponent<AudioController>();
    }

    public void FlipGravityPoke()
    {
        Transform[] childTransforms = GetComponentsInChildren<Transform>();
        foreach (Transform child in childTransforms)
        {
            applyForce forceScript = child.GetComponent<applyForce>();
            if (forceScript != null)
            {
                forceScript.FlipGravity();
            }
        }
        TryPlaySound();
    }

    void TryPlaySound()
    {
        if ((soundName == null || soundName == "") && !randomSound)
        {
            return;
        }
        else
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
}
