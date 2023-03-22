using UnityEngine;

namespace Components
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
    
        private static SoundManager _instance;

        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(this);
                return;
            }

            _instance = this;
        }

        public static void PlayClip(AudioClip clip)
        {
            _instance.audioSource.PlayOneShot(clip);
        }
    }
}