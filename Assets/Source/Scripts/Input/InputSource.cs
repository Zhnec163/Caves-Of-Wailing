using UnityEngine;

namespace Scripts.Input
{
    public abstract class InputSource : MonoBehaviour
    {
        public abstract Vector2 GetDirection();
    }
}