using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using HutongGames.PlayMaker.Actions;
using MSCLoader;
using UnityEngine;

namespace OldFerndale
{
    public class OldFerndaleMod : Mod
    {
        public override string ID => "OldFerndale";
        public override string Name => "Old Ferndale";
        public override string Author => "アカツキ(Akatsuki)";
        public override string Version => "1.2";
        public override string Description => "Old Ferndale mod for My Summer Car.";

        private SettingsSliderInt oldSkin;
        private SettingsSliderInt oldWheels;
        private SettingsSliderInt tachometer;
        private SettingsSliderInt interior;
        private SettingsCheckBox removeScoop;
        private SettingsCheckBox oldEngine;
        private SettingsCheckBox removeLinelockButton;
        private SettingsCheckBox oldLicensePlate;
        private SettingsCheckBox removeMudflaps;
        private SettingsCheckBox oldSuspension;
        private SettingsCheckBox removeRearAxle;
        private SettingsCheckBox redInterior;

        public override void ModSetup()
        {
            SetupFunction(Setup.OnLoad, Mod_Load);
            base.ModSetup();
        }

        public override void ModSettings()
        {
            base.ModSettings();
            oldSkin = Settings.AddSlider(this, "skin", "Skin", 0, 4, 1, textValues: new string[] { "Leave as is", "2016", "build 178", "Red", "Blue" });
            oldWheels = Settings.AddSlider(this, "oldWheels", "Old Wheels", 0, 2, 1, textValues: new string[] { "No change", "Wheels from 2016", "Wheels from Build 178" });
            tachometer = Settings.AddSlider(this, "tachometer", "Tachometer", 0, 2, 1, textValues: new string[] { "Unchanged", "Old", "Remove" });
            removeScoop = Settings.AddCheckBox(this, "removeScoop", "Remove Scoop", true);
            oldEngine = Settings.AddCheckBox(this, "oldEngine", "Old Engine", true);
            removeLinelockButton = Settings.AddCheckBox(this, "linelock", "Remove Linelock Button", true);
            removeMudflaps = Settings.AddCheckBox(this, "removeMudflaps", "Remove Mudflaps", true);
            oldSuspension = Settings.AddCheckBox(this, "oldSuspension", "Old Suspension", true);
            removeRearAxle = Settings.AddCheckBox(this, "removeRearAxle", "Remove Rear Axle", true);
            redInterior = Settings.AddCheckBox(this, "redInterior", "Red Interior", false);
            oldLicensePlate = Settings.AddCheckBox(this, "oldLicPlate", "Old License Plate", false);

            Settings.AddButton(this, "Suggest new features", () =>
            {
                ModUI.ShowYesNoMessage("Open website: https://mldkyt.com/suggestions?type=oldferndale", () =>
                {
                    Application.OpenURL("https://mldkyt.com/suggestions?type=oldferndale");
                });
            });
        }

