using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using MSCLoader;
using UnityEngine;

namespace OldFerndale
{
    public class OldFerndaleMod : Mod
    {
        public override string ID => "OldFerndale";
        public override string Name => "Old Ferndale";
        public override string Author => "mldkyt";
        public override string Version => "1.0.0";
        public override string Description => "Old Ferndale mod for My Summer Car.";

        private SettingsCheckBox oldSkin;
        private SettingsCheckBox removeScoop;
        private SettingsCheckBox oldEngine;
        private SettingsCheckBox removeLinelockButton;

        public override void ModSetup()
        {
            SetupFunction(Setup.OnLoad, Mod_Load);
            base.ModSetup();
        }

        public override void ModSettings()
        {
            base.ModSettings();
            oldSkin = Settings.AddCheckBox(this, "oldSkin", "Old Skin", true);
            removeScoop = Settings.AddCheckBox(this, "removeScoop", "Remove Scoop", true);
            oldEngine = Settings.AddCheckBox(this, "oldEngine", "Old Engine", true);
            removeLinelockButton = Settings.AddCheckBox(this, "linelock", "Remove Linelock Button", true);
        }

        private void Mod_Load()
        {
            var resource = LoadResource();

            var texture = resource.LoadAsset<Material>("muscle_paint");

            if (oldSkin.GetValue())
            {
                var ferndaleBody = GameObject.Find("FERNDALE(1630kg)/MESH/muscle_body");
                ferndaleBody.GetComponent<Renderer>().material = texture;

                var leftDoor = GameObject.Find("FERNDALE(1630kg)/DriverDoors/door(leftx)/door");
                leftDoor.GetComponent<Renderer>().material = texture;

                var rightDoor = GameObject.Find("FERNDALE(1630kg)/DriverDoors/door(right)/door 1");
                rightDoor.GetComponent<Renderer>().material = texture;

                var bootlid = GameObject.Find("FERNDALE(1630kg)/Bootlid/Bootlid/muscle_bootlid");
                bootlid.GetComponent<Renderer>().material = texture;
            }

            if (removeScoop.GetValue())
            {
                var scoop = GameObject.Find("FERNDALE(1630kg)/MESH/muscle_Scoop");
                scoop.SetActive(false);
            }

            if (oldEngine.GetValue())
            {
                var ferndale = GameObject.Find("FERNDALE(1630kg)");
                var drivetrain = ferndale.GetComponent<Drivetrain>();
                drivetrain.maxPower = 190;
                drivetrain.maxPowerRPM = 4400;
                drivetrain.maxTorque = 421;
                drivetrain.maxTorqueRPM = 2400;
                drivetrain.originalMaxPower = 210;
                drivetrain.maxNetPower = 0;
                drivetrain.maxNetPowerRPM = 0;
                drivetrain.maxNetTorque = 0;
                drivetrain.maxNetTorqueRPM = 0;
                drivetrain.torque = 0;
                drivetrain.wheelTireVelo = 0;
                drivetrain.minRPM = 730;
                var soundController = ferndale.GetComponent<SoundController>();
                soundController.engineThrottleVolume = 4;
                soundController.engineThrottlePitchFactor = 0.65f;
                soundController.engineNoThrottleVolume = 1.1f;
                soundController.engineNoThrottlePitchFactor = 0.45f;
            }

            if (removeLinelockButton.GetValue())
            {
                var go = GameObject.Find("FERNDALE(1630kg)")
                    .transform
                    .GetChild(1)
                    .GetChild(3)
                    .GetChild(7)
                    .GetChild(0)
                    .GetChild(2)
                    .gameObject;
                go.SetActive(false);
            }
        }

        private AssetBundle LoadResource()
        {
            byte[] data = null;

            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("OldFerndale.Resources.oldferndale.unity3d"))
            {
                data = new byte[stream.Length];
                stream.Read(data, 0, data.Length);
            }

            return AssetBundle.CreateFromMemoryImmediate(data);
        }
    }
}
