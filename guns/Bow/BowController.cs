using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowController : GunController
{
    // Start is called before the first frame update
    override public void Start()
    {
        base.Start();
        fireRate = 0.75f; // per second

    }

}
