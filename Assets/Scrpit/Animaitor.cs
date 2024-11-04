using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animaitor : SingleTon<Animaitor>
{
    public Animator P_animator;
    // Start is called before the first frame update
    void Start()
    {
        P_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerAttack()
    {
        P_animator.SetTrigger("Attack" + 1);
        Debug.Log("АјАн");
    }
}
