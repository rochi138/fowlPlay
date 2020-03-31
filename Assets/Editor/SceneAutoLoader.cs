#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[InitializeOnLoad]
static class SceneAutoLoader
{
	// Static constructor binds a playmode-changed callback.
	// [InitializeOnLoad] above makes sure this gets executed.
	static SceneAutoLoader() {
		EditorApplication.playModeStateChanged += OnPlayModeChanged;
	}
 
	// Play mode change callback handles the scene load/reload.
	private static void OnPlayModeChanged(PlayModeStateChange state) {
		if (!EditorApplication.isPlaying && EditorApplication.isPlayingOrWillChangePlaymode) {
			// User pressed play -- autoload master scene.
			PreviousScene = EditorSceneManager.GetActiveScene().name;
			if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo()) {
				try {
					EditorSceneManager.OpenScene( "Assets/Scenes/" + MasterScene + ".unity" );
				} catch {
					Debug.LogError(string.Format("error: scene not found: {0}", MasterScene));
					EditorApplication.isPlaying = false;
				}
			} else {
				// User cancelled the save operation -- cancel play as well.
				EditorApplication.isPlaying = false;
			}
		}
 
		// isPlaying check required because cannot OpenScene while playing
		if (!EditorApplication.isPlaying && !EditorApplication.isPlayingOrWillChangePlaymode) {
			// User pressed stop -- reload previous scene.
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