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
    public Vector3 target; // 코인이 향하는 목표 (플레이어 등)
    private bool drop = false;

    // Start is called before the first frame update
    void Start()
    {
        main = Camera.main;
        rand = Random.Range(-3.5f, 3.5f);
        targ = new Vector3(rand, -1f, 0);
        startPosition = transform.position;
        original = transform.position;
        coinpool = FindObjectOfType<Coinpool>(); //풀을 찾아 참조
        Setpos();

    }

    // Update is called once per frame
    void Update()
    {
        DropCoin();
    }

    public void Setpos()
    {
        // 이동 경로의 포인트 설정
        Vector3[] path = new Vector3[]
        {
           startPosition,           //시작점
            (startPosition+targ)/2, //두점사이의 중간값을 계산 
            targ                    //끝점
        };

        // 경로를 따라 1초 동안 이동, 경로 유형은 CatmullRom으로 설정
        transform.DOPath(path, 1f, PathType.CatmullRom).SetEase(Ease.Linear);
    }
    public void Setpos1()
    {
        // 이동 경로의 포인트 설정
        Vector3[] path = new Vector3[]
        {
           startPosition,           //시작점
            (startPosition+target  )/2, //두점사이의 중간값을 계산 
            target                    //끝점
        };

        // 경로를 따라 1초 동안 이동, 경로 유형은 CatmullRom으로 설정
        transform.DOPath(path, 1f, PathType.CatmullRom).SetEase(Ease.Linear).OnComplete(() =>
        {
            // 목표 지점에 도달했을 때 실행할 코드
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
