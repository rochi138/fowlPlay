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
        //This function just gets rid of warnings about eventhandlers not being used
        protected virtual void AllEventHandlers() {
            EventHandler handler = null;
            handler = OnEDown;
            handler = OnXDown;
            handler = OnSpaceDown;
        }

        //IAudioService
        public void playSound(int soundID) {}
        public void stopSound(int soundID) {}
        public void stopAllSounds() {}

        //IInventoryService

        //IPlayerEventsService
        public event EventHandler OnEDown;
        public event EventHandler OnXDown;
        public event EventHandler OnSpaceDown;

        //ISceneService
        public void LoadNextScene() {}

        //IStateService
    }
}