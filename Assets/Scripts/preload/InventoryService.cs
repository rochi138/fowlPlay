using UnityEngine;

namespace ServiceLocator {
    
    public interface IInventoryService : IGameService {}
    
    public class InventoryService : MonoBehaviour, IInventoryService {

        void Awake() {
            Locator.Register<InventoryService>( "InventoryService", this );
        }

        void OnDestroy() {
            Locator.Unregister( "InventoryService" );
        }
    };
}