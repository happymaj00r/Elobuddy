using System.Linq;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using static HMKatarina.MenuLoader;
using static HMKatarina.SpellLoader;
using static HMKatarina.Dagger;
namespace HMKatarina.Modes
{
    public static class Laneclear
    {
        public static void ActivatedLaneClear()
        {
            var q = LaneClearMenu["useQLC"].Cast<CheckBox>().CurrentValue && Q.IsReady();
            var w = LaneClearMenu["useWLC"].Cast<CheckBox>().CurrentValue && W.IsReady();
            var e = LaneClearMenu["useELC"].Cast<CheckBox>().CurrentValue && E.IsReady();


            var d = Dagger.GetClosestDagger();
            

            var minion = EntityManager.MinionsAndMonsters.EnemyMinions.Where(t =>
                t.IsEnemy && !t.IsDead && t.IsValid && !t.IsInvulnerable &&
                t.IsInRange(EloBuddy.Player.Instance.Position, Q.Range));

            foreach (var m in minion)
            {
                if (q && m.IsValidTarget() && m.IsMinion)
                {
                    Q.Cast(m);
                }

                if (e && m.IsMinion && m.IsValidTarget() && !m.Position.IsUnderTurret())
                {
                    if (m.Position.IsInRange(d, W.Range))
                    {
                        E.Cast(GetBestDaggerPoint(d, m));

                    }
                    
                }

                else if (w && m.IsMinion && m.IsValidTarget())
                {

                    W.Cast(m);
                }
            }
        }
    }
}