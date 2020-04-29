using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ServiceLocator {
    
    public class SceneService : SceneBase {

        void Awake() {
            Locator.Register<SceneService>( "SceneService", this );
        }

        void OnDestroy() {
            Locator.Unregister( "SceneService" );
        }
        public override void LoadNextScene() {
            SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex + 1 );
        }
    };
}