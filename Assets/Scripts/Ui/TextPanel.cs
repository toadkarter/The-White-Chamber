using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextPanel : MonoBehaviour
{
    private TextMeshProUGUI _text; 
    
    // Start is called before the first frame update
    private void Start()
    {
        _text = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetText(string text)
    {
        _text.text = text;
    }

    public void ClearText()
    {
        _text.text = "";
    }
}
