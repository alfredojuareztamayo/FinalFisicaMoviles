using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;
using System.IO;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Variables for the movement")]
    public float MoveH;
    public float MoveV;
    public float speed = 2f;
    public float angleRotation;
    Rigidbody rb;
    public GameObject hike;
    public GameObject Running;

    [Header("Vectores")]
    public Vector3 direction;
    public Vector3 movement;

    [Header("Animation")]
    Animator animator;

    [Header("DataPlayer")]
    public PlayerManagerData pm;
    public int Vida;
    Vector3 posInicial = new Vector3(20,1,20);
    public int Id;
    string escena = LoadLevel.siguienteNivel;
    string escenaLast;

    [Header("countLevel")]
    int lvl1count = 0;
    int lvl2count = 0;
    int lvl3count = 0;

    [Header("DataLife")]
    public Scrollbar lifeScroll;
    public float lifeForScroll;
    public float MaxLife;

    [Header("MenuPlayer")]
    public GameObject menuPlayer;
    public MenuPlayer menu;
    public int ActivateMenu = -1;

    [Header("ItemsCollect")]
    public bool collectable = false;
    public GameObject panelItem;
    public bool TakingItem = false;
    public TMP_Text item_text;
    GameObject DataPlayer;
    PlayerManagerData PDM;
    public int item1;
    public int item2;
    public int item3;
    public int item4;
    public int item5;
    public int item6;
    public int item7;
    public int item8;
    public int item9;
    public int totalItems;

    [Header("Guide")]
    public bool TalkigGuide = false;
    public bool ActiveGuide = false;
    public bool DesactivarActivarPanel = true;
   public int indexGuide = 0;
    public GameObject panelGuide;
    public TMP_Text _TextGuide;
    public float coldTimeGuide = 2f;
    public float currenTimeGuide;


    public void Awake()
    {
        DontDestroyOnLoad(this);
    }

    void Start()
    {  
        angleRotation = 150f;
        rb = GetComponent<Rigidbody>();
        animator= GetComponent<Animator>();
        Vida = pm.GetVida();
        //Debug.Log(Vida);
        MaxLife = 100;
        this.transform.position = posInicial;
        DataPlayer = GameObject.FindGameObjectWithTag("Data");
        PDM = DataPlayer.GetComponent<PlayerManagerData>();
        totalItems = PDM.getItemsTotal();
    }

    // Update is called once per frame
    void Update()
    {
        InstanciarMiPerroPersoanje();
        MoveFPC();
        SetAnimation();
        UIPlayer();
        Vida = pm.GetVida();
        totalItems = pm.getItemsTotal();

       
        if (Input.GetKeyDown(KeyCode.O))
        {
            Vida -= 10;
            
            pm.SetVida(Vida);
        }

     
    }
    private void FixedUpdate()
    {
        CollectItems();
        TalkGuide();
    }

    public void MoveFPC()
    {
        movement = Vector3.zero;
        MoveH = Input.GetAxis("Horizontal"); //Para que regrese un valor a 1 si se ueve en el axis horizontal
        MoveV = Input.GetAxis("Vertical"); //Regresa el valor de 1 si se mueve en el axis vertical
        if (MoveV != 0 || MoveH != 0)
        {
            direction = (transform.forward * MoveV) + ( transform.right * MoveH);
            direction.Normalize();

            movement = direction * speed;
           // Debug.Log(speed);
            transform.Rotate((transform.up * MoveH) * angleRotation * Time.fixedDeltaTime);
        }
        movement.y = rb.velocity.y;
        rb.velocity = movement;
    }

    public void SetAnimation()
    {
            Running.SetActive(false);
            hike.SetActive(false);


        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
           
            animator.SetBool("isWalking", true);
            animator.SetBool("isRunnig", false);
            animator.SetBool("isSneaking", false);

            speed = 6f;
        }
        else
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunnig", false);
            animator.SetBool("isSneaking", false);
        }
        if (Input.GetKey(KeyCode.RightShift) && Input.GetKey(KeyCode.W))
        {
            Debug.Log("Hola");
            speed = 10f;
            animator.SetBool("isRunnig", true);
            animator.SetBool("isSneaking", false);
            animator.SetBool("isWalking", false);
           Running.SetActive(true);
        }
        
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            speed = 2f;
            animator.SetBool("isSneaking", true);
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunnig", false);
            hike.SetActive(true);
        }
        
    }
    public void InstanciarMiPerroPersoanje()
    {
        escenaLast = escena;
        escena = LoadLevel.siguienteNivel;
        //Debug.Log(escena);
        if (escena == "Level1" && lvl1count == 0)
        {
            this.transform.position = posInicial;
            lvl1count++;
        }
        if (escena == "SecondCircle" && lvl2count == 0)
        {
            this.transform.position = new Vector3(794,31,339);
            lvl2count++;
        }
        if (escena == "ThirdCircle" && lvl3count == 0)
        {
            this.transform.position = posInicial;
            lvl3count++;
        }
    }

    public void UIPlayer()
    {
        lifeForScroll = MaxLife;
       

        //Debug.Log(lifeForScroll);
        lifeScroll.size = Vida/MaxLife;

        if(Input.GetKeyDown(KeyCode.Escape)) 
        {
            ActivateMenu *= -1;

            switch (ActivateMenu)
            {
                case -1:
                    menuPlayer.SetActive(false);
                    Time.timeScale = 1;
                    break;
                    case 1:
                    menuPlayer.SetActive(true);
                    Time.timeScale = 0;
                    break;

            }
           
            //if(ActivateMenu == 1)
            //{
               
            //}
            //if(ActivateMenu == -1)
            //{
                
            //}
            
        }
    }
    
    public void CollectItems()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 50))
        {
            if(hit.collider.tag == "item" && collectable)
            {
                panelItem.SetActive(true);
                
                item_text.text = "Press [F] to collect the item";
                
                if (Input.GetKeyDown(KeyCode.F))  
                {
                    //  Debug.Log("Esta presionando F");
                   
                    TakingItem = true;
                    

                }
                else
                {
                    TakingItem = false;
                }
                   
                // Debug.DrawLine(ray.origin, hit.point);
                //Debug.Log("Te puedo agarrar");
            }
            else
            {
                panelItem.SetActive(false);
            }
           

        }
    }
    public void TalkGuide()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 50))
        {
            if (hit.collider.tag == "Guide" && TalkigGuide)
            {
               // Debug.Log("Entro a este if");
                if(DesactivarActivarPanel)
                {
                    panelGuide.SetActive(true);
                    _TextGuide.text = "Press [F] para hablar con el guia";
                }
        

               
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        ActiveGuide = true;
                        DesactivarActivarPanel = false;
                        panelGuide.SetActive(false);
                       
                    }
                    else
                    {
                        //  panelGuide.SetActive(true);
                        ActiveGuide = false;
                    }
    
            }
           
           


        }
    }


}
