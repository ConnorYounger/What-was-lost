using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayCollider : MonoBehaviour

{
    public Text myText;
    private Camera myCamera;
    // Start is called before the first frame update
    void Start()
    {
        myCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = myCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit other;
        if (Physics.Raycast(ray, out other))
        {
            myText.text = other.collider.name;
        }
        else
        {
            myText.text = "Not Hittin Anythin";
        }
    }
}
