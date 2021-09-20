using Assets.Scripts.Inventory;
using Assets.Scripts.Objects;
using Assets.Scripts.Objects.Structures;
using Assets.Scripts.Util;
using Assets.Scripts.Voxel;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Weather;

namespace AlwaysActiveGeysers.Scripts
{
    [HarmonyPatch(typeof(GeyserObject))]
    public static class GeyserObjectPatch
	{
		[HarmonyPatch("SetVisible")]
        [HarmonyPrefix]
		public static bool SetVisible(GeyserObject __instance, bool isVisble)
		{
			/* base method */
			bool flag1 = !__instance.GameObject || __instance.GameObject.activeSelf == isVisble;
			if (!flag1)
			{
				__instance.SetActive(isVisble);
			}
			/* base method */
			bool flag = !isVisble;
			if (flag)
			{
				__instance.Pool.MineableObjects.Enqueue(__instance);
			}
			/* end base method */
			/* end base method */

			//if (flag)
			//{
			//	GeyserObject.AllActiveGeysers.Remove(this);
			//	Structure.OnAnyConstructed -= this.CheckState;
			//	Structure.OnAnyBuildState -= this.CheckState;
			//	ChunkObject.OnAnyVoxel -= this.CheckState;
			//}

			return false; // skip original method
		}

		[HarmonyPatch("Initialize")]
		[HarmonyPrefix]
		public static bool InitializePrefix(GeyserObject __instance)
		{
			/* base method */
			__instance.SetRotation(); 
			/* end base method */

			// Only add geysers to active list if they arent already in there. We do this to prevent duplicates, since we dont remove them now.
			if (GeyserObject.AllActiveGeysers.FindIndex(x => x.GetInstanceID() == __instance.GetInstanceID()) == -1)
				GeyserObject.AllActiveGeysers.Add(__instance);

			__instance.CurrentGrid = __instance.GasTransform.position.ToGrid(2f, 0f);
			__instance.RefreshState();
			Structure.OnAnyConstructed += __instance.CheckState;
			Structure.OnAnyBuildState += __instance.CheckState;
			ChunkObject.OnAnyVoxel += __instance.CheckState;

			return false; // skip orignal method
		}
	}
}
