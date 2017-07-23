using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;

namespace HMKatarina
{
    public static class SpellLoader
    {
        public static Spell.Targeted Q;
        public static Spell.Skillshot W;
        public static Spell.Active E;
        public static Spell.Targeted R;

        public static void LoadSpells()
        {
            Q = new Spell.Targeted(SpellSlot.Q, 600);
            W = new Spell.Skillshot(SpellSlot.W, 250, SkillShotType.Circular);
            E = new Spell.Active(SpellSlot.E, 325);
            R = new Spell.Targeted(SpellSlot.R, 700);


        }
    }
}