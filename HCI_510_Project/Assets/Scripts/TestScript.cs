using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoonSharp.Interpreter;
using System.IO;

public class TestScript : MonoBehaviour
{
    public string result = "LOL";
    public string myScript;
    Script script;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		//Debug.Log("Val 1: " + MoonSharpFactorial());
		//Debug.Log(", Val 2: " + MoonSharpFactorial2());
		//Debug.Log(", Val 3: " + MoonSharpFactorial3());
    }
    public Script initScript(string ScriptText)
    {
        script = new Script();
        myScript = ScriptText;
        script.DoString(myScript);
        return script;
    }

    public void RunScript()
    {
        script.Globals["result"] = result; // Come back to this!!
        Debug.Log(script.Globals["result"]);
        DynValue val = script.Call(script.Globals["fact"]);
        result = val.CastToString(); // Come back to this!!
        Debug.Log(val.CastToString());
        Debug.Log("Script complete");


    }

    public void initScriptFromFile(string fileName)
    {
        script = new Script();
        StreamReader sr = new StreamReader(fileName);
        string tmpString = sr.ReadToEnd();
        script.DoString(tmpString);
    }

    /*
    double MoonSharpFactorial()
    {
        string scriptCode = @"    
		-- defines a factorial function
		function fact (n)
			if (n == 0) then
				return 1
			else
				return n*fact(n - 1)
			end
		end

		return fact(mynumber)";

        Script script = new Script();

        script.Globals["mynumber"] = 7;

        DynValue res = script.DoString(scriptCode);
        return res.Number;
    }

    double MoonSharpFactorial2()
    {
        string scriptCode = @"    
		-- defines a factorial function
		function fact (n)
			if (n == 0) then
				return 1
			else
				return n*fact(n - 1)
			end
		end";

        Script script = new Script();

        script.DoString(scriptCode);

        DynValue res = script.Call(script.Globals["fact"], 4);

        return res.Number;
    }

    double MoonSharpFactorial3()
    {
        string scriptCode = @"    
		-- defines a factorial function
		function fact (n)
			if (n == 0) then
				return 1
			else
				return n*fact(n - 1)
			end
		end";

        Script script = new Script();
        script.DoString(scriptCode);
        DynValue luaFactFunction = script.Globals.Get("fact");
        DynValue res = script.Call(luaFactFunction, 4);
        return res.Number;
    }*/


}
