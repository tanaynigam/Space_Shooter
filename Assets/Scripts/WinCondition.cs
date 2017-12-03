using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour {

    public static float win = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (win == 1)
        {
            TextMesh wincondition = GameObject.Find("WinCondition").GetComponent<TextMesh>();
            wincondition.text = "You Win!";
            win = 0;
            StartCoroutine(Wait());
        }
        else if (win == -1)
        {
            TextMesh wincondition = GameObject.Find("WinCondition").GetComponent<TextMesh>();
            wincondition.text = "You Lose";
            StartCoroutine(Wait());
            win = 0;
        }
	}

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        TextMesh wincondition = GameObject.Find("WinCondition").GetComponent<TextMesh>();
        wincondition.text = "";
    }
}
