using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    [Range(0, 20), SerializeField] private float speed = 10f;
    [Range(0, 90), SerializeField] private float rotationSpeed = 45f;
    private float verticalInput;
    private float horizontalInput;
    private float rotateInput;
    private float startInput;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        rotateInput = Input.GetAxis("Fire1");
        startInput = Input.GetAxis("Jump");

        if (startInput > 0.9){
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime*verticalInput);

        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * horizontalInput);

        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime * rotateInput);
    }
}
