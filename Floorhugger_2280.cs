using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using BallisticModding;
using BallisticUnityTools.Placeholders;
using BallisticUnityTools;
using BallisticNG;
using UnityEngine;
using UnityEngine.UI;
using NgUi.RaceUi;
using NgEvents;
using NgData;
using NgGame;
using NgLib;
using NgMusic;
using NgMp;
using NgShips;
using NgModding.Huds;
using NgModding;
using NgPickups;

namespace Floorhugger2280
{
    public class Floorhugger2280ModRegister : CodeMod
    {
        public override void OnRegistered(string modPath)
        {            
            NgEvents.NgRaceEvents.OnCountdownStart += Force_Floorhugger;
        }

        public void Force_Floorhugger(/*ShipController ship*/)
        {
            GameObject FloorhuggerMonoBehaviourHookObject = new GameObject("GlobalManager");
            FloorhuggerMonoBehaviourHookObject.AddComponent<FloorhuggerMonoBehaviour>();

            if (Floorhugger2280HUDOptions.ModMenuOptions.Floorhugger2280Toggle == true)
            {
                NgTrackData.TrackProcessor.ConvertTrackToMaglock(true, false);                
            }            
        }        
    }

    public class FloorhuggerMonoBehaviour : MonoBehaviour
    {
        void Update()
        {
            Ships.Loaded[NgPeer.MySpawnIndex].PysSim.ModernGrounderForce = Floorhugger2280HUDOptions.ModMenuOptions.ModernGrounderForceOverrideValue;
        }
    }
}