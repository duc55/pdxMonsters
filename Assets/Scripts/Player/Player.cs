using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Sprite[] playerSprites;

    [Header("Components")]
    [SerializeField] private Image playerImage;
    [SerializeField] private Animation anim;

    private int spriteIndex;

    private void Awake()
    {
        spriteIndex = Random.Range(0, playerSprites.Length);
        UpdateSprite();
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Attack();
        }
    }

    public void Attack()
    {
        if (!ClickManager.Instance.IsMouseOverEnemy) return;

        anim.Stop();
        anim.Play();
    }

    public void SetNextSprite()
    {
        spriteIndex++;
        if (spriteIndex >= playerSprites.Length) {
            spriteIndex = 0;
        }

        UpdateSprite();
    }

    private void UpdateSprite()
    {
        playerImage.sprite = playerSprites[spriteIndex];
    }
}
