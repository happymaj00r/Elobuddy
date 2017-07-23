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
            ComboMenu.Add("useQCombo", new CheckBox("Use Q", false));
            ComboMenu.Add("useWCombo", new CheckBox("Use W", false));
            ComboMenu.Add("useECombo", new CheckBox("Use E", false));
            ComboMenu.Add("useRCombo", new CheckBox("Use R", false));
            ComboMenu.Add("useD", new CheckBox("Use Jump to Dagger", false));
            ComboMenu.Add("useRECombo", new CheckBox("Use E if Enemy walk outside R range", false));

            LaneClearMenu = Menu.AddSubMenu("Laneclear Settings", "Laneclear");
            LaneClearMenu.Add("useQLC", new CheckBox("Use Q", false));
            LaneClearMenu.Add("useWLC", new CheckBox("Use W", false));
            LaneClearMenu.Add("useELC", new CheckBox("Use E", false));
            
            KillstealMenu = Menu.AddSubMenu("Killsteal Settings", "Killsteal");
            KillstealMenu.Add("useKS", new CheckBox("Use Killsteal",false));
            KillstealMenu.Add("Q", new CheckBox("Use Q", false));
            KillstealMenu.Add("E", new CheckBox("Use E", false));
            KillstealMenu.Add("R", new CheckBox("Use R", false));
           
        }
    }
}