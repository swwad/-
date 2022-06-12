using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, moveSpeed * Time.deltaTime, 0f);
        if (transform.position.y > 5f)
        {
            Destroy(this.gameObject);
            transform.parent.GetComponent<FloorManager>().SpawnFloor(transform.tag);
        }
    }
}
