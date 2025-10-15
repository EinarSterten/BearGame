using UnityEngine;

public class LimbAnimator : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] walkSprites;
    public Sprite[] idleSprites;

    private float animationTimer;
    private int currentFrame;

    void Update()
    {
        //AnimateLimb();
    }

    public void AnimateLimb(bool isWalking)
    {
        Sprite[] currentAnimation = isWalking ? walkSprites : idleSprites;

        if (currentAnimation.Length == 0) return;

        animationTimer += Time.deltaTime;
        if (animationTimer >= 0.1f) // Adjust frame rate
        {
            currentFrame = (currentFrame + 1) % currentAnimation.Length;
            spriteRenderer.sprite = currentAnimation[currentFrame];
            animationTimer = 0f;
        }
    }
}