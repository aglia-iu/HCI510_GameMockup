using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select3DObject : MonoBehaviour
{
    private Renderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        Debug.Log("Click!");
        renderer.material.color =
            renderer.material.color == Color.red ? Color.blue : Color.red;
    }
}
