using UnityEngine;

namespace Extensions
{
    public static class PlayerManagerExtensions
    {
        public static Vector2 Player1Pos(this PlayerManager p)
        {
            return PlayerManager.instance.player1.position;
        }

        public static Vector2 Player2Pos(this PlayerManager p)
        {
            return PlayerManager.instance.player2.position;
        }
    }
}
