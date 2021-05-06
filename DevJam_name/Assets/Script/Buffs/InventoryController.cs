using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryController : MonoBehaviour
{
    public Transform BuffsParent;
    InventoryBuffs inventoryBuffs;

    UIBuff[] slots;
    private void Start()
    {
        inventoryBuffs = InventoryBuffs.instance;
        inventoryBuffs.OnBuffChangedCallBack += UpdateUI;

        slots = BuffsParent.GetComponentsInChildren<UIBuff>();
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++) 
        {
            if (i<inventoryBuffs.buffs.Count)
            {
                slots[i].AddImage(inventoryBuffs.buffs[i]);
            }
            else
            {
                slots[i].RemoveImage();
            }
        }
    }

}
