using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Loading : MonoBehaviour
{
    public TMP_Text TextLoading;
    void Start()
    {
        string nivelCargar = LoadLevel.siguienteNivel;
        StartCoroutine(IniciarCarga(nivelCargar));
    }
    IEnumerator IniciarCarga(string nivel)
    {
        yield return new WaitForSeconds(1f);
        AsyncOperation operation = SceneManager.LoadSceneAsync(nivel);
        operation.allowSceneActivation = false;

        while(!operation.isDone)
        {
            if(operation.progress >= 0.9f)
            {
                TextLoading.text = "Press any Key to continue";
                if (Input.anyKey)
                {
                    operation.allowSceneActivation = true;
                }
            }
            yield return null;
        }
    }

   
}
