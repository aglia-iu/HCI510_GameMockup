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
    void ChangeColorBlue()
    {
        Debug.Log("Click!");
        _renderer.material.color =
            _renderer.material.color == Color.blue ? Color.yellow : Color.blue;
    }
    public void MoveObject(float x, float y, float z)
    {
        _renderer.transform.position = new Vector3(_renderer.transform.position.x + x, _renderer.transform.position.y + y, _renderer.transform.position.z + z);

    }
    public void DuplicateObject()
    {
        GameObject objToInstantiate = Instantiate(_renderer.gameObject);
        objToInstantiate.name = _renderer.gameObject.name + "_";

    }
    public void RotateObject(float x, float y, float z, float w)
    {
        _renderer.transform.rotation = new Quaternion(_renderer.transform.rotation.x + x, _renderer.transform.rotation.y + y, _renderer.transform.rotation.z + z, _renderer.transform.rotation.w + w);

    }
    public void ChangeColorRed()
    {
        Debug.Log("Color change in progress...");
        _renderer.material.color =
            _renderer.material.color == Color.red ? Color.yellow : Color.red;
        Debug.Log("Color change successful!");

    }

    // OnMouseDown is called once per frame
    void OnMouseDown()
    {
        ChangeColorBlue();
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
