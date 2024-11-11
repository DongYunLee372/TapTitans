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
    private Coinpool coinpool;

    // Start is called before the first frame update
    void Start()
    {    

        monsteranimator = GetComponent<Animator>();
        Hp = Gamemanager.Instance.C_lv * 30;
        Debug.Log(Hp);
        coinpool = FindObjectOfType<Coinpool>();
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
        for (int i = 0; i < Gamemanager.Instance.C_lv; i++)
        {
            coinpool.GetCoin(this.gameObject.transform.position + Vector3.up * 1f);
        }
        Gamemanager.Instance.LevelUP();
       
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
