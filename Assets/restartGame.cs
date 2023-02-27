using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartGame : MonoBehaviour
{
    float time;
    float adTime;

    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;
    public GameObject text5;
    public GameObject text6;
    public GameObject text7;
    public GameObject text8;
    public GameObject text9;
    public GameObject text10;
    public GameObject text11;
    public GameObject text12;

    public GameObject buttonTryAgain;
    public GameObject buttonMenu;

    // Start is called before the first frame update
    void Start()
    {
        setDesactive(text1);
        setDesactive(text2);
        setDesactive(text3);
        setDesactive(text4);
        setDesactive(text5);
        setDesactive(text6); 
        setDesactive(text7);
        setDesactive(text8);
        setDesactive(text9);
        setDesactive(text10);
        setDesactive(text11);
        setDesactive(text12);

        setDesactive(buttonTryAgain);
        setDesactive(buttonMenu);

        time = 0f;

        delayActivation(0.5f, text1);
        delayActivation(2, text2);
        delayActivation(1f, text3);
        delayActivation(1f, text4);
        delayActivation(1f, text5);
        delayActivation(1f, text6);
        delayActivation(2f, text7);
        delayActivation(2.5f, text8);
        delayActivation(2.5f, text9);
        delayActivation(2.5f, text10);
        delayActivation(2.5f, text11);
        delayActivation(2.5f, text12);

        delayActivation(1f, buttonTryAgain);
        delayActivation(0.5f, buttonMenu);
    }

    private void Update()
    {
        if (Input.GetAxisRaw("Fire1")==1)
        {
            setActive(text1);
            setActive(text2);
            setActive(text3);
            setActive(text4);
            setActive(text5);
            setActive(text6);
            setActive(text7);
            setActive(text8);
            setActive(text9);
            setActive(text10);
            setActive(text11);
            setActive(text12);

            StartCoroutine(ExecuteAfterTime(1f, buttonTryAgain));
            StartCoroutine(ExecuteAfterTime(1.5f, buttonMenu));
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void RebootGame()
    {
        SceneManager.LoadScene("Menu");
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

    private void delayActivation(float showTime, GameObject theObject)
    {
        time = time + showTime;
        StartCoroutine(ExecuteAfterTime(time, theObject));
    }
}
