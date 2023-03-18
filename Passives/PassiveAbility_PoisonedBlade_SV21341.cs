using BigDLL4221.Extensions;
using LOR_DiceSystem;
using TheGreenHunter_SV21341.Buffs;

namespace TheGreenHunter_SV21341.Passives
{
    public class PassiveAbility_PoisonedBlade_SV21341 : PassiveAbilityBase
    {
        public int Stack = 1;

        public override void OnSucceedAttack(BattleDiceBehavior behavior)
        {
            if (behavior.Detail == BehaviourDetail.Slash || behavior.Detail == BehaviourDetail.Penetrate)
                behavior.card.target?.AddBuff<BattleUnitBuf_Poison_SV21341>(Stack);
        }

        public override void OnRoundEndTheLast()
        {
            Stack = 1;
        }

        public void ChangeStack(int stack)
        {
            Stack = stack;
        }
    }
}