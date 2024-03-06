using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public class BolaController : MonoBehaviour
{
    //Creamos un RigidBody
    public Rigidbody rb;
    //Necesitamos un impulso para controlar cuánto bota la bola
    public float fuerzaImpulso = 3f;
    //Añadimos un boolean para controlar que bote una vez sólo sobre una pieza (un quesito), no sobre dos
    //queremos que cuando bote una vez, no pueda botar otra vez hasta tantos segundos
    public bool ignorarSiguienteColision;
    //¿Cuándo queremos que bote? Cuando toque el HollyTop o un HollyLevel
    //C# trae un método para esto: onCollisionEnter, cuando nuestra pelota entre en colisión con algo se ejecuta este método
    private void OnCollisionEnter(Collision colision)
    {
        //En el momento que bote una vez, salimos del método
        if (ignorarSiguienteColision)
        {
            return;
        }
        //Cuando colisionemos con algo, le añadimos velocidad de Vector3 a cero para evitar problemas de velocidad al colisionar
        //Vector3 son las tres coordenadas en cuanto a posicion
         rb.velocity = Vector3.zero;
        //Cuando choque queremos que vaya hacia arriba, por lo que le añadimos fuerza en el eje de la Y queriendo que vaya para arriba
        //lo que hemos declarado en fuerzaImpulso
        //El ForceMode Impulse añade el impulso del rigibody usando su masa
        rb.AddForce(Vector3.up * fuerzaImpulso, ForceMode.Impulse);
        //cuando ya ha botado una vez ponemos el boolean a true
        ignorarSiguienteColision = true;
        //Llamamos al método de permitirSiguienteColision() para que vuelva a botar la bola pasados 0.2 ms
        Invoke("PermitirSiguienteColision", 0.2f);
    }
    //Para controlar que pueda volver a botar pasados unos cuantos segundos
    private void PermitirSiguienteColision()
    {
        ignorarSiguienteColision = false;
    }
}

