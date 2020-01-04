using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlChangerScript : MonoBehaviour
{
    

    public Animator animator;

    public void FadeToLevel()
    {
        animator.SetTrigger("FadeOut");
    }
    public void OnFadeComplete()
    {

    }

    // Update is called once per frame

    // Start is called before the first frame update
    void Start()
    {
        //Get Animator attached to EmptyPod

    }

    void Update()
    {
        
    }
}
