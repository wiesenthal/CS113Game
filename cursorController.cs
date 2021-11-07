using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Vector3 mousePos = Input.mousePosition;
        transform.position = Camera.main.ScreenToWorldPoint(mousePos);
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // lock to mouse position scaled to camera
        Vector3 mousePos = Input.mousePosition;
        transform.position = Camera.main.ScreenToWorldPoint(mousePos);
    }
}
