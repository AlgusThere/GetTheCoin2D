using System.Collections;
using UnityEngine;

public class TimerIncreaserManager : MonoBehaviour
{
    [SerializeField] Collider2D _Collider2DBounds;
    [SerializeField] GameObject _IncreaserPrefab;
    [SerializeField] float _CoolDown = 10f;
    [SerializeField] float _LifeTime = 2f;

    GameObject _Increaser;

    WaitForSeconds _WaitForIt;
    WaitForSeconds _WaitForLifeTime;

    void Start()
    {
        _WaitForIt = new WaitForSeconds(_CoolDown);
        _WaitForLifeTime = new WaitForSeconds(_LifeTime);
        _Increaser = Instantiate(_IncreaserPrefab, RandomPosition(), Quaternion.identity, transform);
        _Increaser.SetActive(false);

        StartCoroutine(ChangeObjectActiveSelfCoroutine());
    }

    Vector2 RandomPosition()
    {
        Bounds _Bounds = _Collider2DBounds.bounds;

        return new Vector2(
            Random.Range(_Bounds.min.x, _Bounds.max.x),
            Random.Range(_Bounds.min.y, _Bounds.max.y));
    }
    IEnumerator ChangeObjectActiveSelfCoroutine()
    {
        while(true)
        {
            yield return _WaitForIt;
            _Increaser.transform.position = RandomPosition();
            _Increaser.SetActive(true);

            yield return _WaitForLifeTime;
            if(_Increaser.activeSelf)
                _Increaser.SetActive(false);
        }
    }
}
