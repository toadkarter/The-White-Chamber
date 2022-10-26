using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] private Image pointer = null;
    [SerializeField] private Image inventory = null;
    [SerializeField] public Sprite defaultInventoryImage = null;
    private readonly Color _onColor = Color.red;
    private readonly Color _offColor = Color.white;

    [SerializeField] private TextPanel textPanel = null;
    private bool _textPanelEnabled = false;

    private void Start()
    {
        textPanel.gameObject.SetActive(_textPanelEnabled);
        inventory.sprite = defaultInventoryImage;
    }

    public void TogglePointer(bool on)
    {
        pointer.color = @on ? _onColor : _offColor;
    }

    public void ToggleTextPanel(bool on)
    {
        textPanel.gameObject.SetActive(@on);
    }

    public void DisplayText(string text)
    {
        textPanel.SetText(text);
    }

    public void ClearText()
    {
        textPanel.ClearText();
    }

    public void SetCursorIsVisible(bool on)
    {
        pointer.gameObject.SetActive(@on);
    }

    public void SetInventoryImage(Sprite image)
    {
        if (image == null) return;
        inventory.sprite = image;
    }
}
