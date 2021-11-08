using Extensions;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    private LineRenderer line;
    private BoxCollider2D col;

    private void Start()
    {
        line = GetComponent<LineRenderer>();
        col = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        Vector2 player1Pos = PlayerManager.instance.player1.position;
        Vector2 player2Pos = PlayerManager.instance.player2.position;

        line.SetPosition(0, player1Pos);
        line.SetPosition(1, player2Pos);

        Transform t = transform;
        t.rotation = transform.rotation.With(z: player1Pos.Angle(player2Pos));

        col.transform.position = player1Pos.Center(player2Pos);
        col.size = new Vector2(Vector2.Distance(player1Pos, player2Pos), col.size.y);
    }
}
