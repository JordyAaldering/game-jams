using System;
using Extensions;
using UnityEngine;

public class RocketWarn : MonoBehaviour
{
    private float xPos;

    private bool hasTarget;
    private Transform _target;
    public Transform target
    {
        private get => _target;
        set
        {
            if (hasTarget) throw new Exception("Rocket already has a target.");
            _target = value;
            hasTarget = true;
        }
    }

    private void Start()
    {
        var cam = Camera.main;
        if (cam != null)
        {
            xPos = -cam.orthographicSize * cam.aspect + 0.5f;
        }
    }

    private void Update()
    {
        if (hasTarget)
        {
            Transform t = transform;
            Vector3 targetPos = target.position;
            t.position = t.position.With(x: xPos, y: targetPos.y);

            if (targetPos.x > t.position.x)
            {
                Destroy(gameObject);
            }
        }
    }
}
