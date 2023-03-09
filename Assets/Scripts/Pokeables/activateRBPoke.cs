using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateRBPoke : MonoBehaviour
{
    private Rigidbody rb;
    AudioController ac;
    [SerializeField] string soundName;
    [SerializeField] bool randomSound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ac = GetComponent<AudioController>();
        rb.isKinematic = true;
    }

    public void ActivateRBPoke()
    {
        rb.isKinematic = false;
        TryPlaySound();
    }

    void TryPlaySound()
    {
        if ((soundName == null || soundName == "") && !randomSound)
        {
            return;
        } else
        {
            if (randomSound)
            {
                ac.PlayRandomAudio();
            } else
            {
                ac.PlayAudio(soundName);
            }
        }
    }
}
