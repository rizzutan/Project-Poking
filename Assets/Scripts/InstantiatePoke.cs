using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePoke : MonoBehaviour
{
    public bool cooldown = false;
    private float timerDuration = 1f;
    private float elapsedTime = 0f;
    private Poke poke;
    private Rigidbody rb;
    public Vector3 offset;
    public GameObject spawnObject;
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
            cooldown = true;
            elapsedTime = 0;
            GameObject newObject = Instantiate(spawnObject, Vector3.zero, Quaternion.identity);
            newObject.transform.position = transform.position + offset;
        }
        poke.poked = false;
    }

}

