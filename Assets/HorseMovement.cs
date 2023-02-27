using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HorseMovement : MonoBehaviour
{

    public CharacterController2D horseController;

    public GameObject heart1;
    public GameObject heart2;

    bool twoLifes;
    bool oneLife;
    bool dead;

    counterScript counterText;

    public Animator MyAnim;

    garbageScript counterLife;

    public float xPosition;

    public float runSpeed = 40f;

    float horizontalMove = 0f;

    bool jump = false;
    bool crouch = false;

    // Start is called before the first frame update
    void Start()
    {
        setToTwoLifes();
        counterLife = GameObject.FindGameObjectWithTag("Garbages").GetComponent<garbageScript>();
        counterText = GameObject.FindGameObjectWithTag("Counter").GetComponent<counterScript>();
    }

    // Update is called once per frame
    void Update()
    {
        movementCalculation();       

        if (!isDead())
        {
            horseController.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
            jump = false;
        }
        else
        {
            MyAnim.SetBool("Dead", true);
            StartCoroutine(ExecuteAfterTime(5f));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Garbages"))
        {
            if (isTwoLife())
            {
                setToOneLife();
            }
            else if (isOneLife())
            {
                setToDead();
            }
        }

        if (collision.gameObject.CompareTag("Veggies"))
        {
            counterText.incrementCounter();
        }
    }

    private void movementCalculation()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        MyAnim.SetFloat("Speed", Mathf.Abs(horizontalMove));

        xPosition = transform.position.x;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

        if ((transform.position.x < 5) && (Input.GetAxisRaw("Horizontal") < 0))
        {
            horizontalMove = 0;
        }

        if ((transform.position.x > 15) && (Input.GetAxisRaw("Horizontal") > 0))
        {
            horizontalMove = 0;
        }
    }

    private bool isTwoLife()
    {
        return twoLifes;
    }

    private bool isOneLife()
    {
        return oneLife;
    }

    public bool isDead()
    {
        return dead;
    }

    private void setToTwoLifes()
    {
        twoLifes = true;
        oneLife = false;
        dead = false;
        heart1.SetActive(true);
        heart2.SetActive(true);
    }

    private void setToOneLife()
    {
        twoLifes = false;
        oneLife = true;
        dead = false;
        heart1.SetActive(false);
        heart2.SetActive(true);
    }

    private void setToDead()
    {
        twoLifes = false;
        oneLife = false;
        dead = true;
        heart1.SetActive(false);
        heart2.SetActive(false);
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("DeadScene");
    }
}
