using UnityEngine;

namespace ServiceLocator {
    public class AudioBase : MonoBehaviour {
        
        [SerializeField]
        private AudioSource BackgroundAS = null;

        ~AudioBase() {}
        public virtual void playSound(int soundID) { /* Do nothing. */ }
        public virtual void stopSound(int soundID) { /* Do nothing. */ }
        public virtual void stopAllSounds()        { /* Do nothing. */ }
    };
}