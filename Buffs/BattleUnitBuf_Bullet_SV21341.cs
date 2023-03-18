using BigDLL4221.Buffs;
using BigDLL4221.Extensions;

namespace TheGreenHunter_SV21341.Buffs
{
    public class BattleUnitBuf_Bullet_SV21341 : BattleUnitBuf_BaseBufChanged_DLL4221
    {
        public int TempStack;

        public BattleUnitBuf_Bullet_SV21341() : base(infinite: true, lastOneScene: false)
        {
        }

        protected override string keywordId => "Bullet_SV21341";
        protected override string keywordIconId => "Bullet_SV21341";
        public override int MaxStack => 8;

        public override int AdderStackEachScene =>
            _owner.GetActiveBuff<BattleUnitBuf_GreenLeaf_SV21341>()?.stack > 9 ? 2 : 1;

        public override void OnRoundStartAfter()
        {
            TempStack = stack;
        }

        public void ChangeTempStack(int value)
        {
            TempStack += value;
        }
    }
}