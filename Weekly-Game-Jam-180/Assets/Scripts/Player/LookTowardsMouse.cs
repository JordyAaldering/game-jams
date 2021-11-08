using UnityEngine;

public class LookTowardsMouse : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 lookPos = mousePos - transform.position;
        float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
        Quaternion rot = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, rotateSpeed * Time.deltaTime);
    }
}
