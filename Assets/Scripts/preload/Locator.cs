using UnityEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace ServiceLocator {

    static class Locator {
        private static Dictionary<string, IGameService> m_Services = new Dictionary<string, IGameService>();

        static Locator() {
#if UNITY_EDITOR
            try {
                UnityEngine.SceneManagement.SceneManager.LoadScene( EditorPrefs.GetString( "SceneAutoLoader.PreviousScene" ) );
            } catch {
                Debug.LogError( string.Format( "error: Could not load active scene after preload" ));
            }
#endif
        }

        // T is the interface ex IAudioService
        // if key not found, NullService
        public static T Get<T>( string key ) where T : IGameService {
            if ( m_Services.ContainsKey(key) )
                return (T)m_Services[key];
            Debug.Log($"Returning null service for {key}");
            NullService nullService = new NullService();
            return (T)nullService.GetInstance();
        }

        public static void Register<T>( string key, T service ) where T : IGameService {
            if ( !m_Services.ContainsKey(key) ) {
                m_Services.Add(key, service);
                return;
            }
            Debug.Log($"Duplicated key of {key}");
            
        }

        public static void Unregister( string key ) {
            if ( m_Services.ContainsKey(key) ) {
                m_Services.Remove(key);
                return;
            }
            Debug.Log($"No such key of {key}");
        }
    }
}
