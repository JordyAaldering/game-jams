using Extensions;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float dragSpeed = 1f;
    [SerializeField] private float dragDistance = 5f;

    [SerializeField] private float horizontalClamp = 0.1f;
    [SerializeField] private float verticalClamp = 0.1f;
    
    private Vector2 offset;
    private Camera cam;
    
    private void Start()
    {
        cam = Camera.main;

        dragSpeed += UpgradeController.dragSpeedBonus;
        dragDistance += UpgradeController.dragDistanceBonus;
    }

    private void OnMouseDown()
    {
        offset = transform.position - cam.ScreenToWorldPoint(Input.mousePosition.With(z: 0f));
    }

    private void OnMouseDrag()
    {
        Vector2 cursorPos = cam.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));

        float distance = Vector2.Distance(PlayerManager.instance.Player1Pos(), PlayerManager.instance.Player2Pos());
        float speed = dragSpeed * GetDragSpeed(1 - distance.NormalisedBetween(0f, dragDistance));
        
        Vector3 pos = Vector2.Lerp(transform.position, cursorPos + offset, speed);
        
        pos = cam.WorldToViewportPoint(pos);
        pos.x = Mathf.Clamp(pos.x, horizontalClamp, 1 - horizontalClamp);
        pos.y = Mathf.Clamp(pos.y, verticalClamp, 1 - verticalClamp);
        transform.position = cam.ViewportToWorldPoint(pos);
    }

    private static float GetDragSpeed(float distanceNormalised)
    {
        return Mathf.Max(0f, 1f - 6f / (distanceNormalised + 0.1f) * Mathf.Pow(distanceNormalised - 0.35f, 4f));
    }
}
