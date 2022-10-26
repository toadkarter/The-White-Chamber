using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    private Image _pointer = null;
    private readonly Color _onColor = Color.red;
    private readonly Color _offColor = Color.white;
    
    // Start is called before the first frame update
    void Start()
    {
        _pointer = GetComponentInChildren<Image>();
    }

    public void togglePointer(bool on)
    {
        _pointer.color = @on ? _onColor : _offColor;
    }
}
