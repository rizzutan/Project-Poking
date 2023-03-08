using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateRBPoke : MonoBehaviour
{
    private Poke poke;
    private Rigidbody rb;
    AudioController ac;
    [SerializeField] string soundName;
    [SerializeField] bool randomSound;

    // Start is called before the first frame update
    void Start()
    {
        poke = GetComponent<Poke>();
        rb = GetComponent<Rigidbody>();
        ac = GetComponent<AudioController>();
        rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
            if (poke.poked == true)
        {
            print("poked!");
            poke.poked = false;
            rb.isKinematic = false;

            TryPlaySound();
        }
        poke.poked = false;
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

