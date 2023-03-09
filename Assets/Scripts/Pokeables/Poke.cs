using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Poke : MonoBehaviour
{
    public UnityEvent OnPoke;

    public void PokeObject()
    {
        OnPoke?.Invoke();
    }
}
