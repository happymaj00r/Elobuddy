using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using static HMKatarina.MenuLoader;
using static HMKatarina.SpellLoader;
using static HMKatarina.Dagger;
using static HMKatarina.Program;


namespace HMKatarina.Modes
{
    public class Harras
    {
        public static void ActivatedHarass()
        {
            var q = HarassMenu["useQH"].Cast<CheckBox>().CurrentValue && Q.IsReady();
            var w = HarassMenu["useWH"].Cast<CheckBox>().CurrentValue && W.IsReady();
            var e = HarassMenu["useEH"].Cast<CheckBox>().CurrentValue && E.IsReady();
            var r = HarassMenu["useQA"].Cast<CheckBox>().CurrentValue && R.IsReady();
            var dd = HarassMenu["useDH"].Cast<CheckBox>().CurrentValue;
            var qtarget = TargetSelector.GetTarget(Q.Range, DamageType.Magical);
            var wtarget = TargetSelector.GetTarget(W.Range, DamageType.Magical);
            var rtarget = TargetSelector.GetTarget(R.Range, DamageType.Magical);
            var etarget = TargetSelector.GetTarget(E.Range, DamageType.Magical);

            var dagger = GetDaggers();
            var d = GetClosestDagger();
            
            
            
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
            
            
            
            
        }
    }
}