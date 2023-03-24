using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerClock : MonoBehaviour
{
    [SerializeField] int min, seg;
    [SerializeField] TMP_Text tiempo;

    private float restante;
    private float vidaRestante;
    private bool OnGoing;
    int vidaLess;
    GameObject player;
    GameObject DataManager;
    PlayerManagerData playerManagerData;
    private void Awake()
    {
        restante = (min * 60) + seg;
        OnGoing = true;
    }
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        DataManager = GameObject.FindGameObjectWithTag("Data");
        playerManagerData = DataManager.GetComponent<PlayerManagerData>();
        vidaLess = playerManagerData.GetVida();

    }


    void Update()
    {
        if (OnGoing)
        {
            restante -= Time.deltaTime;
            vidaRestante += Time.deltaTime;
            if(vidaRestante > 60) 
            {
                vidaLess -= 5;
                playerManagerData.SetVida(vidaLess);
                vidaRestante = 0;
            }
            if (restante < 1)
            {
                OnGoing = true;
                Debug.Log("LOSE");
                SceneManager.LoadScene("Lose");
            }
            int tempMin = Mathf.FloorToInt(restante / 60);
            int tempSeg = Mathf.FloorToInt(restante % 60);
            tiempo.text = string.Format("{00:00}:{01:00}", tempMin, tempSeg);
        }

    }
}
