using UnityEngine;

public class RandomHelper : MonoBehaviour
{
    public static int GetRandomInt(int minValue, int maxValue) =>
        Random.Range(minValue, maxValue);
}