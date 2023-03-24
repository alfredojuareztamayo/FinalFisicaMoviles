using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LoadScene : MonoBehaviour
{
    public List<string> dialogos = new List<string>();
    private int randomNumber;
    private int randomDialoge;
    public List<GameObject> BackGrounds = new List<GameObject>();
    public TMP_Text m_Text;
    
    void Start()
    {
       
        randomNumber = Random.Range(0,3);
        randomDialoge = Random.Range(0, dialogos.Count);
      //  Debug.Log(dialogos.Count);
        // m_Text.text = dialogos[randomDialoge];
    }

    // Update is called once per frame
    void Update()
    {
        ChangeBackground();
    }

    public void ChangeBackground()
    {
        switch (randomNumber)
        {
            case 0:
                BackGrounds[randomNumber].gameObject.SetActive(true);
                m_Text.text = dialogos[randomDialoge];
                break;
            case 1:
                BackGrounds[randomNumber].gameObject.SetActive(true);
               m_Text.text = dialogos[randomDialoge];
                break;
            case 2:
                BackGrounds[randomNumber].gameObject.SetActive(true);
                m_Text.text = dialogos[randomDialoge];
                break;
        }
    }
    public void ChangeNumber()
    {
        randomNumber = Random.Range(0, 3);
        randomDialoge = Random.Range(0, dialogos.Count);
        ChangeBackground();
        Debug.Log(randomNumber);
    }
}
