using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : SingleTon<PlayerController>
{
    // Start is called before the first frame update
    public bool attack = false;
    public Animator m_animator;
    private int m_currentAttack = 0;
    public float delaytime=0f;
    void Start()
    {
        m_animator = GetComponent<Animator>();
     
    }

    // Update is called once per frame
    void Update()
    {
        Attack();

    }
    private void Attack()
    {
        delaytime += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && delaytime > 0.25f)
        {

            Target();

             m_currentAttack++;
            if (m_currentAttack > 3)
                m_currentAttack = 1;

        
            if (delaytime > 1.0f)
                m_currentAttack = 1;

         
            m_animator.SetTrigger("Attack" + m_currentAttack);
            
          
            delaytime = 0.0f;

            
        }
        else
        {
            // Prevents flickering transitions to idle
            m_animator.SetInteger("AnimState", 0);
        }
    }
    private void Target()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit))
        {
            GameObject monster = hit.transform.gameObject;
            Monster scrpit = monster.GetComponent<Monster>();

            if( scrpit !=null)
            {
                scrpit.Takedamage();
                
            }
            else
            {
                Debug.Log("scrpit 붙어있지 않습니다.");
            }
            
            Debug.Log(hit.transform.name);
        }
    }
}
