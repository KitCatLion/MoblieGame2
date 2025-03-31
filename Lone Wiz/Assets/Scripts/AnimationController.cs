using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;
    private bool isPlaying = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void ToggleAnimation()
    {
        isPlaying = !isPlaying;

        if (animator != null)
        {
            if (isPlaying)
                animator.Play("YourAnimationName");
            else
                animator.StopPlayback();
        }
    }
}
