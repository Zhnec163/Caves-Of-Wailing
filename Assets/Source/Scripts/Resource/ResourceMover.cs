using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class ResourceMover : MonoBehaviour
{
    private const float MovingInfelicity = 0.0001F;
    
    [SerializeField] private float _movingSpeed;
    [SerializeField] private float _upscaleSpeed;
    [SerializeField] private float _rotatingSpeed;

    public event Action MoveEnded;

    public void MoveTo(Transform target)
    {
        transform.localScale = Vector3.zero;
        transform.DOScale(Vector3.one, _upscaleSpeed);
        
        StartCoroutine(Moving(target));
        StartCoroutine(Rotating(target));
    }

    private IEnumerator Moving(Transform target)
    {
        while ((transform.position - target.position).sqrMagnitude > MovingInfelicity)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, _movingSpeed);
            yield return null;
        }
        
        MoveEnded?.Invoke();
    }
    
    private IEnumerator Rotating(Transform target)
    {
        while (QuaternionComparator.Approximately(transform.rotation, target.rotation, Mathf.Epsilon) == false)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, _rotatingSpeed);
            yield return null;
        }
    }
}
