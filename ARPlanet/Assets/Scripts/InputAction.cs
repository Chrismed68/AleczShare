using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputAction : MonoBehaviour
{
    public string theName;
    public GameObject inputField;
    public GameObject textDisplay;

    public void StoreName()
    {
        theName = inputField.GetComponent<Text>().text;
        textDisplay.GetComponent<Text>().text = "Hello " + theName + " are you ready for your launch today. Don't be nervious you'll do great just try. " +
            "Tap the Knob up there to fastword thorught the scenes";
    }

}
