using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HexaSlot : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private TextMeshProUGUI slotPositionText;

    public float GetSlotSize()
    {
        // get slot size
        return rectTransform.sizeDelta.x;
    }

    public void SetData(HexaSlotData _data)
    {
        slotPositionText.text = $"({(int)_data.Position.x}, {(int)_data.Position.y})";
    }
}
[Serializable]
public class HexaSlotData
{
    public Vector2 Position;
    public bool IsShow;
}
