using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ServiceLocator {
    public class AudioService : MonoBehaviour, IAudioService {
        public Type Type = typeof(AudioService);

        [SerializeField]
        private AudioSource BackgroundAS = null;

        private void Awake() {
            Locator.Register<AudioService>( "AudioService", this );
        }

        private void OnDestroy() {
            Locator.Unregister( "AudioService" );
        }

        public void playSound(int soundID) {
        // Play sound using audio api...
            Debug.Log("AudioService.playSound");
        }

        public void stopSound(int soundID) {
        // Stop sound using audio api...
        }

        public void stopAllSounds() {
        // Stop all sounds using audio api...
        }
    }

    public class AudioBase : IGameService {
        public void playSound(int soundID) {
        // Play sound using audio api...
            Debug.Log("AudioBase.playSound");
        }
        // public static implicit operator AudioBase(AudioBase audioservice) {
        //     return new AudioBase();
        // }
        public static explicit operator AudioBase(AudioService audioservice) {
            return new AudioBase();
        }
    }
}