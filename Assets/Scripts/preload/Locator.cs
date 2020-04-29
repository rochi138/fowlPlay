using UnityEngine;
using System;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace ServiceLocator {

    static class Locator {
        private static Dictionary<string, IGameService> services = new Dictionary<string, IGameService>();

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
        public static T Get<T, U>( string key ) 
            where T : IGameService
            where U : IGameService, new()
        {
            if ( services.ContainsKey(key) )
                return (T)services[key];
            Debug.Log("Returning null service");
            return (T)Activator.CreateInstance(typeof(U), new object[] {  });
            
        }

        public static void Register<T>( string key, T service ) where T : IGameService {
            if ( services.ContainsKey(key) ) {
                Debug.Log($"Duplicated key of {key}");
                return;
            }
            services.Add(key, service);
        }

        public static void Unregister( string key ) {
            if ( !services.ContainsKey(key) ) {
                Debug.Log($"No such key of {key}");
                return;
            }
            services.Remove(key);
        }
    }
}
