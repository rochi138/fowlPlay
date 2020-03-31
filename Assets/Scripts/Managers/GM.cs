using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using UnityEngine.SceneManagement;
#endif

static class GM {
   public static SceneController SceneController;

    static GM() {
        GameObject g = safeFind("__app");
        
         SceneController = (SceneController)SafeComponent( g, "SceneController" );

 #if UNITY_EDITOR
        try {
            SceneManager.LoadScene( EditorPrefs.GetString( "SceneAutoLoader.PreviousScene" ) );
        } catch {
            Debug.LogError( string.Format( "error: Could not load active scene after preload" ));
        }
 #endif
    }
    
    private static GameObject safeFind(string s) {
        GameObject g = GameObject.Find(s);
        if (g == null) 
            Woe("GameObject " +s+ "  not on _preload.");
        return g;
    }
    private static Component SafeComponent(GameObject g, string s) {
        Component c = g.GetComponent(s);
        if (c == null) 
            Woe("Component " +s+ " not on _preload.");
        return c;
    }

    private static void Woe(string error) {
        Debug.Log(">>> Cannot proceed... " +error);
        Debug.Log(">>> It is very likely you just forgot to launch");
        Debug.Log(">>> from scene zero, the _preload scene.");
    }

    public static void Nothing() {
        // Temp call for now
        // GM needs to be called by one of its static classes to instantiate it
        Debug.Log("Nothing call");
    }
}