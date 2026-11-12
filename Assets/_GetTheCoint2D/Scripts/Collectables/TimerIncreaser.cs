using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class TimerIncreaser : MonoBehaviour, ICollectable
{
    [SerializeField] CollectableItemsSO _TimerIncreaserSO;

    public void Collectable()
    {
        EventManager.IncreaseTimerMethod((float)_TimerIncreaserSO._AMOUNT);
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            Collectable();
    }

}
