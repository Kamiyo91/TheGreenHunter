namespace TheGreenHunter_SV21341.Actions
{
    public class BehaviourAction_GreenHunterFire_SV21341 : BehaviourActionBase
    {
        public override FarAreaEffect SetFarAreaAtkEffect(BattleUnitModel self)
        {
            _self = self;
            Singleton<BattleFarAreaPlayManager>.Instance.SetActionDelay(0f, 0.2f);
            var component = Util.LoadPrefab("Battle/DiceAttackEffects/CreatureBattle/RedHood_NansaFilter")
                .GetComponent<FarAreaEffect>();
            return component;
        }
    }
}