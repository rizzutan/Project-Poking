using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePoke : MonoBehaviour
{
    public Vector3 offset;
    public GameObject spawnObject;

    AudioController ac;
    [SerializeField] string soundName;
    [SerializeField] bool randomSound;
    // Start is called before the first frame update
    void Start()
    {
        ac = GetComponent<AudioController>();

    }

    public void instantiatePoke()
    {
        GameObject newObject = Instantiate(spawnObject, Vector3.zero, Quaternion.identity);
        newObject.transform.position = transform.position + offset;
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
