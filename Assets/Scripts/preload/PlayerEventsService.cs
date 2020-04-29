using UnityEngine;
using UnityEngine.Events;

namespace ServiceLocator {
    public class PlayerEventsService : MonoBehaviour, IGameService {
        //Alphabetical-ish
        public UnityAction OnEDown = null;
        public UnityAction OnXDown = null;
        public UnityAction OnSpaceDown = null;

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

            if (Input.GetKeyDown(KeyCode.E) && OnEDown != null ) OnEDown();
            if (Input.GetKeyDown(KeyCode.X) && OnXDown != null ) OnXDown();
            if (Input.GetKeyDown(KeyCode.Space) && OnSpaceDown != null ) OnSpaceDown();
        }
    }
}
