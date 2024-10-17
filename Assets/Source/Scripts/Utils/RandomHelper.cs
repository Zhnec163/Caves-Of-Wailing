using UnityEngine;

namespace Scripts.Utils
{
    public class RandomHelper : MonoBehaviour
    {
        public static int GetRandomInt(int minValue, int maxValue) =>
            Random.Range(minValue, maxValue);
    }
}