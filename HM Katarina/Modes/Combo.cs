using System.Diagnostics.Eventing.Reader;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using SharpDX;
using static HMKatarina.SpellLoader;
using static HMKatarina.MenuLoader;
using static HMKatarina.Dagger;
using static HMKatarina.Program;
using static HMKatarina.Itemactivatorr;

namespace HMKatarina.Modes
{
    public static class Combo
    {
       
        public static bool IsValidVector(this Vector3 source) => source != Vector3.Zero;
        public static void ActivatedCombo()
        {
            var q = ComboMenu["useQCombo"].Cast<CheckBox>().CurrentValue && Q.IsReady();
            var w = ComboMenu["useWCombo"].Cast<CheckBox>().CurrentValue && W.IsReady();
            var e = ComboMenu["useECombo"].Cast<CheckBox>().CurrentValue && E.IsReady();
            var r = ComboMenu["useRCombo"].Cast<CheckBox>().CurrentValue && R.IsReady();
            var items = ComboMenu["useITEMS"].Cast<CheckBox>().CurrentValue;
            var re = ComboMenu["useRECombo"].Cast<CheckBox>().CurrentValue;
            var dd = ComboMenu["useD"].Cast<CheckBox>().CurrentValue;
            var qtarget = TargetSelector.GetTarget(Q.Range, DamageType.Magical);
            var wtarget = TargetSelector.GetTarget(W.Range, DamageType.Magical);
            var rtarget = TargetSelector.GetTarget(R.Range, DamageType.Magical);
            var etarget = TargetSelector.GetTarget(E.Range, DamageType.Magical);
           
            var dagger = GetDaggers();
             var d = GetClosestDagger();

            
            
            if (items && _isUlting != true)
            {
                CastItems(qtarget);
            }
            if (q && _isUlting != true)
            {
                if (qtarget != null)
                {
                    Q.Cast(qtarget);
                }

            }
            if (!Q.IsReady() && etarget != null && e && _isUlting != true)
            {
               
                if ( etarget.Position.IsInRange(d, W.Range) && dd )

                {
                
                    E.Cast(GetBestDaggerPoint(d, etarget));
                }
                else if (_isUlting != true && !etarget.Position.IsInRange(d, W.Range) && etarget != null)
                    E.Cast(etarget.Position);
            }
           
            if (etarget != null && e && _isUlting != true && !dd)
            {
                E.Cast(etarget.Position);
            }
 
            
             
            if (w && wtarget != null && _isUlting != true)
            {

                if (wtarget.IsValidTarget(W.Range))

                {
                    W.Cast();
                }


            }


            if (r && rtarget != null && _isUlting != true  && !W.IsReady() && !Q.IsReady())
            {
                R.Cast(rtarget);

            }
            
            
          
        }
    }
}