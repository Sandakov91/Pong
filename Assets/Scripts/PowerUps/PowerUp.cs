using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    private float speed = 3f;
    private int scoreCost = 30;
    void Start()
    {
        
    }
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        if(transform.position.y <= 0f)
        {
            Destroy(gameObject);
        }
    }
    public virtual void ApplyPowerUp()
    {
        GameManager.instance.IncreaseScore(scoreCost);
    }
}
