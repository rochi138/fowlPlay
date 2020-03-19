using UnityEngine;
using UnityEngine.Events;

public class PlayerEvents : MonoBehaviour {

    public static UnityAction OnEDown = null;
    public static UnityAction OnXDown = null;
    public static UnityAction OnJumpDown = null;

    void Update() {
        // check for active input
        if (!Input.anyKey) {
            return;
        }

        // Press = GetKey
        // Down = GetKeyDown
        // Up = GetKeyUp

        if (Input.GetKeyDown(KeyCode.E) && OnEDown != null ) OnEDown();
        if (Input.GetKeyDown(KeyCode.X) && OnXDown != null ) OnXDown();
        if (Input.GetKeyDown(KeyCode.Space) && OnJumpDown != null ) OnJumpDown();
    }
}
