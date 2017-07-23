using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using static HMKatarina.SpellLoader;
using static HMKatarina.MenuLoader;

namespace HMKatarina.Modes
{
    
    public class Killsteal
    {
        
       

        public static void ActivateKS()
        {
            
            
            var target = TargetSelector.GetTarget(E.Range, DamageType.Magical);

            if (target != null && Q.GetSpellDamage(target) >= target.Health &&  KillstealMenu["Q"].Cast<CheckBox>().CurrentValue )

                Q.Cast(target);



            if (target != null && E.GetSpellDamage(target) >= target.Health &&
                KillstealMenu["E"].Cast<CheckBox>().CurrentValue)
            {
                E.Cast();
              
            }
                
            if (target != null && R.GetSpellDamage(target) >= target.Health &&
                KillstealMenu["R"].Cast<CheckBox>().CurrentValue)
            {
                R.Cast(target.Position);
              
            }


        }
    }
}