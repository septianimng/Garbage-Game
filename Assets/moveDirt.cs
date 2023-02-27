using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveDirt : MonoBehaviour
{
    HorseMovement isHorseDead;
    bool horseDead;

    float horizontalInput = 0f;
    
    float movementSpeed = 8f;

    float posX = 57.5f;

    int horseLeftPos = 5;
    int horseRightPos = 15;

    // Start is called before the first frame update
    void Start()
    {
        isHorseDead = GameObject.FindGameObjectWithTag("Player").GetComponent<HorseMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        horseDead = !isHorseDead.isDead();

        if (transform.position.x<=-22)
        {
            transform.position = transform.position + new Vector3(posX, 0, 0);
        }

        if (transform.position.x >= 38)
        {
            transform.position = transform.position - new Vector3(posX, 0, 0);
        }

        if (horseDead && !((GameObject.Find("Horse").transform.position.x) > horseLeftPos && (GameObject.Find("Horse").transform.position.x < horseRightPos)))
        {
            horizontalInput = Input.GetAxis("Horizontal");
            transform.position = transform.position - new Vector3(horizontalInput * movementSpeed * Time.fixedDeltaTime, 0, 0);
        }
        
    }
}
