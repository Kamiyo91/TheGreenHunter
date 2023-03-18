using BigDLL4221.Extensions;
using BigDLL4221.Passives;
using LOR_DiceSystem;
using TheGreenHunter_SV21341.Buffs;

namespace TheGreenHunter_SV21341.Passives
{
    public class PassiveAbility_GreenHunter_SV21341 : PassiveAbility_PlayerMechBase_DLL4221
    {
        public override void OnSucceedAttack(BattleDiceBehavior behavior)
        {
            if (behavior.card.card.GetSpec().Ranged == CardRange.Far)
                owner?.AddBuff<BattleUnitBuf_GreenLeaf_SV21341>(1);
        }

        public override void Init(BattleUnitModel self)
        {
            base.Init(self);
            SetUtil(new GreenGuardianUtil().GreenGuardianPlayerUtil);
        }

        public override void OnWaveStart()
        {
            var passive = owner.passiveDetail.AddPassive(new PassiveAbility_251201());
            passive.Hide();
            base.OnWaveStart();
        }

        public override void OnWinParrying(BattleDiceBehavior behavior)
        {
            if (behavior.Detail == BehaviourDetail.Guard)
                owner?.AddBuff<BattleUnitBuf_GreenLeaf_SV21341>(1);
        }
    }
}