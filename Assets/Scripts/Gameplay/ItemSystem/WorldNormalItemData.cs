using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldNormalItemData : WorldBaseItemData
{
    public WorldNormalItemData()
    {
    }

    public WorldNormalItemData(BaseNormalItemData baseNormalItemData)
    {
        id = baseNormalItemData.id;
        itemName = baseNormalItemData.itemName;
        description = baseNormalItemData.description;
        canStack = baseNormalItemData.canStack;
        StackNum = 1;
        itemType = baseNormalItemData.itemType;
        price = baseNormalItemData.price;
    }

    
    public string GetDescription()
    {
        string tempDescription = "";
        tempDescription = tempDescription + itemName + "\n";
        tempDescription = tempDescription + "价值：" + price.ToString() + "\n";
        tempDescription = tempDescription + description + "\n";
        return tempDescription;
    }
}
