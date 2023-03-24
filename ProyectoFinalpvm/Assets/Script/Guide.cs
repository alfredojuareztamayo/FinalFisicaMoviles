using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Guide : MonoBehaviour
{
    public List<string> guides = new List<string>();
    PlayerManager playerManager;
    GameObject Player;
    public GameObject panleGuide;
    public TMP_Text guide_text;
   public float distance;
    int indexList;
    public GameObject portal;
    public GameObject item;
    
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerManager = Player.GetComponent<PlayerManager>();
        indexList = guides.Count; 
            }

    // Update is called once per frame
    void Update()
    {
        
        DisctanceGuide();
    }
    public void ChatGuide()
    {
        if (playerManager.ActiveGuide)
        {
            if(playerManager.indexGuide == indexList - 1)
            {
                panleGuide.SetActive(false);
                playerManager.indexGuide = 0;
                portal.SetActive(true);
                item.SetActive(true);
               //playerManager.DesactivarActivarPanel = true;

            }
            else
            {
                panleGuide.SetActive(true);
                guide_text.text = guides[playerManager.indexGuide];
                playerManager.indexGuide++;
            }
            
        }
    }
    public void DisctanceGuide()
    {
        distance = Vector3.Distance(Player.transform.position, this.transform.position);
        if (distance < 5f)
        {
            playerManager.TalkigGuide = true;
            ChatGuide();
            //Debug.Log(playerManager.TalkigGuide);
        }
        else
        {
            playerManager.TalkigGuide = false;
        }
    }

}
