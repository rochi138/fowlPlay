using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlChangerScript : MonoBehaviour
{
    public Animator animator;

    public void FadeToLevel() {
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete() {
    }

    void Start() {
        //Get Animator attached to EmptyPod
    }
}
