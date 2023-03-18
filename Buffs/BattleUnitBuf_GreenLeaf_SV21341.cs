using BigDLL4221.Buffs;
using BigDLL4221.Extensions;
using Sound;
using UnityEngine;

namespace TheGreenHunter_SV21341.Buffs
{
    public class BattleUnitBuf_GreenLeaf_SV21341 : BattleUnitBuf_BaseBufChanged_DLL4221
    {
        private GameObject _aura;

        public BattleUnitBuf_GreenLeaf_SV21341() : base(infinite: true, lastOneScene: false)
        {
        }

        protected override string keywordId => "GreenLeaf_SV21341";
        protected override string keywordIconId => "GreenLeaf_SV21341";
        public override int MaxStack => 10;

        public override void OnAddBuf(int addedStack)
        {
            stack += addedStack;
            stack = Mathf.Clamp(stack, 0, 10);
            if (stack > 9 && _aura == null) CreateAura();
        }

        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            if (stack > 9 && behavior.card.target.GetActiveBuff<BattleUnitBuf_Poison_SV21341>() != null)
                behavior.ApplyDiceStatBonus(new DiceStatBonus { power = 1 });
        }

        public override int GetCardCostAdder(BattleDiceCardModel card)
        {
            return stack > 9 && card.GetOriginCost() == 2 ? -1 : base.GetCardCostAdder(card);
        }

        private void CreateAura()
        {
            if (_aura != null) return;
            var @object = Resources.Load("Prefabs/Battle/SpecialEffect/IndexRelease_Aura");
            if (@object != null)
            {
                var gameObject = Object.Instantiate(@object) as GameObject;
                if (gameObject != null)
                {
                    gameObject.transform.parent = _owner.view.charAppearance.transform;
                    gameObject.transform.localPosition = Vector3.zero;
                    gameObject.transform.localRotation = Quaternion.identity;
                    gameObject.transform.localScale = Vector3.one;
                    var component = gameObject.GetComponent<IndexReleaseAura>();
                    component?.Init(_owner.view);
                    _aura = gameObject;
                }

                if (_aura != null)
                    foreach (var particle in _aura.GetComponentsInChildren<ParticleSystem>())
                    {
                        var main = particle.main;
                        main.startColor = new Color(0, 1, 0, 1);
                    }
            }

            SingletonBehavior<SoundEffectManager>.Instance.PlayClip("Buf/Effect_Index_Unlock");
        }
    }
}