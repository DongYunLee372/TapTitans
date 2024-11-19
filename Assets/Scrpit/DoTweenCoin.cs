using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoTweenCoin : MonoBehaviour
{
    private Camera main;
    private Vector3 original;
    private Vector3 startPosition;
    public Vector3 targ;
    private float rand;
    private Coinpool coinpool;
    public Vector3 target; // ������ ���ϴ� ��ǥ (�÷��̾� ��)
    private bool drop = false;

    // Start is called before the first frame update
    void Start()
    {
        main = Camera.main;
        rand = Random.Range(-3.5f, 3.5f);
        targ = new Vector3(rand, -1f, 0);
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
            (startPosition+target  )/2, //���������� �߰����� ��� 
            target                    //����
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
                  
                    GameObject obj1 = GameObject.Find("UIcoin");
                    RectTransform uiRect = obj1.GetComponent<RectTransform>();
                    Vector3 screenPos = RectTransformUtility.WorldToScreenPoint(main, uiRect.position);
                    Vector3 worldTargetPos = main.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, main.nearClipPlane));
                    target = worldTargetPos;
             
                    // Camera.main.WorldToScreenPoint(obj1.transform.position);
                    Setpos1();
                    Gamemanager.Instance.GetCoin();
                }
            }
        }
    }

    public void Resetting()
    {
        rand = Random.Range(-3.5f, 3.5f);
        targ = new Vector3(rand, -1f, 0);
        startPosition = transform.position;
    }
   
    private void OnEnable()
    {

        Setpos();
    }
}
