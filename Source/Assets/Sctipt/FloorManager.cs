using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    [SerializeField] GameObject[] floorObjects;
    public void SpawnFloor(string tagName)
    {
        GameObject floor = Instantiate(floorObjects[Random.Range(0, floorObjects.Length)], transform);

        if (tagName == "Floor")
        {
            floor.transform.position = new Vector3(Random.Range(-3f, 3f), -6f, 0f);
        }
        else
        {
            floor.transform.position = new Vector3(Random.Range(-3.2f, 3.2f), -6f, 0f);
            if (floor.transform.position.x < 1)
            {
                floor.transform.GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                floor.transform.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
    }
}
