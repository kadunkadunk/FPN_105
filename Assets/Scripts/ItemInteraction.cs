using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    private string _selectTag = "Selection";
    private bool _isHighlighted = false;
    private Transform _selection;
    public TMP_Text _nameDisplay;
    public float distanceFromItem = 3f;

    private void Update()
    {
        if (_selection != null)
        {
            _isHighlighted = false;
            _selection = null;
            Renderer selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material.DisableKeyword("_EMISSION");
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distanceFromItem))
        {
            var selection = hit.transform;
            if (selection.CompareTag(_selectTag))
            {
                if (selection != _isHighlighted)
                {
                    selection.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                    _isHighlighted = true;
                    _nameDisplay.text = selection.gameObject.name;
                }
                _selection = selection;
            }
        }
    }
}

