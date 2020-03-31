#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[InitializeOnLoad]
static class SceneAutoLoader
{ 
	static SceneAutoLoader() {
		EditorApplication.playModeStateChanged += OnPlayModeChanged;
	}

	private static void OnPlayModeChanged(PlayModeStateChange state) {
		if (!EditorApplication.isPlaying && EditorApplication.isPlayingOrWillChangePlaymode) {
			PreviousScene = EditorSceneManager.GetActiveScene().name;
			if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo()) {
				try {
					EditorSceneManager.OpenScene( "Assets/Scenes/" + MasterScene + ".unity" );
				} catch {
					Debug.LogError(string.Format("error: scene not found: {0}", MasterScene));
					EditorApplication.isPlaying = false;
				}
			} else {
				EditorApplication.isPlaying = false;
			}
		}
 
		if (!EditorApplication.isPlaying && !EditorApplication.isPlayingOrWillChangePlaymode) {
			try {
				EditorSceneManager.OpenScene( "Assets/Scenes/" + PreviousScene + ".unity" );
			} catch {
				Debug.LogError(string.Format("error: scene not found: {0}", PreviousScene));
			}
		}
	}
 
	private static string MasterScene = "_preload";
 
	private static string PreviousScene
	{
		get { return EditorPrefs.GetString("SceneAutoLoader.PreviousScene", EditorSceneManager.GetActiveScene().name); }
		set { EditorPrefs.SetString("SceneAutoLoader.PreviousScene", value); }
	}
}
#endif