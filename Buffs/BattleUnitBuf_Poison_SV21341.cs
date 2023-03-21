using BigDLL4221.Buffs;

namespace TheGreenHunter_SV21341.Buffs
{
    public class BattleUnitBuf_Poison_SV21341 : BattleUnitBuf_BaseBufChanged_DLL4221
    {
        public BattleUnitBuf_Poison_SV21341() : base(lastOneScene: false)
        {
        }

        protected override string keywordId => "GreenPoison_SV21341";
        protected override string keywordIconId => "GreenPoison_SV21341";
        public override int MaxStack => 10;
        public override int AdderStackEachScene => -1;
        public override bool DestroyedAt0Stack => true;

        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            _owner.TakeDamage(1);
            OnAddBuf(-1);
        }

        public override void OnRoundEndTheLast()
        {
            _owner.TakeDamage(stack);
            OnAddBuf(-(stack /= 2));
        }
    }
}