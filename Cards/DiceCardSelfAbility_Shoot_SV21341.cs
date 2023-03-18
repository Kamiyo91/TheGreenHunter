using BigDLL4221.Extensions;
using TheGreenHunter_SV21341.Buffs;

namespace TheGreenHunter_SV21341.Cards
{
    public class DiceCardSelfAbility_Shoot_SV21341 : DiceCardSelfAbilityBase
    {
        public override bool OnChooseCard(BattleUnitModel owner)
        {
            return owner.GetActiveBuff<BattleUnitBuf_Bullet_SV21341>()?.TempStack > 1 &&
                   !owner.cardSlotDetail.cardAry.Exists(x =>
                       x?.card?.GetID().packageId == GreenModParameters.PackageId && x.card?.GetID().id == 1);
        }

        public override void OnApplyCard()
        {
            owner.GetActiveBuff<BattleUnitBuf_Bullet_SV21341>()?.ChangeTempStack(-2);
        }

        public override void OnReleaseCard()
        {
            owner.GetActiveBuff<BattleUnitBuf_Bullet_SV21341>()?.ChangeTempStack(2);
        }

        public override void OnUseCard()
        {
            owner.AddBuff<BattleUnitBuf_Bullet_SV21341>(-2);
        }
    }
}