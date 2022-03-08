using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseNav : MonoBehaviour
{
    // Use this for initialization
    void Awake()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = true;
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Game");


        }else
        {
            if (Input.GetKeyDown("b"))
            {
                SceneManager.LoadScene("WorldScene");
            }
        }

        
    }
}
