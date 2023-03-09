using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pokeController : MonoBehaviour
{
    public float range = 3f;
    public float radius = 1f;
    private Transform stick;
    private LayerMask layerMask;

    [SerializeField] Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        Transform[] transforms = GetComponentsInChildren<Transform>();
        foreach (Transform component in transforms)
        {
            if (component.transform != transform)
            {
                stick = component;
                break;
            }
        }
        layerMask = LayerMask.GetMask("Poke");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Poke();
            anim.SetBool("Poking", true);
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            anim.SetBool("Poking", false);
        }
    }

    void Poke()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, range, layerMask))
        {
            Collider[] colliderArray = Physics.OverlapSphere(hit.point, radius, layerMask);
            for (int i = 0; i < colliderArray.Length; i++)
            {
                if (colliderArray[i].GetComponent<Poke>())
                {
                    colliderArray[i].GetComponent<Poke>().PokeObject();
                }
            }
        }
    }
}
