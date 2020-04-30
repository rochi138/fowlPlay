using UnityEngine;
using UnityEngine.Events;

namespace ServiceLocator {

    public interface IGameService { }

    public class NullService : IGameService, IAudioService, IInventoryService, ISceneService, IStateService {
        private static NullService instance_ = null;
        public IGameService GetInstance() { return (IGameService)instance_; }
        public NullService() {
            if ( instance_ == null )
                instance_ = this;
        }

        //IAudioService
        public void playSound(int soundID) {}
        public void stopSound(int soundID) {}
        public void stopAllSounds() {}

        //IInventoryService

        //IPlayerEventsService

        //ISceneService
        public void LoadNextScene() { /* Do nothing. */ }

        //IStateService
    }

    public interface IAudioService : IGameService {
        void playSound(int soundID);
        void stopSound(int soundID);
        void stopAllSounds();
    }

    public interface IInventoryService : IGameService {}

    public interface IPlayerEventsService : IGameService {
        UnityAction OnEDown();
        UnityAction OnXDown();
        UnityAction OnSpaceDown();
    }

    public interface ISceneService : IGameService {
        void LoadNextScene();
    }

    public interface IStateService : IGameService {}
}