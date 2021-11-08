using System.Collections.Generic;
using UnityEngine;

public class AnimationSetter : MonoBehaviour
{
    public List<GameObject> hittables = new List<GameObject>();
    
    private Animator anim;
    private static readonly int IsHappy = Animator.StringToHash("isHappy");
    private static readonly int Distance = Animator.StringToHash("distance");

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (hittables.Count > 0)
        {
            GameObject closest = GetClosestHittable();
            
            anim.SetBool(IsHappy, closest.GetComponent<HittableText>().textBox.isPositive);
            anim.SetFloat(Distance, Vector2.Distance(transform.position, closest.transform.position));
        }
    }

    private GameObject GetClosestHittable()
    {
        Vector3 position = transform.position;
        GameObject closest = null;
        float distance = Mathf.Infinity;
        
        foreach (GameObject go in hittables)
        {
            float curr = Vector2.Distance(position, go.transform.position);
            if (curr < distance)
            {
                closest = go;
                distance = curr;
            }
        }

        return closest;
    }
}
