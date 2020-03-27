using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource BackgroundAS;
    public static AudioManager m_Instance = null;
    public static AudioManager GetInstance() {
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
