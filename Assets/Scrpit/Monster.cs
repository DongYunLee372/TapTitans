using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public int currentlv = 1;
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
       
    }

     public void Takedamage()
     {
        StartCoroutine(Hitaction());
        Hp = Hp - Gamemanager.Instance.playerdamage;
        Debug.Log(Hp);
        if (Hp <= 0)
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
        Gamemanager.Instance.Monstercreate(Gamemanager.Instance.Level);
        Destroy(this.gameObject);
    }

    private IEnumerator Hitaction()
    {
        monsteranimator.SetBool("Hit", true);
        // 현재 애니메이션 길이를 가져와 그 시간만큼 대기
        float animationLength = monsteranimator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(animationLength);

        monsteranimator.SetBool("Hit", false);
    }
}
