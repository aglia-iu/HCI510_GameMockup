using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{
    TestScript testScript;
    public TMP_InputField inputField;
    public TMP_Text resultText;
    // Start is called before the first frame update
    void Start()
    {
        string tmpString = @"
        -- defines a factorial function
		function fact ()
			return 'Hello World!'
			end
		end";
        testScript = inputField.GetComponentInChildren<TestScript>();
        testScript.initScript(tmpString);
        inputField.text = testScript.myScript;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateScript()
    {
        string tmpString = inputField.text;
        testScript.initScript(tmpString);
        testScript.RunScript();
        
        resultText.text = testScript.result;

    }
}
