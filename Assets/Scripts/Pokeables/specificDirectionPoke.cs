using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class specificDirectionPoke : MonoBehaviour
{
    public float force = 10f;
    public Vector3 directionForce; 
    private Rigidbody rb;

    AudioController ac;
    [SerializeField] string soundName;
    [SerializeField] bool randomSound;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ac = GetComponent<AudioController>();
    }

    public void directionPoke()
    {
        Vector3 direction = transform.position - transform.position + directionForce;
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
