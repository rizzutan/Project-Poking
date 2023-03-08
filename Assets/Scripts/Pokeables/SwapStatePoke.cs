using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapStatePoke : MonoBehaviour
{
    public bool cooldown = false;
    private float timerDuration = 1f;
    private float elapsedTime = 0f;
    private float pokeCount = 0f;
    private Poke poke;
    [SerializeField] int maxPokeCount;
    [SerializeField] GameObject objectSwap;
    // Start is called before the first frame update
    void Start()
    {
        poke = GetComponent<Poke>();

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
            pokeCount += 1;
            cooldown = true;
            elapsedTime = 0;
        }
        if (pokeCount >= maxPokeCount)
        {
            Instantiate(objectSwap, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        poke.poked = false;
    }

}

