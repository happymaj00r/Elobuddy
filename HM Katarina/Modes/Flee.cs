using System.Runtime.InteropServices;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using static HMKatarina.SpellLoader;
using static HMKatarina.MenuLoader;

namespace HMKatarina.Modes
{
    public class Flee
    {
        public static void FleeActivate()
        {

            var q = FleeMenu["useEF"].Cast<CheckBox>().CurrentValue && E.IsReady();
            var w = FleeMenu["useWF"].Cast<CheckBox>().CurrentValue && W.IsReady();


            if (q)
            {
                W.Cast();
            }
              

           
            var Mpos = Game.CursorPos;


            if (w)
            {
                E.Cast(Mpos);
            }
               
            
        }
    }
}