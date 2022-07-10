using System;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    private PlayerBehaviour _playerBehaviour;

    private void Start()
    {
        _playerBehaviour = GetComponent<PlayerBehaviour>();
    }

    private void Update()
    {
        // Use legacy input manager for convenience
        var hValue = Input.GetAxisRaw("Horizontal");
        var vValue = Input.GetAxisRaw("Vertical");
        var leftShiftPressed = Input.GetKey(KeyCode.LeftShift);

        _playerBehaviour.HandleInput(hValue, vValue, leftShiftPressed);
    }
}
