using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAnimation : MonoBehaviour
{
    [SerializeField] private Sprite ani1;
    [SerializeField] private Sprite ani2;
    [SerializeField] private float waitTimer = 0f;
    [SerializeField] private float maxWaitTimer = 1f;
    private SpriteRenderer aniSprite;
    private bool hasChanged = false;

    private void Awake()
    {
        aniSprite = gameObject.GetComponent<SpriteRenderer>();    
    }
    private void Update()
    {
        waitTimer++;
        if (waitTimer > maxWaitTimer)
        {
            if (!hasChanged)
            {
                aniSprite.sprite = ani2;
                hasChanged = true;
                waitTimer = 0f;
            }
            else if (hasChanged)
            {
                aniSprite.sprite = ani1;
                hasChanged = false;
                waitTimer = 0f;
            }
        }
    }
}
