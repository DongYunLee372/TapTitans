using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : SingleTon<Gamemanager>
{
    public GameObject monster;
    public GameObject Player;
    public int Level=1;
    public int PlayerCoin = 0;
    public int playerdamage = 1;
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
        Level++;
    }
    public void GetCoin()
    {
        PlayerCoin+=Level;
    }
}
