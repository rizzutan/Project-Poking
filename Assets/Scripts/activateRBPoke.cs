using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateRBPoke : MonoBehaviour
{
    private Poke poke;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        poke = GetComponent<Poke>();
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
            if (poke.poked == true)
        {
            poke.poked = false;
            rb.isKinematic = false;
        }
        poke.poked = false;
    }
}

