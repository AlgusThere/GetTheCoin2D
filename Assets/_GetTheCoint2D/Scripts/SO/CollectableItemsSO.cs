using NUnit.Framework;
using UnityEngine;

[CreateAssetMenu(fileName = "CollectableItemsSO", menuName = "CollectableItems/Items")]
public class CollectableItemsSO : ScriptableObject
{
    [SerializeField] int _Amount;

    public int _AMOUNT => _Amount;
}
