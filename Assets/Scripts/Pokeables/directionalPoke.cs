using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class directionalPoke : MonoBehaviour
{
    public float force = 10f;
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

        ac = GetComponent<AudioController>();
        poke = GetComponent<Poke>();
        rb = GetComponent<Rigidbody>();
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
            Vector3 direction = transform.position - cameraPos.transform.position;
            direction = direction.normalized;
            rb.AddForce(force * direction, ForceMode.Impulse);
            cooldown = true;
            elapsedTime = 0;
            TryPlaySound();
        }
    }
    private void LateUpdate()
    {
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
