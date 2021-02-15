using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E09 : MonoBehaviour
{
    private int valor;
    private int a = 10;
    private int b;
    private int edad = 19;
    private string texto;

    // Start is called before the first frame update
    void Start()
    {
        valor = valor + 1;
        valor += 1;
        valor++;

        Debug.Log(valor);

        b = a--;
        Debug.Log("a = " + a + "\nb = " + b);

        texto = (edad >= 18) ? "Mayor de edad": "Menor de edad";
        Debug.Log(texto);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
