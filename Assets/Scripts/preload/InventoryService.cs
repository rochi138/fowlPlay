using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ServiceLocator {
    
    public class InventoryService : InventoryBase {

        void Awake() {
            Locator.Register<InventoryService>( "InventoryService", this );
        }

        void OnDestroy() {
            Locator.Unregister( "InventoryService" );
        }
    };
}