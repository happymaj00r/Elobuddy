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
            if (Player.Instance.ChampionName != "Akali") return;

            LoadSpells();
            LoadMenu();
            Game.OnTick += Game_OnTick;
           
            Obj_AI_Base.OnSpellCast += OnDoCast;

            Chat.Print("<font color='#FFFFFF'>HM Katarina <font color='#CF2942'>By HappyMajor</font>  has been loaded.</font>");
        }

        public static void OnDoCast(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            if (!sender.IsMe || !Orbwalker.IsAutoAttacking) //!Orbwalking.IsAutoAttack(args.SData.Name))
            {
                return;
            }
            var e = ComboMenu["useECombo"].Cast<CheckBox>().CurrentValue && E.IsReady();
            var a = TargetSelector.GetTarget(E.Range, DamageType.Physical);
            if (a == null || a.IsInvulnerable || a.MagicImmune)
            {
                return;
            }
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))

            {
                if (e)
                {
                    E.Cast();
                }
            }
        }

        public static bool _isChannelingImportantSpell;
        
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

