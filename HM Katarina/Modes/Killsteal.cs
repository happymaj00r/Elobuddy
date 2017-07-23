using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using static HMKatarina.SpellLoader;
using static HMKatarina.MenuLoader;
using static HMKatarina.Modes.Combo;
using static HMKatarina.Dagger;
 

namespace HMKatarina.Modes
{
    
    public class Killsteal
    {
        private static AIHeroClient User = Player.Instance;
        public static float QDamage(Obj_AI_Base target)
        {
            if (Q.IsReady())
                return Player.Instance.CalculateDamageOnUnit(target, DamageType.Magical, new[] { 0f, 75f, 105f, 135f, 165f, 195f }[Q.Level] + 0.3f * Player.Instance.TotalMagicalDamage);
            else
                return 0f;
        }
        public static float WDamage(Obj_AI_Base target)
        {
            return 0f;
        }
        public static float EDamage(Obj_AI_Base target)
        {
            if (E.IsReady())
                return Player.Instance.CalculateDamageOnUnit(target, DamageType.Magical, new[] { 0f, 25f, 40f, 55f, 70f, 85f }[E.Level] + 0.25f * Player.Instance.TotalMagicalDamage + 0.5f * User.TotalAttackDamage);
            else
                return 0f;
        }
        
       

        public static void ActivateKS()
        {
            var dd = ComboMenu["useD"].Cast<CheckBox>().CurrentValue;
            
            var target = TargetSelector.GetTarget(E.Range, DamageType.Magical);

            if (target != null && QDamage(target) >= target.Health &&  KillstealMenu["Q"].Cast<CheckBox>().CurrentValue )

                Q.Cast(target);


            var d = GetClosestDagger();
            if (target != null && EDamage(target) >= target.Health &&
                KillstealMenu["E"].Cast<CheckBox>().CurrentValue)
            {
                if (target.Position.IsInRange(d, W.Range) && dd)

                {

                    E.Cast(GetBestDaggerPoint(d, target));
                }
                else
                {
                    E.Cast(target.Position);
                }
            }
            var qtarget = TargetSelector.GetTarget(Q.Range, DamageType.Magical);    
            var r = HarassMenu["useQA"].Cast<CheckBox>().CurrentValue && Q.IsReady();
            if (r && qtarget != null )
            {
                Q.Cast(qtarget);
            }

        }
    }
}