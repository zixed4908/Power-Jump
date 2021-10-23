using System;
using System.Collections.Generic;
using HarmonyLib;
using BepInEx;
using UnityEngine;
using System.Reflection;
using UnityEngine.XR;
using Photon.Pun;
using System.IO;
using System.Net;
using Photon.Realtime;
using UnityEngine.Rendering;

namespace MonkeHaveLoooooooongArms_
{
        [BepInPlugin("org.ZixedTheMonkeGuy.monkeytag.MonkeHaveLoooooooongArms", "Monke Have Looong Arms!", "Version 1.0.0")]
        public class MyPatcher : BaseUnityPlugin
        {
            public void Awake()
            {
                var harmony = new Harmony("com.ZixedTheMonkeGuy.monkeytag");
                harmony.PatchAll(Assembly.GetExecutingAssembly());
            }
        }
        public class Class1
        {
             static bool longarms = false;
             static void Postfix(GorillaLocomotion.Player __instance)
             {
                  if(!PhotonNetwork.CurrentRoom.IsVisible || !PhotonNetwork.InRoom)
                  {
                        List<InputDevice> list = new List<InputDevice>();
                        InputDevices.GetDevicesWithCharacteristics(UnityEngine.XR.InputDeviceCharacteristics.HeldInHand | UnityEngine.XR.InputDeviceCharacteristics.Right | UnityEngine.XR.InputDeviceCharacteristics.Controller, list);
                        list[0].TryGetFeatureValue(CommonUsages.userPresence, out longarms);

                         if(longarms)
                         {
                             __instance.maxArmLength = 500f;
                         }
                  }
             }
        }
}
