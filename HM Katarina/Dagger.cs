using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using SharpDX;

namespace HMKatarina
{
    class Dagger
    {
        public static IEnumerable<Obj_AI_Base> GetDaggers()
        {
            return ObjectManager.Get<Obj_AI_Base>().Where(a => a.Name == "HiddenMinion" && a.IsValid && a.Health == 100);
        }

        public static Vector3 GetClosestDagger()
        {
            var dagger = GetDaggers();
            if (!dagger.Any() || dagger == null || dagger.Count() <= 0) return new Vector3();
            var t = dagger.Where(p => p.Distance(Player.Instance) >= 150).OrderBy(p => p.Distance(Player.Instance.Position)).FirstOrDefault();
            return t == null ? new Vector3() : t.Position;
        }
        
        public static Vector3 GetBestDaggerPoint(Vector3 position, Obj_AI_Base target)
        {
            if (target.Position.IsInRange(position, 150)) return position;
            return position.Extend(target, 150).To3D();
        }
    }
}