using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablePooling : MonoBehaviour, IPool
{
    [SerializeField] GameObject _CoinPrefab;
    [SerializeField] float _SpawnCoolDown = 2f;

    Collider2D _Collider2DBounds;

    const int COIN_AMOUNT = 6;
    
    Queue<GameObject> _Coins;

    void Start()
    {
        _Collider2DBounds = GetComponent<Collider2D>();

        _Coins = new Queue<GameObject>();

        for (int i = 0; i < COIN_AMOUNT; ++i)
        {
            GameObject _Coin = Instantiate(_CoinPrefab, SpawnBounds(), Quaternion.identity, transform);
            _Coin.SetActive(false);
            _Coins.Enqueue(_Coin);
        }

        StartCoroutine(SpawnCoinNumerator());
    }

    Vector2 SpawnBounds()
    {
        Bounds _Bounds = _Collider2DBounds.bounds;

        float _xRandom = Random.Range(_Bounds.min.x, _Bounds.max.x);
        float _yRandom = Random.Range(_Bounds.min.y, _Bounds.max.y);

        return new Vector2(_xRandom,_yRandom);
    }

    public GameObject GetCoinFromPool()
    {
        if(_Coins.Count > 0)
        {
            GameObject _Coin = _Coins.Dequeue();
            _Coin.SetActive(true);
            return _Coin;
        }
        else
        {
            GameObject _NewCoin = Instantiate(_CoinPrefab, SpawnBounds(), Quaternion.identity, transform);
            _NewCoin.SetActive(true);
            return _NewCoin;
        }
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
