using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadLevel 
{
    public static string siguienteNivel;

    public static void NivelLoad(string nombre)
    {
        siguienteNivel= nombre;
        SceneManager.LoadScene("ScenaCarga");
    }
}
