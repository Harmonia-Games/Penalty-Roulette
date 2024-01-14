using UnityEngine;

public class CharacterAnimatiorController : MonoBehaviour
{
    private Animator animator;

    public string[] animationNames; 

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void RandomAnimation()
    {
        int randomIndex = Random.Range(0, animationNames.Length);
        string randomAnimation = animationNames[randomIndex];
        animator.Play(randomAnimation);
    }
}
