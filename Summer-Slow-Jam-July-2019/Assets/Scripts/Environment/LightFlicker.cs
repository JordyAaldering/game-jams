#pragma warning disable 0649
using UnityEngine;

namespace Environment
{
    public class LightFlicker : MonoBehaviour
    {
        [SerializeField] private float minIntensity = 0.25f;
        [SerializeField] private float maxIntensity = 0.5f;

        private Light myLight;
        private float seed;

        private void Start()
        {
            myLight = GetComponent<Light>();
            seed = Random.Range(0f, 65535f);
        }

        private void Update()
        {
            float noise = Mathf.PerlinNoise(seed, Time.time);
            myLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, noise);
        }
    }
}
