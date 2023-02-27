using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class counterScript : MonoBehaviour
{
    int counter;

    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void incrementCounter()
    {
        counter++;
        GetComponent<TMPro.TextMeshProUGUI>().text = counter.ToString();
    }

    public int getCounter()
    {
        return counter;
    }

}
