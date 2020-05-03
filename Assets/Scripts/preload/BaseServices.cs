using UnityEngine;
using UnityEngine.Events;
using System;

namespace ServiceLocator {

    public interface IGameService {
    }

    public class NullService : IGameService, IAudioService, IInventoryService, IPlayerEventsService, ISceneService, IStateService {
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
        public event EventHandler SpaceDown;
        // protected virtual void OnSpaceDown()
        // {
        //     EventHandler handler = SpaceDown;
        //     Debug.Log("Null");
        //     handler?.Invoke(this, EventArgs.Empty);
        // }

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
        event EventHandler SpaceDown;
    }

    public interface ISceneService : IGameService {
        void LoadNextScene();
    }

    public interface IStateService : IGameService {}
}