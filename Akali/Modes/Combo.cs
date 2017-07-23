using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using SharpDX;
using static HMKatarina.SpellLoader;
using static HMKatarina.MenuLoader;
using static HMKatarina.Program;
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
            var re = ComboMenu["useRECombo"].Cast<CheckBox>().CurrentValue;
            var dd = ComboMenu["useD"].Cast<CheckBox>().CurrentValue;
            var qtarget = TargetSelector.GetTarget(Q.Range, DamageType.Magical);
            var wtarget = TargetSelector.GetTarget(W.Range, DamageType.Magical);
            var rtarget = TargetSelector.GetTarget(R.Range, DamageType.Magical);
            var etarget = TargetSelector.GetTarget(E.Range, DamageType.Magical);

            if (q && qtarget != null)
            {
                Q.Cast(qtarget);
            }

            if (r && rtarget != null)
            {
                R.Cast(rtarget);
            }
            
            
        }
    }
}