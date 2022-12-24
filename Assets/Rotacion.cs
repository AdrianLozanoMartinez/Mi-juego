using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacion : MonoBehaviour
{
    public Vector3 speed; //vector3 3 eje, vector2 2 eje y si es uno float del tiron, si fuera uno se pone float del tiron -> los ejes son x,y,z
                          //speed es el nombre que le pone

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(speed*Time.deltaTime, Space.Self); //Gira sobre el eje del objecto para que se respete el giro esté en la posición que esté
    }
}
