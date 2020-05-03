using UnityEngine;
using UnityEngine.Events;
using System;

namespace ServiceLocator {

    public interface IGameService {}

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
        //This function just gets rid of warnings about eventhandlers not being used
        protected virtual void AllEventHandlers() {
            EventHandler handler = SpaceDown;
        }

        //ISceneService
        public void LoadNextScene() {}

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