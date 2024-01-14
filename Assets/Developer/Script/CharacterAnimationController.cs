using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    private Animator animator;

    public string[] animationNames; 

    void Start()
    {
        animator = GetComponent<Animator>();
        PlayRandomAnimation();
    }

    void PlayRandomAnimation()
    {
        int randomIndex = Random.Range(0, animationNames.Length);
        string randomAnimation = animationNames[randomIndex];
        animator.SetTrigger("Jump_LeftUp_V01");
    }
}
