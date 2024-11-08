using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : SingleTon<Gamemanager>
{
    public GameObject monster;
    public GameObject Player;
    public int Level=1;
    public int Bosslv = 1;
    public int C_lv = 1;
    public int PlayerCoin = 0;
    public int playerdamage = 1;
    public bool nextstage = false;
    // Start is called before the first frame update
    void Start()
    {
        
         
        
      //  monster = Monster.Instance.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Gamestart(int num)
    {
        monster = Resources.Load<GameObject>("Prefabs/Monster"+ num);
        Player = Resources.Load<GameObject>("Prefabs/HeroKnight");

        Instantiate(Player);
        Instantiate(monster);
    }
    public void Monstercreate(int num)
    {
        monster = Resources.Load<GameObject>("Prefabs/Monster" + num);
        Instantiate(monster);
    }
    public void LevelUP()
    {
        if (Level < 4)
        {
            Level++;
        }
        else if ( nextstage==false)
        {
            Level = 1;
            Bosslv++;
            nextstage = true;
        }
        else
        {
            Level = 1;
        }
    }
    public void Clear()
    {
        C_lv++;
        nextstage = false;
        Level = 1;
    }
    public void GetCoin()
    {
        PlayerCoin+=1;
    }
}
