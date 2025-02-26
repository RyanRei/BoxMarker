using UnityEngine;

public class MaskAnimator : MonoBehaviour
{
    private Animator animator;
    public AudioClip scan;
    public SoundManager soundManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void maskAnimate()
    {
        soundManager.PlaySFX(scan);
        animator.SetTrigger("trigger");
    }
}
