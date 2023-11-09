using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ChangeSprite : MonoBehaviour
{
    public Sprite newSprite; // Assign the new sprite in the Inspector
    public Sprite oldSprite;
    private SpriteRenderer spriteRenderer;

    public Color newColor = Color.blue;
    public Color oldColor = Color.white;

    private Color originalColour;
    private Color newColour;

    float currentTime = 0f;
    float startingTime = 0f;
    bool isColorChanged = false;

    public float abilityCountdownInterval;
    private float abilityCountdownTimer;

    private void Start()
    {
        currentTime = startingTime;

        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer component not found on this GameObject.");
        }

        if (spriteRenderer != null)
        {
            originalColour = spriteRenderer.color;
        }
    }

    private void Update()
    {
        abilityCountdownTimer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.F) & abilityCountdownTimer <= 0)
        {
            ChangeToNewSpriteAndColour();
            currentTime = 5f;
            isColorChanged = true;
            abilityCountdownTimer = abilityCountdownInterval;
        }

        if (currentTime < 0)
        {
            ChangeToOldSpriteAndColour();
            isColorChanged = false;
        }

        currentTime -= Time.deltaTime;
    }

    private void ChangeToNewSpriteAndColour()
    {
        if (spriteRenderer != null && newSprite != null)
        {
            spriteRenderer.sprite = newSprite;
            spriteRenderer.color = newColor;
        }
    }

    private void ChangeToOldSpriteAndColour()
    {
        if (spriteRenderer != null && oldSprite != null)
        {
            spriteRenderer.sprite = oldSprite;
            spriteRenderer.color = oldColor;
        }
    }
}
