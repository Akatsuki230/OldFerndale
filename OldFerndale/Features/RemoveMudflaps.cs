using MSCLoader;
using UnityEngine;

namespace OldFerndale.Features
{
    internal class RemoveMudflaps
    {
        internal static void ApplyRemoveMudflaps(AssetBundle resource, SettingsCheckBox removeMudflaps)
        {
            if (!removeMudflaps.GetValue()) return;
            GameObject.Find("FERNDALE(1630kg)")
                .transform
                .GetChild(1)
                .GetChild(14)
                .GetChild(6)
                .gameObject
                .SetActive(false);

            var chassis = GameObject.Find("FERNDALE(1630kg)")
                .transform
                .GetChild(1)
                .GetChild(14)
                .GetChild(0)
                .gameObject;

            chassis.GetComponent<MeshFilter>().sharedMesh = resource.LoadAsset<Mesh>("muscle_chassis.mat");
            // chassis.GetComponent<Renderer>().materials = new Material[1] { new Material(Shader.Find("Diffuse")) { color = Color.white } };
        }
    }
}