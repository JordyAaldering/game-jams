#pragma warning disable 0649
using UnityEngine;

namespace Environment
{
    public class SpikeTrap : MonoBehaviour
    {
        [SerializeField] private float activeDuration = 2f;
        [SerializeField] private float inactiveDuration = 2f;

        [SerializeField] private Transform spike;

        [SerializeField] private bool startActive = true;
        [SerializeField] private bool randomize = false;

        private void Start()
        {
            if (startActive)
            {
                SetActive();
            }
            else
            {
                SetInactive();
            }
        }

        private void SetActive()
        {
            spike.gameObject.SetActive(true);

            float duration = activeDuration;
            if (randomize)
            {
                duration = Random.Range(activeDuration * .25f, activeDuration * 1.25f);
            }

            Invoke(nameof(SetInactive), duration);
        }

        private void SetInactive()
        {
            spike.gameObject.SetActive(false);

            float duration = activeDuration;
            if (randomize)
            {
                duration = Random.Range(inactiveDuration * .25f, inactiveDuration * 1.25f);
            }

            Invoke(nameof(SetActive), duration);
        }
    }
}
