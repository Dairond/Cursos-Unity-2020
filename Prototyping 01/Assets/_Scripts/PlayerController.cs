using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;

    [SerializeField,Range(40,200)] private float force;
    [SerializeField, Range(20, 100)] private float torqueForce;
    [SerializeField, Range(5, 50)] private float jumpForce;

    private float horizontalInput, verticalInput;
    private float zoneLimit = 19.6f;
    

    private Vector3 playerPosition;
    


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = transform.position;
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        MovePlayer();
        PlayerJump();
        KeepPlayerInBounds();
        
    }

    void MovePlayer()
    {
        if (horizontalInput > 0 || horizontalInput < 0)
        {
            _rigidbody.AddForce(Vector3.left * Time.deltaTime * -horizontalInput * force);
            _rigidbody.AddTorque(Vector3.forward * Time.deltaTime * -horizontalInput * torqueForce);
        }
        if (verticalInput > 0 || verticalInput < 0)
        {
            _rigidbody.AddForce(Vector3.forward * Time.deltaTime * verticalInput * force);
            _rigidbody.AddTorque(Vector3.left * Time.deltaTime * verticalInput * torqueForce);
        }
    }
    void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    void KeepPlayerInBounds()
    {
        if (Mathf.Abs(transform.position.x) >= zoneLimit || Mathf.Abs(transform.position.z) >= zoneLimit)
        {
            _rigidbody.velocity = Vector3.zero;
            if (playerPosition.z > zoneLimit)
            {
                transform.position = new Vector3(playerPosition.x, playerPosition.y, zoneLimit);
            }
            else if (playerPosition.z < -zoneLimit)
            {
                transform.position = new Vector3(playerPosition.x, playerPosition.y, -zoneLimit);
            }
            if (playerPosition.x < -zoneLimit)
            {
                transform.position = new Vector3(-zoneLimit, playerPosition.y, playerPosition.z);
            }
            else if (playerPosition.x > zoneLimit)
            {
                transform.position = new Vector3(zoneLimit, playerPosition.y, playerPosition.z);
            }
        }
    }



}
