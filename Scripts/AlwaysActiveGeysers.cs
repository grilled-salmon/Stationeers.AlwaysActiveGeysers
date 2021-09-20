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

        public static string WorkshopId = "2607080562";

        public static string ModName = "AlwaysActiveGeysers";
    }
}
