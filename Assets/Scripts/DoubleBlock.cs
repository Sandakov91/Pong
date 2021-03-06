using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleBlock : MonoBehaviour
{
    private int scoreCost = 70;
    private bool isQuitting = false;
    private GameObject[] powerUpPrefabs => GameManager.instance.powerUpPrefabs;
    private bool isBroken = false;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite secondPhaseSprite;
    private void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.GetComponent<Ball>() && !isBroken)
        {
            isBroken = true;
            spriteRenderer.sprite = secondPhaseSprite;
            spriteRenderer.color = Color.green;
        }
        else if (collision.collider.GetComponent<Ball>() && isBroken)
        {
            Destroy(gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        isQuitting = true;
    }

    private void OnDestroy()
    {
        GameManager.instance.ReduceBlocksAmount();
        GameManager.instance.IncreaseScore(scoreCost);
        if (Random.Range(0f, 1f) <= 0.4f && !isQuitting)
        {
            GameObject powerUp = Instantiate(powerUpPrefabs[Random.Range(0, powerUpPrefabs.Length)], transform.position, transform.rotation);
            powerUp.transform.SetParent(null);
        }
    }
}
