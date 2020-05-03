using UnityEngine;
using UnityEngine.SceneManagement;

namespace ServiceLocator {

    public interface ISceneService : IGameService {
        void LoadNextScene();
    }
    
    public class SceneService : MonoBehaviour, ISceneService {

        void Awake() {
            Locator.Register<SceneService>( "SceneService", this );
        }

        void OnDestroy() {
            Locator.Unregister( "SceneService" );
        }
        public void LoadNextScene() {
            SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex + 1 );
        }
    };
}