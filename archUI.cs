using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class archUI : MonoBehaviour
{
    public GameObject panel;
    public GameObject panel1;
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(true);
        panel1.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void getstarted()
    {
        panel1.SetActive(true);
        panel.SetActive(false);
    }
    public void mainpage()
    {
        panel.SetActive(true);
        panel1.SetActive(false);
    }

}
