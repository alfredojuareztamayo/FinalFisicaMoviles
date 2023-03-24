using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeDialoge : MonoBehaviour
{
    public List<string> dialogues = new List<string>();
    int indexTotal;
    int m_contador;
    public TMP_Text m_text;
    public GameObject startButtom;
    float coldTime = 0;

    void Start()
    {
        indexTotal = dialogues.Count;
        m_contador = 0;
        m_text.text = dialogues[m_contador];
        StartCoroutine(MostrarCaracter(dialogues[m_contador]));
      
    }

    // Update is called once per frame
    void Update()
    {
        coldTime += Time.deltaTime;
       // Debug.Log(coldTime);
    }
    public void ChangeTextRight() //Funcion para ir cmabiando de frase de la lista
    {
       if(coldTime > 2f)
        {
            if (m_contador == (indexTotal - 1)) //Al llegar a la ultima frase de la lista se activa el boton que me manda al inicio del juego
            {
              //  Debug.Log("Sirvo");
                startButtom.SetActive(true);
                //m_text.text = dialogues[m_contador];
                //StartCoroutine(MostrarCaracter(dialogues[m_contador]));

            }
            else //S aun no se llega a la ultima frase, 
            {

                m_contador++;
                m_text.text = dialogues[m_contador];
                StartCoroutine(MostrarCaracter(dialogues[m_contador]));
               // Debug.Log(m_contador);
            }
            if (m_contador >= indexTotal)
            {
                m_contador = indexTotal;
            }
            coldTime = 0;
        }
       
    }
    public void ChangeTextLeft() //No lo use solo para probar
    {
        m_contador--;
        m_text.text = dialogues[m_contador];
    }
    public void skipDialogues()
    {
        m_contador = indexTotal - 1;
        m_text.text = dialogues[m_contador];
        StartCoroutine(MostrarCaracter(dialogues[m_contador]));
       // Debug.Log("Sirvo");
        startButtom.SetActive(true);
    }
    IEnumerator MostrarCaracter(string TextoToShow)
    {
        m_text.text = "";
        foreach(char caracter in TextoToShow.ToCharArray())
        {
            m_text.text += caracter;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
