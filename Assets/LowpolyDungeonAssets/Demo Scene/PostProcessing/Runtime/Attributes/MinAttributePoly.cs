namespace UnityEngine.PostProcessing
{
    public sealed class MinAttributePoly : PropertyAttribute
    {
        public readonly float min;

        public MinAttributePoly(float min)
        {
            this.min = min;
        }
    }
}
