using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace HMKatarina
{
    internal class MenuLoader
    {
        public static Menu Menu,
            ItemActivatorMenu,
            ComboMenu,
            HarassMenu,
            LastHitMenu,
            LaneClearMenu,
            JungleClearMenu,
            DrawingMenu,
            KillstealMenu,
            FleeMenu;

        public static void LoadMenu()
        {
            Menu = MainMenu.AddMenu("HM Katarina", "HMKatarina");
            Menu.AddLabel(" HM Katarina  ");
            Menu.AddLabel(" Made by HappyMajor ");
            Menu.AddLabel("Enjoy");

            /* Combo Section */
            ComboMenu = Menu.AddSubMenu("Combo Settings", "Combo");
            ComboMenu.Add("useQCombo", new CheckBox("Use Q", true));
            ComboMenu.Add("useWCombo", new CheckBox("Use W", true));
            ComboMenu.Add("useECombo", new CheckBox("Use E", true));
            ComboMenu.Add("useRCombo", new CheckBox("Use R", true));
            ComboMenu.Add("useD", new CheckBox("Use Jump to Dagger", true));
            ComboMenu.Add("useRECombo", new CheckBox("Use E if Enemy walk outside R range", false));
            ComboMenu.Add("useITEMS", new CheckBox("Use Items", true));
            
            
            HarassMenu = Menu.AddSubMenu("Harass Settings", "Harass");
            HarassMenu.Add("UseQH", new CheckBox("Use Q", true));
            HarassMenu.Add("useWH", new CheckBox("Use W", true));
            HarassMenu.Add("useEH", new CheckBox("Use E", false));
            HarassMenu.Add("UseQA", new CheckBox("Use Auto Q", false));
            HarassMenu.Add("UseDH", new CheckBox("Use Dagger Logic in Harras", true));
            
            LaneClearMenu = Menu.AddSubMenu("Laneclear Settings", "Laneclear");
            LaneClearMenu.Add("useQLC", new CheckBox("Use Q", true));
            LaneClearMenu.Add("useWLC", new CheckBox("Use W", true));
            LaneClearMenu.Add("useELC", new CheckBox("Use E", true));
            
            KillstealMenu = Menu.AddSubMenu("Killsteal Settings", "Killsteal");
            KillstealMenu.Add("useKS", new CheckBox("Use Killsteal",true));
            KillstealMenu.Add("Q", new CheckBox("Use Q", true));
            KillstealMenu.Add("E", new CheckBox("Use EW", true));
            
             
            FleeMenu = Menu.AddSubMenu("Flee Settings", "Flee");
            FleeMenu.Add("useEF", new CheckBox("Use E Flee",true));
            FleeMenu.Add("useWF", new CheckBox("Use W Flee", false));
            
           
        }
    }
}