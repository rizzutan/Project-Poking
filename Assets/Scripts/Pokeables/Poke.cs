using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Poke : MonoBehaviour
{
    //[HideInInspector]
    public bool poked = false;
    // Start is called before the first frame update

    public UnityEvent OnPoke;

    public void PokeObject()
    {
        poked = true;
        OnPoke?.Invoke();
    }
}
