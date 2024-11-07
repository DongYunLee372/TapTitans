using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : SingleTon<Coin>
{
    // Start is called before the first frame update
    public Transform target; // ������ ���ϴ� ��ǥ (�÷��̾� ��)
    public Vector3 targ;
    public float duration = 1f; // �̵� �ð�
    private Vector3 startPosition;
    private Vector3 controlPoint;
    private float timeElapsed;
    private float rand;
    private bool drop = false;
    private float t;
    void Start()
    {
        rand = Random.Range(-6f, 6f);
        targ = new Vector3(rand, -2.5f, 0);
        startPosition = transform.position;
        controlPoint = startPosition + Vector3.up * 2f; // ������ ���̷� ������ ����
        timeElapsed = 0f;
    }

    void Update()
    {    
         t = timeElapsed / duration;

        if (drop == false)
        {
            // ������ � ���� ����
            Vector3 position = (1 - t) * (1 - t) * startPosition +
                               2 * (1 - t) * t * controlPoint +
                               t * t * targ;

            transform.position = position;

            if (t >= 1f)
            {
                // Destroy(gameObject);
            }
            else
            {
                timeElapsed += Time.deltaTime;
            }
        }
            DropCoin(); 

        if ( drop == true)
        {
            

            Vector3 position = (1 - t) * (1 - t) * startPosition +
                             2 * (1 - t) * t * controlPoint +
                             t * t * target.position;

            transform.position = position;

            // ��ǥ ������ �����ϸ� ������Ʈ ����
            if (t >= 1f)
            {
                 Destroy(gameObject);
            }
            else
            {
                timeElapsed += Time.deltaTime;
            }
        }
    }
    public void DropCoin()
    {
        if (Input.GetMouseButtonDown(0) )
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.position == this.transform.position)
                {
                    drop = true;
                    timeElapsed = 0f;
                    t = 0f;
                    startPosition = transform.position;
                    controlPoint = startPosition + Vector3.up * 2f;

                    GameObject obj1 = GameObject.Find("Cube");
                    Debug.Log(obj1);
                    target = obj1.transform;
                }
            }
        }
    }
    public void Create(Vector3 pos)
    {
       
    }
}
