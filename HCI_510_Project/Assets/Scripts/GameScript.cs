using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using MoonSharp.Interpreter;

public class GameScript : MonoBehaviour
{   
    public Select3DObject select3DObject;
    TestScript testScript;
    public TMP_InputField inputField;
    public TMP_Text resultText;
    // Start is called before the first frame update
    void Start()
    {
        /*string tmpString = @"
        -- defines a factorial function
		function fact ()
			return 'Hello World!'
	    end";*/

        testScript = inputField.GetComponentInChildren<TestScript>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void UpdateScript()
    {
        string tmpString = inputField.text;
        /*testScript.initScript(tmpString);
        testScript.RunScript();*/

        Script script = testScript.initScript(tmpString);
        //inputField.text = testScript.myScript;

        UserData.RegisterType<Select3DObject>();// Register GameObject Type here.
        script.Globals["cube"] = select3DObject;
        testScript.RunScript();

        resultText.text = testScript.result;
    }
}
