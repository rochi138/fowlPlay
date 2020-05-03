using UnityEngine;

namespace ServiceLocator {
    
    public interface IStateService : IGameService {}
    
    public class StateService : MonoBehaviour, IStateService {

        void Awake() {
            Locator.Register<StateService>( "StateService", this );
        }

        void OnDestroy() {
            Locator.Unregister( "StateService" );
        }
    };
}