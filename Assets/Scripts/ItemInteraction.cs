using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemInteraction : MonoBehaviour
{
    private string _selectTag = "Selection";
    private bool _isHighlighted = false;
    private Transform _selection;
    public TMP_Text nameDisplay;
    public float distanceFromItem = 3f;

    public Animator doorAnimator;
    public GameObject doorText;
    public bool hasKey = false;
    private bool _isOpen = false;

    private void Update()
    {
        if (_selection != null)
        {
            nameDisplay.text = "";
            _isHighlighted = false;
            if (_selection.gameObject.name == "Shovel")
            {
                var materials = _selection.GetComponent<Renderer>().materials;
                materials[1].DisableKeyword("_EMISSION");
            }
            else if (_selection.gameObject.name == "Hammer")
            {
                _selection.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
            }
            //var materials = _selection.GetComponent<Renderer>().materials;
            //materials[1].DisableKeyword("_EMISSION");
            _selection = null;
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        //Debug.DrawRay(ray.origin, ray.direction * distanceFromItem, Color.red); 

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distanceFromItem))
        {
            //Debug.Log("Test");
            var selection = hit.transform;
            if (selection.CompareTag("Selection") || selection.CompareTag("Door"))
            {
                //Debug.Log("Test2");
                if (selection != _isHighlighted)
                {
                    //Debug.Log("Test3");
                    _isHighlighted = true;
                    if (selection.gameObject.name == "Shovel")
                    {
                        selection.GetComponent<Renderer>().materials[1].EnableKeyword("_EMISSION");
                        
                    }
                   else if (selection.gameObject.name == "Hammer")
                    {
                        //Debug.Log("Test4");
                        selection.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                    }
                    else if (selection.gameObject.name == "Paperclip")
                    {
                        selection.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                    }
                    
                    nameDisplay.text = selection.gameObject.name;
                }
                _selection = selection;
            }
        }

        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            DoorInteraction();
        }
    }
    void DoorInteraction()
    {
        RaycastHit hitInfo;
        Vector2 mousePos = Mouse.current.position.ReadValue();
        Ray rayOrigin = Camera.main.ScreenPointToRay(mousePos); 

        if(Physics.Raycast(rayOrigin, out hitInfo, distanceFromItem ))
        {
            var selection = hitInfo.transform;

            if(!_isOpen)
            {
                doorAnimator.SetTrigger("Open");
                doorAnimator.ResetTrigger("Close");
                _isOpen = true;
            }
            else
            {
                doorAnimator.SetTrigger("Close");
                doorAnimator.ResetTrigger("Open");
                _isOpen = false;
            }
        }
    }

}
   

