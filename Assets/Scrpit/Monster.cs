using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public int currentlv = 0;
    public int Level = 0;
    public int Hp=0;
    public float delaytime = 0f;

    public Animator monsteranimator;


    // Start is called before the first frame update
    void Start()
    {    

        monsteranimator = GetComponent<Animator>();
        Hp = Gamemanager.Instance.Level * 30;
        Debug.Log(Hp);
    }

    // Update is called once per frame
    void Update()
    {
        Takedamage();
    }
        public void Takedamage()
    {

        delaytime += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && delaytime > 0.25f)
        {
            Hp = Hp - Gamemanager.Instance.playerdamage;
            monsteranimator.SetBool("Hit", true);
            Debug.Log(Hp);

        }
        else
        {
           monsteranimator.SetBool("Hit", false);
        }
        if(Hp<=0)
        {
            Die();
            Changemonster();
        }
    }
    public void Die()
    {
        Gamemanager.Instance.LevelUP();
        Hp = Gamemanager.Instance.Level * 30;
    }

    public void Changemonster()
    {
        Gamemanager.Instance.Gamestart(2);
        Destroy(this.gameObject);
    }
}
