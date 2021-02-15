using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E12 : MonoBehaviour
{
    private string[] mensajes = { "esto es", "un ejemplo", "de como",
        "se pueden", "recorrer todos", "los elementos", "de un array","digan hola" };
    private int contador = 0;
    // Start is called before the first frame update
    void Start()
    {
        while (contador < mensajes.Length)
        {
            Debug.Log(mensajes[contador]);
            contador++;
           
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
