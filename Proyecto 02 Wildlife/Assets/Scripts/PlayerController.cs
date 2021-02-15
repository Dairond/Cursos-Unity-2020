using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizantalInput;
    public float movementSpeed = 25f;
    public float xRange = 15f;

    public GameObject projetilePrefab;
    
    void Update()
    {
        //Movimiento del personaje
        horizantalInput = Input.GetAxis("Horizontal");
        transform.Translate(movementSpeed * Vector3.right * Time.deltaTime * horizantalInput);

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        //Acciones del personaje
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projetilePrefab, transform.position, projetilePrefab.transform.rotation);
        }

    }
}
