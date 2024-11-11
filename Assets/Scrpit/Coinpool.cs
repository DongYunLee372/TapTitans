using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coinpool : MonoBehaviour
{
    public GameObject coinPrefabs;
    public int poolsize = 20;

    private Queue<GameObject> coinpool = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<poolsize; i++)
        {
            GameObject coin = Instantiate(coinPrefabs);
            coin.SetActive(false);
            coinpool.Enqueue(coin);
            
        }
    }
    public GameObject GetCoin(Vector3 position)
    {
        if(coinpool.Count>0)
        {
            GameObject coin = coinpool.Dequeue();
            coin.transform.position = position;
            coin.SetActive(true);
            return coin;
        }
        else
        {
            GameObject coin = Instantiate(coinPrefabs, position, Quaternion.identity);
            return coin;
        }
    }

    public void ReturnCoin(GameObject coin)
    {
        coin.SetActive(false);
        coinpool.Enqueue(coin);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
