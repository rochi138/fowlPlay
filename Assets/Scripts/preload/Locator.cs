using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace ServiceLocator {
    static class Locator {
        private static AudioBase m_AudioService = new AudioBase();
        private static AudioBase m_NullAudio = new AudioBase();

        static Locator() {]
#if UNITY_EDITOR
        try {
            UnityEngine.SceneManagement.SceneManager.LoadScene( EditorPrefs.GetString( "SceneAutoLoader.PreviousScene" ) );
        } catch {
            Debug.LogError( string.Format( "error: Could not load active scene after preload" ));
        }
#endif
        }

        public static AudioBase AudioService { 
            get { return m_AudioService; }
            set { 
                m_AudioService = value as AudioBase ? m_AudioService : m_NullAudio;
            }
        }
    };
}
