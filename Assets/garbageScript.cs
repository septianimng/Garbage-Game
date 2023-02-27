using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class garbageScript : MonoBehaviour
{
    HorseMovement isHorseDead;
    bool horseDead;
    
    bool spawning;

    float randomNumber;
    float randomBool;

    float horizontalInput = 0f;

    readonly float movementSpeed = 8f;

    readonly int horseLeftPos = 5;
    readonly int horseRightPos = 15;

    readonly int lowRand = 20;
    readonly int highRand = 100;

    // Start is called before the first frame update
    void Start()
    {
        isHorseDead = GameObject.FindGameObjectWithTag("Player").GetComponent<HorseMovement>();
        spawningObject();
    }

    // Update is called once per frame
    void Update()
    {

        horseDead = !isHorseDead.isDead();
        
        if (transform.position.y <= -20)
        {
            spawningObject();
        }

        if (!spawning)
        {
            if (horseDead && (!((GameObject.Find("Horse").transform.position.x) > horseLeftPos && (GameObject.Find("Horse").transform.position.x < horseRightPos))))
            {
                horizontalInput = Input.GetAxis("Horizontal");
                transform.position = transform.position - new Vector3(Input.GetAxis("Horizontal") * movementSpeed * Time.fixedDeltaTime, 0, 0);
            }
        }          
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            spawningObject();
        }
        else spawning = false;
    }

    private void spawningObject()
    {
        randomBool = Random.Range(0, 2);
        randomNumber = Random.Range(lowRand, highRand);
        spawning = true;
        transform.rotation = new Quaternion(0, 0, 0, 0);
        transform.position = new Vector3(35 - (randomBool * 54), randomNumber, 0);
    }   
}
