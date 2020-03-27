using UnityEngine;

public class StateManager : MonoBehaviour
{
    public static StateManager m_Instance = null;
    public static StateManager GetInstance() {
        return m_Instance;
    }

    void Awake() {
        if (m_Instance == null) {
            m_Instance = this;
        } else if (m_Instance != this) {
            Destroy(gameObject);
        }
    }
}
