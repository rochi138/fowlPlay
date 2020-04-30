using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ServiceLocator {
    
    public class InventoryService : MonoBehaviour, IInventoryService {

        void Awake() {
            Locator.Register<InventoryService>( "InventoryService", this );
        }

        void OnDestroy() {
            Locator.Unregister( "InventoryService" );
        }
    };
}