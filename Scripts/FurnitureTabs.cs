using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureTabs : MonoBehaviour
{

    public GameObject tabbutton1;
    public GameObject tabbutton2;
    public GameObject tabbutton3;

    public GameObject tabcontent1;
    public GameObject tabcontent2;
    public GameObject tabcontent3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HideAllTabs()
    {
        tabcontent1.SetActive(false);
        tabcontent2.SetActive(false);
        tabcontent3.SetActive(false);
    }

    public void ShowTab1() 
    {
        HideAllTabs();
        tabcontent1.SetActive(true);
    }

    public void ShowTab2()
    {
        HideAllTabs();
        tabcontent2.SetActive(true);
    }

    public void ShowTab3()
    {
        HideAllTabs();
        tabcontent3.SetActive(true);
    }


}
