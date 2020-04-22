using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ServiceLocator {
    public class AudioService : AudioBase {

        void Awake() {
            Locator.AudioService = this;
        }

        // public override void playSound(int soundID) {
        // // Play sound using audio api...
        // }

        // public override void stopSound(int soundID) {
        // // Stop sound using audio api...
        // }

        // public override void stopAllSounds() {
        // // Stop all sounds using audio api...
        // }
    };
}