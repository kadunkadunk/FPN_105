using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    private string _selectTag = "Selection";
    private bool _isHighlighted = false;
    private Transform _selection;
    public TMP_Text nameDisplay;
    public float distanceFromItem = 3f;

    private void Update()
    {
        if (_selection != null)
        {
            nameDisplay.text = "";
            _isHighlighted = false;
            //Renderer selectionRenderer = _selection.GetComponent<Renderer>();
            //selectionRenderer.material.DisableKeyword("_EMISSION");
            _selection = null;
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * distanceFromItem, Color.red); 

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distanceFromItem))
        {
            Debug.Log("Test");
            var selection = hit.transform;
            if (selection.CompareTag(_selectTag))
            {
                Debug.Log("Test2");
                if (selection != _isHighlighted)
                {
                    Debug.Log("Test3");
                    _isHighlighted = true;
                    //selection.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                    nameDisplay.text = selection.gameObject.name;
                }
                _selection = selection;
            }
        }
    }
}
   

