using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popItems : MonoBehaviour
{
    //public GameObject popItemsPrefab;
    public List<GameObject> popItem = new List<GameObject>();
    float currentTime;
    float spawnItem = 2;
    bool CloseWindows = false;
    bool activeTime = false;
    int lastId;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            CloseWin();
        }
       

    }
    public void pop(int ID) //funcion para aparecer una frase y que item se agarro
    {
        lastId = ID;
        int index = ID - 1;
        switch (ID)
        {
            
            case 1:
                    popItem[index].SetActive(true);
                   // activeTime = true;
                    Time.timeScale = 0;
                  
 

                break;
            case 2:
                popItem[index].SetActive(true);
                // activeTime = true;
                Time.timeScale = 0;
              
                break;
            case 3:
                popItem[index].SetActive(true);
                // activeTime = true;
                Time.timeScale = 0;
                break;
                case 4:
                popItem[index].SetActive(true);
                // activeTime = true;
                Time.timeScale = 0;
                break;
            case 5:
                popItem[index].SetActive(true);
                // activeTime = true;
                Time.timeScale = 0;
                break;
            case 6:
                popItem[index].SetActive(true);
                // activeTime = true;
                Time.timeScale = 0;
                break;
                case 7:
                popItem[index].SetActive(true);
                // activeTime = true;
                Time.timeScale = 0;
                break;
                case 8:
                popItem[index].SetActive(true);
                Time.timeScale = 0;
                break;
               
                case 9:
                popItem[index].SetActive(true);
                Time.timeScale = 0;
                break;
             
        }
       
    }
    public void CloseWin()
    {
        popItem[lastId-1].SetActive(false);
        Time.timeScale = 1;
    }
}
