using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamestart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GoGo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GoGo()
    {
        Gamemanager.Instance.Gamestart(1);
    }
}
