using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pokeController : MonoBehaviour
{
    public bool leftHanded = false;
    public float speed = 3f;
    public float range = 10f;
    public float radius = 1f;
    public float minSpeed = 1f;
    public float minDistance = 1f;
    public float maxDistance = 6f;
    private Transform stick;
    public Transform restPos;
    private Vector3 lastMousePosition;
    private LayerMask layerMask;
    private bool poke = false;
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
        if (leftHanded == true)
        {
            restPos.position = new Vector3(-restPos.position.x, restPos.position.y, restPos.position.z);
        }
        stick.position = restPos.position;
        layerMask = LayerMask.GetMask("Poke");
    }

    // Update is called once per frame
    void Update()
    {
        //calculate mouse speed
        Vector3 currentMousePosition = Input.mousePosition;
        float mouseSpeed = (currentMousePosition - lastMousePosition).magnitude / Time.deltaTime;
        lastMousePosition = currentMousePosition;

        if (Input.GetKey(KeyCode.Mouse0))
        {
            //move relative to the rotation
            float horMovement = Input.GetAxis("Mouse Y");
            Vector3 pokeMovement = transform.TransformDirection(new Vector3(0f, 0f, horMovement));
            stick.position += pokeMovement * speed * Time.deltaTime;
            //check mouse speed and displacement
            float displacement = Mathf.Abs(Vector3.Distance(restPos.position, stick.position));
            if (displacement >= minDistance)
            {
                poke = true;
            }

        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            //reset mouse position
            stick.position = restPos.position;
        }
        if (poke == true)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, range))
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
            poke = false;
        }
    }
}
