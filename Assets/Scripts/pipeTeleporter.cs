using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeTeleporter : MonoBehaviour
{
    private LayerMask playerMask;
    private LayerMask pokeMask;

    public Transform teleport;
    private void Start()
    {
        playerMask = LayerMask.GetMask("Player");
        pokeMask = LayerMask.GetMask("Poke");
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3 || other.gameObject.layer == 7)
        {
            other.transform.position = teleport.position;
        }
    }
}
