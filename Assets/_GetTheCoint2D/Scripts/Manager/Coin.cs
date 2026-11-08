using UnityEngine;

public class Coin : MonoBehaviour, ICollectable
{
    [SerializeField] CollectableItemsSO _CollectableItemSO;

    public void Collectable()
    {
        EventManager.CoinCollected(_CollectableItemSO._AMOUNT);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Collectable();
            Destroy(gameObject);
        }
    }

}
