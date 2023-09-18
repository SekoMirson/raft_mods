using RaftModLoader;
using UnityEngine;
using System.Collections.Generic;

public class GiveItem : Mod
{
    private void Awake()
    {
        RConsole.RegisterCommand("give", GiveItemCommand, "Give an item to the player.");
        Debug.Log("Mod GiveItem has been loaded!");
    }

    private void GiveItemCommand(List<string> args)
    {
        if (args.Count < 3)
        {
            RConsole.Log("Usage: give item_name amount");
            return;
        }

        string itemName = args[1];
        int amount;

        if (!int.TryParse(args[2], out amount))
        {
            RConsole.Log("Invalid amount specified.");
            return;
        }
		
		RAPI.GetLocalPlayer().Inventory.AddItem(itemName, amount);
        RConsole.Log($"{amount} {itemName}(s) given to the player.");
    }

    public void OnModUnload()
    {
        RConsole.UnregisterCommand("give");
        Debug.Log("Mod GiveItem has been unloaded!");
    }
}
