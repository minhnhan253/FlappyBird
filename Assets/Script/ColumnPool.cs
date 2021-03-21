using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{
    public int poolSize = 5;
    public GameObject columnPrefab;
    public float spawRate;
    public float columnMinY = -1f;
    public float columnMaxY = 35f;

    private GameObject[] columns;
    private Vector2 poolObjPosition  = new Vector2(-35f, -25f);
    private float timeSinceLastSpawned = 0f;
    private float spawXPosition = 15f;
    private int currentColumn = 0;
    private float timeSpaw = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        columns = new GameObject[poolSize];

        for (int i = 0; i < poolSize; i++)
        {
            columns[i] = (GameObject) Instantiate (columnPrefab,  poolObjPosition, Quaternion.identity);
        }
        timeSpaw = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;
        if (GameController.instance.gameOver == false && timeSinceLastSpawned >= timeSpaw)
        {
            timeSpaw = spawRate;
            timeSinceLastSpawned = 0f;
            float columnY = Random.Range(columnMinY, columnMaxY);
            columns[currentColumn].transform.position = new Vector2(spawXPosition, columnY);
            currentColumn ++;
            if (currentColumn >= poolSize) currentColumn = 0;
        }
    }
}