        private void Mod_Load()
        {
            var resource = LoadResource();

            switch (oldSkin.GetValue())
            {
                case 1:
                    {
                        var texture = resource.LoadAsset<Material>("muscle_2016");
                        var ferndaleBody = GameObject.Find("FERNDALE(1630kg)/MESH/muscle_body");
                        ferndaleBody.GetComponent<Renderer>().material = texture;

                        var leftDoor = GameObject.Find("FERNDALE(1630kg)/DriverDoors/door(leftx)/door");
                        leftDoor.GetComponent<Renderer>().material = texture;

                        var rightDoor = GameObject.Find("FERNDALE(1630kg)/DriverDoors/door(right)/door 1");
                        rightDoor.GetComponent<Renderer>().material = texture;

                        var bootlid = GameObject.Find("FERNDALE(1630kg)/Bootlid/Bootlid/muscle_bootlid");
                        bootlid.GetComponent<Renderer>().material = texture;
                        break;
                    }
                case 2:
                    {
                        var texture = resource.LoadAsset<Material>("muscle_178");
                        var ferndaleBody = GameObject.Find("FERNDALE(1630kg)/MESH/muscle_body");
                        ferndaleBody.GetComponent<Renderer>().material = texture;

                        var leftDoor = GameObject.Find("FERNDALE(1630kg)/DriverDoors/door(leftx)/door");
                        leftDoor.GetComponent<Renderer>().material = texture;

                        var rightDoor = GameObject.Find("FERNDALE(1630kg)/DriverDoors/door(right)/door 1");
                        rightDoor.GetComponent<Renderer>().material = texture;

                        var bootlid = GameObject.Find("FERNDALE(1630kg)/Bootlid/Bootlid/muscle_bootlid");
                        bootlid.GetComponent<Renderer>().material = texture;
                        break;
                    }
                case 3:
                    {
                        var texture = resource.LoadAsset<Material>("red");
                        var ferndaleBody = GameObject.Find("FERNDALE(1630kg)/MESH/muscle_body");
                        ferndaleBody.GetComponent<Renderer>().material = texture;

                        var leftDoor = GameObject.Find("FERNDALE(1630kg)/DriverDoors/door(leftx)/door");
                        leftDoor.GetComponent<Renderer>().material = texture;

                        var rightDoor = GameObject.Find("FERNDALE(1630kg)/DriverDoors/door(right)/door 1");
                        rightDoor.GetComponent<Renderer>().material = texture;

                        var bootlid = GameObject.Find("FERNDALE(1630kg)/Bootlid/Bootlid/muscle_bootlid");
                        bootlid.GetComponent<Renderer>().material = texture;
                        break;
                    }
                case 4:
                    {
                        var texture = resource.LoadAsset<Material>("blue");
                        var ferndaleBody = GameObject.Find("FERNDALE(1630kg)/MESH/muscle_body");
                        ferndaleBody.GetComponent<Renderer>().material = texture;

                        var leftDoor = GameObject.Find("FERNDALE(1630kg)/DriverDoors/door(leftx)/door");
                        leftDoor.GetComponent<Renderer>().material = texture;

                        var rightDoor = GameObject.Find("FERNDALE(1630kg)/DriverDoors/door(right)/door 1");
                        rightDoor.GetComponent<Renderer>().material = texture;

                        var bootlid = GameObject.Find("FERNDALE(1630kg)/Bootlid/Bootlid/muscle_bootlid");
                        bootlid.GetComponent<Renderer>().material = texture;
                        break;
                    }
                    break;
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

            if (oldLicensePlate.GetValue())
            {
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

            if (removeMudflaps.GetValue())
            {                
                var chassis = GameObject.Find("FERNDALE(1630kg)")
                    .transform
                    .GetChild(1)
                    .GetChild(14)
                    .GetChild(6)
                    .gameObject;

                chassis.GetComponent<MeshFilter>().sharedMesh = resource.LoadAsset<Mesh>("muscle_chassis");
                chassis.GetComponent<Renderer>().materials = new Material[1] { new Material(Shader.Find("Diffuse")) { color = Color.white } };
            }

            if (oldSuspension.GetValue())
            {
                var axleController = GameObject.Find("FERNDALE(1630kg)").GetComponent<Axles>();

                axleController.frontAxle.suspensionTravel = 0.2f;
                axleController.frontAxle.suspensionRate = 50000;
                axleController.frontAxle.bumpRate = 1100;
                axleController.frontAxle.reboundRate = 1100;
                axleController.frontAxle.fastBumpFactor = 0.3f;
                axleController.frontAxle.fastReboundFactor = 0.3f;
                axleController.frontAxle.brakeFrictionTorque = 800;
                axleController.frontAxle.handbrakeFrictionTorque = 0;
                axleController.frontAxle.maxSteeringAngle = 22;
                axleController.frontAxle.forwardGripFactor = 1;
                axleController.frontAxle.sidewaysGripFactor = 1;
                axleController.frontAxle.camber = -1.4f;
                axleController.frontAxle.caster = 1.15f;
                axleController.frontAxle.deltaCamber = 0;

                axleController.rearAxle.suspensionTravel = 0.2f;
                axleController.rearAxle.suspensionRate = 50000;
                axleController.rearAxle.bumpRate = 1100;
                axleController.rearAxle.reboundRate = 1100;
                axleController.rearAxle.fastBumpFactor = 0.3f;
                axleController.rearAxle.fastReboundFactor = 0.3f;
                axleController.rearAxle.brakeFrictionTorque = 800;
                axleController.rearAxle.handbrakeFrictionTorque = 0;
                axleController.rearAxle.maxSteeringAngle = 22;
                axleController.rearAxle.forwardGripFactor = 1;
                axleController.rearAxle.sidewaysGripFactor = 1;
                axleController.rearAxle.camber = -1.4f;
                axleController.rearAxle.caster = 1.15f;
                axleController.rearAxle.deltaCamber = 0;

                axleController.frontAxle.wheels[0].transform.localPosition = new Vector3(-0.785f, 0.199f, 1.492f);
                axleController.frontAxle.wheels[0].suspensionTravel = 0.2f;
                axleController.frontAxle.wheels[0].suspensionRate = 50000;
                axleController.frontAxle.wheels[0].bumpRate = 1100;
                axleController.frontAxle.wheels[0].reboundRate = 1100;
                axleController.frontAxle.wheels[0].fastBumpFactor = 0.3f;
                axleController.frontAxle.wheels[0].fastReboundFactor = 0.3f;
                axleController.frontAxle.wheels[0].brakeFrictionTorque = 800;
                axleController.frontAxle.wheels[0].handbrakeFrictionTorque = 0;
                axleController.frontAxle.wheels[0].maxSteeringAngle = 22;
                axleController.frontAxle.wheels[0].forwardGripFactor = 1;
                axleController.frontAxle.wheels[0].sidewaysGripFactor = 1;
                axleController.frontAxle.wheels[0].camber = -1.4f;
                axleController.frontAxle.wheels[0].caster = 1.15f;
                axleController.frontAxle.wheels[0].deltaCamber = 0;
                
                axleController.frontAxle.wheels[1].transform.localPosition = new Vector3(0.785f, 0.199f, 1.492f);
                axleController.frontAxle.wheels[1].suspensionTravel = 0.2f;
                axleController.frontAxle.wheels[1].suspensionRate = 50000;
                axleController.frontAxle.wheels[1].bumpRate = 1100;
                axleController.frontAxle.wheels[1].reboundRate = 1100;
                axleController.frontAxle.wheels[1].fastBumpFactor = 0.3f;
                axleController.frontAxle.wheels[1].fastReboundFactor = 0.3f;
                axleController.frontAxle.wheels[1].brakeFrictionTorque = 800;
                axleController.frontAxle.wheels[1].handbrakeFrictionTorque = 0;
                axleController.frontAxle.wheels[1].maxSteeringAngle = 22;
                axleController.frontAxle.wheels[1].forwardGripFactor = 1;
                axleController.frontAxle.wheels[1].sidewaysGripFactor = 1;
                axleController.frontAxle.wheels[1].camber = -1.4f;
                axleController.frontAxle.wheels[1].caster = 1.15f;
                axleController.frontAxle.wheels[1].deltaCamber = 0;

                axleController.rearAxle.wheels[0].transform.localPosition = new Vector3(-0.82f, 0.15f, -1.492f);
                axleController.rearAxle.wheels[0].suspensionTravel = 0.2f;
                axleController.rearAxle.wheels[0].suspensionRate = 50000;
                axleController.rearAxle.wheels[0].bumpRate = 1100;
                axleController.rearAxle.wheels[0].reboundRate = 1100;
                axleController.rearAxle.wheels[0].fastBumpFactor = 0.3f;
                axleController.rearAxle.wheels[0].fastReboundFactor = 0.3f;
                axleController.rearAxle.wheels[0].brakeFrictionTorque = 500;
                axleController.rearAxle.wheels[0].handbrakeFrictionTorque = 1200;
                axleController.rearAxle.wheels[0].maxSteeringAngle = 0;
                axleController.rearAxle.wheels[0].forwardGripFactor = 0.95f;
                axleController.rearAxle.wheels[0].sidewaysGripFactor = 0.95f;
                axleController.rearAxle.wheels[0].camber = 0;
                axleController.rearAxle.wheels[0].caster = 0;
                axleController.rearAxle.wheels[0].deltaCamber = 0;

                axleController.rearAxle.wheels[1].transform.localPosition = new Vector3(0.82f, 0.15f, -1.492f);
                axleController.rearAxle.wheels[1].suspensionTravel = 0.2f;
                axleController.rearAxle.wheels[1].suspensionRate = 50000;
                axleController.rearAxle.wheels[1].bumpRate = 1100;
                axleController.rearAxle.wheels[1].reboundRate = 1100;
                axleController.rearAxle.wheels[1].fastBumpFactor = 0.3f;
                axleController.rearAxle.wheels[1].fastReboundFactor = 0.3f;
                axleController.rearAxle.wheels[1].brakeFrictionTorque = 500;
                axleController.rearAxle.wheels[1].handbrakeFrictionTorque = 1200;
                axleController.rearAxle.wheels[1].maxSteeringAngle = 0;
                axleController.rearAxle.wheels[1].forwardGripFactor = 0.95f;
                axleController.rearAxle.wheels[1].sidewaysGripFactor = 0.95f;
                axleController.rearAxle.wheels[1].camber = 0;
                axleController.rearAxle.wheels[1].caster = 0;
                axleController.rearAxle.wheels[1].deltaCamber = 0;
            }

            if (oldWheels.GetValue() == 1)
            {
                var frontMesh = resource.LoadAsset<Mesh>("rim_inner_front");

                var wheelFL = GameObject.Find("FERNDALE(1630kg)")
                    .transform
                    .GetChild(13)
                    .GetChild(1)
                    .GetChild(0)
                    .GetChild(1)
                    .GetChild(0);

                var wheelFR = GameObject.Find("FERNDALE(1630kg)")
                    .transform
                    .GetChild(14)
                    .GetChild(1)
                    .GetChild(0)
                    .GetChild(2)
                    .GetChild(0);

                wheelFL.GetComponent<MeshFilter>().mesh = frontMesh;
                wheelFR.GetComponent<MeshFilter>().mesh = frontMesh;

                var rearMesh = resource.LoadAsset<Mesh>("rim_inner_rear");

                var wheelRL = GameObject.Find("FERNDALE(1630kg)")
                    .transform
                    .GetChild(15)
                    .GetChild(1)
                    .GetChild(0)
                    .GetChild(1)
                    .GetChild(0);

                var wheelRR = GameObject.Find("FERNDALE(1630kg)")
                    .transform
                    .GetChild(16)
                    .GetChild(1)
                    .GetChild(0)
                    .GetChild(1)
                    .GetChild(0);

                wheelRL.GetComponent<MeshFilter>().mesh = rearMesh;
                wheelRR.GetComponent<MeshFilter>().mesh = rearMesh;
            }

            if (oldWheels.GetValue() == 2)
            {
                var mesh = resource.LoadAsset<Mesh>("rim_old_1");

                var wheelFL = GameObject.Find("FERNDALE(1630kg)")
                    .transform
                    .GetChild(13)
                    .GetChild(1)
                    .GetChild(0)
                    .GetChild(1);

                var wheelFR = GameObject.Find("FERNDALE(1630kg)")
                    .transform
                    .GetChild(14)
                    .GetChild(1)
                    .GetChild(0)
                    .GetChild(2);

                wheelFL.GetChild(0).gameObject.SetActive(false);
                wheelFL.GetComponent<MeshFilter>().mesh = mesh;
                wheelFR.GetChild(0).gameObject.SetActive(false);
                wheelFR.GetComponent<MeshFilter>().mesh = mesh;

                var wheelRL = GameObject.Find("FERNDALE(1630kg)")
                    .transform
                    .GetChild(15)
                    .GetChild(1)
                    .GetChild(0)
                    .GetChild(1);

                var wheelRR = GameObject.Find("FERNDALE(1630kg)")
                    .transform
                    .GetChild(16)
                    .GetChild(1)
                    .GetChild(0)
                    .GetChild(1);

                wheelRL.GetChild(0).gameObject.SetActive(false);
                wheelRL.GetComponent<MeshFilter>().mesh = mesh;
                wheelRR.GetChild(0).gameObject.SetActive(false);
                wheelRR.GetComponent<MeshFilter>().mesh = mesh;
            }

            if (tachometer.GetValue() == 1)
            {
                var tachometer = GameObject.Find("FERNDALE(1630kg)")
                    .transform
                    .GetChild(1)
                    .GetChild(3)
                    .GetChild(1)
                    .GetChild(5);

                var model = tachometer.GetChild(0);
                model.GetComponent<MeshFilter>().mesh = resource.LoadAsset<Mesh>("muscle_tacho");

                var dash = model.GetChild(0);
                dash.GetComponent<MeshFilter>().mesh = resource.LoadAsset<Mesh>("muscle_tacho_dash");
                dash.GetComponent<Renderer>().material = resource.LoadAsset<Material>("rpm_gauge");

                var pivot = tachometer.GetChild(1);
                pivot.transform.localPosition = new Vector3(-0.012f, 0.004f, 0.01f);
                pivot.transform.localRotation = Quaternion.Euler(40.579f, 23.866f, 77.57f);

                var rpmMeter = pivot.GetComponent<PlayMakerFSM>()
                    .GetState("State 1");

                rpmMeter.GetAction<FloatOperator>(1).float2.Value = 30f;
                rpmMeter.GetAction<FloatClamp>(2).maxValue.Value = 250;

                var needle = pivot.GetChild(0);
                needle.GetComponent<MeshFilter>().mesh = resource.LoadAsset<Mesh>("needle_minute");
                needle.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                needle.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 180.0f);
                needle.transform.localScale = Vector3.one;
            }

            if (tachometer.GetValue() == 2)
            {
                GameObject.Find("FERNDALE(1630kg)")
                    .transform
                    .GetChild(1)
                    .GetChild(3)
                    .GetChild(1)
                    .GetChild(5)
                    .gameObject
                    .SetActive(false);
            }

            if (removeRearAxle.GetValue())
            {
                GameObject.Find("FERNDALE(1630kg)")
                    .transform
                    .GetChild(15)
                    .GetChild(0)
                    .gameObject
                    .SetActive(false);
                GameObject.Find("FERNDALE(1630kg)")
                    .transform
                    .GetChild(16)
                    .GetChild(0)
                    .gameObject
                    .SetActive(false);
                GameObject.Find("FERNDALE(1630kg)")
                    .transform
                    .GetChild(1)
                    .GetChild(6)
                    .gameObject
                    .SetActive(false);
            }

            if (redInterior.GetValue())
            {
                var mat = resource.LoadAsset<Material>("legacy_red");

                GameObject.Find("FERNDALE(1630kg)")
                    .transform
                    .GetChild(1)
                    .GetChild(14)
                    .GetChild(3)
                    .GetComponent<Renderer>()
                    .material = mat;
                GameObject.Find("FERNDALE(1630kg)")
                    .transform
                    .GetChild(1)
                    .GetChild(14)
                    .GetChild(4)
                    .GetComponent<Renderer>()
                    .material = mat;
                GameObject.Find("FERNDALE(1630kg)")
                    .transform
                    .GetChild(8)
                    .GetChild(0)
                    .GetChild(0)
                    .GetChild(2)
                    .GetComponent<Renderer>()
                    .material = mat;
                GameObject.Find("FERNDALE(1630kg)")
                    .transform
                    .GetChild(8)
                    .GetChild(1)
                    .GetChild(0)
                    .GetChild(2)
                    .GetComponent<Renderer>()
                    .material = mat;
                GameObject.Find("FERNDALE(1630kg)")
                    .transform
                    .GetChild(12)
                    .GetChild(0)
                    .GetComponent<Renderer>()
                    .material = mat;
                GameObject.Find("FERNDALE(1630kg)")
                    .transform
                    .GetChild(12)
                    .GetChild(1)
                    .GetComponent<Renderer>()
                    .material = mat;
                GameObject.Find("FERNDALE(1630kg)")
                    .transform
                    .GetChild(1)
                    .GetChild(3)
                    .GetChild(7)
                    .GetChild(0)
                    .GetChild(1)
                    .GetComponent<Renderer>().material = resource.LoadAsset<Material>("white");
            }

            resource.Unload(false);
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
