using UnityEngine;

namespace Extensions
{
    public static class Vector2Extensions
    {
        public static Vector2 Center(this Vector2 v1, Vector2 v2)
        {
            return new Vector2((v1.x + v2.x) / 2f, (v1.y + v2.y) / 2f);
        }

        public static float Angle(this Vector2 from, Vector2 to)
        {
            return Mathf.Atan2(to.y - from.y, to.x - from.x) * 180f / Mathf.PI;
        }
    }
}
