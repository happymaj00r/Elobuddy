using System.Runtime.InteropServices;
using EloBuddy;
using EloBuddy.SDK;
using static HMKatarina.SpellLoader;
namespace HMKatarina.Modes
{
    public class Flee
    {
        public static void FleeActivate()
        {


           

            
                W.Cast();

           
            var Mpos = Game.CursorPos;

            

                E.Cast(Mpos);
            
        }
    }
}