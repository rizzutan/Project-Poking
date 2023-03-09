using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeMatColour : MonoBehaviour
{
    public Material[] mats;
    // Start is called before the first frame update
    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        int randomIndex = Random.Range(0, mats.Length);
        renderer.material = mats[randomIndex];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
