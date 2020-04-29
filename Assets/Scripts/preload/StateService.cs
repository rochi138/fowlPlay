using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ServiceLocator {
    
    public class StateService : StateBase {

        void Awake() {
            Locator.Register<StateService>( "StateService", this );
        }

        void OnDestroy() {
            Locator.Unregister( "StateService" );
        }
    };
}