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
using NgUi.MenuUi;
using NgContent;
using ModOptions = NgUi.Options.ModOptions;
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

namespace Floorhugger2280HUDOptions
{

    public class ModMenuOptions : CodeMod
    {
        private string _configPath;

        public static bool Floorhugger2280Toggle;
        public static float ModernGrounderForceOverrideValue;

        public override void OnRegistered(string ModLocation)
        {
            _configPath = Path.Combine(ModLocation, "config.ini");

            RegisterSettings();

            NgSystemEvents.OnConfigRead += OnConfigRead;
            NgSystemEvents.OnConfigWrite += OnConfigWrite;
        }

        private void RegisterSettings()
        {
            string ModID = "Floorhugger 2280";

            string SelectorCategory0 = "Floorhugger 2280 Settings";            

            ModOptions.RegisterOption<NgBoxSelector>(false, ModID, SelectorCategory0, "Floorhugger2280Toggle_ID",
                selector =>
                {
                    selector.Configure("Floorhugger-2280 Toggle", "Whether to enable or disable the forcing of Floorhugger.",
                        Floorhugger2280Toggle, EBooleanDisplayType.EnabledDisabled);
                },
                selector =>
                {
                    Floorhugger2280Toggle = selector.ToBool();
                });

            ModOptions.RegisterOption<NgBoxSlider>(false, ModID, SelectorCategory0, "ModernGrounderForceOverrideValue_ID",
                slider =>
                {
                    slider.Configure("Modern Grounder Force Override Value", "A numerical representation of how strong the force keeping ships grounded in 2280 is. Internal default value is 0.0, changes made to this value will apply immediately in-race and override the internal default of zero.",
                        "", ModernGrounderForceOverrideValue, 0.0f, 225.0f, 0.1f);
                }, slider =>
                {
                    ModernGrounderForceOverrideValue = slider.Value;
                });
        }
        
        private void OnConfigRead()
        {
            INIParser ini = new INIParser();

            ini.Open(_configPath);

            Floorhugger2280Toggle = ini.ReadValue("Settings", "Floorhugger2280Toggle_ID", Floorhugger2280Toggle);
            ModernGrounderForceOverrideValue = (float)ini.ReadValue("Settings", "ModernGrounderForceOverrideValue_ID", ModernGrounderForceOverrideValue);

            ini.Close();
        }

        private void OnConfigWrite()
        {
            INIParser ini = new INIParser();

            ini.Open(_configPath);

            ini.WriteValue("Settings", "Floorhugger2280Toggle_ID", Floorhugger2280Toggle);
            ini.WriteValue("Settings", "ModernGrounderForceOverrideValue_ID", ModernGrounderForceOverrideValue);

            ini.Close();
        }
    }
}