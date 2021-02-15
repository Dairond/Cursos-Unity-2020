using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerController : MonoBehaviour
{
    [Range(0,10000),SerializeField] private float rotateSpeed;
    private float startInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        startInput = Input.GetAxis("Jump");

        if (startInput > 0.9)
        {
            transform.Rotate(rotateSpeed * Time.deltaTime * Vector3.forward);
        }
    }
}
