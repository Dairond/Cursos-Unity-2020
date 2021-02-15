using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E05 : MonoBehaviour
{
    public string saludo = "Hola mundo";
    public int a = 42;
    public int b = -96;
    public string nombre = "Adrian Cangahuala";
    public int edad = 17;
    public float pi = 3.14159f;
    public bool dia = false;


    // Start is called before the first frame update
    void Start()
    {
        nombre = "Deivins";
        edad = 16;

        Debug.Log(saludo);
        Debug.Log(a);
        Debug.Log(b);
        Debug.Log(nombre);
        Debug.Log(edad);
        Debug.Log(pi);
        Debug.Log(dia);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
