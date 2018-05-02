using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreMenu : MonoBehaviour
{
    [SerializeField]
    private int characterLimit = 3;

    [SerializeField]
    private InputField inputField;

    // Use this for initialization
    void Start ()
    {
        inputField.characterLimit = characterLimit;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
