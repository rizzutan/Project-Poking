using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class specificDirectionPoke : MonoBehaviour
{
    public float force = 10f;
    public Vector3 directionForce;
    private bool cooldown = false;
    private float timerDuration = 1f; 
    private float elapsedTime = 0f;
    private Transform cameraPos;
    private Poke poke;
    private Rigidbody rb;

    AudioController ac;
    [SerializeField] string soundName;
    [SerializeField] bool randomSound;
    // Start is called before the first frame update
    void Start()
    {
        GameObject camera = GameObject.FindWithTag("MainCamera");
        cameraPos = camera.GetComponent<Transform>();
        poke = GetComponent<Poke>();
        rb = GetComponent<Rigidbody>();
        ac = GetComponent<AudioController>();
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= timerDuration)
        {
            cooldown = false;
        }
            if (poke.poked == true && cooldown == false)
        {
            poke.poked = false;
            Vector3 direction = transform.position - transform.position + directionForce;
            direction = direction.normalized;
            rb.AddForce(force * direction, ForceMode.Impulse);
            cooldown = true;
            elapsedTime = 0;

            TryPlaySound();
        }
        poke.poked = false;
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

