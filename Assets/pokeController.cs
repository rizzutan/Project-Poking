using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pokeController : MonoBehaviour
{
    public float speed = 1f;
    private Transform stick;
    public Transform restPos;
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
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            //move relative to the rotation
            float horMovement = Input.GetAxis("Mouse X");
            Vector3 pokeMovement = transform.TransformDirection(new Vector3(0f, 0f, horMovement));
            stick.transform.position += pokeMovement * -speed * Time.deltaTime;


        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            stick.transform.position = restPos.position;
        }


    }
}
