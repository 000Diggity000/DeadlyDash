using BepInEx;
using BoplFixedMath;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Deadly_Dash
{
    [BepInPlugin("com.000diggity000.Deadly_Dash", "Deadly Dash", "1.0.0")]//A unique name could be anything, The name of your plugin, The version of your plugin
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            // Plugin startup logic
            Logger.LogInfo($"Plugin {"Deadly Dash"} is loaded!");//feel free to remove this
            Harmony harmony = new Harmony("com.000diggity000.Deadly_Dash");
            MethodInfo original = AccessTools.Method(typeof(Ability), "Awake");
            MethodInfo patch = AccessTools.Method(typeof(Patches), "Awake_Ability_Plug");
            harmony.Patch(original, new HarmonyMethod(patch));
        }
        public class Patches
        {
            public static bool Awake_Ability_Plug(Ability __instance)
            {

                GameObject ability = __instance.gameObject;
                //GameObject.Instantiate(ability);
                //__instance.Cooldown = (Fix)0f;
                if (ability.gameObject.GetComponent<Dash>() == true)
                {
                    __instance.KillPlayersOnContact = true;
                }

                return true;
            }
        }

    }
}
