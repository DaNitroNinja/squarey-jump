using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonPress : MonoBehaviour
{

    public GameObject menuManager;
    public Button play;
    public Button changeLog;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }

[ContextMenu("PlayButton")]
    public void Play() 
    {
        SceneManager.LoadScene(1);
    }
}
