using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSequence : MonoBehaviour
{
    public GameObject player;
    public GameObject Cam1;
    public GameObject Cam2;
    public GameObject UI;
    public GameObject Symbol;
    //public GameObject Cam3;
    //public GameObject Cam4;
    //public GameObject Cam5;
    //public GameObject Cam6;
    //public GameObject Cam7;
    //public GameObject Cam8;
    //public GameObject Cam9;
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TheSequence());
    }
    IEnumerator TheSequence()
    {
        yield return new WaitForSeconds(50);
        
        Cam2.SetActive(true);
        Cam1.SetActive(false);
        //yield return new WaitForSeconds(4);
        //Cam3.SetActive(true);
        //Cam2.SetActive(false);
        //yield return new WaitForSeconds(4);
        //Cam4.SetActive(true);
        //Cam3.SetActive(false);
        //yield return new WaitForSeconds(4);
        //Cam5.SetActive(true);
        //Cam4.SetActive(false);
        //yield return new WaitForSeconds(4);
        //Cam6.SetActive(true);
        //Cam5.SetActive(false);
        //yield return new WaitForSeconds(4);
        //Cam7.SetActive(true);
        //Cam6.SetActive(false);
        //yield return new WaitForSeconds(4);
        //Cam8.SetActive(true);
        //Cam7.SetActive(false);
        //yield return new WaitForSeconds(4);
        //Cam9.SetActive(true);
        //Cam8.SetActive(false);
        
        yield return new WaitForSeconds(4);
        Cam2.SetActive(false);
        player.SetActive(true);
        UI.SetActive(true);
        Symbol.SetActive(true);
        
    }

    
}
