using UnityEngine;

namespace ServiceLocator {

    public interface IGameService { }
    public interface IBaseService : IGameService { 
        IBaseService GetInstance();
    }
    public interface IAudioService : IGameService {
        void playSound(int soundID);
        void stopSound(int soundID);
        void stopAllSounds();
    }

    public class AudioBase : IAudioService, IBaseService {
        private static AudioBase instance_ = null;
        public IBaseService GetInstance() { return (IBaseService)instance_; }
        public AudioBase() {
            if ( instance_ == null )
                instance_ = this;
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