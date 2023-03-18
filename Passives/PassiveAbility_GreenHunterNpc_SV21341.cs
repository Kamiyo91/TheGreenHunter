using System.Linq;
using BigDLL4221.Extensions;
using BigDLL4221.Passives;
using LOR_DiceSystem;
using TheGreenHunter_SV21341.Buffs;

namespace TheGreenHunter_SV21341.Passives
{
    public class PassiveAbility_GreenHunterNpc_SV21341 : PassiveAbility_NpcMechBase_DLL4221
    {
        public override void OnSucceedAttack(BattleDiceBehavior behavior)
        {
            if (behavior.card.card.GetSpec().Ranged == CardRange.Far)
                owner?.AddBuff<BattleUnitBuf_GreenLeaf_SV21341>(1);
        }

        public override void Init(BattleUnitModel self)
        {
            base.Init(self);
            SetUtil(new GreenGuardianUtil().GreenGuardianNpcUtil);
        }

        public override void OnWaveStart()
        {
            InitDialog();
            var passive = owner.passiveDetail.AddPassive(new PassiveAbility_251201());
            passive.Hide();
            base.OnWaveStart();
        }

        private void InitDialog()
        {
            var playerUnit = BattleObjectManager.instance.GetAliveList(Faction.Player).FirstOrDefault();
            if (playerUnit == null) return;
            if (playerUnit.Book.BookId.packageId == GreenModParameters.VortexPackageId &&
                (playerUnit.Book.BookId.id == 10000004 || playerUnit.Book.BookId.id == 10000903))
                owner.UnitData.unitData.InitBattleDialogByDefaultBook(new LorId(GreenModParameters.PackageId, 4));
        }

        public override void OnWinParrying(BattleDiceBehavior behavior)
        {
            if (behavior.Detail == BehaviourDetail.Guard)
                owner?.AddBuff<BattleUnitBuf_GreenLeaf_SV21341>(1);
        }
    }
}