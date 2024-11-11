using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoTweenCoin : MonoBehaviour
{
    private Vector3 original;
    private Vector3 startPosition;
    public Vector3 targ;
    private float rand;
    private Coinpool coinpool;
    public Transform target; // ������ ���ϴ� ��ǥ (�÷��̾� ��)
    private bool drop = false;

    // Start is called before the first frame update
    void Start()
    {
        rand = Random.Range(-6f, 6f);
        targ = new Vector3(rand, -2.8f, 0);
        startPosition = transform.position;
        original = transform.position;
        coinpool = FindObjectOfType<Coinpool>(); //Ǯ�� ã�� ����
        Setpos();

    }

    // Update is called once per frame
    void Update()
    {
        DropCoin();
    }

    public void Setpos()
    {
        // �̵� ����� ����Ʈ ����
        Vector3[] path = new Vector3[]
        {
           startPosition,           //������
            (startPosition+targ)/2, //���������� �߰����� ��� 
            targ                    //����
        };

        // ��θ� ���� 1�� ���� �̵�, ��� ������ CatmullRom���� ����
        transform.DOPath(path, 1f, PathType.CatmullRom).SetEase(Ease.Linear);
    }
    public void Setpos1()
    {
        // �̵� ����� ����Ʈ ����
        Vector3[] path = new Vector3[]
        {
           startPosition,           //������
            (startPosition+target.transform.position  )/2, //���������� �߰����� ��� 
            target.transform.position                    //����
        };

        // ��θ� ���� 1�� ���� �̵�, ��� ������ CatmullRom���� ����
        transform.DOPath(path, 1f, PathType.CatmullRom).SetEase(Ease.Linear).OnComplete(() =>
        {
            // ��ǥ ������ �������� �� ������ �ڵ�
            Resetting();
            coinpool.ReturnCoin(this.gameObject);

        });
    }

    public void DropCoin()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.position == this.transform.position)
                {
                    drop = true;
                    startPosition = transform.position;
                  
                    GameObject obj1 = GameObject.Find("Cube");
                    target = obj1.transform;
                    Setpos1();
                    Gamemanager.Instance.GetCoin();
                }
            }
        }
    }

    public void Resetting()
    {
        rand = Random.Range(-6f, 6f);
        targ = new Vector3(rand, -2.8f, 0);
        startPosition = transform.position;
    }
   
    private void OnEnable()
    {

        Setpos();
    }
}
