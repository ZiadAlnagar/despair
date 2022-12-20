using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationController : MonoBehaviour
{
    public void GoToIntroScene()
    {
        Application.LoadLevel(0);
    }
    public void GoToLevelOne()
    {
        Application.LoadLevel(1);
    }

    public void GoToLevelTwo()
    {
        Application.LoadLevel(2);
    }

    public void GoToLevelThree()
    {
        Application.LoadLevel(3);
    }

    public void GoToEndScreen()
    {
        Application.LoadLevel(4);
    }

    public void Quit()
    {
        Application.Quit();
    }


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
