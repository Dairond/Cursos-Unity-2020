using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    private PickUpPowerUp _pickUpPowerUp;

    public float powerUpForce;

    private void Start()
    {
        _pickUpPowerUp = GetComponent<PickUpPowerUp>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && _pickUpPowerUp.hasPowerUp)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - this.transform.position;
            enemyRigidbody.AddForce(awayFromPlayer * powerUpForce, ForceMode.Impulse);
            Debug.Log("El jugador a colisionado con" + collision.gameObject + "y tiene el Power Up a" + _pickUpPowerUp.hasPowerUp);

        }
    }
}
