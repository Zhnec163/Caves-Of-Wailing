using System;
using System.Collections;
using UnityEngine;

public class EndGameTimer : MonoBehaviour
{
    [SerializeField] public int _time;

    private Coroutine _counting;

    public event Action<int> Changed;
    public event Action Ended;

    public int Time => _time;

    private void Awake() =>
        _counting = StartCoroutine(Counting());

    public bool TrySubtract(int amount)
    {
        if (_time == 0)
            return false;

        int newTime = _time - amount;

        if (newTime < 0)
        {
            _time = 0;
            StopCoroutine(_counting);
            Ended?.Invoke();
        }
        else
        {
            _time = newTime;
            Changed?.Invoke(_time);
        }

        return true;
    }

    private IEnumerator Counting()
    {
        while (_time > 0)
        {
            yield return new WaitForSeconds(1F);
            _time--;
            Changed?.Invoke(_time);
        }

        Ended?.Invoke();
    }
}