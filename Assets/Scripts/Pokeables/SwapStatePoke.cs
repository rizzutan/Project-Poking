using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapStatePoke : MonoBehaviour
{
    private float pokeCount = 0f;
    [SerializeField] int maxPokeCount;
    [SerializeField] GameObject objectSwap;

    AudioController ac;
    [SerializeField] string soundName;
    [SerializeField] bool randomSound;

    void Start()
    {
        ac = GetComponent<AudioController>();
    }

    public void swapPokeState()
    {
        pokeCount += 1;

        if (pokeCount >= maxPokeCount)
        {
            GameObject newGameObject = Instantiate(objectSwap, transform.position, Quaternion.identity);
            newGameObject.transform.rotation = transform.rotation;
            Destroy(gameObject);
        } else
        {
            TryPlaySound();
        }
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
