using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : ProjectileBehavior
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        speed = 40f;
        lifeTime = 0.7f;
        damage = 25f;
        knockbackMultiplier = 0.5f;
    }
}
