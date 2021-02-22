using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    private Rigidbody _rigidbody;
    private float minForce = 12,
     maxforce = 16,
     maxTorque = 10, 
     xRange = 4, 
     ySpawnPos = -6;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(RandomForce(), ForceMode.Impulse);
        _rigidbody.AddTorque(RandomTorque(), 
        RandomTorque(), RandomTorque());
        transform.position = RandomSpawnPos();
    }
    
    /// <summary>
    /// Generates a random vector of force in 3D
    /// </summary>
    /// <returns>A random force up between the minimun and maximun force</returns>
    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minForce, maxforce);
    }
    /// <summary>
    /// Generates a random torque between -maxTorque and maxTorque
    /// </summary>
    /// <returns>A random value of torque between -maxTorque and maxTorque</returns>
    private float RandomTorque() 
    {
        return Random.Range(-maxTorque, maxTorque);
    }
    /// <summary>
    /// Generates a random position between the minimun and maximun range
    /// </summary>
    /// <returns>A random position between the minimun and maximun range</returns>
    private Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
    
    private void OnMouseDown()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("KillZone"))
        {
            Destroy(gameObject);
        }
    }
}
