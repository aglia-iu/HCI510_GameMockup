using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Select3DObject : MonoBehaviour
{
    public GameObject canvasObject;

    // private Transform transform;
    private Camera mainCamera;
    private Renderer _renderer;
    private Color prevColor;
    private bool click = true;
    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<Renderer>();
    }


    // OnMouseDown is called once per frame
    void OnMouseDown()
    {
        Debug.Log("Click!");
        _renderer.material.color =
            _renderer.material.color == Color.blue ? Color.yellow : Color.blue;
        if (click)
        {
            InstantiateNameTag();
        }
        else
        {
            DestroyNameTag();
        }
        click = !click;
    }

    void InstantiateNameTag()
    {
        GameObject objToInstantiate = Instantiate(canvasObject);
        TextMeshProUGUI text = objToInstantiate.GetComponentInChildren<TextMeshProUGUI>();
        objToInstantiate.transform.SetPositionAndRotation(new Vector3(_renderer.transform.position.x, _renderer.transform.position.y + 0.5f, _renderer.transform.position.z), new Quaternion(0,0,0,0));
        text.text = _renderer.gameObject.name;
    }
    void DestroyNameTag()
    {
        GameObject objToDestroy = GameObject.FindGameObjectWithTag("tag");
        Destroy(objToDestroy);
    }
}
