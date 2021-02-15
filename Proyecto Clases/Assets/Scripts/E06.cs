using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E06 : MonoBehaviour
{
    
    public string[] cadena = { "Llovera", "No llovera", "Tormenta", "No Tormenta", "Calma" };

    // Start is called before the first frame update
    void Start()
    {
        

        int numeroAleatorio = Random.Range(0, 5);

        Debug.Log(cadena[numeroAleatorio]);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
