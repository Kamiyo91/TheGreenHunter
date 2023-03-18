using BigDLL4221.Extensions;
using TheGreenHunter_SV21341.Buffs;

namespace TheGreenHunter_SV21341.Cards
{
    internal class DiceCardSelfAbility_GreenHunterMassAttack_SV21341 : DiceCardSelfAbilityBase
    {
        private bool _motionChanged;

        public override bool OnChooseCard(BattleUnitModel owner)
        {
            return owner.GetActiveBuff<BattleUnitBuf_GreenLeaf_SV21341>()?.stack > 9 &&
                   owner.GetActiveBuff<BattleUnitBuf_Bullet_SV21341>()?.TempStack > 7;
        }

        public override void OnUseCard()
        {
            owner.AddBuff<BattleUnitBuf_Bullet_SV21341>(-8);
            if (owner.hp < owner.MaxHp * 0.50f)
                card.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus
                {
                    power = 1
                });
            if (owner.hp < owner.MaxHp * 0.25f)
                card.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus
                {
                    power = 2
                });
        }

        public override void OnEndAreaAttack()
        {
            if (!_motionChanged) return;
            _motionChanged = false;
            owner.view.charAppearance.ChangeMotion(ActionDetail.Default);
        }

        public override void OnApplyCard()
        {
            owner.GetActiveBuff<BattleUnitBuf_Bullet_SV21341>()?.ChangeTempStack(-8);
            if (!string.IsNullOrEmpty(owner.UnitData.unitData.workshopSkin) ||
                owner.UnitData.unitData.bookItem != owner.UnitData.unitData.CustomBookItem) return;
            _motionChanged = true;
            owner.view.charAppearance.ChangeMotion(ActionDetail.Aim);
        }

        public override void OnReleaseCard()
        {
            owner.GetActiveBuff<BattleUnitBuf_Bullet_SV21341>()?.ChangeTempStack(8);
            _motionChanged = false;
            owner.view.charAppearance.ChangeMotion(ActionDetail.Default);
        }
    }
}