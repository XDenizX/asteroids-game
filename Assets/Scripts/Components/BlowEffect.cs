using System.Linq;
using UnityEngine;

namespace Components
{
    public class BlowEffect : MonoBehaviour
    {
        [SerializeField] private GameObject blow;
        [SerializeField] private AudioClip blowSound;
        
        private float _animationDuration;

        private void Start()
        {
            Animator animator = blow.GetComponent<Animator>();
            AnimationClip clip = animator.runtimeAnimatorController.animationClips.First();
            _animationDuration = clip.length;
        }

        public void Play()
        {
            GameObject blowInstance = Instantiate(blow);
            blowInstance.transform.position = gameObject.transform.position;
            Destroy(blowInstance, _animationDuration);
            
            SoundManager.PlayClip(blowSound);
        }
    }
}