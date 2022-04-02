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
    public GameObject Cam3;
    public GameObject Cam4;
    public GameObject Cam5;
    public GameObject Title;
    public GameObject Music;
    public GameObject MiniMap;
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
        yield return new WaitForSeconds(11);
        
        Cam2.SetActive(true);
        Cam1.SetActive(false);
        yield return new WaitForSeconds(5);
        Cam3.SetActive(true);
        Cam2.SetActive(false);
        yield return new WaitForSeconds(5);
        Cam5.SetActive(true);
        Cam3.SetActive(false);
        yield return new WaitForSeconds(8);
        Cam4.SetActive(true);
        Cam5.SetActive(false);
        yield return new WaitForSeconds(8);
        Cam1.SetActive(true);
        Cam4.SetActive(false);
        

        yield return new WaitForSeconds(17);
        Cam1.SetActive(false);
        player.SetActive(true);
        UI.SetActive(true);
        Symbol.SetActive(true);
        Title.SetActive(false);
        Music.SetActive(false);
        MiniMap.SetActive(true);
        
    }

    
}
