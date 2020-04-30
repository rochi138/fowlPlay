using UnityEngine;
using System;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace ServiceLocator {

    static class Locator {
        public static Dictionary<string, IBaseService> m_BaseClasses = new Dictionary<string, IBaseService>() {
            { "IAudioService" , new AudioBase() }
        };
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
        // U is the base service class with null methods ex AudioBase
        // if key not found, return instance of null service
        public static T Get<T>( string key ) where T : IGameService {
            if ( m_Services.ContainsKey(key) )
                return (T)m_Services[key];
            Debug.Log("Returning null service");
            return (T)m_BaseClasses[typeof(T).Name].GetInstance();
            
        }

        public static void Register<T>( string key, T service ) where T : IGameService {
            if ( m_Services.ContainsKey(key) ) {
                Debug.Log($"Duplicated key of {key}");
                return;
            }
            m_Services.Add(key, service);
        }

        public static void Unregister( string key ) {
            if ( !m_Services.ContainsKey(key) ) {
                Debug.Log($"No such key of {key}");
                return;
            }
            m_Services.Remove(key);
        }
    }
}
