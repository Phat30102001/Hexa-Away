using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "HexaSlotMap", menuName = "ScriptableObjects/HexaSlotMap", order = 1)]
public class HexaSlotMap : ScriptableObject
{
    public List<HexaSlotData> SlotMap;
    public int Width;
    public int Height;


    public void GenerateSlotMap()
    {
        SlotMap = new List<HexaSlotData>();
        for (int i = 0; i < Width; i++)
        {
            for (int j = 0; j < Height; j++)
            {
                SlotMap.Add(new HexaSlotData()
                {
                    Position = new Vector2(i, j),
                    IsShow = true
                });
            }
        }
    }

    [CustomEditor(typeof(HexaSlotMap))]
    public class HexaSlotMapEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            // Call the base class method to draw the default inspector
            base.OnInspectorGUI();

            HexaSlotMap myComponent = (HexaSlotMap)target;

            // Create a button
            if (GUILayout.Button("Generate Slot Map"))
            {
                // Call the method in MyComponent
                myComponent.GenerateSlotMap();
            }
        }
    }
}