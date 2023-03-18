using System.Linq;
using BigDLL4221.Extensions;
using TheGreenHunter_SV21341.Buffs;

namespace TheGreenHunter_SV21341.Cards
{
    public class DiceCardSelfAbility_FluoriteRain_SV21341 : DiceCardSelfAbilityBase
    {
        public override bool OnChooseCard(BattleUnitModel owner)
        {
            return owner.GetActiveBuff<BattleUnitBuf_Bullet_SV21341>()?.TempStack > 2;
        }

        public override void OnApplyCard()
        {
            owner.GetActiveBuff<BattleUnitBuf_Bullet_SV21341>()?.ChangeTempStack(-3);
        }

        public override void OnReleaseCard()
        {
            owner.GetActiveBuff<BattleUnitBuf_Bullet_SV21341>()?.ChangeTempStack(3);
        }

        public override void OnUseCard()
        {
            owner.cardSlotDetail.RecoverPlayPointByCard(1);
            if (owner.GetActiveBuff<BattleUnitBuf_Bullet_SV21341>()?.TempStack > 7)
            {
                card.AddDice(card.card.CreateDiceCardBehaviorList().FirstOrDefault());
                owner.AddBuff<BattleUnitBuf_Bullet_SV21341>(-1);
            }

            owner.AddBuff<BattleUnitBuf_Bullet_SV21341>(-3);
        }
    }
}