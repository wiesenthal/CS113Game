using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool isWithinBounds(Vector3 pos)
    {
        return GetComponent<Renderer>().bounds.Contains(pos);
    }
}
