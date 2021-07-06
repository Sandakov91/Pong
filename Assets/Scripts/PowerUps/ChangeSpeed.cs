using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpeed : PowerUp
{
    [SerializeField] private float speedModifier = 1f;

    public override void ApplyPowerUp()
    {
        base.ApplyPowerUp();
        GameManager.instance.ball.ChangeSpeed(speedModifier);
    }
}
