using MSCLoader;
using UnityEngine;

namespace OldFerndale.Features
{
    internal class OldLicensePlate
    {
        internal static void ApplyOldLicensePlate(SettingsCheckBox oldLicensePlate)
        {
            if (!oldLicensePlate.GetValue()) return;
            var hayoRegPlate = GameObject.Find("HAYOSIKO(1500kg, 250)")
                .transform
                .GetChild(6)
                .GetChild(14)
                .gameObject;

            var ferndaleFrontRegPlate = GameObject.Find("FERNDALE(1630kg)")
                .transform
                .GetChild(1)
                .GetChild(11)
                .gameObject;

            var ferndaleRearRegPlate = GameObject.Find("FERNDALE(1630kg)")
                .transform
                .GetChild(1)
                .GetChild(12)
                .gameObject;

            ferndaleFrontRegPlate.GetComponent<Renderer>()
                .material = hayoRegPlate.GetComponent<Renderer>()
                .material;

            ferndaleRearRegPlate.GetComponent<Renderer>()
                .material = hayoRegPlate.GetComponent<Renderer>()
                .material;
        }
    }
}