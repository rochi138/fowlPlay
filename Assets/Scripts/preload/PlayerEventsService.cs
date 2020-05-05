using UnityEngine;
using UnityEngine.Events;
using System;

namespace ServiceLocator {

    public interface IPlayerEventsService : IGameService {
        event EventHandler OnEDown;
        event EventHandler OnXDown;
        event EventHandler OnSpaceDown;
    }

    public class PlayerEventsService : MonoBehaviour, IPlayerEventsService {
        //Alphabetical-ish
        public event EventHandler OnEDown;
        public event EventHandler OnXDown;
        public event EventHandler OnSpaceDown;
        protected virtual void InputHandler( EventHandler handler ) {
            handler?.Invoke(this, EventArgs.Empty);
        }

        void Awake() {
            Locator.Register<PlayerEventsService>( "PlayerEventsService", this );
        }

        void OnDestroy() {
            Locator.Unregister( "PlayerEventsService" );
        }

        void Update() {
            // check for active input
            if (!Input.anyKey)
                return;

            // Press = GetKey
            // Down = GetKeyDown
            // Up = GetKeyUp

            if (Input.GetKeyDown(KeyCode.E)) InputHandler( OnEDown );
            if (Input.GetKeyDown(KeyCode.X)) InputHandler( OnXDown );
            if (Input.GetKeyDown(KeyCode.Space)) InputHandler( OnSpaceDown );
        }
    }
}
