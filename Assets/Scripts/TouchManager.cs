using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    [SerializeField] LayerMask _lm;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, _lm))
            {
                hit.collider.GetComponent<IDashable>().ActiveDash();
            }
        }

        
        
    }
}
