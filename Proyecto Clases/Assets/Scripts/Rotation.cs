using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{

    public float rotationSpeed = 220f;

    public float verticalMove;

    // Start is called before the first frame update
    void Start()
    {
        


    }

    // Update is called once per frame
    void Update()
    {
        verticalMove = Input.GetAxis("Vertical");

        transform.Rotate(rotationSpeed * Time.deltaTime * Vector3.right * verticalMove);
    }
}
