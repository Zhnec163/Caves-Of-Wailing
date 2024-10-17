using System;
using System.Collections;
using Scripts.Utils;
using UnityEngine;

namespace Scripts.Interactive.Resource
{
    public class ResourceMover : MonoBehaviour
    {
        private const float MovingInfelicity = 0.0001F;

        [SerializeField] private float _movingSpeed;
        [SerializeField] private float _rotatingSpeed;

        public event Action MoveEnded;

        public void MoveTo(Transform target)
        {
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
}