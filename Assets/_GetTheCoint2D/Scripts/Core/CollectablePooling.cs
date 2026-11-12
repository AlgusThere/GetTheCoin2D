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

    WaitForSeconds _SpawnWait;

    void Start()
    {
        _Collider2DBounds = GetComponent<Collider2D>();

        _SpawnWait = new WaitForSeconds(_SpawnCoolDown);

        _Coins = new Queue<GameObject>(COIN_AMOUNT);

        for (int i = 0; i < COIN_AMOUNT; i++)
            _Coins.Enqueue(CreateCoin());

        StartCoroutine(SpawnCoinNumerator());
    }

    GameObject CreateCoin()
    {
        GameObject _Coin = Instantiate(_CoinPrefab, SpawnBounds(), Quaternion.identity, transform);

        if (_Coin.TryGetComponent(out Coin _CoinScript))
        {
            _CoinScript.SetPool(this);
        }

        _Coin.SetActive(false);
        return _Coin;
    }

    Vector2 SpawnBounds()
    {
        Bounds _Bounds = _Collider2DBounds.bounds;

        return new Vector2(
            Random.Range(_Bounds.min.x,_Bounds.max.x),
            Random.Range(_Bounds.min.y,_Bounds.max.y));
    }

    public GameObject GetCoinFromPool()
    {
        if (_Coins.Count == 0) return null;

        GameObject _Coin = _Coins.Dequeue();
        _Coin.transform.position = SpawnBounds();
        _Coin.SetActive(true);
        return _Coin;
    }

    public void ReturnToPool(GameObject _Coin)
    {
        if(_Coin == null || !_Coin.activeSelf)
            return;

        _Coin.SetActive(false);
        _Coins.Enqueue(_Coin);
    }


    IEnumerator SpawnCoinNumerator()
    {
        while(true)
        {
            GetCoinFromPool();
            yield return _SpawnWait;
        }

    }
}
