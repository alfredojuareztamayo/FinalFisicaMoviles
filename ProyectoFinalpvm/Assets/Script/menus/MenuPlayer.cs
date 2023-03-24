using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MenuPlayer : MonoBehaviour
{
    [Header("Botones")]
    public GameObject Controllers;
    public GameObject Save;
    public GameObject Exit;
    public GameObject Items;
    public GameObject NextButtom;
    public GameObject FormerButtom;
    [Header("ListaDeControles")]
    public List<string> controllers = new List<string>();
    int index;
    int maxIndex;

    [Header("Texto")]
    public TMP_Text M_Text;

    [Header("Items")]
    public List <GameObject> m_image = new List<GameObject>();
    GameObject DataPlayer;
    PlayerManagerData PDM;
     int indexitem;
    public int item1;
    public int item2;
    public int item3;
    public int item4;
    public int item5;
    public int item6;
    public int item7;
    public int item8;
    public int item9;


    [Header("Menus")]
    public GameObject itemMenu;
    public GameObject MenuPrincipal;
    //public Image image;
    void Start()
    {
        index = 0;
        maxIndex = controllers.Count;
        DataPlayer = GameObject.FindGameObjectWithTag("Data");
        PDM = DataPlayer.GetComponent<PlayerManagerData>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckForItems();
    }
    

    public void ButtomControllers()
    {
        NextButtom.SetActive(true);
        FormerButtom.SetActive(true);
        M_Text.text = controllers[index];
    }
    public void NextCommand()
    {
      
       if(index == maxIndex - 1)
        {
           
            M_Text.text = controllers[index];
        }
        else
        {
            index++;
            M_Text.text = controllers[index];
        }
       if(index >= maxIndex)
        {
            index = maxIndex;
        }
    }
    public void FormerCommand()
    {
        Debug.Log("Boton former sirve");
        if (index == 0)
        {
            index = 0;
            M_Text.text = controllers[index];
        }
        if (index > 0)
        {
            index--;
            M_Text.text = controllers[index];
        }
         
    }
    public void Guardar()
    {
        NextButtom.SetActive(false);
        FormerButtom.SetActive(false);
        Debug.Log("Guardar");
    }
    public void Salir()
    {
        NextButtom.SetActive(false);
        FormerButtom.SetActive(false);
        Application.Quit();
    }

    public void ActiveItemMenu()
    {
        NextButtom.SetActive(false);
        FormerButtom.SetActive(false);
        MenuPrincipal.SetActive(false);
        itemMenu.SetActive(true);

    }
    public void MenuPrincipalMenu()
    { 
        
            MenuPrincipal.SetActive(true);
            itemMenu.SetActive(false);
     }
    public void LoadImage(int id)
    {
       
      
        foreach(GameObject item in m_image)
        {
            indexitem++;
            if (indexitem == id)
            {
                item.SetActive(true);
                indexitem = 0;
                break;
            }
        }
       
    }

    public void CheckForItems()
    {
        item1 = PDM.GetIdItem1();
        item2 = PDM.GetIdItem2();
        item3 = PDM.GetIdItem3();
        item4 = PDM.GetIdItem4();
        item5 = PDM.GetIdItem5();
        item6 = PDM.GetIdItem6();
        item7 = PDM.GetIdItem7();
        item8 = PDM.GetIdItem8();
        item9 = PDM.GetIdItem9();
        if (item1 == 1)
        {
            LoadImage(item1);
        }
        if (item2 == 2)
        {
            LoadImage (item2);
           // Debug.Log("Se seteo y gett correcto 2");
        }
        if (item3 == 3)
        {
            LoadImage(item3);
        }
        if(item4 == 4)
        {
            LoadImage(item4);
        }
        if (item5 == 5)
        {
            LoadImage(item5);
        }
        if(item6 == 6)
        {
            LoadImage(item6);
        }
        if( item7 == 7)
        {
            LoadImage(item7);
        }
        if (item8 == 8)
        {
            LoadImage(item8);
        }
        if(item9 == 9)
        {
            LoadImage(item9);
        }
    }
}
