using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flipGravityPoke : MonoBehaviour
{
    private bool cooldown = false;
    private float timerDuration = 1f; 
    private float elapsedTime = 0f;
    private Poke poke;
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
            Transform[] childTransforms = GetComponentsInChildren<Transform>();
            foreach (Transform child in childTransforms)
            {
                applyForce forceScript = child.GetComponent<applyForce>();
                if (forceScript != null)
                {
                    forceScript.FlipGravity();
                }
            }
            poke.poked = false;
            cooldown = true;
            elapsedTime = 0;
        }
        poke.poked = false;
    }
}
