using BepInEx;
using System.ComponentModel;
using System;
using UnityEngine;
using Utilla;
using Photon.Pun;

namespace RandomSound
{
    /// <summary>
    /// This is your mod's main class.
    /// </summary>

    /* This attribute tells Utilla to look for [ModdedGameJoin] and [ModdedGameLeave] */
    [Description("HauntedModMenu")]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [ModdedGamemode]
    public class Plugin : BaseUnityPlugin
    {
        bool on;

        void Start()
        {
           
            Utilla.Events.GameInitialized += OnGameInitialized;
        }

        void OnEnable()
        {
            on = true;
            HarmonyPatches.ApplyHarmonyPatches();
        }

        void OnDisable()
        {
            on = false;
            /* Undo mod setup here */
            /* This provides support for toggling mods with ComputerInterface, please implement it :) */
            /* Code here runs whenever your mod is disabled (including if it disabled on startup)*/

            HarmonyPatches.RemoveHarmonyPatches();
        }

        void OnGameInitialized(object sender, EventArgs e)
        {
            /* Code here runs after the game initializes (i.e. GorillaLocomotion.Player.Instance != null) */
        }

        void Update()
        {
            if (on)
            {
                System.Random rnd = new System.Random();
                System.Threading.Thread.Sleep(rnd.Next(9500, 30000));
                GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(rnd.Next(3, 153), false, 9999f);
                GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(rnd.Next(3, 153), false, 9999f);
                GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(rnd.Next(3, 153), false, 9999f);
            }
        }

        /* This attribute tells Utilla to call this method when a modded room is joined */
        [ModdedGamemodeJoin]
        public void OnJoin(string gamemode)
        {
            /* Activate your mod here */
            /* This code will run regardless of if the mod is enabled*/

            
        }

        /* This attribute tells Utilla to call this method when a modded room is left */
        [ModdedGamemodeLeave]
        public void OnLeave(string gamemode)
        {
            /* Deactivate your mod here */
            /* This code will run regardless of if the mod is enabled*/

            
        }
    }
}
