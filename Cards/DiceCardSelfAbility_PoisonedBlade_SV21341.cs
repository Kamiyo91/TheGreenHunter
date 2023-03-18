using BigDLL4221.Extensions;
using TheGreenHunter_SV21341.Buffs;
using TheGreenHunter_SV21341.Passives;

namespace TheGreenHunter_SV21341.Cards
{
    public class DiceCardSelfAbility_PoisonedBlade_SV21341 : DiceCardSelfAbilityBase
    {
        public override void OnUseCard()
        {
            owner.GetActivePassive<PassiveAbility_PoisonedBlade_SV21341>()?.ChangeStack(2);
            if (card.target?.GetActiveBuff<BattleUnitBuf_Poison_SV21341>() != null) owner.allyCardDetail.DrawCards(1);
        }
    }
}