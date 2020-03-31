using UnityEngine;
using UnityEngine.Events;

public class PlayerEvents : MonoBehaviour {
    public UnityAction OnEDown = null;
    public UnityAction OnXDown = null;
    public UnityAction OnJumpDown = null;

    void Update() {
        // check for active input
        if (!Input.anyKey)
            return;

        // Press = GetKey
        // Down = GetKeyDown
        // Up = GetKeyUp

        if (Input.GetKeyDown(KeyCode.E) && OnEDown != null ) OnEDown();
        if (Input.GetKeyDown(KeyCode.X) && OnXDown != null ) OnXDown();
        if (Input.GetKeyDown(KeyCode.Space) && OnJumpDown != null ) OnJumpDown();
    }
}
