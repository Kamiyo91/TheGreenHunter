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

        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            _owner.TakeDamage(1);
            if (stack < 1) _owner.bufListDetail.RemoveBuf(this);
        }

        public override void OnRoundEndTheLast()
        {
            _owner.TakeDamage(stack);
            _owner.bufListDetail.RemoveBuf(this);
        }
    }
}