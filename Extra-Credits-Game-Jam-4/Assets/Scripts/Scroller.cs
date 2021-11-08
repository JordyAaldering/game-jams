using UnityEngine;

public class Scroller : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float destroyPoint = -10f;

    private void Update()
    {
        Transform t = transform;
        float x = t.position.x;
        
        t.Translate(-speed * Time.deltaTime, 0f, 0f);

        if (destroyPoint < 0 && x < destroyPoint || destroyPoint > 0 && x > destroyPoint * 2f)
        {
            PlayerManager.instance.RemoveFromFearSetter(gameObject);
            Destroy(gameObject);
        }
    }
}
