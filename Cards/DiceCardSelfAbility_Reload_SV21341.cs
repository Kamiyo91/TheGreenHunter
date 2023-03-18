using BigDLL4221.Extensions;
using TheGreenHunter_SV21341.Buffs;

namespace TheGreenHunter_SV21341.Cards
{
    public class DiceCardSelfAbility_Reload_SV21341 : DiceCardSelfAbilityBase
    {
        public override bool OnChooseCard(BattleUnitModel owner)
        {
            return !owner.cardSlotDetail.cardAry.Exists(x =>
                x?.card?.GetID().packageId == GreenModParameters.PackageId && (x.card?.GetID().id == 4 ||
                                                                               x.card?.GetID().id == 5 ||
                                                                               x.card?.GetID().id == 9));
        }

        public override void OnUseCard()
        {
            owner.AddBuff<BattleUnitBuf_Bullet_SV21341>(4);
            owner.cardSlotDetail.RecoverPlayPointByCard(1);
            owner.allyCardDetail.DrawCards(1);
        }
    }
}