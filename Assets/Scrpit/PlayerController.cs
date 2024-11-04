using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : SingleTon<PlayerController>
{
    // Start is called before the first frame update
    public Animator m_animator;
    private int m_currentAttack = 0;
    public float delaytime=0f;
    void Start()
    {
        m_animator = GetComponent<Animator>();
        Gamemanager.Instance.Gamestart(1);
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
           // Monster.Instance.Takedamage();

            m_currentAttack++;
            if (m_currentAttack > 3)
                m_currentAttack = 1;

            // Reset Attack combo if time since last attack is too large
            if (delaytime > 1.0f)
                m_currentAttack = 1;

            // Call one of three attack animations "Attack1", "Attack2", "Attack3"
            m_animator.SetTrigger("Attack" + m_currentAttack);
            
            // Reset timer
            delaytime = 0.0f;

            
        }
        else
        {
            // Prevents flickering transitions to idle
            m_animator.SetInteger("AnimState", 0);
        }
    }
    private void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit))
        {
            Debug.Log(hit.transform.name);
        }
    }
}
