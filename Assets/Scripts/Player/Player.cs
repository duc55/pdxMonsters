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


    private void Awake()
    {
        playerImage.sprite = playerSprites[Random.Range(0, playerSprites.Length)];
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Attack();
        }
    }

    public void Attack()
    {
        anim.Stop();
        anim.Play();
    }
}
