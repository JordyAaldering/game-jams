using UnityEngine;
using Random = UnityEngine.Random;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float speedMin = 1f;
    [SerializeField] private float speedMax = 2f;
    private float speed;

    private void Start()
    {
        speed = Random.Range(speedMin, speedMax);
    }

    private void Update()
    {
        transform.Rotate(0f, 0f, speed * Time.deltaTime);
    }
}
