using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Info : MonoBehaviour
{
    [SerializeField] private Text _applesPickedText;
    [SerializeField] private Text _totalDistanceText;

    [SerializeField] private ApplePicker _applePicker;
    [SerializeField] private MovementController _movementController;
    void Start()
    {
        _applesPickedText.text = $"Apples Picked: {_applePicker.ApplesPicked}";
        _totalDistanceText.text = $"Total Distance: {_movementController.TotalDistance}";
    }
    
    void Update()
    {
        _applesPickedText.text = $"Apples Picked: {_applePicker.ApplesPicked}";
        _totalDistanceText.text =
            $"Total Distance: {Mathf.Round(_movementController.TotalDistance * 100f) / 100f}m.";
    }
}
