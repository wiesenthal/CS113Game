using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehavior : ProjectileBehavior
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        speed = 10f;
        lifeTime = 2f;
        damage = 50f;
        knockbackMultiplier = 1f;
    }
}
