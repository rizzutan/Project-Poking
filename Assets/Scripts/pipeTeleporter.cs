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
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == playerMask || other.gameObject.layer == pokeMask)
        {
            other.transform.position = teleport.position;
        }
    }
}
