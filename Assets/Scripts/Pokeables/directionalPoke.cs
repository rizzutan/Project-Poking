using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class directionalPoke : MonoBehaviour
{
    public float force = 10f;
    private Transform cameraPos;
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
        rb = GetComponent<Rigidbody>();
    }

    public void DirectionalPoke()
    {
        Vector3 direction = transform.position - cameraPos.transform.position;
        direction = direction.normalized;
        rb.AddForce(force * direction, ForceMode.Impulse);
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
