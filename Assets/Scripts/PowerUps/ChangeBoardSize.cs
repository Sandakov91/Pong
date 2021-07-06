using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBoardSize : PowerUp
{
    [SerializeField] private Vector3 sizeModifier = new Vector3(0.2f, 0f, 0f);

    public override void ApplyPowerUp()
    {
        base.ApplyPowerUp();
        float playerScale = GameManager.instance.player.transform.localScale.x;
        if (playerScale <= 1.6 && playerScale >= 0.6)
        {
            GameManager.instance.player.transform.localScale += sizeModifier;
        } 
    }
}
