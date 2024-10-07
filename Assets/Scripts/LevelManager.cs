using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Transform slotContainerTransform;
    [SerializeField] private HexaSlot hexaSlotPrefab;
    [SerializeField] private List<HexaSlot> slotList;
    [SerializeField] private List<HexaSlotMap> mapList;
    [SerializeField] private float spacing = 1.5f; 
    private int maxWidthAmount;
    private int maxHeightAmount;
    private float slotSize;
    [SerializeField] private int currentMapIndex = 0;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        getSlotSize();
        GenerateSlots(currentMapIndex);
    }

    private void getSlotSize()
    {
        // get slot size
        slotSize = hexaSlotPrefab.GetSlotSize() + spacing;
    }

    public void GenerateSlots(int _currentMapIndex)
    {
        HexaSlotMap _mapData = mapList[_currentMapIndex];
        maxWidthAmount = _mapData.Width;
        maxHeightAmount = _mapData.Height;
        float offsetX = (maxWidthAmount % 2 == 0)
            ? (maxWidthAmount / 2 - 0.5f) * slotSize * 0.75f
            : (maxWidthAmount / 2) * slotSize * 0.75f;
        float offsetY = (maxHeightAmount - 1) * slotSize / 2;

        foreach (var slot in _mapData.SlotMap)
        {
            if (!slot.IsShow) continue;

            HexaSlot hexaSlot = Instantiate(hexaSlotPrefab, slotContainerTransform);
            float xPos = slot.Position.x * slotSize * 0.75f - offsetX;
            float yPos = slot.Position.y * slotSize + (slot.Position.x % 2 == 0 ? 0 : slotSize / 2) - offsetY;
            hexaSlot.transform.localPosition = new Vector2(xPos, yPos);
            hexaSlot.SetData(new HexaSlotData { Position = slot.Position });
            slotList.Add(hexaSlot);
        }
    }
}