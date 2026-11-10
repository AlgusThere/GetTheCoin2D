using UnityEngine;

public class Coin : MonoBehaviour, ICollectable
{
    [SerializeField] CollectableItemsSO _CollectableItemSO;

    IPool _IPool;

    public void SetPool(IPool IPool)
    {
        _IPool = IPool;
    }

    public void Collectable()
    {
        EventManager.CoinCollected(_CollectableItemSO._AMOUNT);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Collectable();
            _IPool?.ReturnToPool(gameObject);
        }
    }

}
