using UnityEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace ServiceLocator {

    static class Locator {
        public static Dictionary<string, IGameService> m_BaseClasses = new Dictionary<string, IGameService>() {
            { "IAudioService" , new AudioBase() }
        };
        private static Dictionary<string, IGameService> m_Services = new Dictionary<string, IGameService>();
        private static PlayerEvents m_PlayerEvents;
        public static PlayerEvents PlayerEvents { get { return m_PlayerEvents; } }

        static Locator() {
            GameObject g = safeFind("__app");
            m_PlayerEvents = (PlayerEvents)SafeComponent( g, "PlayerEvents" );
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
        // if using delegates, the return value must be cast back to original, but this would throw an error for null services
        public static T Get<T>( string key ) where T : IGameService {
            if ( m_Services.ContainsKey(key) )
                return (T)m_Services[key];
            Debug.Log($"Returning null service for {key}");
            NullService nullService = new NullService();
            return (T)nullService.GetInstance();
        }

        // public static T Get<T>( string key ) where T : IGameService {
        //     if ( m_Services.ContainsKey(key) )
        //         return (T)m_Services[key];
        //     Debug.Log("Returning null service");
        //     NullService nullService = new NullService();
        //     return (T)nullService.GetInstance();
        // }

        // public static AudioBase GetAudioBase( string key ) {
        //     // AudioService audio = (AudioService)m_Services["AudioService"];
        //     var service = m_Services["AudioService"];
        //     Type serviceType = service.GetType();
        //     // return (AudioBase)(TypeDescriptor.GetClassName(m_Services["AudioService"]))m_Services["AudioService"];
        //     var convert = (serviceType) Convert.ChangeType(service, typeof(serviceType));
        //     convert.playSound(0);
        //     var convert2 = (AudioBase) Convert.ChangeType(service, typeof(AudioBase));
        //     return convert2;
        // }

//         public T ConvertObject<T>(object input) {
//     return (T) Convert.ChangeType(input, typeof(T));
// }

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

        private static GameObject safeFind(string s) {
            GameObject g = GameObject.Find(s);
            if (g == null) 
                Woe("GameObject " +s+ "  not on _preload.");
            return g;
        }
        private static UnityEngine.Component SafeComponent(GameObject g, string s) {
            UnityEngine.Component c = g.GetComponent(s);
            if (c == null) 
                Woe("Component " +s+ " not on _preload.");
            return c;
        }

        private static void Woe(string error) {
            Debug.Log(">>> Cannot proceed... " +error);
            Debug.Log(">>> It is very likely you just forgot to launch");
            Debug.Log(">>> from scene zero, the _preload scene.");
        }
    }
}
