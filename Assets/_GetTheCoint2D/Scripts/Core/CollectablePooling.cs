using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablePooling : MonoBehaviour
{
    [SerializeField] GameObject _CoinPrefab;
    [SerializeField] Transform[] _CoinSpawnTransforms;
    [SerializeField] float _SpawnCoolDown = 2f;

    const int COIN_AMOUNT = 6;
    
    Queue<GameObject> _Coins;

    void Start()
    {
        _Coins = new Queue<GameObject>();

        for (int i = 0; i < COIN_AMOUNT; ++i)
        {
            GameObject _Coin = Instantiate(_CoinPrefab, _CoinSpawnTransforms[i].position, Quaternion.identity, transform);
            _Coin.SetActive(false);
            _Coins.Enqueue(_Coin);
        }

        StartCoroutine(SpawnCoinNumerator());
    }

    public GameObject GetCoinFromPool()
    {
        if(_Coins.Count > 0)
        {
            GameObject _Coin = _Coins.Dequeue();
            _Coin.SetActive(true);
            return _Coin;
        }
        return null;
    }

    public void ReturnToPool(GameObject _Coin)
    {
        if(_Coin != null)
        {
            _Coin.SetActive(false);
            _Coins.Enqueue(_Coin);    
        }
    }


    IEnumerator SpawnCoinNumerator()
    {
        while(true)
        {
            GameObject _Coin = GetCoinFromPool();

            if(_Coin != null)
            {
                yield return new WaitForSeconds(_SpawnCoolDown);
                ReturnToPool(_Coin);   
            }
            else
            {
                yield return null;
            }
        }

    }
}
