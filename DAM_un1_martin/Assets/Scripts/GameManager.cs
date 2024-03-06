using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    //Declaramos una variable para almacenar la mejor puntuaci�n
    public int mejorPuntuacion;
    //Declaramos otra variable para almacenar la puntuaci�n actual
    public int puntuacionActual;
    //Declaramos otra variable para almacenar el nivel actual y lo inicializamos con el nivel 0
 public int nivelActual = 0;
    //Declaramos una instancia de GameManager
    public static GameManager singleton;
        // Llamamos al m�todo Awake, porque queremos que antes de que comience con Start, lo primero que haga
     //sea mirar si no hay GameManager y en ese caso crearlo
     //o mirar si hay m�s de un GameManager y en este caso borrar todos menos uno
 void Awake()
    {
        //si no tenemos ning�n GameManager
        if (singleton == null)
        {
            //nuestro GameManager ser� �ste
            singleton = this;
        }
        //si el GameManager no es este
        else if (singleton != this)
        {
            //Lo destruimos
            Destroy(gameObject);
        }
    }
    //Para gestionar cu�ndo pasamos de nivel
    public void PasarNivel()
    {
    }
    //Para resetear el nivel por si damos con alg�n obst�culo
    public void RestartNivel()
    {
    }
    //Para a�adir puntuaci�n pas�ndole la puntuaci�n que tenemos que a�adir
    public void addPuntuacion(int puntuacionToAdd)
    {
        //sumamos a nuestra puntuaci�n actual la que le tenemos que a�adir
        puntuacionActual += puntuacionToAdd;
        //comprobamos si nuestra puntuaci�n actual es mejor que nuestra mejor puntuaci�n
        if (puntuacionActual > mejorPuntuacion)
        {
            //en este caso nuestra mejor puntuaci�n pasar�a a ser la actual
            mejorPuntuacion = puntuacionActual;
        }
    }
}
