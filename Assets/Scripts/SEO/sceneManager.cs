using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ClickReset()
    {
        SceneManager.LoadScene("Game Scene");
    }

    public void ClickMenu()
    {
        
        SceneManager.LoadScene("Main Scene");
    }
}