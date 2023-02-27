using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class startGame : MonoBehaviour
{
    float time;
    bool textAppearing;

    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;
    public GameObject text5;
    public GameObject text6;

    public GameObject buttonNext;
    public GameObject buttonStart;

    // Start is called before the first frame update
    void Start()
    {
        setDesactive(text1);
        setDesactive(text2);
        setDesactive(text3);
        setDesactive(text4);
        setDesactive(text5);
        setDesactive(text6);
        setDesactive(buttonNext);

        textAppearing = false;
    }

    private void Update()
    {
        if (textAppearing && Input.GetAxisRaw("Fire1") == 1)
        {
            setActive(text1);
            setActive(text2);
            setActive(text3);
            setActive(text4);
            setActive(text5);
            setActive(text6);

            StartCoroutine(ExecuteAfterTime(1f, buttonNext));
        }
    }

    public void startText()
    {
        transform.position = transform.position + new Vector3(0, 250, 0);
        StartCoroutine(ExecuteAfterTime(0.5f, text1));
        StartCoroutine(ExecuteAfterTime(2f, text2));
        StartCoroutine(ExecuteAfterTime(5f, text3));
        StartCoroutine(ExecuteAfterTime(7.5f, text4));
        StartCoroutine(ExecuteAfterTime(11.5f, text5));
        StartCoroutine(ExecuteAfterTime(13f, text6));
        StartCoroutine(ExecuteAfterTime(14f, buttonNext));

        textAppearing = true;
    }

    public void beginGame()
    {
        SceneManager.LoadScene("Main");
    }

    private void setActive(GameObject theObject)
    {
        theObject.SetActive(true);
    }

    private void setDesactive(GameObject theObject)
    {
        theObject.SetActive(false);
    }

    IEnumerator ExecuteAfterTime(float time, GameObject theObject)
    {
        yield return new WaitForSeconds(time);
        setActive(theObject);
    }
}
