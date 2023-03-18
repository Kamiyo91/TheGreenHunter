namespace TheGreenHunter_SV21341.Cards
{
    public class DiceCardSelfAbility_Willpower_SV21341 : DiceCardSelfAbilityBase
    {
        public override void OnUseCard()
        {
            owner.allyCardDetail.DrawCards(1);
            if (owner.hp < owner.MaxHp * 0.25f) owner.RecoverHP(3);
            if (owner.breakDetail.breakGauge < owner.breakDetail.GetDefaultBreakGauge() * 0.50f)
                owner.breakDetail.RecoverBreak(5);
        }
    }
}