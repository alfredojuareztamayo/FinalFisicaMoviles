using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollectItem : MonoBehaviour
{
    public int IdItem;
    public float distance;
    GameObject player;
    PlayerManager playerManager;
    GameObject Menu;
    MenuPlayer menuPlayer;
    GameObject popItem;
    popItems popItemScript;
    GameObject DataPlayer;
    PlayerManagerData PDM;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
       // Debug.Log(player.tag);
        playerManager = player.GetComponent<PlayerManager>();
        Menu = GameObject.FindWithTag("Menu");
        menuPlayer = Menu.GetComponent<MenuPlayer>();
        popItem = GameObject.FindWithTag("Menu");
        popItemScript = popItem.GetComponent<popItems>();
        DataPlayer = GameObject.FindGameObjectWithTag("Data");
        PDM = DataPlayer.GetComponent<PlayerManagerData>();

    }

    // Update is called once per frame
    void Update()
    {
        ActivateItemTiCollect();
        


    }

    public void ActivateItemTiCollect()
    {
        distance = Vector3.Distance(player.transform.position, this.transform.position);
        if (distance < 3f)
        {
            playerManager.collectable = true;
            ItemIsTaken();
            // Destroy(this.gameObject);
        }
        else
        {
            playerManager.collectable = false;
        }
    }
    public void ItemIsTaken()
    {
        if (playerManager.TakingItem)
        {
           // Debug.Log("Si entro a ItemIsTaken");
            menuPlayer.LoadImage(IdItem);
            popItemScript.pop(IdItem);
            playerManager.collectable = false;
            playerManager.TakingItem = false;
            PDM.SetItemsData(IdItem);
            playerManager.totalItems++;
            PDM.setItemsTotal(playerManager.totalItems);
            PDM.Win(playerManager.totalItems);
            Debug.Log(playerManager.totalItems);
            Destroy(this.gameObject);
            
        }
    }
}
