using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkCollisions : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            //El projectil colisiona con el animal 
            Destroy(this.gameObject); //Destruye la bala
            Destroy(other.gameObject); //Destruye el animal
        }
    }

}
