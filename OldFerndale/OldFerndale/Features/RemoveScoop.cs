using MSCLoader;
using UnityEngine;

namespace OldFerndale.Features
{
    internal class RemoveScoop
    {
        internal static void ApplyRemoveScoop(SettingsCheckBox removeScoop)
        {
            if (!removeScoop.GetValue()) return;
            var scoop = GameObject.Find("FERNDALE(1630kg)/MESH/muscle_Scoop");
            scoop.SetActive(false);
        }
    }
}