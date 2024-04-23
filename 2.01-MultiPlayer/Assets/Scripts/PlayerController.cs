using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;


public class PlayerController : NetworkBehaviour
{
    [SerializeField] private float speed = 7f;
    [SerializeField] private float rotationSpeed = 500f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsOwner)
            return;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDir = new Vector3(horizontalInput,0, verticalInput);
        movementDir.Normalize();

        transform.Translate(movementDir* Time.deltaTime * speed, Space.World);

        if (movementDir != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDir, Vector3.up);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, toRotation,90);
            transform.rotation = rotation;
        }

    }
}
