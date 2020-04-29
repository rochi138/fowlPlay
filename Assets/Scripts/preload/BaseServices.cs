using UnityEngine;

namespace ServiceLocator {

    public interface IGameService { }
    public interface IAudioService : IGameService {
        void playSound(int soundID);
        void stopSound(int soundID);
        void stopAllSounds();
    }

    public class AudioBase : IAudioService {
        private static AudioBase instance_ = null;
        public static AudioBase GetInstance() { 
            if ( instance_ == null )
                instance_ = new AudioBase();
            return instance_;
        }
        public void playSound(int soundID) { }
        public void stopSound(int soundID) { }
        public void stopAllSounds() { }

    };

    public class InventoryBase : MonoBehaviour, IGameService {

        ~InventoryBase() {}

    };

    public interface ISceneService : IGameService {}
    public class SceneBase : MonoBehaviour, IGameService {

        ~SceneBase() {}
        public virtual void LoadNextScene() { /* Do nothing. */ }
        
    };

    public class StateBase : MonoBehaviour, IGameService {

        ~StateBase() {}
        
    };
}