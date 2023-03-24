using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public  class PlayerManagerData : MonoBehaviour
{
    // public static PlayerManager instance;
    int item1;
    int item2;
    int item3;
    int item4;
    int item5;
    int item6;
    int item7;
    int item8;
    int item9;
    public int m_life;
    int totalItems;
    int lvl1;
    int lvl2;
 
    // Update is called once per frame
    public void Awake()
    {
        m_life = 100;
        
        DontDestroyOnLoad(this);
    }
    

    void Update()
    {
        Die();
       
    }

    public void Win(int max)
    {
        if (max == 4)
        {
            Debug.Log("Ganaste");
            SceneManager.LoadScene("Win");
            
        }
    }
    public int SetLvl1(int lvl)
    {
        lvl1 = lvl;
        return lvl1;
    }
    public int SetLvl2(int lvl)
    {
        lvl2 = lvl;
        return lvl2;
    }   
    public int GetLvl1()
    {
        return lvl1;
    }
    public int GetLvl2()
    {
        return lvl2;
    }
    public  int SetVida(int life)
    {
        m_life = life;
        return m_life;
    }

    public  int GetVida()
    {

        return m_life;
    }
    public void Die()
    {
        if(m_life <= 0) 
        {
            Debug.Log("Me mori");

        }
    }
    public int SetItemsData(int id)
    {
        if (id == 1)
        {
            item1 = id;
            return item1;
        }
        if (id == 2)
        {
            item2 = id;
            return item2;
        }
        if (id == 3)
        {
            item3 = id;
            return item3;
        }
        if (id == 4)
        {
            item4 = id;
            return item4;
        }
        if(id == 5)
        {
            item5 = id;
            return item5;
        }
        if (id == 6)
        {
            item6 = id;
            return item6;
        }
        if (id == 7)
        {
            item7 = id;
            return item7;
        }
        if(id==8)
        {
            item8 = id;
            return item8;
        }
        if(id==9)
        {
            item9 = id;
            return item9;
        }
        return 0;

        
    }
    public int GetIdItem1()
    {
        return item1;
    }
    public int GetIdItem2()
    {
        return item2;
    }
    public int GetIdItem3()
    {
        return item3;
    }
    public int GetIdItem4()
    {
        return item4;
    }
    public int GetIdItem5()
    {
        return item5;
    }
    public int GetIdItem6()
    {
        return item6;
    }
    public int GetIdItem7()
    {
        return item7;
    }
    public int GetIdItem8()
    {
        return item8;
    }
    public int GetIdItem9()
    {
        return item9;
    }
    
    public int setItemsTotal(int total)
    {
        totalItems = total;
        return totalItems;
    }
    public int getItemsTotal()
    {
        return totalItems;
    }
}
