using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Rendering;
using System;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Utils;
using SharpDX;
using HMKatarina.Modes;
using static HMKatarina.Modes.Combo;
using static  HMKatarina.SpellLoader;
using static HMKatarina.MenuLoader;
using static  HMKatarina.Modes.Laneclear;
using static HMKatarina.Modes.Killsteal;
using static HMKatarina.Modes.Flee;

namespace HMKatarina
{
    class Program
    {
        private static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            if (Player.Instance.ChampionName != "Katarina") return;

            LoadSpells();
            LoadMenu();
            Game.OnTick += Game_OnTick;
            Obj_AI_Base.OnBuffGain += OnBuffGain;
            Obj_AI_Base.OnBuffLose += OnBuffLose;
            

            Chat.Print("<font color='#FFFFFF'>HM Katarina <font color='#CF2942'>By HappyMajor</font>  has been loaded.</font>");
        }


        public static bool _isChannelingImportantSpell;
        public static bool _isUlting;

        public static void OnBuffGain(Obj_AI_Base sender, Obj_AI_BaseBuffGainEventArgs args)

        {
            if (args.Buff.Name.ToLower() == "katarinarsound" || args.Buff.Name.ToLower() == "katarinar" ||
                _isChannelingImportantSpell)
            {

                
                Orbwalker.DisableAttacking = true;
                Orbwalker.DisableMovement = true;
                _isUlting = true;



            }
        }

        public static void OnBuffLose(Obj_AI_Base sender, Obj_AI_BaseBuffLoseEventArgs args)
        {
            if (args.Buff.Name.ToLower() == "katarinarsound" || args.Buff.Name.ToLower() == "katarinar")
            {
                
                Orbwalker.DisableAttacking = false;
                Orbwalker.DisableMovement = false;
                _isUlting = false;
            }
        }

        private static void Game_OnTick(EventArgs args)
        {
           
            if (Orbwalker.ActiveModesFlags.Equals(Orbwalker.ActiveModes.Combo))
            {
               ActivatedCombo();
            }
            if (Orbwalker.ActiveModesFlags.Equals(Orbwalker.ActiveModes.LaneClear))
            {
                ActivatedLaneClear();
            }
            if (Orbwalker.ActiveModesFlags.Equals(Orbwalker.ActiveModes.Flee))
            {
                FleeActivate();
            }
            if (KillstealMenu["useKS"].Cast<CheckBox>().CurrentValue)
            {
                ActivateKS();
            }
           
        }
    }
}

