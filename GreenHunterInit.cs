using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using BigDLL4221.Enum;
using BigDLL4221.Models;
using BigDLL4221.Utils;
using LOR_DiceSystem;
using MonoMod.Utils;
using UnityEngine;

namespace TheGreenHunter_SV21341
{
    public class GreenHunterInit : ModInitializer
    {
        public override void OnInitializeMod()
        {
            OnInitParameters();
            ArtUtil.GetArtWorks(new DirectoryInfo(GreenModParameters.Path + "/ArtWork"));
            CardUtil.ChangeCardItem(ItemXmlDataList.instance, GreenModParameters.PackageId);
            PassiveUtil.ChangePassiveItem(GreenModParameters.PackageId);
            LocalizeUtil.AddGlobalLocalize(GreenModParameters.PackageId);
            ArtUtil.MakeCustomBook(GreenModParameters.PackageId);
            ArtUtil.PreLoadBufIcons();
            LocalizeUtil.RemoveError();
            CardUtil.InitKeywordsList(new List<Assembly> { Assembly.GetExecutingAssembly() });
            ArtUtil.InitCustomEffects(new List<Assembly> { Assembly.GetExecutingAssembly() });
        }

        private static void OnInitParameters()
        {
            ModParameters.PackageIds.Add(GreenModParameters.PackageId);
            GreenModParameters.Path = Path.GetDirectoryName(
                Uri.UnescapeDataString(new UriBuilder(Assembly.GetExecutingAssembly().CodeBase).Path));
            ModParameters.Path.Add(GreenModParameters.PackageId, GreenModParameters.Path);
            ModParameters.DefaultKeyword.Add(GreenModParameters.PackageId, "GreenPoisonModPage_SV21341");
            ModParameters.Assemblies.Add(Assembly.GetExecutingAssembly());
            OnInitSprites();
            OnInitSkins();
            OnInitKeypages();
            OnInitCards();
            OnInitStageOptions();
            OnInitPassives();
            OnInitDropBook();
            OnInitRewards();
            OnInitCredenza();
            OnInitCustomSkins();
        }

        private static void OnInitSkins()
        {
            ModParameters.SkinOptions.AddRange(new Dictionary<string, SkinOptions>
            {
                {
                    "TheGreenHunter_SV21341", new SkinOptions(GreenModParameters.PackageId,
                        motionSounds: new Dictionary<MotionDetail, MotionSound>
                        {
                            { MotionDetail.F, new MotionSound("GreenHunterShot_SV21341.ogg") }
                        })
                },

                {
                    "TheGreenHunterHeadless_SV21341", new SkinOptions(GreenModParameters.PackageId,
                        motionSounds: new Dictionary<MotionDetail, MotionSound>
                        {
                            { MotionDetail.F, new MotionSound("GreenHunterShot_SV21341.ogg") }
                        })
                }
            });
        }

        private static void OnInitSprites()
        {
            ModParameters.SpriteOptions.Add(GreenModParameters.PackageId, new List<SpriteOptions>
            {
                new SpriteOptions(SpriteEnum.Custom, 10000001, "GreenDefault_SV21341")
            });
        }

        private static void OnInitCustomSkins()
        {
            ModParameters.CustomBookSkinsOptions.Add(GreenModParameters.PackageId, new List<CustomBookSkinsOption>
            {
                new CustomBookSkinsOption("TheGreenHunter_SV21341", 10000001, characterNameId: 1)
            });
        }

        private static void OnInitRewards()
        {
            ModParameters.StartUpRewardOptions.Add(new RewardOptions(new Dictionary<LorId, int>
            {
                { new LorId(GreenModParameters.PackageId, 2), 0 }
            }));
        }

        private static void OnInitCards()
        {
            ModParameters.CardOptions.Add(GreenModParameters.PackageId, new List<CardOptions>
            {
                new CardOptions(1, CardOption.Personal, cardColorOptions: new CardColorOptions(
                    new Color(0.6f, 1f, 0.6f),
                    customIconColor: new Color(0.6f, 1f, 0.6f),
                    useHSVFilter: false)),
                new CardOptions(4, CardOption.Personal, cardColorOptions: new CardColorOptions(
                    new Color(0.6f, 1f, 0.6f),
                    customIconColor: new Color(0.6f, 1f, 0.6f),
                    useHSVFilter: false)),
                new CardOptions(5, CardOption.Personal,
                    cardColorOptions: new CardColorOptions(new Color(0.6f, 1f, 0.6f),
                        customIconColor: new Color(0.6f, 1f, 0.6f), useHSVFilter: false)),
                new CardOptions(9, CardOption.EgoPersonal)
            });
        }

        private static void OnInitPassives()
        {
            ModParameters.PassiveOptions.Add(GreenModParameters.PackageId, new List<PassiveOptions>
            {
                new PassiveOptions(1, false,
                    passiveColorOptions: new PassiveColorOptions(new Color(0.6f, 1f, 0.6f),
                        new Color(0.6f, 1f, 0.6f))),
                new PassiveOptions(2, false,
                    passiveColorOptions: new PassiveColorOptions(new Color(0.6f, 1f, 0.6f),
                        new Color(0.6f, 1f, 0.6f)))
            });
        }

        private static void OnInitKeypages()
        {
            ModParameters.KeypageOptions.Add(GreenModParameters.PackageId, new List<KeypageOptions>
            {
                new KeypageOptions(10000001,
                    keypageColorOptions: new KeypageColorOptions(new Color(0.6f, 1f, 0.6f),
                        new Color(0.6f, 1f, 0.6f))),
                new KeypageOptions(1, bookCustomOptions: new BookCustomOptions(nameTextId: 1),
                    keypageColorOptions: new KeypageColorOptions(new Color(0.6f, 1f, 0.6f),
                        new Color(0.6f, 1f, 0.6f)))
            });
        }

        private static void OnInitStageOptions()
        {
            ModParameters.StageOptions.Add(GreenModParameters.PackageId, new List<StageOptions>
            {
                new StageOptions(1,
                    stageColorOptions: new StageColorOptions(new Color(0.6f, 1f, 0.6f), new Color(0.6f, 1f, 0.6f)))
            });
        }

        private static void OnInitDropBook()
        {
            ModParameters.DropBookOptions.Add(GreenModParameters.PackageId, new List<DropBookOptions>
            {
                new DropBookOptions(1, new DropBookColorOptions(new Color(0.6f, 1f, 0.6f), new Color(0.6f, 1f, 0.6f)))
            });
        }

        private static void OnInitCredenza()
        {
            ModParameters.CredenzaOptions.Add(GreenModParameters.PackageId, new CredenzaOptions(
                CredenzaEnum.ModifiedCredenza, new List<int> { 10000001 },
                "GreenHunterSV21341", "", "GreenHunterSV21341",
                bookDataColor: new CredenzaColorOptions(new Color(0.6f, 1f, 0.6f), new Color(0.6f, 1f, 0.6f))));
        }
    }
}