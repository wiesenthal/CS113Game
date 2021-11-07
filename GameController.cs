using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public GameObject background;
    public GameObject bugEnemy;
    
    void Start()
    {
        createEnemies();
    }

    void createEnemies()
    {
        // create 5 bug enemies randomly scattered on the background
        int numEnemies = 5;
        // get background size
        Vector3 bottomLeft = background.GetComponent<Renderer>().bounds.min;
        Vector3 topRight = background.GetComponent<Renderer>().bounds.max;
        Debug.Log("bg: " + bottomLeft[0] + topRight[0]);
        for (int i = 0; i < numEnemies; i++)
        {
            Vector3 position = new Vector3(Random.Range(bottomLeft[0], topRight[0]), Random.Range(bottomLeft[1], topRight[1]), 0);
            Instantiate(bugEnemy, position, Quaternion.identity);
        }
    }
}
