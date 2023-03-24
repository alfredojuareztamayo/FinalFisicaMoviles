using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string nivelToChange;
    public void iniciar()
    {
        LoadLevel.NivelLoad(nivelToChange);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Me presiono");
    }

}
