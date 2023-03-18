using BigDLL4221.Utils;
using LOR_DiceSystem;

namespace TheGreenHunter_SV21341.Passives
{
    public class PassiveAbility_HunterReflex_SV21341 : PassiveAbilityBase
    {
        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            if (behavior.Detail == BehaviourDetail.Guard) behavior.ApplyDiceStatBonus(new DiceStatBonus { power = 1 });
        }

        public override void OnStartBattle()
        {
            UnitUtil.ReadyCounterCard(owner, 3, GreenModParameters.PackageId);
        }
    }
}