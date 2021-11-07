using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolController : GunController
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        fireRate = 1.5f;
    }

}
