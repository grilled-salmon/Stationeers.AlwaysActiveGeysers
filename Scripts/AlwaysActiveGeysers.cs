using Stationeers.Addons;
using UnityEngine;

namespace AlwaysActiveGeysers.Scripts
{
    public class AlwaysActiveGeysers : IPlugin
    {
        public void OnLoad()
        {
            Debug.Log(AlwaysActiveGeysers.ModName + ": Loaded");
        }

        public void OnUnload()
        {
            Debug.Log(AlwaysActiveGeysers.ModName + ": Unloaded");
        }

        public static string WorkshopId = "";

        public static string ModName = "AlwaysActiveGeysers";
    }
}
