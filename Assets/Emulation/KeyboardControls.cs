using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardControls : MonoBehaviour
{
    public float movementSpeed = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"),0, Input.GetAxis("Vertical"));
        movement *= movementSpeed * Time.deltaTime;

        Vector3 forward = transform.forward;
        forward.y = 0;
        forward.Normalize();
        Vector3 right = transform.right;
        right.y = 0;
        right.Normalize();
        transform.position += forward * movement.z + right * movement.x;
    }
}
