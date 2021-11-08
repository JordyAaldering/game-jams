using UnityEngine;

namespace Extensions
{
    public static class FloatExtensions
    {
        public static float NormalisedBetween(this float x, float min, float max)
        {
            return Mathf.Clamp((x - min) / (max - min), 0f, 1f);
        }
    }
}
