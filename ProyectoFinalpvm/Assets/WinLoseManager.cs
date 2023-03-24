using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseManager : MonoBehaviour
{
    GameObject player;
    GameObject DataManager;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        DataManager = GameObject.FindGameObjectWithTag("Data");
        
    }
    public void MenuLevel()
    {
        SceneManager.LoadScene("Menu");
        Destroy(player);
        Destroy(DataManager);

    }
    
}
