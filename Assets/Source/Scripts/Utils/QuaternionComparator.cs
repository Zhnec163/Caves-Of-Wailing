using UnityEngine;

namespace Scripts.Utils
{
    public static class QuaternionComparator
    {
        public static bool Approximately(Quaternion quaternionA, Quaternion quaternionB, float acceptableRange) =>
            1 - Mathf.Abs(Quaternion.Dot(quaternionA, quaternionB)) < acceptableRange;
    }
}