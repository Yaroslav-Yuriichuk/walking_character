using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplePicker : MonoBehaviour
{
    [SerializeField] private int _applesPicked = 0;
    private string _lastTouchedAppleName = "";
    
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        GameObject objectCollided = hit.gameObject;
        
        if (objectCollided.CompareTag("Apple") && _lastTouchedAppleName != objectCollided.name)
        {
            Destroy(objectCollided);
            _applesPicked++;
            _lastTouchedAppleName = objectCollided.name;
        }
    }
}
