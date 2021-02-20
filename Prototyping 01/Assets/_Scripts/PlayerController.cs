using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;

    [SerializeField,Range(10,20)] private float force;
    [SerializeField, Range(5, 10)] private float torqueForce;
    [SerializeField, Range(50, 100)] private float jumpForce;

    private float horizontalInput, verticalInput;
    private float zoneLimit = 19.6f;
    
    public GameObject focalPoint;
    private Vector3 forwardMove;
    private Vector3 horizontalMove;
    private Vector3 playerPos;

    


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        forwardMove = focalPoint.transform.forward;
        horizontalMove = focalPoint.transform.right;

        playerPos = transform.position;
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        MovePlayer();
        PlayerJump();
        KeepPlayerInBounds();
        
    }
    
    
    /// <summary>
    /// Move's the player with the horizontal and vertical input
    /// </summary>
    void MovePlayer()
    {
            _rigidbody.AddForce(horizontalMove * horizontalInput * force);
            _rigidbody.AddForce(forwardMove  * verticalInput * force);
    }

    /// <summary>
    /// Make the player jump with the"Space" key
    /// </summary>
    void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    /// <summary>
    /// Keep's the player inside the bounds
    /// </summary>
    void KeepPlayerInBounds()
    {
        if (Mathf.Abs(transform.position.x) >= zoneLimit || Mathf.Abs(transform.position.z) >= zoneLimit)
        {
            _rigidbody.velocity = Vector3.zero;
            if (playerPos.z > zoneLimit)
            {
                transform.position = new Vector3(playerPos.x, playerPos.y, zoneLimit);
            }
            else if (playerPos.z < -zoneLimit)
            {
                transform.position = new Vector3(playerPos.x, playerPos.y, -zoneLimit);
            }
            if (playerPos.x < -zoneLimit)
            {
                transform.position = new Vector3(-zoneLimit, playerPos.y, playerPos.z);
            }
            else if (playerPos.x > zoneLimit)
            {
                transform.position = new Vector3(zoneLimit, playerPos.y, playerPos.z);
            }
        }
    }



}
