using EloBuddy;
using EloBuddy.SDK;

namespace HMKatarina
{
    public static class SpellLoader
    {
        public static Spell.Targeted Q;
        public static Spell.Active W;
        public static Spell.Targeted E;
        public static Spell.Active R;

        public static void LoadSpells()
        {
            Q = new Spell.Targeted(SpellSlot.Q, 625);
            W = new Spell.Active(SpellSlot.W, 385);
            E = new Spell.Targeted(SpellSlot.E, 725);
            R = new Spell.Active(SpellSlot.R, 550);


        }
    }
}