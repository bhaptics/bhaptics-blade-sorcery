using System.Globalization;
using UnityEngine;
using ThunderRoad;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using Bhaptics.Tact;
using CustomWebSocketSharp;
using Newtonsoft.Json.Linq;
using UnityEngine.SceneManagement;
using HarmonyLib;
using UnityEngine.Audio;
using ThunderRoad.Skill.Spell;
using ThunderRoad.Skill.SpellPower;
using ThunderRoad.Skill.SpellMerge;

namespace TactsuitBS
{
    public class Engine : ThunderScript
    {
        //Public parameters

        #region Public Parameters

        [ModOption("Enable Logging", "Enables Logging", defaultValueIndex = 0, order = 0)]
        public static bool Logging = false;


        [ModOption("Disable Native bHaptics", "Disable Native bHaptics", defaultValueIndex = 1, order = 1)]
        public static bool disableNativeBHaptics = true;

        public static bool GravityEffectOnArms = false;
        public static bool GravityEffectOnHead = false;

        [ModOption("Play Fallback Effects", "Enables Fallback Effects", defaultValueIndex = 1, order = 2)]
        public static bool PlayFallbackEffectsForArmHead = true;

        public static bool NoFallEffectWhenFallDamageIsDisabled = false;


        //Rain
        public static int RainVestSleepDuration = 500;
        public static int RainHeadSleepDuration = 1000;
        public static int RainArmSleepDuration = 1000;
        public static int RainEffectDuration = 60;


        public static float IntensityRaindropVest = 1.25f;
        public static float IntensityRaindropArm = 0.85f;
        public static float IntensityRaindropHead = 0.75f;


        //Sleep Durations
        public static int SleepDurationHeartBeat = 900;
        
        public static int SleepDurationHeartBeatFast = 500;
        
        public static int SleepDurationSpellCast = 500;
        
        public static int SleepDurationBowString = 150;
        
        public static int SleepDurationShootGun = 300;
        
        public static int SleepDurationClimb = 300;
        
        public static int SleepDurationSlowMotion = 1500;
        
        public static int SleepDurationSpellHit = 300;
        
        public static int SleepDurationStuckArrow = 210;


        //public float StuckArrowIntensityMultiplier = 0.4f;
        //public float StuckArrowDurationMultiplier = 4.0f;
        //public int StuckArrowSleepDuration = 3000;

        
        [ModOption("Melee Intensity Multiplier", "Melee Intensity Multiplier", defaultValueIndex = 10, order = 3)]
        public static float IntensityMultiplierMelee = 1.0f;

        [ModOption("Bow Intensity Multiplier", "Bow Intensity Multiplier", defaultValueIndex = 10, order = 4)]
        public static float IntensityMultiplierBow = 1.0f;

        [ModOption("Spell Intensity Multiplier", "Spell Intensity Multiplier", defaultValueIndex = 10, order = 5)]
        public static float IntensityMultiplierSpell = 1.0f;

        [ModOption("Telekinesis Intensity Multiplier", "Telekinesis Intensity Multiplier", defaultValueIndex = 10, order = 6)]
        public static float IntensityMultiplierTelekinesis = 1.0f;

        [ModOption("Arrow Damage Intensity Multiplier", "Arrow Damage Intensity Multiplier", defaultValueIndex = 10, order = 7)]
        public static float IntensityMultiplierArrowDamage = 1.0f;

        [ModOption("Melee Damage Intensity Multiplier", "Melee Damage Intensity Multiplier", defaultValueIndex = 10, order = 8)]
        public static float IntensityMultiplierMeleeDamage = 1.0f;

        [ModOption("Spell Damage Intensity Multiplier", "Spell Damage Intensity Multiplier", defaultValueIndex = 10, order = 9)]
        public static float IntensityMultiplierSpellDamage = 1.0f;

        [ModOption("Fall Intensity Multiplier", "Fall Intensity Multiplier", defaultValueIndex = 10, order = 10)]
        public static float IntensityMultiplierFall = 1.0f;

        [ModOption("Fall Effect Min Velocity", "Fall Effect Min Velocity", defaultValueIndex = 70, order = 11)]
        public static float FallEffectMinVelocityMagnitude = 7.0f;

        [ModOption("Climbing Intensity Multiplier", "Climb Intensity Multiplier", defaultValueIndex = 10, order = 12)]
        public static float IntensityMultiplierClimbing = 1.0f;

        [ModOption("Consuming Intensity Multiplier", "Consuming Intensity Multiplier", defaultValueIndex = 10, order = 13)]
        public static float IntensityMultiplierConsuming = 1.0f;

        [ModOption("Heartbeat Intensity Multiplier", "Heartbeat Intensity Multiplier", defaultValueIndex = 10, order = 14)]
        public static float IntensityMultiplierHeartbeat = 1.0f;

        [ModOption("Stuck Arrow Intensity Multiplier", "Stuck Arrow Intensity Multiplier", defaultValueIndex = 10, order = 15)]
        public static float IntensityMultiplierStuckArrow = 1.0f;

        [ModOption("Healing Intensity Multiplier", "Healing Intensity Multiplier", defaultValueIndex = 10, order = 16)]
        public static float IntensityHealing = 1.0f;

        [ModOption("Holster Intensity Multiplier", "Holster Intensity Multiplier", defaultValueIndex = 10, order = 17)]
        public static float IntensityMultiplierHolster = 1.0f;

        [ModOption("Explosion Intensity Multiplier", "Explosion Intensity Multiplier", defaultValueIndex = 10, order = 18)]
        public static float IntensityExplosion = 1.0f;

        [ModOption("Raindrop Intensity Multiplier", "Raindrop Intensity Multiplier", defaultValueIndex = 10, order = 19)]
        public static float IntensityMultiplierRaindrop = 1.0f;

        [ModOption("Equip/Unequip Intensity Multiplier", "Equip/Unequip Intensity Multiplier", defaultValueIndex = 10, order = 20)]
        public static float IntensityEquipUnequip = 1.0f;

        [ModOption("Other Damage Intensity Multiplier", "Other Damage Intensity Multiplier", defaultValueIndex = 20, order = 21)]
        public static float IntensityDefaultDamage = 2.0f;

        [ModOption("Slow Motion Intensity Multiplier", "Slow Motion Intensity Multiplier", defaultValueIndex = 10, order = 22)]
        public static float IntensityMultiplierSlowMotion = 1.0f;

        [ModOption("Gun Firing Intensity Multiplier", "Gun Firing Intensity Multiplier", defaultValueIndex = 0, order = 23)]
        public static float IntensityMultiplierGun = 0.0f;

        //[ModOption("Swimming Intensity Multiplier", "Swimming Intensity Multiplier", defaultValueIndex = 10, order = 24)]
        //public static float IntensitySwim = 1.0f;

        //[ModOption("Drowning Intensity Multiplier", "Drowning Intensity Multiplier", defaultValueIndex = 10, order = 25)]
       // public static float IntensityDrowning = 1.0f;

        public static float IntensityPlayerBowPull = 0.6f;
        
        public static float IntensityPlayerMeleeBladeWoodPierce = 1.0f;
        
        public static float IntensityPlayerMeleeBladeMetalPierce = 1.0f;
        
        public static float IntensityPlayerMeleeBladeStonePierce = 1.0f;
        
        public static float IntensityPlayerMeleeBladeFabricPierce = 1.0f;
        
        public static float IntensityPlayerMeleeBladeFleshPierce = 1.3f;
        
        public static float IntensityPlayerMeleeBladeWoodSlash = 1.0f;
        
        public static float IntensityPlayerMeleeBladeMetalSlash = 1.0f;
        
        public static float IntensityPlayerMeleeBladeStoneSlash = 1.0f;
        
        public static float IntensityPlayerMeleeBladeFabricSlash = 1.0f;
        
        public static float IntensityPlayerMeleeBladeFleshSlash = 1.3f;
        
        public static float IntensityPlayerMeleeBladeWoodBlunt = 1.0f;
        
        public static float IntensityPlayerMeleeBladeMetalBlunt = 1.0f;
        
        public static float IntensityPlayerMeleeBladeStoneBlunt = 1.0f;
        
        public static float IntensityPlayerMeleeBladeFabricBlunt = 1.0f;
        
        public static float IntensityPlayerMeleeBladeFleshBlunt = 1.3f;
        
        public static float IntensityPlayerMeleeWoodWoodBlunt = 1.0f;
        
        public static float IntensityPlayerMeleeWoodMetalBlunt = 1.0f;
        
        public static float IntensityPlayerMeleeWoodStoneBlunt = 1.0f;
        
        public static float IntensityPlayerMeleeWoodFabricBlunt = 1.0f;
        
        public static float IntensityPlayerMeleeWoodFleshBlunt = 1.3f;
        
        public static float IntensityPlayerMeleeStoneStoneBlunt = 2.0f;
        
        public static float IntensityPlayerMeleeStoneFabricBlunt = 1.5f;
        
        public static float IntensityPlayerMeleeStoneFleshBlunt = 1.5f;

        
        public static float IntensityPlayerMeleeLightsaberClashRight = 1.0f;
        
        public static float IntensityPlayerMeleeLightsaberSlashRight = 1.5f;
        
        public static float IntensityPlayerMeleeLightsaberPierceRight = 1.5f;
        
        public static float IntensityPlayerMeleeLightsaberBluntRight = 1.5f;

        
        public static float IntensityPlayerSpellFire = 0.5f;
        
        public static float IntensityPlayerSpellLightning = 0.5f;
        
        public static float IntensityPlayerSpellGravity = 0.5f;
        
        public static float IntensityPlayerSpellIce = 0.5f;
        
        public static float IntensityPlayerSpellCrush = 0.5f;
        
        public static float IntensityPlayerSpellHeal = 0.5f;
        
        public static float IntensityPlayerSpellImplosion = 0.5f;
        
        public static float IntensityPlayerSpellInvisibility = 0.5f;
        
        public static float IntensityPlayerSpellTesla = 0.5f;
        
        public static float IntensityPlayerSpellUtility = 0.5f;
        
        public static float IntensityPlayerSpellCorruption = 0.5f;
        
        public static float IntensityPlayerSpellTeleport = 0.5f;
        
        public static float IntensityPlayerSpellRasengan = 0.5f;
        
        public static float IntensityPlayerSpellNeedle = 0.5f;
        
        public static float IntensityPlayerSpellDrain = 0.5f;
        
        public static float IntensityPlayerSpellForceField = 0.5f;
        
        public static float IntensityPlayerSpellOther = 0.5f;

        
        public static float IntensityPlayerTelekinesisActive = 0.3f;
        
        public static float IntensityPlayerTelekinesisPull = 0.3f;
        
        public static float IntensityPlayerTelekinesisRepel = 0.3f;
        
        public static float IntensityPlayerTelekinesisCatch = 0.3f;

        
        public static float IntensityDamageVestArrow = 1.0f;
        
        public static float IntensityDamageArmArrow = 1.0f;
        
        public static float IntensityDamageHeadArrow = 1.0f;
        
        public static float IntensityDamageVestFireArrow = 1.0f;
        
        public static float IntensityDamageArmFireArrow = 1.0f;
        
        public static float IntensityDamageHeadFireArrow = 1.0f;
        
        public static float IntensityDamageVestLightningArrow = 1.0f;
        
        public static float IntensityDamageArmLightningArrow = 1.0f;
        
        public static float IntensityDamageHeadLightningArrow = 1.0f;
        
        public static float IntensityDamageVestIceArrow = 1.0f;
        
        public static float IntensityDamageArmIceArrow = 1.0f;
        
        public static float IntensityDamageHeadIceArrow = 1.0f;
        
        public static float IntensityDamageHeadFire = 1.0f;
        
        public static float IntensityDamageHeadLightning = 1.0f;
        
        public static float IntensityDamageHeadGravity = 1.0f;
        
        public static float IntensityDamageHeadIce = 1.0f;
        
        public static float IntensityDamageHeadDrain = 1.0f;
        
        public static float IntensityDamageHeadEnergy = 1.0f;
        
        public static float IntensityDamageArmFire = 1.0f;
        
        public static float IntensityDamageArmLightning = 1.0f;
        
        public static float IntensityDamageArmGravity = 1.0f;
        
        public static float IntensityDamageArmIce = 1.0f;
        
        public static float IntensityDamageArmDrain = 1.0f;
        
        public static float IntensityDamageArmEnergy = 1.0f;

        
        public static float IntensityDamageVestEnergy = 1.2f;
        
        public static float IntensityDamageVestFire = 3.0f;
        
        public static float IntensityDamageVestLightning = 1.2f;
        
        public static float IntensityDamageVestGravity = 1.0f;
        
        public static float IntensityDamageVestIce = 1.2f;
        
        public static float IntensityDamageVestDrain = 1.2f;

        
        public static float IntensityDamageVestPierceBladeSmall = 1.2f;
        
        public static float IntensityDamageVestSlashBladeSmall = 1.6f;
        
        public static float IntensityDamageVestBluntBladeSmall = 1.6f;
        
        public static float IntensityDamageVestBluntWoodSmall = 1.2f;
        
        public static float IntensityDamageVestBluntMetalSmall = 1.6f;
        
        public static float IntensityDamageVestBluntStoneSmall = 1.2f;
        
        public static float IntensityDamageVestBluntFleshSmall = 1.2f;
        
        public static float IntensityDamageVestPierceFireSmall = 1.2f;
        
        public static float IntensityDamageVestSlashFireSmall = 1.2f;
        
        public static float IntensityDamageVestBluntFireSmall = 1.2f;
        
        public static float IntensityDamageVestPierceLightningSmall = 1.2f;
        
        public static float IntensityDamageVestSlashLightningSmall = 1.6f;
        
        public static float IntensityDamageVestBluntLightningSmall = 1.2f;
        
        public static float IntensityDamageVestPierceIceSmall = 1.2f;
        
        public static float IntensityDamageVestSlashIceSmall = 1.6f;
        
        public static float IntensityDamageVestBluntIceSmall = 1.2f;
        
        public static float IntensityDamageVestPierceBladeLarge = 1.2f;
        
        public static float IntensityDamageVestSlashBladeLarge = 1.6f;
        
        public static float IntensityDamageVestBluntBladeLarge = 1.6f;
        
        public static float IntensityDamageVestBluntWoodLarge = 1.2f;
        
        public static float IntensityDamageVestBluntMetalLarge = 1.6f;
        
        public static float IntensityDamageVestBluntStoneLarge = 1.2f;
        
        public static float IntensityDamageVestBluntFleshLarge = 1.2f;
        
        public static float IntensityDamageVestPierceFireLarge = 1.2f;
        
        public static float IntensityDamageVestSlashFireLarge = 1.2f;
        
        public static float IntensityDamageVestBluntFireLarge = 1.2f;
        
        public static float IntensityDamageVestPierceLightningLarge = 1.2f;
        
        public static float IntensityDamageVestSlashLightningLarge = 1.6f;
        
        public static float IntensityDamageVestBluntLightningLarge = 1.2f;
        
        public static float IntensityDamageVestPierceIceLarge = 1.2f;
        
        public static float IntensityDamageVestSlashIceLarge = 1.6f;
        
        public static float IntensityDamageVestBluntIceLarge = 1.2f;

        
        public static float IntensityDamageVestBlaster = 2.0f;
        
        public static float IntensityDamageVestBlasterStun = 2.0f;
        
        public static float IntensityDamageArmBlaster = 2.0f;
        
        public static float IntensityDamageArmBlasterStun = 2.0f;
        
        public static float IntensityDamageHeadBlaster = 2.0f;
        
        public static float IntensityDamageHeadBlasterStun = 2.0f;


        
        public static float IntensityDamageVestPierceLightsaber = 2.0f;
        
        public static float IntensityDamageVestSlashLightsaber = 2.0f;
        
        public static float IntensityDamageVestBluntLightsaber = 2.0f;
        
        public static float IntensityDamageRightArmBluntLightsaber = 2.0f;
        
        public static float IntensityDamageRightArmPierceLightsaber = 2.0f;
        
        public static float IntensityDamageRightArmSlashLightsaber = 2.0f;
        
        public static float IntensityDamageHeadPierceLightsaber = 2.0f;
        
        public static float IntensityDamageHeadSlashLightsaber = 2.0f;
        
        public static float IntensityDamageHeadBluntLightsaber = 2.0f;

        
        public static float IntensityDamageArmPierceBladeSmall = 1.3f;
        
        public static float IntensityDamageArmSlashBladeSmall = 1.3f;
        
        public static float IntensityDamageArmBluntBladeSmall = 1.3f;
        
        public static float IntensityDamageArmBluntWoodSmall = 1.3f;
        
        public static float IntensityDamageArmBluntMetalSmall = 1.3f;
        
        public static float IntensityDamageArmBluntStoneSmall = 1.3f;
        
        public static float IntensityDamageArmBluntFleshSmall = 1.3f;
        
        public static float IntensityDamageArmPierceFireSmall = 1.3f;
        
        public static float IntensityDamageArmSlashFireSmall = 1.5f;
        
        public static float IntensityDamageArmBluntFireSmall = 1.5f;
        
        public static float IntensityDamageArmPierceLightningSmall = 1.5f;
        
        public static float IntensityDamageArmSlashLightningSmall = 1.5f;
        
        public static float IntensityDamageArmBluntLightningSmall = 1.5f;
        
        public static float IntensityDamageArmPierceIceSmall = 1.5f;
        
        public static float IntensityDamageArmSlashIceSmall = 1.5f;
        
        public static float IntensityDamageArmBluntIceSmall = 1.5f;
        
        public static float IntensityDamageArmPierceBladeLarge = 1.3f;
        
        public static float IntensityDamageArmSlashBladeLarge = 1.30f;
        
        public static float IntensityDamageArmBluntBladeLarge = 1.3f;
        
        public static float IntensityDamageArmBluntWoodLarge = 1.3f;
        
        public static float IntensityDamageArmBluntMetalLarge = 1.3f;
        
        public static float IntensityDamageArmBluntStoneLarge = 1.3f;
        
        public static float IntensityDamageArmBluntFleshLarge = 1.3f;
        
        public static float IntensityDamageArmPierceFireLarge = 1.3f;
        
        public static float IntensityDamageArmSlashFireLarge = 1.5f;
        
        public static float IntensityDamageArmBluntFireLarge = 1.5f;
        
        public static float IntensityDamageArmPierceLightningLarge = 1.5f;
        
        public static float IntensityDamageArmSlashLightningLarge = 1.5f;
        
        public static float IntensityDamageArmBluntLightningLarge = 1.5f;
        
        public static float IntensityDamageArmPierceIceLarge = 1.5f;
        
        public static float IntensityDamageArmSlashIceLarge = 1.5f;
        
        public static float IntensityDamageArmBluntIceLarge = 1.5f;
        
        public static float IntensityDamageHeadPierceBladeSmall = 1.0f;
        
        public static float IntensityDamageHeadSlashBladeSmall = 1.0f;
        
        public static float IntensityDamageHeadBluntBladeSmall = 1.0f;
        
        public static float IntensityDamageHeadBluntWoodSmall = 1.0f;
        
        public static float IntensityDamageHeadBluntMetalSmall = 1.0f;
        
        public static float IntensityDamageHeadBluntStoneSmall = 1.0f;
        
        public static float IntensityDamageHeadBluntFleshSmall = 1.0f;
        
        public static float IntensityDamageHeadPierceFireSmall = 1.0f;
        
        public static float IntensityDamageHeadSlashFireSmall = 1.0f;
        
        public static float IntensityDamageHeadBluntFireSmall = 1.0f;
        
        public static float IntensityDamageHeadPierceLightningSmall = 1.0f;
        
        public static float IntensityDamageHeadSlashLightningSmall = 1.0f;
        
        public static float IntensityDamageHeadBluntLightningSmall = 1.0f;
        
        public static float IntensityDamageHeadPierceIceSmall = 1.0f;
        
        public static float IntensityDamageHeadSlashIceSmall = 1.0f;
        
        public static float IntensityDamageHeadBluntIceSmall = 1.0f;
        
        public static float IntensityDamageHeadPierceBladeLarge = 1.0f;
        
        public static float IntensityDamageHeadSlashBladeLarge = 1.0f;
        
        public static float IntensityDamageHeadBluntBladeLarge = 1.0f;
        
        public static float IntensityDamageHeadBluntWoodLarge = 1.0f;
        
        public static float IntensityDamageHeadBluntMetalLarge = 1.0f;
        
        public static float IntensityDamageHeadBluntStoneLarge = 1.0f;
        
        public static float IntensityDamageHeadBluntFleshLarge = 1.0f;
        
        public static float IntensityDamageHeadPierceFireLarge = 1.0f;
        
        public static float IntensityDamageHeadSlashFireLarge = 1.0f;
        
        public static float IntensityDamageHeadBluntFireLarge = 1.0f;
        
        public static float IntensityDamageHeadPierceLightningLarge = 1.0f;
        
        public static float IntensityDamageHeadSlashLightningLarge = 1.0f;
        
        public static float IntensityDamageHeadBluntLightningLarge = 1.0f;
        
        public static float IntensityDamageHeadPierceIceLarge = 1.0f;
        
        public static float IntensityDamageHeadSlashIceLarge = 1.0f;
        
        public static float IntensityDamageHeadBluntIceLarge = 1.0f;

        
        public static float IntensityHeartBeat = 0.5f;
        
        public static float IntensityHeartBeatFast = 0.5f;
        
        public static float IntensityPotionDrinking = 0.8f;
        
        public static float IntensityPoisonDrinking = 1.0f;
        
        public static float IntensityFallDamage = 4.0f;
        
        public static float IntensityFallDamageFeet = 1.7f;
        
        public static float IntensitySlowMotion = 0.8f;
        
        public static float IntensityHolster = 1.0f;
        
        public static float IntensityUnholster = 1.0f;
        
        public static float IntensityHolsterArrow = 1.0f;
        
        public static float IntensityUnholsterArrow = 1.0f;
        
        public static float IntensityClimbing = 1.2f;
        
        public static float IntensityPlayerKickOther = 3.0f;
        
        public static float IntensityPlayerKickWood = 3.0f;
        
        public static float IntensityPlayerKickFlesh = 3.0f;
        
        public static float IntensityPlayerKickStone = 3.0f;
        
        public static float IntensityPlayerKickMetal = 3.0f;
        
        public static float IntensityPlayerKickFabric = 3.0f;
        
        public static float IntensityPlayerPunchOther = 4.0f;
        
        public static float IntensityPlayerPunchWood = 4.0f;
        
        public static float IntensityPlayerPunchFlesh = 4.0f;
        
        public static float IntensityPlayerPunchStone = 4.0f;
        
        public static float IntensityPlayerPunchMetal = 4.0f;
        
        public static float IntensityPlayerPunchFabric = 4.0f;

        
        public static float IntensityPlayerGun = 1.0f;
        
        public static float IntensityPlayerGunBlaster = 1.2f;
        
        public static float IntensityPlayerGunAutomatic = 1.5f;
        
        public static float IntensityPlayerGunBallistic = 1.3f;
        
        public static float IntensityPlayerGunSpray = 1.0f;
        
        public static float IntensityPlayerGunMiniGun = 1.0f;
        
        public static float IntensityPlayerGunBazooka = 1.5f;
        
        public static float IntensityPlayerGunHeavy = 1.0f;
        
        public static float IntensityPlayerGunLaser = 1.0f;
        
        public static float IntensityPlayerGunRifle = 1.0f;
        
        public static float IntensityPlayerGunPistol = 1.0f;
        
        public static float IntensityPlayerGunPlasma = 1.2f;
        
        public static float IntensityPlayerGunShotgun = 1.0f;
        
        public static float IntensityPlayerGunEnergy = 1.0f;
        
        public static float IntensityKickbackPlayerGun = 1.0f;
        
        public static float IntensityKickbackPlayerGunPistol = 1.0f;
        
        public static float IntensityKickbackPlayerGunBallistic = 1.5f;
        
        public static float IntensityKickbackPlayerGunLaser = 1.0f;
        
        public static float IntensityKickbackPlayerGunPlasma = 1.5f;
        
        public static float IntensityKickbackPlayerGunSpray = 1.0f;
        
        public static float IntensityKickbackPlayerGunHeavy = 2.0f;

        
        public static float IntensityPlayerThrow = 1.5f;

        

        
        public static float IntensityShoulderTurret = 1.0f;
        
        public static float IntensityHoverJetFeet = 1.0f;


        
        public static float IntensityConsumableFood = 1.0f;

        
        public static float IntensityStuckArrow = 0.35f;


        #endregion

        //Private parameters

        #region Private Parameters

        private bool eventsCreated = false;

        //private bool playerEventsCreated = false;
        private static TactsuitVR tactsuitVr;
        private static bool Heartbeating = false;
        private static bool HeartbeatingFast = false;
        private static bool gamePaused = false;
        

        private bool TelekinesisPullLeft = false;
        private bool TelekinesisPullRight = false;
        private bool TelekinesisRepelLeft = false;
        private bool TelekinesisRepelRight = false;
        private bool TelekinesisActiveLeft = false;
        private bool TelekinesisActiveRight = false;
        private bool TelekinesisSpinLeft = false;
        private bool TelekinesisSpinRight = false;


        private ParticleSystem leftItemShootVFX = null;
        private ParticleSystem leftItemShoot2VFX = null;

        private ParticleSystem rightItemShootVFX = null;
        private ParticleSystem rightItemShoot2VFX = null;

        private ParticleSystem leftShoulderTurretShootVFX = null;
        private ParticleSystem hoverJetVFX = null;


        private AudioSource leftItemShootSFX = null;

        private AudioSource rightItemShootSFX = null;

        private AudioSource leftItemChargeSFX = null;

        private AudioSource rightItemChargeSFX = null;

        private AudioSource leftItemChargeReadySFX = null;

        private AudioSource rightItemChargeReadySFX = null;

        private float deltaTime = 0.0f;
        private float shootGunCheckTimeLeft = 0.0f;
        private float climbingCheckTimeLeft = 0.0f;

        private bool bowStringHeld = false;

        private bool ItemHeldInLeftHand = false;
        private bool ItemHeldInRightHand = false;

        private bool leftHandClimbing = false;
        private bool rightHandClimbing = false;

        private bool grabbedLadderWithLeftHand = false;
        private bool grabbedLadderWithRightHand = false;

        private bool beingPushed = false;
        private bool beingPushedOther = false;
        private bool beingPulledLeft = false;
        private bool beingPulledRight = false;

        private float TOLERANCE = 0.0001f;

        private bool leftItemUseStarted = false;
        private bool leftItemAltUseStarted = false;

        private bool rightItemUseStarted = false;
        private bool rightItemAltUseStarted = false;

        private bool leftModularGunFiring = false;
        private bool rightModularGunFiring = false;


        private bool shootingLeftGun = false;
        private bool shootingRightGun = false;
        private bool altShootingLeftGun = false;
        private bool altShootingRightGun = false;

        private bool shootingLeftShoulderTurret = false;
        private bool hoveringWithHoverJet = false;

        private GameObject rainController;

        private bool raining = false;
        private float rainIntensity = 0.52f;
        private float rainDensity = 7.0f; 

        private Vector3 lastFrameVelocity = Vector3.zero;
        private bool noExplosionFeedback = false;

        private List<string> SFXList;
        private List<string> VFXList;

        Dictionary<string, bool> GunUseMultipleShotMap = new Dictionary<string, bool>();
        Dictionary<string, bool> GunAltUseMultipleShotMap = new Dictionary<string, bool>();

        private Item leftItem;
        private Item rightItem;
        private Component leftItemBlasterComponent;
        private Component rightItemBlasterComponent;

        Component leftItemModularFireArmBaseComponent1;
        Component leftItemModularFireArmBaseComponent2;

        Component rightItemModularFireArmBaseComponent1;
        Component rightItemModularFireArmBaseComponent2;

        private Harmony harmony;

        #endregion

        void LOG(string logStr)
        {
            if (Logging)
            {
                Utility.LOG(logStr);
            }
        }

        #region Overrides

        public override void ScriptLoaded(ModManager.ModData modData)
        {
            EventManager.OnPlayerPrefabSpawned += new EventManager.PlayerPrefabSpawnedEvent(EngineStart);
            base.ScriptLoaded(modData);
        }

        public void EngineStart()
        {
            tactsuitVr = new TactsuitVR();
            Bhaptics.Tact.HapticPlayerManager.SetAppInfo("mod_blade_sorcery", "mod_blade_sorcery");
            tactsuitVr.CreateSystem();

            this.harmony = new Harmony("com.shizof.bhaptics");
            this.harmony.PatchAll(Assembly.GetExecutingAssembly());

            LOG("Loaded.");

            foreach (TactsuitVR.FeedbackType f in Enum.GetValues(typeof(TactsuitVR.FeedbackType)))
            {
                if (f == TactsuitVR.FeedbackType.NoFeedback)
                    continue;

                if (!tactsuitVr.feedbackMap.ContainsKey(f) || tactsuitVr.feedbackMap[f].feedbackFileCount == 0)
                {
                    LOG("Tact file NOT found: " + f.ToString());
                }
            }

            FillFXLists();

            SceneManager.sceneLoaded += this.OnSceneLoadedFunc;
            SceneManager.sceneUnloaded += this.OnSceneUnloadedFunc;

            Player.onSpawn += new Player.SpawnEvent(this.OnPlayerSpawned);
        }

        private void OnPlayerSpawned(Player player)
        {
            foreach (GameObject gameObject in (GameObject[])UnityEngine.Object.FindObjectsOfType<GameObject>())
            {
                if (gameObject != null)
                {
                    if (gameObject.GetComponent("RainController"))
                    {
                        rainController = gameObject;
                        break;
                    }
                }
            }

            if (rainController != null)
            {
                LOG("Rain Controller found in scene.");
            }
            else
            {
                LOG("Rain Controller not found in scene.");
            }

            Thread thread = new Thread(CheckPlayerSpawn);
            thread.Start();
        }

        private void OnSceneUnloadedFunc(Scene scene)
        {
            gamePaused = true;
            LOG("Scene unloaded: " + scene.name);
        }

        private void OnSceneLoadedFunc(Scene scene, LoadSceneMode mode)
        {
            gamePaused = false;

            LOG("Scene loaded: " + scene.name);
        }

        private void FillFXLists()
        {
            SFXList= new List<string>();
            VFXList = new List<string>();

            string modPath = Directory.GetCurrentDirectory() + "\\BladeAndSorcery_Data\\StreamingAssets";

            DirectoryInfo d = new DirectoryInfo(modPath);
            if (d != null)
            {
                FileInfo[] Files = d.GetFiles("Item_*.json", SearchOption.AllDirectories);
                if (Files != null)
                {
                    for (int i = 0; i < Files.Length; i++)
                    {
                        string filename = Files[i].Name;
                        string fullName = Files[i].FullName;
                        if (filename == "." || filename == "..")
                            continue;

                        string jsonFileStr = File.ReadAllText(fullName);
                        if (!jsonFileStr.IsNullOrEmpty())
                        {
                            if (jsonFileStr.Contains("Shooter"))
                            {
                                JObject obj = JObject.Parse(jsonFileStr);
                                if (obj != null)
                                {
                                    string displayName = (string) obj["displayName"];

                                    foreach (var module in obj.SelectTokens("modules[*]"))
                                    {
                                        if (module != null)
                                        {
                                            bool shotWithAltUse = false;

                                            if (module["shootWithAltUse"] != null)
                                            {
                                                shotWithAltUse = (bool) module["shootWithAltUse"];
                                                bool multipleShots = false;
                                                if (module["multipleShotsWithoutReleasingTrigger"] != null)
                                                {
                                                    multipleShots = (bool) module["multipleShotsWithoutReleasingTrigger"];

                                                    if (shotWithAltUse)
                                                    {
                                                        GunAltUseMultipleShotMap[displayName] = multipleShots;
                                                        LOG("Gun " + displayName + " alt fire: " + (multipleShots ? "multiple" : "single"));
                                                    }
                                                    else
                                                    {
                                                        GunUseMultipleShotMap[displayName] = multipleShots;
                                                        LOG("Gun " + displayName + " fire: " + (multipleShots ? "multiple" : "single"));
                                                    }
                                                }
                                            }

                                            string shootSfx = (string) module["shootSFX"];
                                            string shootVfx = (string) module["shootVFX"];
                                            if (!shootSfx.IsNullOrEmpty())
                                            {
                                                if (!SFXList.Contains(shootSfx))
                                                    SFXList.Add(shootSfx);
                                            }

                                            if (!shootVfx.IsNullOrEmpty())
                                            {
                                                if (!VFXList.Contains(shootVfx))
                                                    VFXList.Add(shootVfx);
                                            }
                                        }
                                    }
                                }
                            }
                            else if (jsonFileStr.Contains("SimpleBallistics"))
                            {
                                JObject obj = JObject.Parse(jsonFileStr);
                                if (obj != null)
                                {
                                    string displayName = (string) obj["displayName"];

                                    foreach (var module in obj.SelectTokens("modules[*]"))
                                    {
                                        if (module != null)
                                        {
                                            GunUseMultipleShotMap[displayName] = false;
                                            LOG("Gun " + displayName + " fire: single");

                                            string shootSfx = (string) module["fireSoundRef"];
                                            string shootVfx = (string) module["muzzleFlashRef"];
                                            if (!shootSfx.IsNullOrEmpty())
                                            {
                                                if (!SFXList.Contains(shootSfx))
                                                    SFXList.Add(shootSfx);
                                            }

                                            if (!shootVfx.IsNullOrEmpty())
                                            {
                                                if (!VFXList.Contains(shootVfx))
                                                    VFXList.Add(shootVfx);
                                            }
                                        }
                                    }
                                }
                            }
                            else if (jsonFileStr.Contains("TheOuterRim") || jsonFileStr.Contains("GunScript") || jsonFileStr.Contains("Shoot"))
                            {
                                JObject obj = JObject.Parse(jsonFileStr);
                                if (obj != null)
                                {
                                    string displayName = (string) obj["displayName"];

                                    GunUseMultipleShotMap[displayName] = false;
                                    GunAltUseMultipleShotMap[displayName] = false;

                                }
                            }
                        }
                    }
                }
            }

            SFXList.Add("GrappleSound"); //Support for ButtersAndSorcery's Batman Grapple Mod
            SFXList.Add("FireSounds"); //Support for The Outer Rim
            SFXList.Add("FireSounds2"); //Support for The Outer Rim
            SFXList.Add("FireSounds3"); //Support for The Outer Rim
            GunUseMultipleShotMap["GrappleGun"] = false;
            GunUseMultipleShotMap["BatmanGrapple"] = false;

            

            //Support for Piepop101's Glock and Gun Framework
            VFXList.Add("bulletShotVFX");
            SFXList.Add("bulletShotSFX"); 

            LOG("Found Gun VFX count: " + VFXList.Count + " Gun SFX count: " + SFXList.Count);
            LOG("Found Gun VFXs: " + String.Join(", ", VFXList));
            LOG("Found Gun SFXs: " + String.Join(", ", SFXList));
        }

        public override void ScriptUpdate()
        {
            gamePaused = UIPlayerMenu.instance.IsShownToPlayer;
                        
            if (!eventsCreated)
            {
                EventManager.onCreatureHit += OnCreatureHitFunc;
                EventManager.onCreatureHeal += OnCreatureHealFunc;
                EventManager.onCreatureKill += OnCreatureKillFunc;
                EventManager.onCreatureAttackParry += OnCreatureParryFunc;
                EventManager.onDeflect += OnDeflectFunc;
                EventManager.onEdibleConsumed += OnEdibleConsumedFunc;
                EventManager.onLiquidConsumed += OnLiquidConsumedFunc;

                SpellTelekinesis.onTelekinesisPullEvent += OnTelekinesisPullEventFunc;
                SpellTelekinesis.onTelekinesisRepelEvent += OnTelekinesisRepelEvent;
                SpellTelekinesis.onTelekinesisUngrabEvent += OnTelekinesisUngrabEvent;
                SpellTelekinesis.onTelekinesisGrabEvent += OnTelekinesisGrabEvent;
                SpellTelekinesis.onTelekinesisUnTargetEvent += OnTelekinesisUnTargetEvent;
                SpellTelekinesis.onTelekinesisSpinStart += Telekinesis_onTelekinesisSpinStart;
                SpellTelekinesis.onTelekinesisSpinEnd += Telekinesis_onTelekinesisSpinEnd;

                //Locomotion.OnGroundEvent 
                eventsCreated = true;
                LOG("Events are created.");
            }

            deltaTime = Time.deltaTime * 1000f;

            if (!TimeManager.timeStopped)
            {
                if (Player.local != null && Player.local.creature != null && Player.local.creature.initialized)
                {
                    CheckStates(Player.local.creature);
                    CheckStatesRarest(Player.local.creature);
                }
                //else
                //{
                //    lastFrameVelocity = Vector3.zero;
                //}
            }
            //else
            //{
            //    lastFrameVelocity = Vector3.zero;
            //}

            base.ScriptUpdate();
        }

        private void Telekinesis_onTelekinesisSpinEnd(SpellCaster spellCaster, SpellTelekinesis spellTelekinesis, Side side, Handle handle, bool spinning, EventTime eventTime)
        {
            if (side == Side.Left)
            {
                if (TelekinesisSpinLeft)
                {
                    TelekinesisSpinLeft = false;
                    LOG("Player stops spinning with telekinesis left hand.");
                }
            }
            else
            {
                if (TelekinesisSpinRight)
                {
                    TelekinesisSpinRight = false;
                    LOG("Player stops spinning with telekinesis right hand.");
                }
            }
        }

        private void Telekinesis_onTelekinesisSpinStart(SpellCaster spellCaster, SpellTelekinesis spellTelekinesis, Side side, Handle handle, bool spinning, EventTime eventTime)
        {
            if (eventTime == EventTime.OnStart)
            {
                if (side == Side.Left)
                {
                    if (!TelekinesisSpinLeft)
                    {
                        TelekinesisSpinLeft = true;
                        Thread thread = new Thread(() => TelekinesisFunc(true, true));
                        thread.Start();
                        LOG("Player is spinning with telekinesis left hand.");
                    }
                }
                else
                {
                    if (!TelekinesisSpinRight)
                    {
                        TelekinesisSpinRight = true;
                        Thread thread = new Thread(() => TelekinesisFunc(true, false));
                        thread.Start();
                        LOG("Player is spinning with telekinesis right hand.");
                    }
                }
            }
        }

        private void OnHeldItemsChangeEventFunc(Item oldRightHand, Item oldLeftHand, Item newRightHand, Item newLeftHand)
        {
            if (IntensityMultiplierGun > TOLERANCE)
            {
                if (newRightHand != oldRightHand)
                {
                    rightItem = newRightHand;

                    ParticleSystem temp_rightItemShootVFX = null;

                    if (rightItem.customReferences.Find((Predicate<CustomReference>)(cr => cr.name == "FireEffect")) != null && rightItem.GetCustomReference("FireEffect")?.GetComponent<ParticleSystem>() != null)
                    {
                        temp_rightItemShootVFX = rightItem.GetCustomReference("FireEffect").GetComponent<ParticleSystem>();
                    }
                    else if (rightItem.customReferences.Find((Predicate<CustomReference>)(cr => cr.name == "bulletShotVFX")) != null && rightItem.GetCustomReference("bulletShotVFX")?.GetComponent<ParticleSystem>() != null)
                    {
                        temp_rightItemShootVFX = rightItem.GetCustomReference("bulletShotVFX").GetComponent<ParticleSystem>();
                    }
                    else
                    {
                        foreach (var vfx in VFXList)
                        {
                            if (rightItem.transform?.Find(vfx)?.gameObject?.GetComponentInChildren<ParticleSystem>() != null)
                            {
                                temp_rightItemShootVFX = rightItem.transform.Find(vfx).gameObject.GetComponentInChildren<ParticleSystem>();
                                if (temp_rightItemShootVFX != null)
                                    break;
                            }
                            else if (rightItem.customReferences.Find((Predicate<CustomReference>)(cr => cr.name == vfx)) != null && rightItem.GetCustomReference(vfx)?.GetComponent<ParticleSystem>() != null)
                            {
                                temp_rightItemShootVFX = (ParticleSystem)((Component)rightItem.GetCustomReference(vfx)).GetComponent<ParticleSystem>();
                                if (temp_rightItemShootVFX != null)
                                    break;
                            }
                        }
                    }

                    rightItemShootVFX = temp_rightItemShootVFX;

                    if (rightItem.customReferences.Find((Predicate<CustomReference>)(cr => cr.name == "AltFireEffect")) != null && rightItem.GetCustomReference("AltFireEffect")?.GetComponent<ParticleSystem>() != null)
                    {
                        rightItemShoot2VFX = rightItem.GetCustomReference("AltFireEffect").GetComponent<ParticleSystem>();
                    }
                    else
                    {
                        rightItemShoot2VFX = null;
                    }

                    if (rightItem.customReferences.Find((Predicate<CustomReference>)(cr => cr.name == "bulletShotSFX")) != null && rightItem.GetCustomReference("bulletShotSFX")?.GetComponent<AudioSource>() != null)
                    {
                        rightItemShootSFX = rightItem.GetCustomReference("bulletShotSFX").GetComponent<AudioSource>();
                    }
                    else
                    {
                        foreach (var sfx in SFXList)
                        {
                            if (rightItem.transform?.Find(sfx)?.gameObject?.GetComponentInChildren<AudioSource>() != null)
                            {
                                rightItemShootSFX = rightItem.transform.Find(sfx).gameObject.GetComponentInChildren<AudioSource>();
                                if (rightItemShootSFX != null)
                                    break;
                            }
                            else if (rightItem.customReferences.Find((Predicate<CustomReference>)(cr => cr.name == sfx)) != null && rightItem.GetCustomReference(sfx)?.GetComponent<AudioSource>() != null)
                            {
                                rightItemShootSFX = (AudioSource)((Component)rightItem.GetCustomReference(sfx)).GetComponent<AudioSource>();
                                if (rightItemShootSFX != null)
                                    break;
                            }
                        }
                    }


                    if (rightItem.transform?.Find("ChargeReadySounds")?.gameObject?.GetComponentInChildren<AudioSource>() != null)
                    {
                        rightItemChargeReadySFX = rightItem.transform.Find("ChargeReadySounds").gameObject.GetComponentInChildren<AudioSource>();
                    }
                    else if (rightItem.customReferences.Find((Predicate<CustomReference>)(cr => cr.name == "ChargeReadySounds")) != null && rightItem.GetCustomReference("ChargeReadySounds")?.GetComponent<AudioSource>() != null)
                    {
                        rightItemChargeReadySFX = (AudioSource)((Component)rightItem.GetCustomReference("ChargeReadySounds")).GetComponent<AudioSource>();
                    }

                    if (rightItem.transform?.Find("ChargeStartSounds")?.gameObject?.GetComponentInChildren<AudioSource>() != null)
                    {
                        rightItemChargeSFX = rightItem.transform.Find("ChargeStartSounds").gameObject.GetComponentInChildren<AudioSource>();
                    }
                    else if (rightItem.customReferences.Find((Predicate<CustomReference>)(cr => cr.name == "ChargeStartSounds")) != null && rightItem.GetCustomReference("ChargeStartSounds")?.GetComponent<AudioSource>() != null)
                    {
                        rightItemChargeSFX = (AudioSource)((Component)rightItem.GetCustomReference("ChargeStartSounds")).GetComponent<AudioSource>();
                    }
                    else if (rightItem.transform?.Find("ChargeSounds")?.gameObject?.GetComponentInChildren<AudioSource>() != null)
                    {
                        rightItemChargeSFX = rightItem.transform.Find("ChargeSounds").gameObject.GetComponentInChildren<AudioSource>();
                    }
                    else if (rightItem.customReferences.Find((Predicate<CustomReference>)(cr => cr.name == "ChargeSounds")) != null && rightItem.GetCustomReference("ChargeSounds")?.GetComponent<AudioSource>() != null)
                    {
                        rightItemChargeSFX = (AudioSource)((Component)rightItem.GetCustomReference("ChargeSounds")).GetComponent<AudioSource>();
                    }

                    rightItemBlasterComponent = rightItem.GetComponent("ItemBlaster");
                    if (rightItemBlasterComponent != null)
                    {
                        if (rightItemChargeReadySFX == null)
                        {
                            rightItemChargeReadySFX = Utility.GetValuePrivateAudioSource(rightItemBlasterComponent, "chargeReadySound");
                        }
                        if (rightItemChargeReadySFX == null)
                        {
                            rightItemChargeReadySFX = Utility.GetValuePrivateAudioSource(rightItemBlasterComponent, "chargeReadySound2");
                        }
                        if (rightItemChargeSFX == null)
                        {
                            rightItemChargeSFX = Utility.GetValuePrivateAudioSource(rightItemBlasterComponent, "chargeStartSound");
                        }
                        if (rightItemChargeSFX == null)
                        {
                            rightItemChargeSFX = Utility.GetValuePrivateAudioSource(rightItemBlasterComponent, "chargeStartSound2");
                        }
                        if (rightItemChargeSFX == null)
                        {
                            rightItemChargeSFX = Utility.GetValuePrivateAudioSource(rightItemBlasterComponent, "chargeSound");
                        }
                        if (rightItemChargeSFX == null)
                        {
                            rightItemChargeSFX = Utility.GetValuePrivateAudioSource(rightItemBlasterComponent, "chargeSound2");
                        }
                    }

                    rightItemModularFireArmBaseComponent1 = rightItem.GetComponent("ItemFirearmBase");
                    if (rightItemModularFireArmBaseComponent1 == null)
                        rightItemModularFireArmBaseComponent2 = rightItem.GetComponent("ItemMagicFirearm"); //If first is null
                    else
                        rightItemModularFireArmBaseComponent2 = null;
                }

                if (newLeftHand != oldLeftHand)
                {
                    leftItem = newLeftHand;

                    if (leftItem != null)
                    {
                        ParticleSystem temp_leftItemShootVFX = null;

                        if (leftItem.customReferences.Find((Predicate<CustomReference>)(cr => cr.name == "FireEffect")) != null && leftItem.GetCustomReference("FireEffect")?.GetComponent<ParticleSystem>() != null)
                        {
                            temp_leftItemShootVFX = leftItem.GetCustomReference("FireEffect").GetComponent<ParticleSystem>();
                        }
                        else if (leftItem.customReferences.Find((Predicate<CustomReference>)(cr => cr.name == "bulletShotVFX")) != null && leftItem.GetCustomReference("bulletShotVFX")?.GetComponent<ParticleSystem>() != null)
                        {
                            temp_leftItemShootVFX = leftItem.GetCustomReference("bulletShotVFX").GetComponent<ParticleSystem>();
                        }
                        else
                        {
                            foreach (var vfx in VFXList)
                            {
                                if (leftItem.transform?.Find(vfx)?.gameObject?.GetComponentInChildren<ParticleSystem>() != null)
                                {
                                    temp_leftItemShootVFX = leftItem.transform.Find(vfx).gameObject.GetComponentInChildren<ParticleSystem>();
                                    if (temp_leftItemShootVFX != null)
                                        break;
                                }
                                else if (leftItem.customReferences.Find((Predicate<CustomReference>)(cr => cr.name == vfx)) != null && leftItem.GetCustomReference(vfx)?.GetComponent<ParticleSystem>() != null)
                                {
                                    temp_leftItemShootVFX = (ParticleSystem)((Component)leftItem.GetCustomReference(vfx)).GetComponent<ParticleSystem>();
                                    if (temp_leftItemShootVFX != null)
                                        break;
                                }
                            }
                        }

                        leftItemShootVFX = temp_leftItemShootVFX;

                        if (leftItem.customReferences.Find((Predicate<CustomReference>)(cr => cr.name == "AltFireEffect")) != null && leftItem.GetCustomReference("AltFireEffect")?.GetComponent<ParticleSystem>() != null)
                        {
                            leftItemShoot2VFX = leftItem.GetCustomReference("AltFireEffect").GetComponent<ParticleSystem>();
                        }
                        else
                        {
                            leftItemShoot2VFX = null;
                        }

                        if (leftItem.customReferences.Find((Predicate<CustomReference>)(cr => cr.name == "bulletShotSFX")) != null && leftItem.GetCustomReference("bulletShotSFX")?.GetComponent<AudioSource>() != null)
                        {
                            leftItemShootSFX = leftItem.GetCustomReference("bulletShotSFX").GetComponent<AudioSource>();
                        }
                        else
                        {
                            foreach (var sfx in SFXList)
                            {
                                if (leftItem.transform?.Find(sfx)?.gameObject?.GetComponentInChildren<AudioSource>() != null)
                                {
                                    leftItemShootSFX = leftItem.transform.Find(sfx).gameObject.GetComponentInChildren<AudioSource>();
                                    if (leftItemShootSFX != null)
                                        break;
                                }
                                else if (leftItem.customReferences.Find((Predicate<CustomReference>)(cr => cr.name == sfx)) != null && leftItem.GetCustomReference(sfx)?.GetComponent<AudioSource>() != null)
                                {
                                    leftItemShootSFX = (AudioSource)((Component)leftItem.GetCustomReference(sfx)).GetComponent<AudioSource>();
                                    if (leftItemShootSFX != null)
                                        break;
                                }
                            }
                        }

                        if (leftItem.transform?.Find("ChargeReadySounds")?.gameObject?.GetComponentInChildren<AudioSource>() != null)
                        {
                            leftItemChargeReadySFX = leftItem.transform.Find("ChargeReadySounds").gameObject.GetComponentInChildren<AudioSource>();
                        }
                        else if (leftItem.customReferences.Find((Predicate<CustomReference>)(cr => cr.name == "ChargeReadySounds")) != null && leftItem.GetCustomReference("ChargeReadySounds")?.GetComponent<AudioSource>() != null)
                        {
                            leftItemChargeReadySFX = (AudioSource)((Component)leftItem.GetCustomReference("ChargeReadySounds")).GetComponent<AudioSource>();
                        }

                        if (leftItem.transform?.Find("ChargeStartSounds")?.gameObject?.GetComponentInChildren<AudioSource>() != null)
                        {
                            leftItemChargeSFX = leftItem.transform.Find("ChargeStartSounds").gameObject.GetComponentInChildren<AudioSource>();
                        }
                        else if (leftItem.customReferences.Find((Predicate<CustomReference>)(cr => cr.name == "ChargeStartSounds")) != null && leftItem.GetCustomReference("ChargeStartSounds")?.GetComponent<AudioSource>() != null)
                        {
                            leftItemChargeSFX = (AudioSource)((Component)leftItem.GetCustomReference("ChargeStartSounds")).GetComponent<AudioSource>();
                        }
                        else if (leftItem.transform?.Find("ChargeSounds")?.gameObject?.GetComponentInChildren<AudioSource>() != null)
                        {
                            leftItemChargeSFX = leftItem.transform.Find("ChargeSounds").gameObject.GetComponentInChildren<AudioSource>();
                        }
                        else if (leftItem.customReferences.Find((Predicate<CustomReference>)(cr => cr.name == "ChargeSounds")) != null && leftItem.GetCustomReference("ChargeSounds")?.GetComponent<AudioSource>() != null)
                        {
                            leftItemChargeSFX = (AudioSource)((Component)leftItem.GetCustomReference("ChargeSounds")).GetComponent<AudioSource>();
                        }

                        leftItemBlasterComponent = leftItem.GetComponent("ItemBlaster");
                        if (leftItemBlasterComponent != null)
                        {
                            if (leftItemChargeReadySFX == null)
                            {
                                leftItemChargeReadySFX = Utility.GetValuePrivateAudioSource(leftItemBlasterComponent, "chargeReadySound");
                            }
                            if (leftItemChargeReadySFX == null)
                            {
                                leftItemChargeReadySFX = Utility.GetValuePrivateAudioSource(leftItemBlasterComponent, "chargeReadySound2");
                            }
                            if (leftItemChargeSFX == null)
                            {
                                leftItemChargeSFX = Utility.GetValuePrivateAudioSource(leftItemBlasterComponent, "chargeStartSound");
                            }
                            if (leftItemChargeSFX == null)
                            {
                                leftItemChargeSFX = Utility.GetValuePrivateAudioSource(leftItemBlasterComponent, "chargeStartSound2");
                            }
                            if (leftItemChargeSFX == null)
                            {
                                leftItemChargeSFX = Utility.GetValuePrivateAudioSource(leftItemBlasterComponent, "chargeSound");
                            }
                            if (leftItemChargeSFX == null)
                            {
                                leftItemChargeSFX = Utility.GetValuePrivateAudioSource(leftItemBlasterComponent, "chargeSound2");
                            }
                        }

                        leftItemModularFireArmBaseComponent1 = leftItem.GetComponent("ItemFirearmBase");
                        if (leftItemModularFireArmBaseComponent1 == null)
                            leftItemModularFireArmBaseComponent2 = leftItem.GetComponent("ItemMagicFirearm"); //If first is null
                        else
                            leftItemModularFireArmBaseComponent2 = null;
                    }
                }
            }
        }


        private void OnTelekinesisUnTargetEvent(SpellCaster spellCaster, SpellTelekinesis spellTelekinesis, Side side, Handle handle)
        {
            if (side == Side.Left)
            {
                TelekinesisActiveLeft = false;
                TelekinesisPullLeft = false;
                TelekinesisRepelLeft = false;
                TelekinesisSpinLeft = false;
            }
            else
            {
                TelekinesisActiveRight = false;
                TelekinesisPullRight = false;
                TelekinesisRepelRight = false;
                TelekinesisSpinRight = false;
            }
        }

        private void OnTelekinesisGrabEvent(SpellCaster spellCaster, SpellTelekinesis spellTelekinesis, Side side, Handle handle)
        {
            if (handle != null)
            {
                if (side == Side.Left)
                {
                    if (!TelekinesisActiveLeft)
                    {
                        TelekinesisActiveLeft = true;
                        Thread thread = new Thread(() => TelekinesisActivateFunc(true));
                        thread.Start();
                        LOG("Player is activating with telekinesis left hand.");
                    }
                }
                else
                {
                    if (!TelekinesisActiveRight)
                    {
                        TelekinesisActiveRight = true;
                        Thread thread = new Thread(() => TelekinesisActivateFunc(false));
                        thread.Start();
                        LOG("Player is activating with telekinesis right hand.");
                    }
                }
            }
            else
            {
                if (side == Side.Left)
                {
                    if (TelekinesisActiveLeft)
                    {
                        TelekinesisActiveLeft = false;
                        LOG("Player stops activating telekinesis left hand.");
                    }
                }
                else
                {
                    if (TelekinesisActiveRight)
                    {
                        TelekinesisActiveRight = false;
                        LOG("Player stops activating telekinesis right hand.");
                    }
                }
            }

            //tactsuitVr?.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.PlayerTelekinesisCatchRight, true, spellCaster.telekinesis.pullSpeed / spellCaster.telekinesis.pullAndRepelMaxSpeed, TactsuitVR.FeedbackType.NoFeedback, side == Side.Left);
        }
        private void OnTelekinesisUngrabEvent(SpellCaster spellCaster, SpellTelekinesis spellTelekinesis, Side side, Handle handle, bool thrown)
        {
            if (side == Side.Left)
            {
                if (TelekinesisActiveLeft)
                {
                    TelekinesisActiveLeft = false;
                    LOG("Player stops activating telekinesis left hand.");
                }
            }
            else
            {
                if (TelekinesisActiveRight)
                {
                    TelekinesisActiveRight = false;
                    LOG("Player stops activating telekinesis right hand.");
                }
            }
        }

        private void OnTelekinesisRepelEvent(SpellCaster spellCaster, SpellTelekinesis spellTelekinesis, Side side, Handle handle, EventTime eventTime)
        {
            if (eventTime == EventTime.OnStart)
            {
                if (side == Side.Left)
                {
                    if (!TelekinesisRepelLeft)
                    {
                        TelekinesisRepelLeft = true;
                        Thread thread = new Thread(() => TelekinesisFunc(false, true));
                        thread.Start();
                        LOG("Player is repelling with telekinesis left hand.");
                    }
                }
                else
                {
                    if (!TelekinesisRepelRight)
                    {
                        TelekinesisRepelRight = true;
                        Thread thread = new Thread(() => TelekinesisFunc(false, false));
                        thread.Start();
                        LOG("Player is repelling with telekinesis right hand.");
                    }
                }
            }
            else
            {
                if (side == Side.Left)
                {
                    if (TelekinesisRepelLeft)
                    {
                        TelekinesisRepelLeft = false;
                        LOG("Player stops repelling with telekinesis left hand.");
                    }
                }
                else
                {
                    if (TelekinesisRepelRight)
                    {
                        TelekinesisRepelRight = false;
                        LOG("Player stops repelling with telekinesis right hand.");
                    }
                }
            }
        }

        private void OnTelekinesisPullEventFunc(SpellCaster spellCaster, SpellTelekinesis spellTelekinesis, Side side, Handle handle, EventTime eventTime)
        {
            if (eventTime == EventTime.OnStart)
            {
                if (side == Side.Left)
                {
                    if (!TelekinesisPullLeft)
                    {
                        TelekinesisPullLeft = true;
                        Thread thread = new Thread(() => TelekinesisFunc(true, true));
                        thread.Start();
                        LOG("Player is pulling with telekinesis left hand.");
                    }
                }
                else
                {
                    if (!TelekinesisPullRight)
                    {
                        TelekinesisPullRight = true;
                        Thread thread = new Thread(() => TelekinesisFunc(true, false));
                        thread.Start();
                        LOG("Player is pulling with telekinesis right hand.");
                    }
                }
            }
            else
            {
                if (side == Side.Left)
                {
                    if (TelekinesisPullLeft)
                    {
                        TelekinesisPullLeft = false;
                        LOG("Player stops pulling with telekinesis left hand.");
                    }
                }
                else
                {
                    if (TelekinesisPullRight)
                    {
                        TelekinesisPullRight = false;
                        LOG("Player stops pulling with telekinesis right hand.");
                    }
                }
            }
        }

        private void CheckPlayerSpawn()
        {
            Thread.Sleep(1000);
            while (Player.local == null || Player.local.creature == null || Player.local.locomotion == null || Player.local.creature.initialized == false || Player.local.creature.ragdoll == null)
            {
                Thread.Sleep(1000);
            }

            LOG("Player spawned.");

            Player.local.locomotion.OnGroundEvent -= OnGroundFunc;
            Player.local.locomotion.OnGroundEvent += OnGroundFunc;
            LOG("OnGround function added.");

            Player.local.creature.OnDamageEvent -= OnDamageFunc;
            Player.local.creature.OnDamageEvent += OnDamageFunc;
            Player.local.creature.OnKillEvent -= OnKillFunc;
            Player.local.creature.OnKillEvent += OnKillFunc;

            //Player.local.creature.equipment.OnHeldWeaponHitEvent
            //Player.local.creature.equipment.OnHolsterInteractedEvent
            Player.local.creature.equipment.OnArmourEquippedEvent += new Equipment.OnArmourEquipped(ArmorEquippedFunc);
            Player.local.creature.equipment.OnArmourUnEquippedEvent += new Equipment.OnArmourUnEquipped(ArmorUnequippedFunc);

            if (Player.local.GetHand(Side.Left)?.ragdollHand != null)
            {
                Player.local.GetHand(Side.Left).ragdollHand.OnGrabEvent -= new RagdollHand.GrabEvent(GrabFunc);
                Player.local.GetHand(Side.Left).ragdollHand.OnGrabEvent += new RagdollHand.GrabEvent(GrabFunc);
            }
            if (Player.local.GetHand(Side.Right)?.ragdollHand != null)
            {
                Player.local.GetHand(Side.Right).ragdollHand.OnGrabEvent -= new RagdollHand.GrabEvent(GrabFunc);
                Player.local.GetHand(Side.Right).ragdollHand.OnGrabEvent += new RagdollHand.GrabEvent(GrabFunc);
            }
            if (Player.local.GetHand(Side.Left)?.ragdollHand != null)
            {
                Player.local.GetHand(Side.Left).ragdollHand.OnUnGrabEvent -= new RagdollHand.UnGrabEvent(UnGrabFunc);
                Player.local.GetHand(Side.Left).ragdollHand.OnUnGrabEvent += new RagdollHand.UnGrabEvent(UnGrabFunc);
            }
            if (Player.local.GetHand(Side.Right)?.ragdollHand != null)
            {
                Player.local.GetHand(Side.Right).ragdollHand.OnUnGrabEvent -= new RagdollHand.UnGrabEvent(UnGrabFunc);
                Player.local.GetHand(Side.Right).ragdollHand.OnUnGrabEvent += new RagdollHand.UnGrabEvent(UnGrabFunc);
            }

            List<CollisionHandler> playerCollisionHandlersList = new List<CollisionHandler>((IEnumerable<CollisionHandler>)Player.local.GetComponentsInChildren<CollisionHandler>());

            foreach (var collisionHandler in playerCollisionHandlersList)
            {
                if (collisionHandler != null)
                {
                    LOG("Player has this collisionhandler: " + collisionHandler.name + " Item: " + (collisionHandler.item != null ? collisionHandler.item.name : ""));
                    //collisionHandler.OnCollisionStartEvent += BodyPartCollisionStartFunc;
                }
            }

            if (Player.local.handLeft?.ragdollHand?.collisionHandler != null)
            {
                Player.local.handLeft.ragdollHand.collisionHandler.OnCollisionStartEvent -= LeftHandCollisionStartFunc;
                Player.local.handLeft.ragdollHand.collisionHandler.OnCollisionStartEvent += LeftHandCollisionStartFunc;
                Player.local.handLeft.ragdollHand.collisionHandler.OnCollisionStopEvent -= BodyPartCollisionStopFunc;
                Player.local.handLeft.ragdollHand.collisionHandler.OnCollisionStopEvent += BodyPartCollisionStopFunc;
                LOG("Adding collision event to: Left Hand");
            }

            if (Player.local.handLeft?.ragdollHand.collisionHandler != null)
            {
                Player.local.handLeft.ragdollHand.collisionHandler.OnCollisionStartEvent -= LeftHandCollisionStartFunc;
                Player.local.handLeft.ragdollHand.collisionHandler.OnCollisionStartEvent += LeftHandCollisionStartFunc;
                Player.local.handLeft.ragdollHand.collisionHandler.OnCollisionStopEvent -= BodyPartCollisionStopFunc;
                Player.local.handLeft.ragdollHand.collisionHandler.OnCollisionStopEvent += BodyPartCollisionStopFunc;
                LOG("Adding collision event to: Left Hand");
            }

            if (Player.local.handRight?.ragdollHand.collisionHandler != null)
            {
                Player.local.handRight.ragdollHand.collisionHandler.OnCollisionStartEvent -= RightHandCollisionStartFunc;
                Player.local.handRight.ragdollHand.collisionHandler.OnCollisionStartEvent += RightHandCollisionStartFunc;
                Player.local.handRight.ragdollHand.collisionHandler.OnCollisionStopEvent -= BodyPartCollisionStopFunc;
                Player.local.handRight.ragdollHand.collisionHandler.OnCollisionStopEvent += BodyPartCollisionStopFunc;
                LOG("Adding collision event to: Right Hand");
            }

            if (Player.local.footLeft?.ragdollFoot?.collisionHandler != null)
            {
                Player.local.footLeft.ragdollFoot.collisionHandler.OnCollisionStartEvent -= LeftFootCollisionStartFunc;
                Player.local.footLeft.ragdollFoot.collisionHandler.OnCollisionStartEvent += LeftFootCollisionStartFunc;
                LOG("Adding collision event to: Left Foot");
            }

            if (Player.local.footRight?.ragdollFoot?.collisionHandler != null)
            {
                Player.local.footRight.ragdollFoot.collisionHandler.OnCollisionStartEvent -= RightFootCollisionStartFunc;
                Player.local.footRight.ragdollFoot.collisionHandler.OnCollisionStartEvent += RightFootCollisionStartFunc;
                LOG("Adding collision event to: Right Foot");
            }

            foreach (var part in Player.local.creature.ragdoll.parts)
            {
                if (part.type == RagdollPart.Type.Torso)
                {
                    LOG("Adding collision event to: " + part.collisionHandler.name);
                    part.collisionHandler.OnCollisionStartEvent -= TorsoCollisionFunc;
                    part.collisionHandler.OnCollisionStartEvent += TorsoCollisionFunc;
                }
                else if(part.collisionHandler.name == "LeftForeArm")
                {
                    part.collisionHandler.OnCollisionStartEvent -= LeftHandCollisionStartFunc;
                    part.collisionHandler.OnCollisionStartEvent += LeftHandCollisionStartFunc;
                    LOG("Adding collision event to: " + part.collisionHandler.name);
                }
                else if (part.collisionHandler.name == "LeftArm")
                {
                    part.collisionHandler.OnCollisionStartEvent -= LeftHandCollisionStartFunc;
                    part.collisionHandler.OnCollisionStartEvent += LeftHandCollisionStartFunc;
                    LOG("Adding collision event to: " + part.collisionHandler.name);
                }
                else if (part.collisionHandler.name == "RightForeArm")
                {
                    part.collisionHandler.OnCollisionStartEvent -= RightHandCollisionStartFunc;
                    part.collisionHandler.OnCollisionStartEvent += RightHandCollisionStartFunc;
                    LOG("Adding collision event to: " + part.collisionHandler.name);
                }
                else if (part.collisionHandler.name == "RightArm")
                {
                    part.collisionHandler.OnCollisionStartEvent -= RightHandCollisionStartFunc;
                    part.collisionHandler.OnCollisionStartEvent += RightHandCollisionStartFunc;
                    LOG("Adding collision event to: " + part.collisionHandler.name);
                }
            }

            LiquidReceiver lr = Player.local.creature.GetComponentInChildren<LiquidReceiver>();
            if (lr != null)
            {
                lr.OnReceptionEvent -= LrOnOnReceptionEvent;
                lr.OnReceptionEvent += LrOnOnReceptionEvent;
                LOG("Liquid reception function added.");
            }
            else
            {
                LOG("Can't find Liquid Receiver on player.");
            }

            Player.local.creature.equipment.OnHeldItemsChangeEvent -= OnHeldItemsChangeEventFunc;
            Player.local.creature.equipment.OnHeldItemsChangeEvent += OnHeldItemsChangeEventFunc;
        }

        //[HarmonyPatch("OnCollisionEnter")]
        //[HarmonyPatch(typeof(CollisionHandler))]
        //private static class CollisionHandlerOnCollisionEnterPatch
        //{
        //    [HarmonyPostfix]
        //    private static void Postfix(CollisionHandler __instance, UnityEngine.Collision collision)
        //    {
        //        if (__instance != null && Player.local?.creature !=null && __instance.active && __instance.isActive && __instance.ragdollPart?.ragdoll?.creature != null && __instance.ragdollPart.ragdoll.creature == Player.local.creature)
        //        {
        //            if (__instance.name == "Spine" || __instance.name == "Spine1" || __instance.name == "Hips")
        //            {
        //                if (collision!=null && collision.contactCount > 0)
        //                {
        //                    float impulse = (collision.impulse.magnitude / Time.fixedDeltaTime) / 1000.0f;

        //                    if (impulse > 0.01f)
        //                    {
        //                        ContactPoint cp = collision.GetContact(0);
        //                        if (cp.otherCollider.gameObject != null && cp.otherCollider.gameObject.isStatic)
        //                        {
        //                            float hitAngle = Utility.GetAngleForPosition(cp.point);

        //                            float locationHeight = 0.0f;

        //                            if (__instance.name == "Spine" || __instance.name == "Spine1")
        //                            {
        //                                locationHeight = (((float)(RandomNumber.Between(0, 5))) / 10.0f) - 0.20f;
        //                            }
        //                            else if (__instance.name == "Hips")
        //                            {
        //                                locationHeight = -0.40f;
        //                            }

        //                            tactsuitVr.ProvideHapticFeedback(hitAngle, locationHeight, TactsuitVR.FeedbackType.DamageVestBluntStoneLarge, false, impulse*0.05f, TactsuitVR.FeedbackType.NoFeedback, false);

        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}

        [HarmonyPatch("PushPlayer")]
        [HarmonyPatch(typeof(SpellCastGravity))]
        private static class SpellCastGravityPushPlayerPatch
        {
            [HarmonyPostfix]
            private static void Postfix(SpellCastGravity __instance, RagdollPart ragdollPart, UnityEngine.Vector3 velocity)
            {
                Vector3 contactPoint = Player.local.locomotion.transform.position - velocity;
                float hitAngle = Utility.GetAngleForPosition(contactPoint);

                float intensity = Player.local.locomotion.velocity.magnitude / 5f;
                tactsuitVr.ProvideHapticFeedback(hitAngle, 0, TactsuitVR.FeedbackType.DamageVestGravity, false, intensity, TactsuitVR.FeedbackType.NoFeedback, false);
                if (GravityEffectOnHead)
                {
                    tactsuitVr.ProvideHapticFeedback(hitAngle, 0, TactsuitVR.FeedbackType.DamageHeadGravity, false, intensity, TactsuitVR.FeedbackType.NoFeedback, false);
                }
                if (GravityEffectOnArms)
                {
                    tactsuitVr.ProvideHapticFeedback(hitAngle, 0, TactsuitVR.FeedbackType.DamageRightArmGravity, false, intensity, TactsuitVR.FeedbackType.NoFeedback, true);
                    tactsuitVr.ProvideHapticFeedback(hitAngle, 0, TactsuitVR.FeedbackType.DamageRightArmGravity, false, intensity, TactsuitVR.FeedbackType.NoFeedback, false);
                }
            }
        }
     

        private static void RightProjectileRemovedFunc(Item item)
        {
            if (!gamePaused && !TimeManager.timeStopped)
            {
                tactsuitVr?.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.UnholsterArrowRightShoulder, false, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);
            }
        }

        private static void RightProjectileAddedFunc(Item item)
        {
            if (!gamePaused && !TimeManager.timeStopped)
            {
                tactsuitVr?.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.HolsterArrowRightShoulder, false, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);
            }
        }

        private static void LeftProjectileRemovedFunc(Item item)
        {
            if (!gamePaused && !TimeManager.timeStopped && Player.local != null)
            {
                tactsuitVr?.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.UnholsterArrowLeftShoulder, false, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);
            }
        }

        private static void LeftProjectileAddedFunc(Item item)
        {
            if (!gamePaused && !TimeManager.timeStopped && Player.local != null)
            {
                tactsuitVr?.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.HolsterArrowLeftShoulder, false, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);
            }
        }

        [HarmonyPatch("UnSnap")]
        [HarmonyPatch(typeof(Holder))]
        private static class HolderUnSnapPatch
        {
            [HarmonyPostfix]
            private static void Postfix(Holder __instance, Item item, bool silent = false)
            {
                if (!gamePaused && !TimeManager.timeStopped && item != null && __instance != null && Player.local.creature != null && __instance.creature == Player.local.creature)
                {
                    if (!silent)
                    {
                        bool arrow = (item.data?.moduleAI != null && item.data.moduleAI.primaryClass == ItemModuleAI.WeaponClass.Arrow);

                        if (__instance.drawSlot == Holder.DrawSlot.BackRight)
                        {
                            tactsuitVr?.ProvideHapticFeedback(0, 0, arrow ? TactsuitVR.FeedbackType.UnholsterArrowRightShoulder : TactsuitVR.FeedbackType.UnholsterRightShoulder, false, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);
                        }
                        else if (__instance.drawSlot == Holder.DrawSlot.BackLeft)
                        {
                            tactsuitVr?.ProvideHapticFeedback(0, 0, arrow ? TactsuitVR.FeedbackType.UnholsterArrowLeftShoulder : TactsuitVR.FeedbackType.UnholsterLeftShoulder, false, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);
                        }
                    }

                    if (item.data.type == ItemData.Type.Quiver)
                    {
                        Holder[] otherholders = item.GetComponentsInChildren<Holder>();
                        foreach (Holder otherholder in otherholders)
                        {
                            if (otherholder != null)
                            {
                                otherholder.Snapped -= new Holder.HolderDelegate(LeftProjectileAddedFunc);
                                otherholder.UnSnapped -= new Holder.HolderDelegate(LeftProjectileRemovedFunc);
                            }
                        }
                    }
                }
            }
        }

        [HarmonyPatch("Snap")]
        [HarmonyPatch(typeof(Holder))]
        private static class HolderSnapPatch
        {
            [HarmonyPostfix]
            private static void Postfix(Holder __instance, Item item, bool silent = false)
            {
                if (!gamePaused && !TimeManager.timeStopped && item != null && __instance != null && Player.local.creature!=null && __instance.creature == Player.local.creature)
                {
                    if (!silent)
                    {
                        bool arrow = (item.data?.moduleAI != null && item.data.moduleAI.primaryClass == ItemModuleAI.WeaponClass.Arrow);

                        if (__instance.drawSlot == Holder.DrawSlot.BackRight)
                        {
                            tactsuitVr?.ProvideHapticFeedback(0, 0, arrow ? TactsuitVR.FeedbackType.HolsterArrowRightShoulder : TactsuitVR.FeedbackType.HolsterRightShoulder, false, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);
                        }
                        else if (__instance.drawSlot == Holder.DrawSlot.BackLeft)
                        {
                            tactsuitVr?.ProvideHapticFeedback(0, 0, arrow ? TactsuitVR.FeedbackType.HolsterArrowLeftShoulder : TactsuitVR.FeedbackType.HolsterLeftShoulder, false, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);
                        }
                    }

                    if (item.data.type == ItemData.Type.Quiver)
                    {
                        Holder[] otherholders = item.GetComponentsInChildren<Holder>();
                        foreach (Holder otherholder in otherholders)
                        {
                            if (otherholder != null)
                            {
                                otherholder.Snapped += new Holder.HolderDelegate(RightProjectileAddedFunc);
                                otherholder.UnSnapped += new Holder.HolderDelegate(RightProjectileRemovedFunc);
                            }
                        }
                    }
                }
            }
        }

        [HarmonyPatch("Explosion")]
        [HarmonyPatch(typeof(SpellMergeFire))]
        private static class SpellMergeFireExplosionPatch
        {
            [HarmonyPostfix]
            private static void Postfix(SpellMergeFire __instance, UnityEngine.Vector3 position, float radius)
            {
                if (!gamePaused && !TimeManager.timeStopped)
                {
                    float dist = Vector3.Distance(Player.local.locomotion.transform.position, position);
                    if (dist < radius * 1.5f)
                    {
                        float hitAngle = Utility.GetAngleForPosition(position);

                        float intensity = 1.0f;
                        if (dist < radius)
                            intensity = 1.0f;
                        else if (dist > radius)
                        {
                            intensity = 1.0f - (radius * 0.5f) * (dist - radius);
                        }

                        tactsuitVr.ProvideHapticFeedback(hitAngle, 0, TactsuitVR.FeedbackType.Explosion, false, intensity, TactsuitVR.FeedbackType.NoFeedback, false);
                    }
                }
            }
        }

        //[HarmonyPatch("FixedUpdate")]
        //[HarmonyPatch(typeof(RepulsionForce))]
        //private static class RepulsionForcePatch
        //{
        //    [HarmonyPostfix]
        //    private static void Postfix(RepulsionForce __instance)
        //    {
        //        if (!gamePaused && !TimeManager.timeStopped)
        //        {
        //            float dist = Vector3.Distance(Player.local.locomotion.transform.position, __instance.transform.position);
        //            if (dist < __instance.radius * 1.5f)
        //            {
        //                float hitAngle = Utility.GetAngleForPosition(__instance.transform.position);

        //                float intensity = 1.0f;
        //                if (dist < __instance.radius)
        //                    intensity = 1.0f;
        //                else if (dist > __instance.radius)
        //                {
        //                    intensity = 1.0f - (__instance.radius * 0.5f) * (dist - __instance.radius);
        //                }

        //                tactsuitVr.ProvideHapticFeedback(hitAngle, 0, TactsuitVR.FeedbackType.Explosion, false, intensity, TactsuitVR.FeedbackType.NoFeedback, false);
        //            }
        //        }
        //    }
        //}

        //[HarmonyPatch("ShockWaveCoroutine")]
        //[HarmonyPatch(typeof(SpellCastGravity))]
        //private static class SpellCastGravityShockWaveCoroutinePatch
        //{
        //    [HarmonyPostfix]
        //    private static void Postfix(SpellCastGravity __instance, UnityEngine.Vector3 contactPoint, UnityEngine.Vector3 impactVelocity)
        //    {
        //        if (!gamePaused && !TimeManager.timeStopped)
        //        {
        //            float radius = 10.0f;

        //            float dist = Vector3.Distance(Player.local.locomotion.transform.position, contactPoint);
        //            if (dist < radius * 1.5f)
        //            {
        //                float hitAngle = Utility.GetAngleForPosition(contactPoint);

        //                float intensity = 1.0f;
        //                if (dist < radius)
        //                    intensity = 1.0f;
        //                else if (dist > radius)
        //                {
        //                    intensity = 1.0f - (radius * 0.5f) * (dist - radius);
        //                }
        //                tactsuitVr.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.DefaultDamage, false, intensity, TactsuitVR.FeedbackType.NoFeedback, false);
        //            }
        //        }
        //    }
        //}

        //[HarmonyPatch("RadialZapCoroutine")]
        //[HarmonyPatch(typeof(SpellCastLightning))]
        //private static class SpellCastLightningRadialZapCoroutinePatch
        //{
        //    [HarmonyPostfix]
        //    private static void Postfix(SpellCastLightning __instance, UnityEngine.Vector3 position, float radius, float duration, System.Action<ColliderGroup> callback = null)
        //    {
        //        if (!gamePaused && !TimeManager.timeStopped)
        //        {
        //            float dist = Vector3.Distance(Player.local.locomotion.transform.position, position);
        //            if (dist < radius * 1.5f)
        //            {
        //                float hitAngle = Utility.GetAngleForPosition(position);

        //                float intensity = 1.0f;
        //                if (dist < radius)
        //                    intensity = 1.0f;
        //                else if (dist > radius)
        //                {
        //                    intensity = 1.0f - (radius * 0.5f) * (dist - radius);
        //                }
        //                tactsuitVr.ProvideHapticFeedback(hitAngle, 0, TactsuitVR.FeedbackType.DamageVestLightning, false, intensity, TactsuitVR.FeedbackType.NoFeedback, false, duration);
        //                tactsuitVr.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.DefaultDamage, false, intensity, TactsuitVR.FeedbackType.NoFeedback, false);
        //            }
        //        }
        //    }
        //}

        [HarmonyPatch("OnCrystalSlam")]
        [HarmonyPatch(typeof(SpellCastCharge))]
        private static class SpellCastChargeOnCrystalSlamPatch
        {
            [HarmonyPostfix]
            private static void Postfix(SpellCastCharge __instance, CollisionInstance collisionInstance)
            {
                if (!gamePaused && !TimeManager.timeStopped)
                {
                    if (__instance is SpellCastProjectile)
                        return;

                    Vector3 position = collisionInstance.contactPoint;
                    float radius = 10.0f;
                    float duration = 1.0f;

                    if (__instance is SpellCastLightning)
                    {
                        radius = ((SpellCastLightning)__instance).staffSlamRadius;
                        duration = ((SpellCastLightning)__instance).staffSlamExpandDuration;
                    }
                    else if(__instance is SpellCastGravity)
                    {
                        radius = ((SpellCastGravity)__instance).staffSlamMaxRadius;
                    }

                    float dist = Vector3.Distance(Player.local.locomotion.transform.position, position);
                    if (dist < radius * 1.5f)
                    {
                        float hitAngle = Utility.GetAngleForPosition(position);

                        float intensity = 1.0f;
                        if (dist < radius)
                            intensity = 1.0f;
                        else if (dist > radius)
                        {
                            intensity = 1.0f - (radius * 0.5f) * (dist - radius);
                        }
                        if (__instance is SpellCastLightning)
                        {
                            tactsuitVr.ProvideHapticFeedback(hitAngle, 0, TactsuitVR.FeedbackType.DamageVestLightning, false, intensity, TactsuitVR.FeedbackType.NoFeedback, false, duration);
                        }
                        tactsuitVr.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.DefaultDamage, false, intensity, TactsuitVR.FeedbackType.NoFeedback, false, duration);
                    }
                }
            }
        }

        [HarmonyPatch("RefreshHealth")]
        [HarmonyPatch(typeof(CameraEffects))]
        private static class CameraEffectsRefreshHealthPatch
        {
            private static void HeartBeatFunc()
            {
                while (!TimeManager.timeStopped && !gamePaused && Heartbeating)
                {
                    tactsuitVr.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.HeartBeat, false, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);

                    Thread.Sleep(SleepDurationHeartBeat);
                }
            }

            private static void HeartBeatFastFunc()
            {
                while (!TimeManager.timeStopped && !gamePaused && HeartbeatingFast)
                {
                    tactsuitVr.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.HeartBeatFast, false, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);

                    Thread.Sleep(SleepDurationHeartBeatFast);
                }
            }

            [HarmonyPostfix]
            private static void Postfix(CameraEffects __instance)
            {
                if (Player.local?.creature)
                {
                    if (!gamePaused && Player.local.creature.state != Creature.State.Dead && !Player.local.creature.isKilled && Player.local.creature.currentHealth <= Player.local.creature.maxHealth * 0.1f && Player.local.creature.currentHealth > 0.01f)
                    {
                        Heartbeating = false;
                        if (!HeartbeatingFast)
                        {
                            HeartbeatingFast = true;
                            Thread thread = new Thread(HeartBeatFastFunc);
                            thread.Start();
                        }
                    }
                    else if (!gamePaused && Player.local.creature.state != Creature.State.Dead && !Player.local.creature.isKilled && Player.local.creature.currentHealth <= Player.local.creature.maxHealth * 0.2f && Player.local.creature.currentHealth > 0.01f)
                    {
                        HeartbeatingFast = false;
                        if (!Heartbeating)
                        {
                            Heartbeating = true;
                            Thread thread = new Thread(HeartBeatFunc);
                            thread.Start();
                        }
                    }
                    else
                    {
                        HeartbeatingFast = false;
                        Heartbeating = false;
                    }
                }
            }
        }

        [HarmonyPatch("AddItemToInventory")]
        [HarmonyPatch(typeof(InventoryChestHolder))]
        private static class InventoryChestHolderAddItemPatch
        {
            [HarmonyPostfix]
            private static void Postfix(InventoryChestHolder __instance, Item item)
            {
                if (item != null && __instance != null && __instance.IsPlayerCreature)
                {
                    tactsuitVr.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.AddToChestInventory, false, 1.00f, TactsuitVR.FeedbackType.NoFeedback, false);
                }
            }
        }

        [HarmonyPatch("TryTouchAction")]
        [HarmonyPatch(typeof(InventoryChestHolder))]
        private static class InventoryChestHolderGrab
        {
            [HarmonyPostfix]
            private static void Postfix(InventoryChestHolder __instance, RagdollHand ragdollHand, Interactable.Action action)
            {
                if (__instance != null && (action == Interactable.Action.Grab))
                {
                    tactsuitVr.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.OpenChestInventory, false, 1.00f, TactsuitVR.FeedbackType.NoFeedback, false);
                }
            }
        }

        [HarmonyPatch("PlayHaptic")]
        [HarmonyPatch(typeof(BhapticsHandler))]
        private static class bHapticsNativePlayHapticPatch
        {
            [HarmonyPrefix]
            private static bool Prefix(BhapticsHandler __instance, float locationAngle, float locationHeight, BhapticsHandler.FeedbackType effect, bool waitToPlay = false, float intensity = 1, BhapticsHandler.FeedbackType secondEffect = BhapticsHandler.FeedbackType.NoFeedback, bool reflected = false, float duration = 1)
            {
                return !disableNativeBHaptics;
            }
        }

        


        private TactsuitVR.FeedbackType GetPlayerPunchFeedback(string material)
        {
            if (!material.IsNullOrEmpty())
            {
                if (material.Contains("Wood"))
                    return TactsuitVR.FeedbackType.PlayerPunchWoodRight;
                else if (material.Contains("Stone") || material.Contains("Glass"))
                    return TactsuitVR.FeedbackType.PlayerPunchStoneRight;
                else if (material.Contains("Metal"))
                    return TactsuitVR.FeedbackType.PlayerPunchMetalRight;
                else if (material.Contains("Fabric"))
                    return TactsuitVR.FeedbackType.PlayerPunchFabricRight;
                else if (material.Contains("Flesh") || material.Contains("Sand"))
                    return TactsuitVR.FeedbackType.PlayerPunchFleshRight;
                else
                    return TactsuitVR.FeedbackType.PlayerPunchOtherRight;
            }
            else
            {
                return TactsuitVR.FeedbackType.PlayerPunchOtherRight;
            }
        }

        private TactsuitVR.FeedbackType GetPlayerKickFeedback(string material)
        {
            if (!material.IsNullOrEmpty())
            {
                if (material.Contains("Wood"))
                    return TactsuitVR.FeedbackType.PlayerKickWoodRight;
                else if (material.Contains("Stone") || material.Contains("Glass"))
                    return TactsuitVR.FeedbackType.PlayerKickStoneRight;
                else if (material.Contains("Metal"))
                    return TactsuitVR.FeedbackType.PlayerKickMetalRight;
                else if (material.Contains("Fabric"))
                    return TactsuitVR.FeedbackType.PlayerKickFabricRight;
                else if (material.Contains("Flesh") || material.Contains("Sand") || material.Contains("Leather"))
                    return TactsuitVR.FeedbackType.PlayerKickFleshRight;
                else
                    return TactsuitVR.FeedbackType.PlayerKickOtherRight;
            }
            else
            {
                return TactsuitVR.FeedbackType.PlayerKickOtherRight;
            }
        }
        private void ArmorUnequippedFunc(Wearable slot, Item item)
        {
            if (slot.Part.type == RagdollPart.Type.Head)
            {
                tactsuitVr.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.UnequipHelmet, false, 0.75f, TactsuitVR.FeedbackType.NoFeedback, false);
            }
            else if (slot.Part.type == RagdollPart.Type.Torso)
            {
                tactsuitVr.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.UnequipCuirass, false, 0.75f, TactsuitVR.FeedbackType.NoFeedback, false);
            }
            else if (slot.Part.type == RagdollPart.Type.RightArm)
            {
                tactsuitVr.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.UnequipGauntletsRight, false, 0.75f, TactsuitVR.FeedbackType.NoFeedback, false);
            }
            else if (slot.Part.type == RagdollPart.Type.LeftArm)
            {
                tactsuitVr.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.UnequipGauntletsLeft, false, 0.75f, TactsuitVR.FeedbackType.NoFeedback, false);
            }
            else if (slot.Part.type == RagdollPart.Type.RightFoot)
            {
                tactsuitVr.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.UnequipFeet, false, 0.75f, TactsuitVR.FeedbackType.NoFeedback, false);
            }
        }
        private void ArmorEquippedFunc(Wearable slot, Item item)
        {
            if (slot.Part.type == RagdollPart.Type.Head)
            {
                tactsuitVr.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.EquipHelmet, false, 0.75f, TactsuitVR.FeedbackType.NoFeedback, false);
            }
            else if (slot.Part.type == RagdollPart.Type.Torso)
            {
                tactsuitVr.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.EquipCuirass, false, 0.75f, TactsuitVR.FeedbackType.NoFeedback, false);
            }
            else if (slot.Part.type == RagdollPart.Type.RightArm)
            {
                tactsuitVr.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.EquipGauntletsRight, false, 0.75f, TactsuitVR.FeedbackType.NoFeedback, false);
            }
            else if (slot.Part.type == RagdollPart.Type.LeftArm)
            {
                tactsuitVr.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.EquipGauntletsLeft, false, 0.75f, TactsuitVR.FeedbackType.NoFeedback, false);
            }
            else if (slot.Part.type == RagdollPart.Type.RightFoot)
            {
                tactsuitVr.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.EquipFeet, false, 0.75f, TactsuitVR.FeedbackType.NoFeedback, false);
            }
        }


        private void BodyPartCollisionStopFunc(CollisionInstance collisionInstance)
        {
            if (collisionInstance.sourceColliderGroup != null && collisionInstance.targetColliderGroup == null && (collisionInstance.sourceColliderGroup.collisionHandler != null ? collisionInstance.sourceColliderGroup.collisionHandler.name : "").Contains("Hand") && (bool)(UnityEngine.Object)collisionInstance.sourceColliderGroup.collisionHandler?.item?.leftPlayerHand)
            {
                leftHandClimbing = false;
            }

            if (collisionInstance.sourceColliderGroup != null && collisionInstance.targetColliderGroup == null && (collisionInstance.sourceColliderGroup.collisionHandler != null ? collisionInstance.sourceColliderGroup.collisionHandler.name : "").Contains("Hand") && (bool)(UnityEngine.Object)collisionInstance.sourceColliderGroup.collisionHandler?.item?.rightPlayerHand)
            {
                rightHandClimbing = false;
            }
        }

        private void LeftHandCollisionStartFunc(CollisionInstance collisionInstance)
        {
            string material = (collisionInstance.sourceMaterial != null ? collisionInstance.sourceMaterial.id + " " + (collisionInstance.targetMaterial != null ? collisionInstance.targetMaterial.id : "") : "");

            material = Utility.ReplaceFirst(material, "Flesh", "");

            TactsuitVR.FeedbackType feedback = GetPlayerPunchFeedback(material);
            tactsuitVr.ProvideHapticFeedback(0, 0, feedback, false, collisionInstance.intensity, TactsuitVR.FeedbackType.NoFeedback, true);
            LOG("Left hand collides with something with intensity=" + collisionInstance.intensity.ToString(CultureInfo.InvariantCulture) + " " + ((collisionInstance.sourceMaterial != null && collisionInstance.targetMaterial != null) ? ("Materials: " + collisionInstance.sourceMaterial.id + " > " + collisionInstance.targetMaterial.id) : ""));
        }

        private void RightHandCollisionStartFunc(CollisionInstance collisionInstance)
        {
            string material = (collisionInstance.sourceMaterial != null ? collisionInstance.sourceMaterial.id + " " + (collisionInstance.targetMaterial != null ? collisionInstance.targetMaterial.id : "") : "");
            material = Utility.ReplaceFirst(material, "Flesh", "");

            TactsuitVR.FeedbackType feedback = GetPlayerPunchFeedback(material);
            tactsuitVr.ProvideHapticFeedback(0, 0, feedback, false, collisionInstance.intensity, TactsuitVR.FeedbackType.NoFeedback, false);
            LOG("Right hand collides with something with intensity=" + collisionInstance.intensity.ToString(CultureInfo.InvariantCulture) + " " + ((collisionInstance.sourceMaterial != null && collisionInstance.targetMaterial != null) ? ("Materials: " + collisionInstance.sourceMaterial.id + " > " + collisionInstance.targetMaterial.id) : ""));
        }

        private void LeftFootCollisionStartFunc(CollisionInstance collisionInstance)
        {
            string material = (collisionInstance.sourceMaterial != null ? collisionInstance.sourceMaterial.id + " " + (collisionInstance.targetMaterial != null ? collisionInstance.targetMaterial.id : "") : "");
            material = Utility.ReplaceFirst(material, "Flesh", "");

            TactsuitVR.FeedbackType feedback = GetPlayerKickFeedback(material);
            tactsuitVr.ProvideHapticFeedback(0, 0, feedback, false, collisionInstance.intensity, TactsuitVR.FeedbackType.NoFeedback, true);
            LOG("Left foot collides with something with intensity=" + collisionInstance.intensity.ToString(CultureInfo.InvariantCulture) + " " + ((collisionInstance.sourceMaterial != null && collisionInstance.targetMaterial != null) ? ("Materials: " + collisionInstance.sourceMaterial.id + " > " + collisionInstance.targetMaterial.id) : ""));
       }

        private void RightFootCollisionStartFunc(CollisionInstance collisionInstance)
        {
            string material = (collisionInstance.sourceMaterial != null ? collisionInstance.sourceMaterial.id + " " + (collisionInstance.targetMaterial != null ? collisionInstance.targetMaterial.id : "") : "");
            material = Utility.ReplaceFirst(material, "Flesh", "");

            TactsuitVR.FeedbackType feedback = GetPlayerKickFeedback(material);
            tactsuitVr.ProvideHapticFeedback(0, 0, feedback, false, collisionInstance.intensity, TactsuitVR.FeedbackType.NoFeedback, false);
            LOG("Right foot collides with something with intensity=" + collisionInstance.intensity.ToString(CultureInfo.InvariantCulture) + " " + ((collisionInstance.sourceMaterial != null && collisionInstance.targetMaterial != null) ? ("Materials: " + collisionInstance.sourceMaterial.id + " > " + collisionInstance.targetMaterial.id) : ""));
        }

        private void TorsoCollisionFunc(CollisionInstance collisionInstance)
        {
            //if (collisionInstance.damageStruct.hitRagdollPart?.ragdoll?.creature != null || collisionInstance.damageStruct.damage > TOLERANCE || collisionInstance.impactVelocity.magnitude < 7.0f)
            //    return;

            //bool sourceIsPlayer = false;
            //bool targetIsPlayer = false;

            //if (collisionInstance.sourceColliderGroup?.collisionHandler != null)
            //{
            //    if (collisionInstance.sourceColliderGroup?.collisionHandler?.isRagdollPart == true)
            //    {
            //        if (collisionInstance.sourceColliderGroup?.collisionHandler?.ragdollPart?.ragdoll?.creature == Player.local?.creature)
            //        {
            //            sourceIsPlayer = true;
            //        }
            //    }
            //    if (!sourceIsPlayer && collisionInstance.sourceColliderGroup?.collisionHandler?.isItem == true)
            //    {
            //        if (collisionInstance.sourceColliderGroup?.collisionHandler?.item?.rightPlayerHand != null
            //            || collisionInstance.sourceColliderGroup?.collisionHandler?.item?.leftPlayerHand != null
            //            || collisionInstance.sourceColliderGroup?.collisionHandler?.item?.ignoredRagdoll?.creature == Player.local?.creature
            //            || collisionInstance.IsSameSourceColliderGroup(null, Player.local?.footLeft.ragdollFoot.colliderGroup)
            //            || collisionInstance.IsSameSourceColliderGroup(null, Player.local?.footRight.ragdollFoot.colliderGroup))
            //        {
            //            sourceIsPlayer = true;
            //        }
            //    }
            //}
            //if (collisionInstance.targetColliderGroup?.collisionHandler != null)
            //{
            //    if (collisionInstance.targetColliderGroup?.collisionHandler?.isRagdollPart == true)
            //    {
            //        if (collisionInstance.targetColliderGroup?.collisionHandler?.ragdollPart?.ragdoll?.creature == Player.local?.creature)
            //        {
            //            targetIsPlayer = true;
            //        }
            //    }
            //    if (!targetIsPlayer && collisionInstance.targetColliderGroup?.collisionHandler?.isItem == true)
            //    {
            //        if (collisionInstance.targetColliderGroup?.collisionHandler?.item?.rightPlayerHand != null
            //            || collisionInstance.targetColliderGroup?.collisionHandler?.item?.leftPlayerHand != null
            //            || collisionInstance.targetColliderGroup?.collisionHandler?.item?.ignoredRagdoll?.creature == Player.local?.creature
            //            || collisionInstance.IsSameTargetColliderGroup(null, Player.local?.footLeft.ragdollFoot.colliderGroup)
            //            || collisionInstance.IsSameTargetColliderGroup(null, Player.local?.footRight.ragdollFoot.colliderGroup))
            //        {
            //            targetIsPlayer = true;
            //        }
            //    }
            //}

            float hitAngle = Utility.GetAngleForPosition(collisionInstance.contactPoint);

            //if (collisionInstance.sourceColliderGroup != null && collisionInstance.targetColliderGroup != null)
            //{
            //    LOG("Player torso collision " + (sourceIsPlayer ? "Source is player!" : "") + " " + (targetIsPlayer ? "Target is player!" : "") + " ST: SourceName: " + (collisionInstance.sourceColliderGroup.collisionHandler != null ? collisionInstance.sourceColliderGroup.collisionHandler.name : "") + " TargetName: " + (collisionInstance.targetColliderGroup.collisionHandler != null ? collisionInstance.targetColliderGroup.collisionHandler.name : "") + " with Hit Angle: " + hitAngle.ToString(CultureInfo.InvariantCulture) + " with intensity=" + collisionInstance.intensity.ToString(CultureInfo.InvariantCulture) + " with ImpactVelocity:" + collisionInstance.impactVelocity.magnitude.ToString(CultureInfo.InvariantCulture) + " DamageType: " + Enum.GetName(typeof(DamageType), collisionInstance.damageStruct.damageType) + " " + ("Materials: " + ((collisionInstance.sourceMaterial != null ? collisionInstance.sourceMaterial.id : "Null") + " > " + (collisionInstance.targetMaterial != null ? collisionInstance.targetMaterial.id : "Null"))));
            //}
            //else if (collisionInstance.sourceColliderGroup != null && collisionInstance.targetColliderGroup == null)
            //{
            //    LOG("Player torso collision " + (sourceIsPlayer ? "Source is player!" : "") + " S: SourceName: " + (collisionInstance.sourceColliderGroup.collisionHandler != null ? collisionInstance.sourceColliderGroup.collisionHandler.name : "") + " with Hit Angle: " + hitAngle.ToString(CultureInfo.InvariantCulture) + " with intensity=" + collisionInstance.intensity.ToString(CultureInfo.InvariantCulture) + " with ImpactVelocity:" + collisionInstance.impactVelocity.magnitude.ToString(CultureInfo.InvariantCulture) + " DamageType: " + Enum.GetName(typeof(DamageType), collisionInstance.damageStruct.damageType) + " " + ("Materials: " + ((collisionInstance.sourceMaterial != null ? collisionInstance.sourceMaterial.id : "Null") + " > " + (collisionInstance.targetMaterial != null ? collisionInstance.targetMaterial.id : "Null"))));
            //}
            //else if (collisionInstance.sourceColliderGroup == null && collisionInstance.targetColliderGroup != null)
            //{
            //    LOG("Player torso collision " + (targetIsPlayer ? "Target is player!" : "") + " T: TargetName: " + (collisionInstance.targetColliderGroup.collisionHandler != null ? collisionInstance.targetColliderGroup.collisionHandler.name : "") + " with Hit Angle: " + hitAngle.ToString(CultureInfo.InvariantCulture) + " with intensity=" + collisionInstance.intensity.ToString(CultureInfo.InvariantCulture) + " with ImpactVelocity:" + collisionInstance.impactVelocity.magnitude.ToString(CultureInfo.InvariantCulture) + " DamageType: " + Enum.GetName(typeof(DamageType), collisionInstance.damageStruct.damageType) + " " + ("Materials: " + ((collisionInstance.sourceMaterial != null ? collisionInstance.sourceMaterial.id : "Null") + " > " + (collisionInstance.targetMaterial != null ? collisionInstance.targetMaterial.id : "Null"))));
            //}
            //else if (collisionInstance.sourceColliderGroup == null && collisionInstance.targetColliderGroup == null)
            //{
            //    LOG("Player torso collision with Hit Angle: " + hitAngle.ToString(CultureInfo.InvariantCulture) + " with intensity=" + collisionInstance.intensity.ToString(CultureInfo.InvariantCulture) + " with ImpactVelocity:" + collisionInstance.impactVelocity.magnitude.ToString(CultureInfo.InvariantCulture) + " DamageType: " + Enum.GetName(typeof(DamageType), collisionInstance.damageStruct.damageType) + " " + ("Materials: " + ((collisionInstance.sourceMaterial != null ? collisionInstance.sourceMaterial.id : "Null") + " > " + (collisionInstance.targetMaterial != null ? collisionInstance.targetMaterial.id : "Null"))));
            //}
            
            tactsuitVr.ProvideHapticFeedback(hitAngle, 0, TactsuitVR.FeedbackType.DamageVestBluntStoneLarge, false, collisionInstance.intensity, TactsuitVR.FeedbackType.NoFeedback, false);
        }

        private void HeldItemRightCollisionStartFunc(CollisionInstance collisionInstance)
        {
            if (collisionInstance.damageStruct.hitRagdollPart?.ragdoll?.creature != null)
                return;

            TactsuitVR.FeedbackType feedback = TactsuitVR.GetPlayerMeleeFeedbackType(collisionInstance.damageStruct.damageType, collisionInstance.sourceMaterial, collisionInstance.targetMaterial);
            tactsuitVr.ProvideHapticFeedback(0, 0, feedback, false, collisionInstance.intensity, TactsuitVR.FeedbackType.NoFeedback, false);
            LOG("Right hand item (" + (collisionInstance.sourceCollider != null ? collisionInstance.sourceCollider.name : "") + ") collides with something (" + (collisionInstance.targetCollider != null ? collisionInstance.targetCollider.name : "") + ") with intensity=" + collisionInstance.intensity.ToString(CultureInfo.InvariantCulture) + " " + ((collisionInstance.sourceMaterial != null && collisionInstance.targetMaterial != null) ? ("Materials: " + collisionInstance.sourceMaterial.id + " > " + collisionInstance.targetMaterial.id) : "") + " DamageType: " + Utility.GetDamageTypeName(collisionInstance.damageStruct.damageType));
        }

        private void HeldItemLeftCollisionStartFunc(CollisionInstance collisionInstance)
        {
            if (collisionInstance.damageStruct.hitRagdollPart?.ragdoll?.creature != null)
                return;

            TactsuitVR.FeedbackType feedback = TactsuitVR.GetPlayerMeleeFeedbackType(collisionInstance.damageStruct.damageType, collisionInstance.sourceMaterial, collisionInstance.targetMaterial);
            tactsuitVr.ProvideHapticFeedback(0, 0, feedback, false, collisionInstance.intensity, TactsuitVR.FeedbackType.NoFeedback, true);
            LOG("Left hand item with (" + (collisionInstance.sourceCollider != null ? collisionInstance.sourceCollider.name : "") + ") collides with something (" + (collisionInstance.targetCollider != null ? collisionInstance.targetCollider.name : "") + ") with intensity=" + collisionInstance.intensity.ToString(CultureInfo.InvariantCulture) + " " + ((collisionInstance.sourceMaterial != null && collisionInstance.targetMaterial != null) ? ("Materials: " + collisionInstance.sourceMaterial.id + " > " + collisionInstance.targetMaterial.id) : "") +  " DamageType: " + Utility.GetDamageTypeName(collisionInstance.damageStruct.damageType));
        }
                        
        private void BeingPushedFunc()
        {
            while (!gamePaused && !TimeManager.timeStopped && Player.local.creature.state != Creature.State.Dead && !Player.local.locomotion.allowMove && Player.local.locomotion.moveDirection == UnityEngine.Vector3.zero && Player.local.locomotion.velocity.magnitude >= 0.1f)
            {
                Vector3 contactPoint = Player.local.locomotion.transform.position - Player.local.locomotion.velocity;
                float hitAngle = Utility.GetAngleForPosition(contactPoint);

                float intensity = Player.local.locomotion.velocity.magnitude / 5f;
                tactsuitVr.ProvideHapticFeedback(hitAngle, 0, TactsuitVR.FeedbackType.DamageVestGravity, false, intensity, TactsuitVR.FeedbackType.NoFeedback, false);
                if (GravityEffectOnHead)
                {
                    tactsuitVr.ProvideHapticFeedback(hitAngle, 0, TactsuitVR.FeedbackType.DamageHeadGravity, false, intensity, TactsuitVR.FeedbackType.NoFeedback, false);
                }
                if (GravityEffectOnArms)
                {
                    tactsuitVr.ProvideHapticFeedback(hitAngle, 0, TactsuitVR.FeedbackType.DamageRightArmGravity, false, intensity, TactsuitVR.FeedbackType.NoFeedback, true);
                    tactsuitVr.ProvideHapticFeedback(hitAngle, 0, TactsuitVR.FeedbackType.DamageRightArmGravity, false, intensity, TactsuitVR.FeedbackType.NoFeedback, false);
                }

                Thread.Sleep(SleepDurationSpellHit);
            }

            beingPushed = false;
        }

        private void BeingPulledFunc(Side side)
        {
            if (Player.local?.creature != null)
            {
                if (side == Side.Left)
                {
                    Item leftItem = Player.local.creature.equipment.GetHeldItem(Side.Left);
                    while (!beingPushed && !gamePaused && !TimeManager.timeStopped && Player.local.locomotion.moveDirection == UnityEngine.Vector3.zero && Player.local.creature.state != Creature.State.Dead && Player.local.locomotion.velocity.magnitude > 1f && Player.local.locomotion.velocity.y >= 0f && leftItem != null && leftItem.name.Contains("Grapple") && leftItemUseStarted)
                    {
                        float intensity = Player.local.locomotion.velocity.magnitude / 3f;
                        tactsuitVr.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.ClimbingRight, false, intensity, TactsuitVR.FeedbackType.NoFeedback, true);

                        Thread.Sleep(SleepDurationSpellCast);
                    }

                    beingPulledLeft = false;
                }
                else
                {
                    Item rightItem = Player.local.creature.equipment.GetHeldItem(Side.Right);

                    while (!beingPushed && !gamePaused && !TimeManager.timeStopped && Player.local.locomotion.moveDirection == UnityEngine.Vector3.zero && Player.local.creature.state != Creature.State.Dead && Player.local.locomotion.velocity.magnitude > 1f && Player.local.locomotion.velocity.y >= 0f && rightItem != null && rightItem.name.Contains("Grapple") && rightItemUseStarted)
                    {
                        float intensity = Player.local.locomotion.velocity.magnitude / 3f;
                        tactsuitVr.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.ClimbingRight, false, intensity, TactsuitVR.FeedbackType.NoFeedback, false);

                        Thread.Sleep(SleepDurationClimb);
                    }
                    beingPulledRight = false;
                }
            }
        }

        private void BeingPushedOtherFunc()
        {
            while (!beingPushed && !gamePaused && !TimeManager.timeStopped && Player.local.locomotion.moveDirection == UnityEngine.Vector3.zero && Player.local.creature.state != Creature.State.Dead && Player.local.locomotion.velocity.magnitude > 1f)
            {
                Vector3 contactPoint = Player.local.locomotion.transform.position - Player.local.locomotion.velocity;
                float hitAngle = Utility.GetAngleForPosition(contactPoint);

                float intensity = Player.local.locomotion.velocity.magnitude / 5f;
                tactsuitVr.ProvideHapticFeedback(hitAngle, 0, TactsuitVR.FeedbackType.Explosion, false, intensity, TactsuitVR.FeedbackType.NoFeedback, false);
               
                Thread.Sleep(SleepDurationSpellHit);
            }

            beingPushedOther = false;
        }

        private void BowStringFunc(Side side)
        {
            Item leftItem = Player.local.creature.equipment.GetHeldWeapon(Side.Left);
            Item rightItem = Player.local.creature.equipment.GetHeldWeapon(Side.Right);

            BowString bowString = leftItem?.GetComponentInChildren<BowString>() ?? rightItem?.GetComponentInChildren<BowString>();

            while (bowString != null && bowStringHeld)
            {
                if (TimeManager.timeStopped)
                {
                    Thread.Sleep(1000);
                    continue;
                }

                if (Player.local?.creature == null)
                    break;

                leftItem = Player.local.creature.equipment.GetHeldWeapon(Side.Left);
                rightItem = Player.local.creature.equipment.GetHeldWeapon(Side.Right);

                if (leftItem == null && rightItem == null)
                    break;

                if ((leftItem != null && leftItem.GetComponentInChildren<BowString>() == null) && (rightItem != null && rightItem.GetComponentInChildren<BowString>() == null))
                {
                    break;
                }

                if (leftItem == rightItem && bowString.isPulling)
                {
                    float intensity = bowString.currentPullRatio* 2.5f;
                    //LOG("Pulling bow CurrentPull:" + currentPull.ToString() + " AnimationClipLength:" + bowString.animationClipLength.ToString() + " MaxDistance:" + bowString.maxDrawDistance);
                    if (intensity >= 0.1f && intensity < 0.2f)
                        intensity = 0.2f;

                    if (side == Side.Right)
                        tactsuitVr.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.PlayerBowPullRight, false, intensity, TactsuitVR.FeedbackType.NoFeedback, false);
                    else
                        tactsuitVr.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.PlayerBowPullRight, false, intensity, TactsuitVR.FeedbackType.NoFeedback, true);
                }

                Thread.Sleep(SleepDurationBowString);
            }
        }

        private void ClimbingFunc(Side side)
        {
            if (side == Side.Left)
            {
                float lastIntensity = 0;
                while (!TimeManager.timeStopped && leftHandClimbing)
                {
                    float intensity = Math.Abs(Player.local.handLeft.transform.position.y - Player.local.head.transform.position.y);
                    //LOG("***> Climbing left debug: " + lastIntensity + " - " + intensity + ">=0.03f");
                    if (Math.Abs(lastIntensity - intensity) >= 0.03f)
                    {
                        lastIntensity = intensity;
                        tactsuitVr.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.ClimbingRight, false, (leftHandClimbing && rightHandClimbing) ? intensity/2f : intensity, TactsuitVR.FeedbackType.NoFeedback, true);
                    }

                    Thread.Sleep(SleepDurationClimb);
                }

                leftHandClimbing = false;
            }
            else
            {
                float lastIntensity = 0;
                while (!TimeManager.timeStopped && rightHandClimbing)
                {
                    float intensity = Math.Abs(Player.local.handRight.transform.position.y - Player.local.head.transform.position.y);
                    //LOG("***> Climbing right debug: " + lastIntensity + " - " + intensity + ">=0.03f");
                    if (Math.Abs(lastIntensity - intensity) >= 0.03f)
                    {
                        lastIntensity = intensity;
                        tactsuitVr.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.ClimbingRight, false, (leftHandClimbing && rightHandClimbing) ? intensity / 2f : intensity, TactsuitVR.FeedbackType.NoFeedback, false);
                    }

                    Thread.Sleep(SleepDurationClimb);
                }

                rightHandClimbing = false;
            }
        }

        private void UnGrabFunc(Side side, Handle handle, bool throwing, EventTime eventTime)
        {
            if (eventTime != EventTime.OnEnd)
                return;

            string objectName = "";
            if (handle.gameObject?.transform?.parent?.transform?.parent?.gameObject != null)
                objectName = handle.gameObject.transform.parent.transform.parent.gameObject.name;

            if (objectName.ToLowerInvariant().Contains("ladder"))
            {
                if (side == Side.Left) grabbedLadderWithLeftHand = false;
                else grabbedLadderWithRightHand = false;
            }

            if (handle != null)
            {
                if (handle.name == "HandleString" && handle.item?.data?.moduleAI?.primaryClass == ItemModuleAI.WeaponClass.Bow)
                {
                    bowStringHeld = false;
                }
                else //if (handle?.item?.data?.moduleAI?.weaponClass != ItemModuleAI.WeaponClass.None)
                {
                    if (handle?.item != null)
                    {
                        if (side == Side.Left)
                        {
                            if(throwing)
                            {
                                tactsuitVr?.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.PlayerThrowRight, true, (PlayerControl.input.GetHandVelocity(side).magnitude / Catalog.gameData.throwVelocity)*0.3f, TactsuitVR.FeedbackType.NoFeedback, true);
                            }

                            ItemHeldInLeftHand = false;
                            foreach (var collisionHandler in handle.item.collisionHandlers)
                            {
                                if (collisionHandler != null)
                                {
                                    collisionHandler.OnCollisionStartEvent -= HeldItemLeftCollisionStartFunc;
                                }
                            }
                            handle.item.OnHeldActionEvent -= LeftItemHeldActionEventFunc;
                            leftItemUseStarted = false;
                            leftItemAltUseStarted = false;
                        }
                        else
                        {
                            if (throwing)
                            {
                                tactsuitVr?.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.PlayerThrowRight, true, (PlayerControl.input.GetHandVelocity(side).magnitude / Catalog.gameData.throwVelocity) * 0.1f, TactsuitVR.FeedbackType.NoFeedback, false);
                            }

                            ItemHeldInRightHand = false;
                            foreach (var collisionHandler in handle.item.collisionHandlers)
                            {
                                if (collisionHandler != null)
                                {
                                    collisionHandler.OnCollisionStartEvent -= HeldItemRightCollisionStartFunc;
                                }
                            }
                            handle.item.OnHeldActionEvent -= RightItemHeldActionEventFunc;
                            rightItemUseStarted = false;
                            rightItemAltUseStarted = false;
                        }
                    }
                }

                LOG("Ungrabbed handle with " + (side == Side.Left ? "left" : "right") + " hand. Handle Name: " + handle.name);
            }
        }

        private void RightItemHeldActionEventFunc(RagdollHand ragdollHand, Handle handle, Interactable.Action action)
        {
            if (action == Interactable.Action.UseStart)
            {
                rightItemUseStarted = true;

                if (Player.local?.creature != null)
                {
                    Item rightItem = Player.local?.creature.equipment.GetHeldItem(Side.Right);

                    if (rightItem != null && rightItem.name.Contains("Grapple"))
                    {
                        if (!noExplosionFeedback)
                        {
                            noExplosionFeedback = true;
                            Thread thread = new Thread(ExplosionWaitFunc);
                            thread.Start();
                        }
                    }
                }
            }
            else if (action == Interactable.Action.UseStop)
            {
                rightItemUseStarted = false;
            }
            else if (action == Interactable.Action.AlternateUseStart)
            {
                rightItemAltUseStarted = true;
            }
            else if (action == Interactable.Action.AlternateUseStop)
            {
                rightItemAltUseStarted = false;
            }
            else if (action == Interactable.Action.Ungrab)
            {
                rightItemUseStarted = false;
                rightItemAltUseStarted = false;
            }
        }

        private void LeftItemHeldActionEventFunc(RagdollHand ragdollHand, Handle handle, Interactable.Action action)
        {
            if (action == Interactable.Action.UseStart)
            {
                leftItemUseStarted = true;

                if(Player.local?.creature != null)
                {
                    Item leftItem = Player.local?.creature.equipment.GetHeldItem(Side.Left);

                    if (leftItem != null && leftItem.name.Contains("Grapple"))
                    {
                        if (!noExplosionFeedback)
                        {
                            noExplosionFeedback = true;
                            Thread thread = new Thread(ExplosionWaitFunc);
                            thread.Start();
                        }
                    }
                }
            }
            else if (action == Interactable.Action.UseStop)
            {
                leftItemUseStarted = false;
            }
            else if (action == Interactable.Action.AlternateUseStart)
            {
                leftItemAltUseStarted = true;
            }
            else if (action == Interactable.Action.AlternateUseStop)
            {
                leftItemAltUseStarted = false;
            }
            else if (action == Interactable.Action.Ungrab)
            {
                leftItemUseStarted = false;
                leftItemAltUseStarted = false;
            }
        }

        private void GrabFunc(Side side, Handle handle, float axisPosition, HandlePose orientation, EventTime eventTime)
        {
            if (eventTime != EventTime.OnStart)
            {
                return;
            }
            
            if (Player.local?.head != null && Player.local?.creature != null)
            {
                string objectName = "";
                string displayName = "";
                string itemName = "";
                if (handle.gameObject?.transform?.parent?.transform?.parent?.gameObject != null)
                    objectName += handle.gameObject.transform.parent.transform.parent.gameObject.name;

                if (handle.item?.data!=null)
                    displayName += handle.item.data.displayName;

                if (handle.item != null)
                    itemName += handle.item.name;

                if (objectName.ToLowerInvariant().Contains("ladder"))
                {
                    if (side == Side.Left) grabbedLadderWithLeftHand = true;
                    else grabbedLadderWithRightHand = true;
                }

                ///LOG("Grabbed handle with " + (side == Side.Left ? "left" : "right") + " hand. Display Name: " + displayName + " Object Name: " + objectName + ". Item Name: " + itemName);

                if (handle !=null)
                {
                    if (handle?.name == "HandleString" && handle?.item?.data?.moduleAI?.primaryClass == ItemModuleAI.WeaponClass.Bow)
                    {
                        LOG("...it is a bow string, grabbed with " + (side == Side.Right ? "right" : "left") + "hand.");
                        if (!bowStringHeld)
                        {
                            bowStringHeld = true;
                            Thread thread = new Thread(() => BowStringFunc(side));
                            thread.Start();
                        }

                        return;
                    }
                    else 
                    {
                        if (handle.item != null)
                        {
                            LOG("...grabbed with " + (side == Side.Right ? "right" : "left") + "hand.");
                            if (side == Side.Left)
                            {
                                if (!ItemHeldInLeftHand)
                                {
                                    ItemHeldInLeftHand = true;
                                    foreach (var collisionHandler in handle.item.collisionHandlers)
                                    {
                                        if (collisionHandler != null)
                                        {
                                            collisionHandler.OnCollisionStartEvent += HeldItemLeftCollisionStartFunc;
                                        }
                                    }
                                    handle.item.OnHeldActionEvent += LeftItemHeldActionEventFunc;
                                }
                            }
                            else
                            {
                                if (!ItemHeldInRightHand)
                                {
                                    ItemHeldInRightHand = true;
                                    foreach (var collisionHandler in handle.item.collisionHandlers)
                                    {
                                        if (collisionHandler != null)
                                        {
                                            collisionHandler.OnCollisionStartEvent += HeldItemRightCollisionStartFunc;
                                        }
                                    }
                                    handle.item.OnHeldActionEvent += RightItemHeldActionEventFunc;
                                }
                            }

                            return;
                        }
                    }
                }
            }
        }

        private void OnDamageFunc(CollisionInstance collisionInstance, EventTime eventTime)
        {
            if (collisionInstance.targetCollider == null && collisionInstance.sourceCollider == null)
            {
                if (collisionInstance.damageStruct.damage > TOLERANCE)
                {
                    tactsuitVr.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.DefaultDamage, false, collisionInstance.intensity, TactsuitVR.FeedbackType.NoFeedback, false);
                    LOG("Player other damage by Damager: " + (collisionInstance.damageStruct.damager != null ? collisionInstance.damageStruct.damager.name : "") + " Imbue: " + (collisionInstance.damageStruct.damager?.damagerImbue != null ? collisionInstance.damageStruct.damager.damagerImbue.name : " None") + " Amount: " + collisionInstance.damageStruct.damage.ToString(CultureInfo.InvariantCulture) + " Source: " + (collisionInstance.sourceCollider != null ? collisionInstance.sourceCollider.name : "Unknown") + " on " + (collisionInstance.targetCollider != null ? collisionInstance.targetCollider.name : "whole body") + " with Intensity:" + collisionInstance.intensity.ToString(CultureInfo.InvariantCulture) + " " + ((collisionInstance.sourceMaterial != null && collisionInstance.targetMaterial != null) ? ("Materials: " + collisionInstance.sourceMaterial.id + " > " + collisionInstance.targetMaterial.id) : "") + " DamageType: " + Utility.GetDamageTypeName(collisionInstance.damageStruct.damageType) + " Penetration: " + ((collisionInstance.damageStruct.damager != null && collisionInstance.damageStruct.damager.data != null) ? (collisionInstance.damageStruct.damager.data.penetrationDamage <= 15.0f ? "Small" : "Large") : ""));
                }
            }
        }

        private void OnGroundFunc(Locomotion locomotion, Vector3 groundPoint, Vector3 velocity, Collider groundCollider)
        {
            if (NoFallEffectWhenFallDamageIsDisabled && !Player.fallDamage)
            {
                return;
            }

            if (Player.local?.locomotion != null && Player.local.locomotion.isGrounded && Player.local?.creature?.data != null)
            {
                //Play default damage effect
                float damage = Player.local.creature.data.playerFallDamageCurve.Evaluate(velocity.magnitude);
                if (damage > 1.0f)
                {
                    float intensity = damage / 20.0f;
                    tactsuitVr.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.FallDamage, false, intensity, TactsuitVR.FeedbackType.NoFeedback, false);
                    tactsuitVr.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.FallDamageFeet, false, intensity, TactsuitVR.FeedbackType.NoFeedback, false);
                    LOG("Player grounded damage. Amount: " + damage.ToString(CultureInfo.InvariantCulture) + " Intensity: " + intensity.ToString(CultureInfo.InvariantCulture));
                }
                else
                {
                    if (velocity.magnitude > FallEffectMinVelocityMagnitude)
                    {
                        tactsuitVr.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.FallDamageFeet, false, velocity.magnitude / 50.0f, TactsuitVR.FeedbackType.NoFeedback, false);
                        tactsuitVr.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.FallDamage, false, velocity.magnitude / 50.0f, TactsuitVR.FeedbackType.NoFeedback, false);
                    }
                }
            }
        }

        private void LrOnOnReceptionEvent(LiquidData liquid, float dilution, LiquidContainer liquidcontainer)
        {
            if (liquid.GetType() != typeof(LiquidPoison))
            {
                //Play just drinking effect
                tactsuitVr.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.PotionDrinking, false, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);                
            }
            else //Poison
            {
                //Play drinking effect and poisoned effect
                tactsuitVr.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.PoisonDrinking, false, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);
            }
        }

        [HarmonyPatch("SetSlowMotion")]
        [HarmonyPatch(typeof(TimeManager))]
        private static class TimeManagerSetSlowMotionPatch
        {
            private static bool slowMotionActive = false;

            private static void SlowMotionFunc()
            {
                while (!TimeManager.timeStopped && TimeManager.slowMotionState == TimeManager.SlowMotionState.Running && slowMotionActive)
                {
                    tactsuitVr.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.SlowMotion, false, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);

                    Thread.Sleep(SleepDurationSlowMotion);
                }
            }

            [HarmonyPostfix]
            private static void Postfix(TimeManager __instance,
              bool active, float scale, AnimationCurve curve, EffectData effectData = null, bool snapshotTransition = true, bool playEndEffect = true)
            {
                if (slowMotionActive)
                {
                    if (!active)
                    {
                        slowMotionActive = false;
                    }
                }
                else
                {
                    if (active)
                    {
                        slowMotionActive = true;
                        Thread thread = new Thread(SlowMotionFunc);
                        thread.Start();
                    }
                }
            }
        }

        private void ExplosionWaitFunc()
        {
            while (true)
            {
                Thread.Sleep(5000);
                if (Player.local?.creature != null && Player.local?.locomotion != null)
                {
                    Item rightItem = Player.local?.creature.equipment.GetHeldItem(Side.Right);

                    if (rightItem != null && rightItem.name.Contains("Grapple") && rightItemUseStarted)
                    {
                        continue;
                    }

                    Item leftItem = Player.local?.creature.equipment.GetHeldItem(Side.Left);

                    if (leftItem != null && leftItem.name.Contains("Grapple") && leftItemUseStarted)
                    {
                        continue;
                    }

                    break;
                }
                else
                {
                    break;
                }
            }

            noExplosionFeedback = false;
        }

        private void FireLeftShoulderTurret()
        {
            if (tactsuitVr != null)
            {
                while (!gamePaused && !TimeManager.timeStopped && (leftShoulderTurretShootVFX != null && leftShoulderTurretShootVFX.isPlaying))
                {
                    tactsuitVr?.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.LeftShoulderTurret, false, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);
                    Thread.Sleep(SleepDurationShootGun);
                }

                LOG("Player stopped firing left shoulder turret.");

                shootingLeftShoulderTurret = false;
            }
        }

        private void FireHoverJet()
        {
            if (tactsuitVr != null)
            {
                while (!gamePaused && !TimeManager.timeStopped && (hoverJetVFX != null && hoverJetVFX.isPlaying))
                {
                    tactsuitVr?.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.HoverJetFeet, false, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);
                    Thread.Sleep(SleepDurationShootGun);
                }

                LOG("Player stopped hovering.");

                hoveringWithHoverJet = false;
            }
        }

        private void FireGun(string name, string displayname, bool altFire, bool leftHand, bool starwarsBlasterStun, bool burst, bool chargedFire)
        {
            if (tactsuitVr != null)
            {
                TactsuitVR.FeedbackType feedback = TactsuitVR.GetPlayerGunShootFeedback(name, displayname, starwarsBlasterStun);
                TactsuitVR.FeedbackType feedbackKickback = TactsuitVR.FeedbackType.NoFeedback;
                if (!name.Contains("Grapple"))
                {
                    feedbackKickback = TactsuitVR.GetPlayerGunShootFeedbackKickback(feedback, leftHand ? Side.Left : Side.Right);
                }
                int burstCount = 2;

                if (leftHand)
                {
                    while (!gamePaused && !TimeManager.timeStopped 
                                       && ((leftItemUseStarted && !altFire && (((leftItemShootVFX != null && leftItemShootVFX.isPlaying) || (leftItemShootSFX != null && leftItemShootSFX.isPlaying) || (leftItemChargeSFX != null && leftItemChargeSFX.isPlaying) || (leftItemChargeReadySFX != null && leftItemChargeReadySFX.isPlaying)))) 
                                           ||(leftItemAltUseStarted && altFire && (((leftItemShootVFX != null && leftItemShootVFX.isPlaying) || (leftItemShootSFX != null && leftItemShootSFX.isPlaying) || (leftItemShoot2VFX != null && leftItemShoot2VFX.isPlaying))))))
                    {
                        tactsuitVr?.ProvideHapticFeedback(0, 0, feedback, false, chargedFire ? 0.5f:1.0f, TactsuitVR.FeedbackType.NoFeedback, true);
                        tactsuitVr?.ProvideHapticFeedback(0, 0, feedbackKickback, false, chargedFire ? 0.5f : 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);
                        Thread.Sleep(!starwarsBlasterStun ? SleepDurationShootGun : SleepDurationShootGun*10 / 6);
                        if (burst)
                        {
                            burstCount--;
                            if (burstCount <= 0)
                            {
                                leftItemUseStarted = false;
                                break;
                            }
                        }
                    }
                    LOG("Player stopped " + (altFire ? "alt" : "") + " firing left gun: " + name);

                    if (altFire) altShootingLeftGun = false;
                    else shootingLeftGun = false;

                    if (chargedFire)
                    {
                        tactsuitVr?.ProvideHapticFeedback(0, 0, feedback, false, 1.2f, TactsuitVR.FeedbackType.NoFeedback, true);
                        tactsuitVr?.ProvideHapticFeedback(0, 0, feedbackKickback, false, 1.2f, TactsuitVR.FeedbackType.NoFeedback, false);
                    }
                }
                else
                {
                    while (!gamePaused && !TimeManager.timeStopped
                                       && ((rightItemUseStarted && !altFire && (((rightItemShootVFX != null && rightItemShootVFX.isPlaying) || (rightItemShootSFX != null && rightItemShootSFX.isPlaying) || (rightItemChargeSFX != null && rightItemChargeSFX.isPlaying) || (rightItemChargeReadySFX != null && rightItemChargeReadySFX.isPlaying))))
                                            || (rightItemAltUseStarted && altFire && (((rightItemShootVFX != null && rightItemShootVFX.isPlaying) || (rightItemShootSFX != null && rightItemShootSFX.isPlaying) || (rightItemShoot2VFX != null && rightItemShoot2VFX.isPlaying))))))
                    {
                        
                        tactsuitVr?.ProvideHapticFeedback(0, 0, feedback, false, chargedFire ? 0.5f : 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);
                        tactsuitVr?.ProvideHapticFeedback(0, 0, feedbackKickback, false, chargedFire ? 0.5f : 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);
                        Thread.Sleep(!starwarsBlasterStun ? SleepDurationShootGun : SleepDurationShootGun * 10 / 6);

                        if (burst)
                        {
                            burstCount--;
                            if (burstCount <= 0)
                            {
                                rightItemUseStarted = false;
                                break;
                            }
                        }
                    }
                    LOG("Player stopped " + (altFire ? "alt" : "") + " firing right gun: " + name);

                    if (altFire) altShootingRightGun = false;
                    else shootingRightGun = false;

                    if (chargedFire)
                    {
                        tactsuitVr?.ProvideHapticFeedback(0, 0, feedback, false, 1.2f, TactsuitVR.FeedbackType.NoFeedback, false);
                        tactsuitVr?.ProvideHapticFeedback(0, 0, feedbackKickback, false, 1.2f, TactsuitVR.FeedbackType.NoFeedback, false);
                    }
                }
            }
        }

        private void FireGunModularFireArms(string name, string displayname, bool leftHand, bool burst)
        {
            if (tactsuitVr != null)
            {
                TactsuitVR.FeedbackType feedback = TactsuitVR.GetPlayerGunShootFeedback(name, displayname, false);
                TactsuitVR.FeedbackType feedbackKickback = TactsuitVR.GetPlayerGunShootFeedbackKickback(feedback, leftHand ? Side.Left : Side.Right);

                int burstCount = 2;

                if (leftHand)
                {
                    while (!gamePaused && !TimeManager.timeStopped && (leftItemUseStarted || leftModularGunFiring))
                    {
                        tactsuitVr?.ProvideHapticFeedback(0, 0, feedback, false, 1.0f, TactsuitVR.FeedbackType.NoFeedback, true);
                        tactsuitVr?.ProvideHapticFeedback(0, 0, feedbackKickback, false, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);
                        Thread.Sleep(SleepDurationShootGun);
                        if (burst)
                        {
                            burstCount--;
                            if (burstCount <= 0)
                            {
                                leftItemUseStarted = false;
                                break;
                            }
                        }

                    }
                    LOG("Player stopped firing left gun: " + name);

                    shootingLeftGun = false;
                }
                else
                {
                    while (!gamePaused && !TimeManager.timeStopped && (rightItemUseStarted || rightModularGunFiring))
                    {
                        tactsuitVr?.ProvideHapticFeedback(0, 0, feedback, false, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);
                        tactsuitVr?.ProvideHapticFeedback(0, 0, feedbackKickback, false, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);
                        Thread.Sleep(SleepDurationShootGun);
                        if (burst)
                        {
                            burstCount--;
                            if (burstCount <= 0)
                            {
                                rightItemUseStarted = false;
                                break;
                            }
                        }
                    }
                    LOG("Player stopped firing right gun: " + name);

                    shootingRightGun = false;
                }
            }
        }

        

        private void TelekinesisActivateFunc(bool leftHand)
        {
            if (tactsuitVr != null)
            {
                while (!TimeManager.timeStopped && ((TelekinesisActiveLeft && leftHand) || (TelekinesisActiveRight && !leftHand)))
                {
                    if ((leftHand && Player.local.creature.equipment.GetHeldItem(Side.Left)) || (!leftHand && Player.local.creature.equipment.GetHeldItem(Side.Right)))
                        break;

                    tactsuitVr.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.PlayerTelekinesisActiveRight, false, 1.0f, TactsuitVR.FeedbackType.NoFeedback, leftHand ? true : false);
                    Thread.Sleep(SleepDurationSpellCast);
                }
                tactsuitVr.PauseHapticFeedBack(TactsuitVR.FeedbackType.PlayerTelekinesisActiveRight);
            }
        }

        private void TelekinesisFunc(bool pull, bool leftHand)
        {
            if (tactsuitVr != null)
            {
                TactsuitVR.FeedbackType feedback = pull ? (TactsuitVR.FeedbackType.PlayerTelekinesisPullRight) : (TactsuitVR.FeedbackType.PlayerTelekinesisRepelRight);
                
                while (!TimeManager.timeStopped && ((TelekinesisPullRight && pull) || (TelekinesisRepelRight && !pull)))
                {
                    if ((leftHand && Player.local.creature.equipment.GetHeldItem(Side.Left)) || (!leftHand && Player.local.creature.equipment.GetHeldItem(Side.Right)))
                        break;

                    tactsuitVr.ProvideHapticFeedback(0, 0, feedback, false, 1.0f, TactsuitVR.FeedbackType.NoFeedback, leftHand ? true : false);
                    Thread.Sleep(SleepDurationSpellCast);
                }
                tactsuitVr.PauseHapticFeedBack(feedback);
            }
        }

        private void RaindropVestEffect()
        {
            float minsleepduration = 100.0f;
            int minsleepDurationInt = 100;
            int sleepDuration = 100;

            while (raining)
            {
                minsleepduration = (float)RainVestSleepDuration / rainDensity;
                minsleepDurationInt = (int)minsleepduration;

                sleepDuration = RandomNumber.Between(minsleepDurationInt, minsleepDurationInt * 2);

                int index = RandomNumber.RandomBetweenLowerMoreProbable(0, 7, 8, 15, 4);
                int pos = RandomNumber.Between(0, 1);
                int durationOffset = RandomNumber.Between(0, 30) - 15;
                tactsuitVr.ProvideDotFeedback(pos == 1 ? PositionType.VestFront : PositionType.VestBack, index, (int)(30.0f * rainIntensity * IntensityRaindropVest * IntensityMultiplierRaindrop), RainEffectDuration + durationOffset);

                Thread.Sleep(sleepDuration);
            }
        }

        private void RaindropArmEffect(bool left)
        {
            float minsleepduration = 100.0f;
            int minsleepDurationInt = 100;
            int sleepDuration = 100;

            if (tactsuitVr.ArmsActive)
            {
                while (raining)
                {
                    minsleepduration = (float)RainArmSleepDuration / rainDensity;
                    minsleepDurationInt = (int)(minsleepduration);

                    sleepDuration = RandomNumber.Between(minsleepDurationInt, minsleepDurationInt * 2);

                    int index = RandomNumber.Between(0, 5);
                    int durationOffset = RandomNumber.Between(0, 30) - 15;
                    tactsuitVr.ProvideDotFeedback(left ? PositionType.ForearmL : PositionType.ForearmR, index, (int)(30.0f * rainIntensity * IntensityRaindropArm * IntensityMultiplierRaindrop), RainEffectDuration + durationOffset);

                    Thread.Sleep(sleepDuration);
                }
            }
        }

        private void RaindropHeadEffect()
        {
            float minsleepduration = 100.0f;
            int minsleepDurationInt = 100;
            int sleepDuration = 1;

            if (tactsuitVr.HeadActive)
            {
                while (raining)
                {
                    minsleepduration = (float)RainHeadSleepDuration / rainDensity;
                    minsleepDurationInt = (int)(minsleepduration);

                    sleepDuration = RandomNumber.Between(minsleepDurationInt, minsleepDurationInt * 2);

                    int index = RandomNumber.Between(0, 5);
                    int durationOffset = RandomNumber.Between(0, 30) - 15;
                    tactsuitVr.ProvideDotFeedback(PositionType.Head, index, (int)(30.0f * rainIntensity * IntensityRaindropHead * IntensityMultiplierRaindrop), RainEffectDuration + durationOffset);

                    Thread.Sleep(sleepDuration);
                }
            }
        }

        private int checkFunction2 = 80;

        private void CheckStatesRarest(Creature creature)
        {
            if (creature != null)
            {
                if(checkFunction2 <= 0)
                {
                    checkFunction2 = (int) (1.0f / Time.fixedDeltaTime);

                    #region Rain Effect (The Outer Rim)

                    bool tempRaining = false;

                    if (rainController != null && rainController.activeSelf)
                    {
                        ParticleSystem[] particleSystems = rainController.GetComponentsInChildren<ParticleSystem>();

                        foreach (var ps in particleSystems)
                        {
                            if (ps.isPlaying && ps.isEmitting && !ps.isStopped && !ps.isPaused)
                            {
                                tempRaining = true;
                                break;
                            }
                        }
                    }

                    if (raining && tempRaining == false)
                    {
                        raining = false;
                        LOG("Rain effect is ending.");
                    }
                    else if (!raining && tempRaining)
                    {
                        raining = true;
                        if (IntensityRaindropVest * IntensityMultiplierRaindrop > TOLERANCE)
                        {
                            Thread t55 = new Thread(() => RaindropVestEffect());
                            t55.Start();
                        }

                        if (IntensityRaindropArm * IntensityMultiplierRaindrop > TOLERANCE)
                        {
                            Thread t56 = new Thread(() => RaindropArmEffect(false));
                            t56.Start();
                            Thread t57 = new Thread(() => RaindropArmEffect(true));
                            t57.Start();
                        }

                        if (IntensityRaindropHead * IntensityMultiplierRaindrop > TOLERANCE)
                        {
                            Thread t58 = new Thread(() => RaindropHeadEffect());
                            t58.Start();
                        }

                        LOG("Rain effect is starting.");
                    }

                    #endregion
                }
                else
                {
                    checkFunction2--;
                }
            }
        }

        [HarmonyPatch("Fire")]
        [HarmonyPatch(typeof(SpellCaster))]
        private static class SpellCasterFirePatch
        {
            private static bool CastingLeft = false;
            private static bool CastingRight = false;
            private static string CastingLeftSpellId = "";
            private static string CastingRightSpellId = "";
            private static void SpellCastFunc(string spellId, bool leftHand)
            {
                if (tactsuitVr != null)
                {
                    TactsuitVR.FeedbackType feedback = TactsuitVR.GetSpellFeedbackFromId(spellId);
                    if (leftHand)
                    {
                        while (!TimeManager.timeStopped && CastingLeft && spellId == CastingLeftSpellId)
                        {
                            if (Player.local != null && Player.local.creature != null
                                && Player.local.creature.mana != null && Player.local.creature.mana.casterLeft != null)
                            {
                                float intensity = 1.0f;
                                if (Player.local.creature.mana.casterLeft.spellInstance is SpellCastCharge)
                                {
                                    SpellCastCharge scc = (Player.local.creature.mana.casterLeft.spellInstance as SpellCastCharge);
                                    if (scc != null)
                                    {
                                        intensity = scc.currentCharge;
                                        if (intensity < 0.2f)
                                            intensity = 0.2f;
                                    }
                                }

                                if ((bool)(UnityEngine.Object)Player.local.creature.mana.casterLeft.ragdollHand.grabbedHandle)
                                {
                                    intensity *= 0.5f;
                                }

                                tactsuitVr.ProvideHapticFeedback(0, 0, feedback, false, intensity, TactsuitVR.FeedbackType.NoFeedback, true);
                                Thread.Sleep(SleepDurationSpellCast);
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        while (!TimeManager.timeStopped && CastingRight && spellId == CastingRightSpellId)
                        {
                            if (Player.local != null && Player.local.creature != null
                                && Player.local.creature.mana != null && Player.local.creature.mana.casterRight != null)
                            {
                                float intensity = 1.0f;
                                if (Player.local.creature.mana.casterRight.spellInstance is SpellCastCharge)
                                {
                                    SpellCastCharge scc = (Player.local.creature.mana.casterRight.spellInstance as SpellCastCharge);
                                    if (scc != null)
                                    {
                                        intensity = scc.currentCharge;
                                        if (intensity < 0.2f)
                                            intensity = 0.2f;
                                    }
                                }

                                if ((bool)(UnityEngine.Object)Player.local.creature.mana.casterRight.ragdollHand.grabbedHandle)
                                {
                                    intensity *= 0.5f;
                                }

                                tactsuitVr.ProvideHapticFeedback(0, 0, feedback, false, intensity, TactsuitVR.FeedbackType.NoFeedback, false);
                                Thread.Sleep(SleepDurationSpellCast);
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }

            [HarmonyPostfix]
            private static void Postfix(SpellCaster __instance, bool active)
            {
                if (__instance != null && Player.local?.creature != null && __instance.mana?.creature != null && __instance.mana.creature == Player.local.creature)
                {
                    if (active && __instance.spellInstance != null && __instance.isFiring)
                    {
                        if (__instance.ragdollHand.side == Side.Left)
                        {
                            if (!CastingLeft)
                            {
                                CastingLeft = true;
                                CastingLeftSpellId = __instance.spellInstance.id;
                                Thread thread = new Thread(() => SpellCastFunc(__instance.spellInstance.id, true));
                                thread.Start();
                            }
                        }
                        else
                        {
                            if (!CastingRight)
                            {
                                CastingRight = true;
                                CastingRightSpellId = __instance.spellInstance.id;
                                Thread thread = new Thread(() => SpellCastFunc(__instance.spellInstance.id, false));
                                thread.Start();
                            }
                        }
                    }
                    else
                    {
                        if (__instance != null && __instance.ragdollHand.side == Side.Left && CastingLeft)
                        {
                            CastingLeft = false;
                            CastingLeftSpellId = "";
                        }
                        else if (__instance != null && __instance.ragdollHand.side == Side.Right && CastingRight)
                        {
                            CastingRight = false;
                            CastingRightSpellId = "";
                        }
                    }
                }
            }
        }

        [HarmonyPatch("Merge")]
        [HarmonyPatch(typeof(SpellMergeData))]
        private static class SpellMergeDataMergePatch
        {
            private static bool Casting = false;

            private static void SpellMergeFunc(SpellMergeData __instance)
            {
                if (tactsuitVr != null)
                {
                    TactsuitVR.FeedbackType leftFeedback = TactsuitVR.GetSpellFeedbackFromId(__instance.leftSpellId);
                    TactsuitVR.FeedbackType rightFeedback = TactsuitVR.GetSpellFeedbackFromId(__instance.rightSpellId);
                    
                    while (!TimeManager.timeStopped && Casting)
                    {
                        if (Player.local != null && Player.local.creature != null
                            && Player.local.creature.mana != null)
                        {
                            float intensity = __instance.currentCharge / __instance.minCharge;                            

                            tactsuitVr.ProvideHapticFeedback(0, 0, leftFeedback, false, intensity, TactsuitVR.FeedbackType.NoFeedback, true);
                            tactsuitVr.ProvideHapticFeedback(0, 0, rightFeedback, false, intensity, TactsuitVR.FeedbackType.NoFeedback, false);
                            Thread.Sleep(SleepDurationSpellCast);
                        }
                        else
                        {
                            break;
                        }
                    }                    
                }
            }

            [HarmonyPostfix]
            private static void Postfix(SpellMergeData __instance, bool active)
            {
                if (__instance != null && Player.local?.creature != null && __instance.mana?.creature != null && __instance.mana.creature == Player.local.creature)
                {
                    if (active && __instance != null)
                    {
                        if (!Casting)
                        {
                            Casting = true;
                            Thread thread = new Thread(() => SpellMergeFunc(__instance));
                            thread.Start();
                        }
                    }
                    else
                    {                        
                        Casting = false;
                    }
                }
            }
        }

        private void CheckStates(Creature creature)
        {
            if (creature != null)
            {               
                #region Pushed

                if (Player.local.locomotion.isGrounded && !Player.local.locomotion.allowMove && Player.local.locomotion.moveDirection == UnityEngine.Vector3.zero && Player.local.locomotion.velocity.magnitude >= 0.1f && (hoverJetVFX == null))
                {
                    if (!beingPushed)
                    {
                        beingPushed = true;

                        Thread thread = new Thread(BeingPushedFunc);
                        thread.Start();
                        LOG("Player is being pushed by a force.");
                    }
                }

                if (!beingPushed && (hoverJetVFX == null))
                {
                    Item leftItem = creature.equipment.GetHeldItem(Side.Left);
                    Item rightItem = creature.equipment.GetHeldItem(Side.Right);

                    if (!noExplosionFeedback && Player.local.locomotion.isGrounded && Player.local.locomotion.moveDirection == UnityEngine.Vector3.zero && Player.local.locomotion.velocity.magnitude > 5f && Player.local.locomotion.velocity.y>=-TOLERANCE
                        && (leftItem == null || (leftItem != null && !leftItemUseStarted) || (leftItem != null && leftItemUseStarted && !leftItem.name.Contains("Grapple")))
                        && (rightItem == null || (rightItem != null && !rightItemUseStarted) || (rightItem != null && rightItemUseStarted && !rightItem.name.Contains("Grapple"))))
                    {
                        //if (!beingPushedOther)
                        //{
                        //    beingPushedOther = true;

                        //    Thread thread = new Thread(BeingPushedOtherFunc);
                        //    thread.Start();
                        //    LOG("Player is being pushed by a strong force like explosion.");
                        //}
                    }
                    else
                    {
                        if (Player.local.locomotion.velocity.magnitude > 3f && Player.local.locomotion.velocity.y >=-TOLERANCE)
                        {
                            if (leftItem != null && leftItem.name.Contains("Grapple") && leftItemUseStarted)
                            {
                                if (!beingPulledLeft)
                                {
                                    beingPulledLeft = true;

                                    Thread thread = new Thread(()=> BeingPulledFunc(Side.Left));
                                    thread.Start();
                                    LOG("Player is being pulled by grappling hook left.");
                                }
                            }

                            if (rightItem != null && rightItem.name.Contains("Grapple") && rightItemUseStarted)
                            {
                                if (!beingPulledRight)
                                {
                                    beingPulledRight = true;

                                    Thread thread = new Thread(() => BeingPulledFunc(Side.Right));
                                    thread.Start();
                                    LOG("Player is being pulled by grappling hook right.");
                                }
                            }
                        }
                    }
                }

                #endregion
                
                #region SuddenStop

                //if (Player.local.locomotion.moveDirection == UnityEngine.Vector3.zero && Player.local.locomotion.rb.velocity.magnitude < 0.1f && lastFrameVelocity.magnitude > 5.0f)
                //{
                //    float hitAngle = Utility.GetAngleForPosition(Player.local.transform.position + lastFrameVelocity);

                //    LOG("Hit a wall. Velocity before hit: " + lastFrameVelocity.magnitude.ToString(CultureInfo.InvariantCulture) + " Angle: " + hitAngle.ToString(CultureInfo.InvariantCulture));
                //    tactsuitVr.ProvideHapticFeedback(hitAngle, 0, TactsuitVR.FeedbackType.DamageVestBluntStoneLarge, false, lastFrameVelocity.magnitude/10f, TactsuitVR.FeedbackType.NoFeedback, false);
                //}

                //lastFrameVelocity = Player.local.locomotion.rb.velocity;

                #endregion

                #region Climbing

                climbingCheckTimeLeft -= deltaTime;

                if (!TimeManager.timeStopped && climbingCheckTimeLeft <= 0f)
                {
                    climbingCheckTimeLeft = 300;

                    Item leftObject = creature.equipment.GetHeldItem(Side.Left);
                    Item rightObject = creature.equipment.GetHeldItem(Side.Right);
                                       

                    if ((/*leftObject == null && Player.local?.handLeft?.link != null && Player.local?.handLeft?.link.isActive == true && Player.local?.handLeft?.link.playerJointActive == true && */Player.local?.handLeft?.ragdollHand?.climb != null && Player.local.handLeft.ragdollHand.climb.isGripping)
                        || (creature.ragdoll.ik != null && creature.ragdoll.ik.handLeftEnabled && creature.ragdoll.ik.handLeftTarget != null && leftObject == null && creature.equipment.GetHeldHandle(Side.Left) != null && !creature.equipment.GetHeldHandle(Side.Left).physicBody.isKinematic && Math.Abs(creature.ragdoll.ik.GetHandPositionWeight(Side.Left) - 1f) < TOLERANCE)
                        || grabbedLadderWithLeftHand
                        )
                    {
                        if (!leftHandClimbing)
                        {
                            leftHandClimbing = true;
                            Thread thread = new Thread(() => ClimbingFunc(Side.Left));
                            thread.Start();
                            LOG("Left hand climbing...");
                        }
                    }
                    else
                    {
                        leftHandClimbing = false;
                    }

                    if ((/*rightObject == null && Player.local?.handRight?.link != null && Player.local?.handRight?.link.isActive == true && Player.local?.handRight?.link.playerJointActive == true &&*/ Player.local?.handRight?.ragdollHand?.climb != null && Player.local.handRight.ragdollHand.climb.isGripping)
                        || (creature.ragdoll.ik != null && creature.ragdoll.ik.handRightEnabled && creature.ragdoll.ik.handRightTarget != null && rightObject == null && creature.equipment.GetHeldHandle(Side.Right) != null && !creature.equipment.GetHeldHandle(Side.Right).physicBody.isKinematic && Math.Abs(creature.ragdoll.ik.GetHandPositionWeight(Side.Right) - 1f) < TOLERANCE)
                        || grabbedLadderWithRightHand
                        )
                    {
                        if (!rightHandClimbing)
                        {
                            rightHandClimbing = true;
                            Thread thread = new Thread(() => ClimbingFunc(Side.Right));
                            thread.Start();
                            LOG("Right hand climbing...");
                        }
                    }
                    else
                    {
                        rightHandClimbing = false;
                    }
                }

                #endregion

                //#region Swimming
                //LOG("Player in water: " + Player.local.waterHandler.inWater + " submerged: " + Player.local.waterHandler.submergedRatio + " player velocity:" + Player.local.locomotion.velocity.magnitude);

                //if (Player.local.waterHandler.inWater && IntensitySwim>0.0001f && Player.local.waterHandler.submergedRatio >= 0.2f && Player.local.locomotion.velocity.magnitude >= 0.1f)
                //{
                //    float hitAngle = Utility.GetAngleForPosition(Player.local.locomotion.moveDirection);

                //    if (Player.local.waterHandler.submergedRatio >= 0.90f)
                //        tactsuitVr.ProvideHapticFeedback(hitAngle, 0, TactsuitVR.FeedbackType.SwimVest100, false, 1.00f, TactsuitVR.FeedbackType.NoFeedback, false);
                //    else if (Player.local.waterHandler.submergedRatio >= 0.70f)
                //        tactsuitVr.ProvideHapticFeedback(hitAngle, 0, TactsuitVR.FeedbackType.SwimVest80, false, 1.00f, TactsuitVR.FeedbackType.NoFeedback, false);
                //    else if (Player.local.waterHandler.submergedRatio >= 0.50f)
                //        tactsuitVr.ProvideHapticFeedback(hitAngle, 0, TactsuitVR.FeedbackType.SwimVest60, false, 1.00f, TactsuitVR.FeedbackType.NoFeedback, false);
                //    else if (Player.local.waterHandler.submergedRatio >= 0.30f)
                //        tactsuitVr.ProvideHapticFeedback(hitAngle, 0, TactsuitVR.FeedbackType.SwimVest40, false, 1.00f, TactsuitVR.FeedbackType.NoFeedback, false);
                //    else
                //        tactsuitVr.ProvideHapticFeedback(hitAngle, 0, TactsuitVR.FeedbackType.SwimVest20, false, 1.00f, TactsuitVR.FeedbackType.NoFeedback, false);
                //}
                //#endregion

                #region Shooting a weapon

                shootGunCheckTimeLeft -= deltaTime;

                if (!TimeManager.timeStopped && IntensityMultiplierGun > TOLERANCE && shootGunCheckTimeLeft <= 0f)
                {
                    shootGunCheckTimeLeft = 30;

                    if(leftItem !=null)
                    {
                        int fireMode = 0;
                        bool stunMode = false;
                        bool isChargedFire = false;
                        bool charging = false;
                        if (leftItemBlasterComponent != null)
                        {
                            fireMode = Utility.GetValue<int>(leftItemBlasterComponent, "currentFiremode");
                            stunMode = Utility.GetValuePrivate<bool>(leftItemBlasterComponent, "altFireEnabled");
                            isChargedFire = Utility.GetValuePrivate<bool>(leftItemBlasterComponent, "isChargedFire");

                            ParticleSystem chargeEffect = Utility.GetValuePrivateParticleSystem(leftItemBlasterComponent, "chargeEffect");
                            if (chargeEffect != null && stunMode == false)
                            {
                                charging = true;
                            }
                        }

                        bool modularFireArmIsFiring = false;
                        bool modularFireArmIsRoundChambered = false;
                        int modularFireArmFireMode = 1;
                        if (leftItemModularFireArmBaseComponent1 != null)
                        {
                            modularFireArmIsFiring = Utility.GetValue<bool>(leftItemModularFireArmBaseComponent1, "isFiring");
                            modularFireArmFireMode = Utility.GetValuePrivate<int>(leftItemModularFireArmBaseComponent1, "fireModeSelection");
                            modularFireArmIsRoundChambered = Utility.GetValuePrivate<bool>(leftItemModularFireArmBaseComponent1, "roundChambered");
                        }
                                                
                        if (leftItemModularFireArmBaseComponent2 != null)
                        {
                            modularFireArmIsFiring = Utility.GetValuePrivate<bool>(leftItemModularFireArmBaseComponent2, "triggerPressed");
                            modularFireArmFireMode = Utility.GetValuePrivate<int>(leftItemModularFireArmBaseComponent2, "fireModeSelection");
                            modularFireArmIsRoundChambered = modularFireArmIsFiring && leftItemUseStarted;
                        }

                        leftModularGunFiring = modularFireArmIsFiring;

                        if ((modularFireArmIsFiring && modularFireArmIsRoundChambered) || (charging && leftItemUseStarted) || (leftItemShootVFX != null && leftItemShootVFX.isPlaying) || (leftItemShootSFX != null && leftItemShootSFX.isPlaying) || (leftItemShoot2VFX != null && leftItemShoot2VFX.isPlaying) || (leftItemChargeSFX != null && leftItemChargeSFX.isPlaying) || (leftItemChargeReadySFX != null && leftItemChargeReadySFX.isPlaying))
                        {
                            if ((leftItemModularFireArmBaseComponent1 != null || leftItemModularFireArmBaseComponent2 != null) && modularFireArmIsFiring && modularFireArmIsRoundChambered && modularFireArmFireMode != 0)
                            {
                                if (modularFireArmFireMode == 3 || modularFireArmFireMode == 2) //This item allows multi shots
                                {
                                    if (!shootingLeftGun)
                                    {
                                        shootingLeftGun = true;
                                        Thread thread = new Thread(() => FireGunModularFireArms(leftItem.name, leftItem.data.displayName, true, modularFireArmFireMode == 2));
                                        thread.Start();
                                        LOG("Player is firing left gun: " + leftItem.data.displayName);
                                    }
                                }
                                else //This item doesn't allow multi shot. Don't play the effect until leftitemusestarted is first false, then true again.
                                {
                                    leftItemUseStarted = false;
                                    TactsuitVR.FeedbackType feedback = TactsuitVR.GetPlayerGunShootFeedback(leftItem.name, leftItem.data.displayName, false);
                                    tactsuitVr?.ProvideHapticFeedback(0, 0, feedback, true, 1.0f, TactsuitVR.FeedbackType.NoFeedback, true);
                                    TactsuitVR.FeedbackType feedbackKickback = TactsuitVR.GetPlayerGunShootFeedbackKickback(feedback, Side.Left);
                                    tactsuitVr?.ProvideHapticFeedback(0, 0, feedbackKickback, true, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);

                                    LOG("Fired left gun: " + leftItem.data.displayName);
                                }
                            }

                            if ((leftItemModularFireArmBaseComponent1 == null && leftItemModularFireArmBaseComponent2 == null))
                            {
                                if (((leftItemShootVFX != null && leftItemShootVFX.isPlaying) || (leftItemShootSFX != null && leftItemShootSFX.isPlaying) || (leftItemChargeSFX != null && leftItemChargeSFX.isPlaying) || (leftItemChargeReadySFX != null && leftItemChargeReadySFX.isPlaying))
                                                                            && ((leftItemUseStarted || (charging && leftItemUseStarted)) && GunUseMultipleShotMap.ContainsKey(leftItem.data.displayName))) // Item allows use and use started
                                {
                                    if (leftItemBlasterComponent != null)
                                        LOG("Left gun fireMode:" + fireMode.ToString() + " StunMode:" + stunMode.ToString());

                                    bool value = false;
                                    if (GunUseMultipleShotMap.TryGetValue(leftItem.data.displayName, out value) || leftItemBlasterComponent != null)
                                    {
                                        if ((leftItemBlasterComponent == null && value) || (fireMode < 0 || fireMode == 3) || (charging && leftItemUseStarted)) //This item allows multi shots
                                        {
                                            if (!shootingLeftGun)
                                            {
                                                shootingLeftGun = true;
                                                Thread thread = new Thread(() => FireGun(leftItem.name, leftItem.data.displayName, false, true, leftItemBlasterComponent != null && stunMode, fireMode == 3, (charging && leftItemUseStarted)));
                                                thread.Start();
                                                LOG("Player is firing left gun: " + leftItem.data.displayName);
                                            }
                                        }
                                        else //This item doesn't allow multi shot. Don't play the effect until leftitemusestarted is first false, then true again.
                                        {
                                            leftItemUseStarted = false;

                                            TactsuitVR.FeedbackType feedback = TactsuitVR.GetPlayerGunShootFeedback(leftItem.name, leftItem.data.displayName, leftItemBlasterComponent != null && stunMode);
                                            tactsuitVr?.ProvideHapticFeedback(0, 0, feedback, true, 1.0f, TactsuitVR.FeedbackType.NoFeedback, true);
                                            if (!leftItem.name.Contains("Grapple"))
                                            {
                                                TactsuitVR.FeedbackType feedbackKickback = TactsuitVR.GetPlayerGunShootFeedbackKickback(feedback, Side.Left);
                                                tactsuitVr?.ProvideHapticFeedback(0, 0, feedbackKickback, true, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);
                                            }

                                            LOG("Fired left gun: " + leftItem.data.displayName);
                                        }
                                    }
                                }
                                if (((leftItemShootVFX != null && leftItemShootVFX.isPlaying) || (leftItemShootSFX != null && leftItemShootSFX.isPlaying) || (leftItemShoot2VFX != null && leftItemShoot2VFX.isPlaying))
                                                                            && (leftItemAltUseStarted && GunAltUseMultipleShotMap.ContainsKey(leftItem.data.displayName)) && leftItemBlasterComponent == null) // Item allows alt use and use started
                                {
                                    bool value = false;
                                    if (GunAltUseMultipleShotMap.TryGetValue(leftItem.data.displayName, out value))
                                    {
                                        if (value) //This item allows multi shots
                                        {
                                            if (!altShootingLeftGun)
                                            {
                                                altShootingLeftGun = true;
                                                Thread thread = new Thread(() => FireGun(leftItem.name, leftItem.data.displayName, true, true, false, false, false));
                                                thread.Start();
                                                LOG("Player is alt firing left gun: " + leftItem.data.displayName);
                                            }
                                        }
                                        else //This item doesn't allow multi shot. Don't play the effect until leftitemaltusestarted is first false, then true again.
                                        {
                                            leftItemAltUseStarted = false;
                                            TactsuitVR.FeedbackType feedback = TactsuitVR.GetPlayerGunShootFeedback(leftItem.name, leftItem.data.displayName, false);
                                            tactsuitVr?.ProvideHapticFeedback(0, 0, feedback, true, 1.0f, TactsuitVR.FeedbackType.NoFeedback, true);
                                            if (!leftItem.name.Contains("Grapple"))
                                            {
                                                TactsuitVR.FeedbackType feedbackKickback = TactsuitVR.GetPlayerGunShootFeedbackKickback(feedback, Side.Left);
                                                tactsuitVr?.ProvideHapticFeedback(0, 0, feedbackKickback, true, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);
                                            }

                                            LOG("Alt Fired left gun: " + leftItem.data.displayName);
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (rightItem != null)
                    {
                        int fireMode = 0;
                        bool stunMode = false;
                        bool isChargedFire = false;
                        bool charging = false;

                        if (rightItemBlasterComponent != null)
                        {
                            fireMode = Utility.GetValue<int>(rightItemBlasterComponent, "currentFiremode");
                            stunMode = Utility.GetValuePrivate<bool>(rightItemBlasterComponent, "altFireEnabled");
                            isChargedFire = Utility.GetValuePrivate<bool>(rightItemBlasterComponent, "isChargedFire");

                            ParticleSystem chargeEffect = Utility.GetValuePrivateParticleSystem(rightItemBlasterComponent, "chargeEffect");
                            if (chargeEffect != null && stunMode == false)
                            {
                                charging = true;
                            }
                        }

                        bool modularFireArmIsFiring = false;
                        bool modularFireArmIsRoundChambered = false;
                        int modularFireArmFireMode = 1;

                        if (rightItemModularFireArmBaseComponent1 != null)
                        {
                            modularFireArmIsFiring = Utility.GetValue<bool>(rightItemModularFireArmBaseComponent1, "isFiring");
                            modularFireArmFireMode = Utility.GetValuePrivate<int>(rightItemModularFireArmBaseComponent1, "fireModeSelection");
                            modularFireArmIsRoundChambered = Utility.GetValuePrivate<bool>(rightItemModularFireArmBaseComponent1, "roundChambered");
                        }
                                                
                        if (rightItemModularFireArmBaseComponent2 != null)
                        {
                            modularFireArmIsFiring = Utility.GetValuePrivate<bool>(rightItemModularFireArmBaseComponent2, "triggerPressed");
                            modularFireArmFireMode = Utility.GetValuePrivate<int>(rightItemModularFireArmBaseComponent2, "fireModeSelection");
                            modularFireArmIsRoundChambered = modularFireArmIsFiring && rightItemUseStarted;
                        }

                        rightModularGunFiring = modularFireArmIsFiring;

                        if ((modularFireArmIsFiring && modularFireArmIsRoundChambered) || (charging && rightItemUseStarted) || (rightItemShootVFX != null && rightItemShootVFX.isPlaying) || (rightItemShootSFX != null && rightItemShootSFX.isPlaying) || (rightItemShoot2VFX != null && rightItemShoot2VFX.isPlaying) || (rightItemChargeSFX != null && rightItemChargeSFX.isPlaying) || (rightItemChargeReadySFX != null && rightItemChargeReadySFX.isPlaying))
                        {
                            //if (!GunUseMultipleShotMap.ContainsKey(rightItem.data.displayName))
                            //{
                            //    LOG("ERROR: GunUseMultipleShotMap doesn't contain key for " + rightItem.data.displayName);
                            //}

                            if ((rightItemModularFireArmBaseComponent1 != null || rightItemModularFireArmBaseComponent2!=null) && modularFireArmIsFiring && modularFireArmIsRoundChambered && modularFireArmFireMode != 0)
                            {
                                if (modularFireArmFireMode == 3 || modularFireArmFireMode == 2) //This item allows multi shots
                                {
                                    if (!shootingRightGun)
                                    {
                                        shootingRightGun = true;
                                        Thread thread = new Thread(() => FireGunModularFireArms(rightItem.name, rightItem.data.displayName, false, modularFireArmFireMode == 2));
                                        thread.Start();
                                        LOG("Player is firing right gun: " + rightItem.data.displayName);
                                    }
                                }
                                else //This item doesn't allow multi shot. Don't play the effect until leftitemusestarted is first false, then true again.
                                {
                                    rightItemUseStarted = false;
                                    TactsuitVR.FeedbackType feedback = TactsuitVR.GetPlayerGunShootFeedback(rightItem.name, rightItem.data.displayName, false);
                                    tactsuitVr?.ProvideHapticFeedback(0, 0, feedback, true, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);
                                    TactsuitVR.FeedbackType feedbackKickback = TactsuitVR.GetPlayerGunShootFeedbackKickback(feedback, Side.Right);
                                    tactsuitVr?.ProvideHapticFeedback(0, 0, feedbackKickback, true, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);

                                    LOG("Fired right gun: " + rightItem.data.displayName);
                                }
                            }

                            if ((rightItemModularFireArmBaseComponent1 == null && rightItemModularFireArmBaseComponent2 == null))
                            {
                                if (((rightItemShootVFX != null && rightItemShootVFX.isPlaying) || (rightItemShootSFX != null && rightItemShootSFX.isPlaying) || (rightItemChargeSFX != null && rightItemChargeSFX.isPlaying) || (rightItemChargeReadySFX != null && rightItemChargeReadySFX.isPlaying))
                                                                            && ((rightItemUseStarted || (charging && rightItemUseStarted)) && GunUseMultipleShotMap.ContainsKey(rightItem.data.displayName))) // Item allows use and use started
                                {
                                    if (rightItemBlasterComponent != null)
                                        LOG("Right blaster fireMode:" + fireMode.ToString() + " StunMode:" + stunMode.ToString());

                                    bool value = false;
                                    if (GunUseMultipleShotMap.TryGetValue(rightItem.data.displayName, out value) || rightItemBlasterComponent != null || !GunUseMultipleShotMap.ContainsKey(rightItem.data.displayName))
                                    {
                                        if ((rightItemBlasterComponent == null && value) || (fireMode < 0 || fireMode == 3) || (charging && rightItemUseStarted)) //This item allows multi shots
                                        {
                                            if (!shootingRightGun)
                                            {
                                                shootingRightGun = true;
                                                Thread thread = new Thread(() => FireGun(rightItem.name, rightItem.data.displayName, false, false, rightItemBlasterComponent != null && stunMode, fireMode == 3, (charging && rightItemUseStarted)));
                                                thread.Start();
                                                LOG("Player is firing right gun: " + rightItem.data.displayName);
                                            }
                                        }
                                        else //This item doesn't allow multi shot. Don't play the effect until rightitemusestarted is first false, then true again.
                                        {
                                            rightItemUseStarted = false;

                                            TactsuitVR.FeedbackType feedback = TactsuitVR.GetPlayerGunShootFeedback(rightItem.name, rightItem.data.displayName, rightItemBlasterComponent != null && stunMode);
                                            tactsuitVr?.ProvideHapticFeedback(0, 0, feedback, true, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);
                                            if (!rightItem.name.Contains("Grapple"))
                                            {
                                                TactsuitVR.FeedbackType feedbackKickback = TactsuitVR.GetPlayerGunShootFeedbackKickback(feedback, Side.Right);
                                                tactsuitVr?.ProvideHapticFeedback(0, 0, feedbackKickback, true, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);
                                            }

                                            LOG("Fired right gun: " + rightItem.data.displayName);
                                        }
                                    }
                                }

                                if (((rightItemShootVFX != null && rightItemShootVFX.isPlaying) || (rightItemShootSFX != null && rightItemShootSFX.isPlaying) || (rightItemShoot2VFX != null && rightItemShoot2VFX.isPlaying))
                                                                            && (rightItemAltUseStarted && GunAltUseMultipleShotMap.ContainsKey(rightItem.data.displayName)) && rightItemBlasterComponent == null) // Item allows alt use and use started
                                {
                                    bool value = false;
                                    if (GunAltUseMultipleShotMap.TryGetValue(rightItem.data.displayName, out value))
                                    {
                                        if (value) //This item allows multi shots
                                        {
                                            if (!altShootingRightGun)
                                            {
                                                altShootingRightGun = true;
                                                Thread thread = new Thread(() => FireGun(rightItem.name, rightItem.data.displayName, true, false, false, false, false));
                                                thread.Start();
                                                LOG("Player is alt firing right gun: " + rightItem.data.displayName);
                                            }
                                        }
                                        else //This item doesn't allow multi shot. Don't play the effect until rightitemaltusestarted is first false, then true again.
                                        {
                                            rightItemAltUseStarted = false;
                                            TactsuitVR.FeedbackType feedback = TactsuitVR.GetPlayerGunShootFeedback(rightItem.name, rightItem.data.displayName, false);
                                            tactsuitVr?.ProvideHapticFeedback(0, 0, feedback, true, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);
                                            if (!rightItem.name.Contains("Grapple"))
                                            {
                                                TactsuitVR.FeedbackType feedbackKickback = TactsuitVR.GetPlayerGunShootFeedbackKickback(feedback, Side.Right);
                                                tactsuitVr?.ProvideHapticFeedback(0, 0, feedbackKickback, true, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);
                                            }

                                            LOG("Alt Fired right gun: " + rightItem.data.displayName);
                                        }
                                    }
                                }
                            }
                        }
                    }

                    //Barzel support
                    if (creature?.animator?.GetBoneTransform(HumanBodyBones.LeftShoulder) != null && creature?.animator?.GetBoneTransform(HumanBodyBones.LeftShoulder).childCount > 0)
                    {
                        for (int i = 0; i < creature?.animator?.GetBoneTransform(HumanBodyBones.LeftShoulder).childCount; i++)
                        {
                            if (creature?.animator?.GetBoneTransform(HumanBodyBones.LeftShoulder)?.GetChild(i)?.Find("muzflash")?.gameObject != null)
                            {
                                leftShoulderTurretShootVFX = creature.animator.GetBoneTransform(HumanBodyBones.LeftShoulder).GetChild(i).Find("muzflash").gameObject.GetComponent<ParticleSystem>();
                                if (leftShoulderTurretShootVFX != null && leftShoulderTurretShootVFX.isPlaying)
                                {
                                    if (!shootingLeftShoulderTurret)
                                    {
                                        shootingLeftShoulderTurret = true;
                                        Thread thread = new Thread(FireLeftShoulderTurret);
                                        thread.Start();
                                        LOG("Player is firing left shoulder turret.");
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        leftShoulderTurretShootVFX = null;
                    }

                    if (creature?.animator?.GetBoneTransform(HumanBodyBones.RightLowerLeg) != null && creature?.animator?.GetBoneTransform(HumanBodyBones.RightLowerLeg).childCount > 0)
                    {
                        for (int i = 0; i < creature.animator.GetBoneTransform(HumanBodyBones.RightLowerLeg).childCount; i++)
                        {
                            if (creature?.animator?.GetBoneTransform(HumanBodyBones.RightLowerLeg)?.GetChild(i)?.Find("Flames_vfx1")?.gameObject != null)
                            {
                                hoverJetVFX = creature.animator.GetBoneTransform(HumanBodyBones.RightLowerLeg).GetChild(i).Find("Flames_vfx1").gameObject.GetComponent<ParticleSystem>();
                                if (hoverJetVFX != null && hoverJetVFX.isPlaying)
                                {
                                    if (!hoveringWithHoverJet)
                                    {
                                        hoveringWithHoverJet = true;
                                        Thread thread = new Thread(FireHoverJet);
                                        thread.Start();
                                        LOG("Player is firing hover jet.");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        hoverJetVFX = null;
                    }
                }

                #endregion

            }
            else
            {
                HeartbeatingFast = false;
                Heartbeating = false;
            }
        }

        #endregion

        #region Events

        private void ContinueArrowEffect(CollisionInstance collisionstruct, float hitAngle, float locationHeight, float intensity, TactsuitVR.FeedbackType feedback, bool reflected)
        {
            Thread.Sleep(400);
            while(collisionstruct!=null && collisionstruct.active && Player.local!=null)
            {
                Thread.Sleep(SleepDurationStuckArrow);
                tactsuitVr?.ProvideHapticFeedback(hitAngle, locationHeight, feedback, false, intensity * IntensityMultiplierStuckArrow * IntensityStuckArrow, TactsuitVR.FeedbackType.NoFeedback, reflected);
            }
        }

        private void PlayerGotHit(CollisionInstance collisionstruct, bool kill, float fixedLocationHeight)
        {
            LOG("Player got hit by something. ImpactVelocity:" + collisionstruct.impactVelocity.magnitude.ToString(CultureInfo.InvariantCulture));

            float hitAngle = Utility.GetAngleForPosition(collisionstruct.contactPoint);
            Direction direction = Utility.GetDirectionFromVector(collisionstruct.impactVelocity, collisionstruct.contactPoint, hitAngle);

            string targetColliderName = (collisionstruct.targetCollider != null ? collisionstruct.targetCollider.name : "") + " " + (collisionstruct.targetColliderGroup?.collisionHandler != null ? collisionstruct.targetColliderGroup.collisionHandler.name : "");

            float locationHeight = fixedLocationHeight;

            string modifiedTargetColliderName = targetColliderName;
            bool heightCalculated = false;
            if (PlayFallbackEffectsForArmHead && !targetColliderName.IsNullOrEmpty())
            {
                if (targetColliderName.Contains("Head") && !tactsuitVr.HeadActive)
                {
                    modifiedTargetColliderName = "Neck";
                    if (hitAngle > 90f && hitAngle < 270f) hitAngle = 180f;
                    else hitAngle = 0f;
                }
                else if(targetColliderName.Contains("Arm"))
                {
                    if (targetColliderName.Contains("Left") && !tactsuitVr.ArmsActive)
                    {
                        modifiedTargetColliderName = "Part_LeftShoulder";
                        locationHeight = 0.45f;
                        hitAngle = 90f;
                        heightCalculated = true;
                    }
                    else if (targetColliderName.Contains("Right") && !tactsuitVr.ArmsActive)
                    {
                        modifiedTargetColliderName = "Part_RightShoulder";
                        locationHeight = 0.45f;
                        hitAngle = 270f;
                        heightCalculated = true;
                    }
                }
            }
            
            Imbue imbue = null;
            if (collisionstruct.sourceColliderGroup?.collisionHandler?.item?.imbues != null)
            {
                if (collisionstruct.sourceColliderGroup?.collisionHandler?.item?.imbues.Count > 0)
                    imbue = collisionstruct.sourceColliderGroup?.collisionHandler?.item?.imbues[0];
            }

            string imbueSpellId = "";

            if (imbue?.spellCastBase?.imbueMetalEffectId != null && (imbue.spellCastBase.imbueMetalEffectId != ""))
            {
                var imbueMaterialData = Catalog.GetData<MaterialData>(imbue.spellCastBase.imbueMetalEffectId, false);
                imbueSpellId = imbueMaterialData != null ? imbueMaterialData.id : "";
            }
            else if (imbue?.spellCastBase?.imbueCrystalEffectId != null && (imbue.spellCastBase.imbueCrystalEffectId != ""))
            {
                var imbueMaterialData = Catalog.GetData<MaterialData>(imbue.spellCastBase.imbueCrystalEffectId, false);
                imbueSpellId = imbueMaterialData != null ? imbueMaterialData.id : "";
            }
            else if (imbue?.spellCastBase?.imbueBladeEffectId != null && (imbue.spellCastBase.imbueBladeEffectId != ""))
            {
                var imbueMaterialData = Catalog.GetData<MaterialData>(imbue.spellCastBase.imbueBladeEffectId, false);
                imbueSpellId = imbueMaterialData != null ? imbueMaterialData.id : "";
            }

            if (imbueSpellId == "" && imbue != null)
            {
                if(imbue.spellCastBase is SpellCastLightning)
                    imbueSpellId = "Lightning";
                else if (imbue.spellCastBase is SpellCastGravity)
                    imbueSpellId = "Gravity";
                else if (imbue.spellCastBase is SpellCastProjectile)
                    imbueSpellId = "Fire";
            }

            if (Logging)
{
                LOG("Player got hit: TargetCollider: " + modifiedTargetColliderName + " TargetColliderGroup: " + (collisionstruct.targetColliderGroup?.collisionHandler != null ? collisionstruct.targetColliderGroup.collisionHandler.name : "null") + " SourceCollider:" + (collisionstruct.sourceCollider != null ? collisionstruct.sourceCollider.name : "Unknown") + " TargetMaterial: " +(collisionstruct.targetMaterial != null ? collisionstruct.targetMaterial.id : "null") + " SourceMaterial:" + (collisionstruct.sourceMaterial != null ? collisionstruct.sourceMaterial.id : "null"));
				
}

            TactsuitVR.FeedbackType feedback = TactsuitVR.GetPlayerGotHitFeedbackType(collisionstruct.damageStruct.damageType, collisionstruct.sourceMaterial, collisionstruct.targetMaterial, collisionstruct.casterHand?.spellInstance != null ? collisionstruct.casterHand.spellInstance.id : "", 
                (collisionstruct.damageStruct.damager != null && collisionstruct.damageStruct.damager.data != null) ? (collisionstruct.damageStruct.damager.data.penetrationDamage <= 15.0f ? TactsuitVR.PenetrationSize.Small : TactsuitVR.PenetrationSize.Large) : TactsuitVR.PenetrationSize.Small, (collisionstruct.sourceCollider != null ? collisionstruct.sourceCollider.name : "Unknown"), modifiedTargetColliderName, direction, imbueSpellId, (collisionstruct.damageStruct.damager?.data != null ? collisionstruct.damageStruct.damager.data.id : ""));
            
            if (!heightCalculated && Math.Abs(fixedLocationHeight) < TOLERANCE && collisionstruct.targetCollider != null)
            {
                //Part_Head, Part_Neck
                //Part_Spine, Part_RightLowerArm, Part_RightUpperArm, Part_LeftLowerArm, Part_LeftUpperArm
                //Part_LeftShoulder, Part_RightShoulder
                //Part_Chest
                //Part_Hips
                //Part_LeftUpperLeg, Part_RightUpperLeg
                if (targetColliderName.Contains("Head") || targetColliderName.Contains("Neck"))
                {
                    locationHeight = 0.45f;
                }
                else if (targetColliderName.Contains("Spine"))
                {
                    locationHeight = (((float) (RandomNumber.Between(0, 6))) / 20.0f);
                }
                else if (targetColliderName.Contains("Shoulder"))
                {
                    locationHeight = 0.45f;
                }
                else if (targetColliderName.Contains("Chest"))
                {
                    locationHeight = (((float) (RandomNumber.Between(0, 5))) / 10.0f) - 0.20f;
                }
                else if (targetColliderName.Contains("Hips"))
                {
                    locationHeight = -0.25f;
                }
                else if (targetColliderName.Contains("Leg"))
                {
                    locationHeight = -0.40f;    
                }
            }

            float intensity = collisionstruct.intensity;

            if (intensity <= 0.001f)
            {
                if (collisionstruct.damageStruct.damage > 0f)
                    intensity = Math.Min(1.0f, collisionstruct.damageStruct.damage);
                else if (collisionstruct.impactVelocity.magnitude > 2f)
                {
                    intensity = Math.Min(1.0f, collisionstruct.impactVelocity.magnitude/5f);
                }
            }

            if(Logging)
                LOG("Player got hit by Spell?: " + (collisionstruct.casterHand?.spellInstance != null ? collisionstruct.casterHand.spellInstance.id : "null") + " Damager: " + (collisionstruct.damageStruct.damager != null ? collisionstruct.damageStruct.damager.name : "") + " DamagerDataId: " + (collisionstruct.damageStruct.damager?.data != null ? collisionstruct.damageStruct.damager.data.id : "") + " DamagerDataMaterialDamageId: " + (collisionstruct.damageStruct.damager?.data != null ? collisionstruct.damageStruct.damager.data.damageModifierId : "") + " Imbue: " + imbueSpellId + " - Source: " + (collisionstruct.sourceCollider != null ? collisionstruct.sourceCollider.name : "Unknown") + " on " + (collisionstruct.targetCollider != null ? collisionstruct.targetCollider.name : "whole body") + " with Hit Angle: " + hitAngle + " LocationHeight: " + locationHeight.ToString(CultureInfo.InvariantCulture) + " Intensity:" + collisionstruct.intensity.ToString(CultureInfo.InvariantCulture) + " " + ("Materials: " + ((collisionstruct.sourceMaterial != null ? collisionstruct.sourceMaterial.id : "Null") + " > " + (collisionstruct.targetMaterial != null ? collisionstruct.targetMaterial.id : "Null"))) + " DamageType: " + Utility.GetDamageTypeName(collisionstruct.damageStruct.damageType) + " Penetration: " + ((collisionstruct.damageStruct.damager != null && collisionstruct.damageStruct.damager.data != null) ? (collisionstruct.damageStruct.damager.data.penetrationDamage <= 15.0f ? "Small" : "Large") : ""));

            bool reflected = (modifiedTargetColliderName.Contains("Arm") || modifiedTargetColliderName.Contains("Hand")) && modifiedTargetColliderName.Contains("Left");
            
            tactsuitVr?.ProvideHapticFeedback(hitAngle, locationHeight, feedback, false, kill ? intensity * 50f : intensity, TactsuitVR.FeedbackType.NoFeedback, reflected);
            if (kill)
            {
                Thread.Sleep(250);
                tactsuitVr?.ProvideHapticFeedback(hitAngle, locationHeight, feedback, false, intensity * 50f, TactsuitVR.FeedbackType.NoFeedback, reflected);
                Thread.Sleep(500);
                tactsuitVr?.ProvideHapticFeedback(hitAngle, locationHeight, feedback, false, intensity * 25f, TactsuitVR.FeedbackType.NoFeedback, reflected);
            }
            else
            {
                if (IntensityMultiplierStuckArrow * IntensityStuckArrow > TOLERANCE && collisionstruct.active &&
                    (feedback == TactsuitVR.FeedbackType.DamageHeadArrow
                    || feedback == TactsuitVR.FeedbackType.DamageHeadFireArrow
                    || feedback == TactsuitVR.FeedbackType.DamageHeadIceArrow
                    || feedback == TactsuitVR.FeedbackType.DamageHeadLightningArrow
                    || feedback == TactsuitVR.FeedbackType.DamageRightArmArrow
                    || feedback == TactsuitVR.FeedbackType.DamageRightArmFireArrow
                    || feedback == TactsuitVR.FeedbackType.DamageRightArmLightningArrow
                    || feedback == TactsuitVR.FeedbackType.DamageRightArmIceArrow
                    || feedback == TactsuitVR.FeedbackType.DamageVestArrow
                    || feedback == TactsuitVR.FeedbackType.DamageVestFireArrow
                    || feedback == TactsuitVR.FeedbackType.DamageVestIceArrow
                    || feedback == TactsuitVR.FeedbackType.DamageVestLightningArrow))
                {
                    var @struct = collisionstruct;
                    Thread thread = new Thread(() => ContinueArrowEffect(@struct, hitAngle, locationHeight, intensity, feedback, reflected));
                    thread.Start();
                }
            }
        }

        private void OnCreatureHitFunc(Creature creature, CollisionInstance collisionstruct, EventTime eventTime)
        {
            try
            {
                if (creature != null && Player.local?.creature != null && Player.local.creature == creature && collisionstruct != null)
                {
                    var @struct = collisionstruct;
                    Thread thread = new Thread(() => PlayerGotHit(@struct, false, 0f));
                    thread.Start();
                }
                else if (creature != null && Player.local?.creature != null && Player.local.creature != creature && collisionstruct != null)
                {
                    //For debug purposes
                    LOG("------------------------>An NPC got hit by Spell: " + (collisionstruct.casterHand?.spellInstance != null ? collisionstruct.casterHand.spellInstance.id : "null") + " Source:" + (collisionstruct.sourceCollider != null ? collisionstruct.sourceCollider.name : "Unknown") + " on " + collisionstruct.targetCollider.name + " with Intensity:" + collisionstruct.intensity.ToString(CultureInfo.InvariantCulture) + " " + ((collisionstruct.sourceMaterial != null && collisionstruct.targetMaterial != null) ? ("Materials: " + collisionstruct.sourceMaterial.id + " > " + collisionstruct.targetMaterial.id) : "") + " DamageType: " + Utility.GetDamageTypeName(collisionstruct.damageStruct.damageType) + " Penetration: " + ((collisionstruct.damageStruct.damager != null && collisionstruct.damageStruct.damager.data != null) ? (collisionstruct.damageStruct.damager.data.penetrationDamage <= 15.0f ? "Small" : "Large") : ""));
                }

                if (collisionstruct != null && collisionstruct.intensity > 0.01f)
                {
                    if (collisionstruct.IsDoneByPlayer() && collisionstruct.sourceCollider != null)
                    {
                        LOG("Player hit something...");
                        LOG("->Player hit something with " + collisionstruct.sourceCollider.name);

                        if ((bool)(UnityEngine.Object)collisionstruct.sourceColliderGroup?.collisionHandler?.item?.rightPlayerHand)
                        {
                            if (collisionstruct.sourceColliderGroup.collisionHandler.item.data?.type == ItemData.Type.Body) //punch
                            {
                                TactsuitVR.FeedbackType feedback = GetPlayerPunchFeedback(collisionstruct.targetMaterial != null ? collisionstruct.targetMaterial.id : "");
                                tactsuitVr.ProvideHapticFeedback(0, 0, feedback, false, collisionstruct.intensity, TactsuitVR.FeedbackType.NoFeedback, false);
                                LOG("Player punched something with right Hand: Intensity: " + collisionstruct.intensity);
                            }
                            else
                            {
                                TactsuitVR.FeedbackType feedback = TactsuitVR.GetPlayerMeleeFeedbackType(collisionstruct.damageStruct.damageType, collisionstruct.sourceMaterial, collisionstruct.targetMaterial);
                                tactsuitVr?.ProvideHapticFeedback(0, 0, feedback, false, collisionstruct.intensity, TactsuitVR.FeedbackType.NoFeedback, false);
                                LOG("Player hit something with right Hand: Intensity: " + collisionstruct.intensity);
                            }
                        }

                        if ((bool)(UnityEngine.Object)collisionstruct.sourceColliderGroup?.collisionHandler?.item?.leftPlayerHand)
                        {
                            if (collisionstruct.sourceColliderGroup.collisionHandler.item.data?.type == ItemData.Type.Body) //punch
                            {
                                TactsuitVR.FeedbackType feedback = GetPlayerPunchFeedback(collisionstruct.targetMaterial != null ? collisionstruct.targetMaterial.id : "");
                                tactsuitVr.ProvideHapticFeedback(0, 0, feedback, false, collisionstruct.intensity, TactsuitVR.FeedbackType.NoFeedback, true);
                                LOG("Player punched something with left Hand: Intensity: " + collisionstruct.intensity);
                            }
                            else
                            {
                                TactsuitVR.FeedbackType feedback = TactsuitVR.GetPlayerMeleeFeedbackType(collisionstruct.damageStruct.damageType, collisionstruct.sourceMaterial, collisionstruct.targetMaterial);
                                tactsuitVr?.ProvideHapticFeedback(0, 0, feedback, false, collisionstruct.intensity, TactsuitVR.FeedbackType.NoFeedback, true);
                                LOG("Player hit something with left Hand weapon: Intensity: " + collisionstruct.intensity);
                            }
                        }
                    }

                    if ((bool)(UnityEngine.Object)collisionstruct.targetColliderGroup && collisionstruct.targetColliderGroup?.collisionHandler?.item != null)
                    {
                        if ((bool)(UnityEngine.Object)collisionstruct.targetColliderGroup.collisionHandler?.item?.leftPlayerHand)
                        {
                            TactsuitVR.FeedbackType feedback = TactsuitVR.GetPlayerMeleeFeedbackType(collisionstruct.damageStruct.damageType, collisionstruct.sourceMaterial, collisionstruct.targetMaterial);
                            tactsuitVr?.ProvideHapticFeedback(0, 0, feedback, false, collisionstruct.intensity, TactsuitVR.FeedbackType.NoFeedback, true);
                            LOG("Something hit Player's left Hand item: Intensity: " + collisionstruct.intensity);
                        }

                        if ((bool)(UnityEngine.Object)collisionstruct.targetColliderGroup.collisionHandler?.item?.rightPlayerHand)
                        {
                            TactsuitVR.FeedbackType feedback = TactsuitVR.GetPlayerMeleeFeedbackType(collisionstruct.damageStruct.damageType, collisionstruct.sourceMaterial, collisionstruct.targetMaterial);
                            tactsuitVr?.ProvideHapticFeedback(0, 0, feedback, false, collisionstruct.intensity, TactsuitVR.FeedbackType.NoFeedback, false);
                            LOG("Something hit Player's right Hand item: Intensity: " + collisionstruct.intensity);
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void OnCreatureParryFunc(Creature parriedCreature, Item parriedItem, Creature parryingCreature, Item parryingItem, CollisionInstance collisionstruct)
        {
            if (collisionstruct.damageStruct.damage <= 0.00001f)
                return;

            LOG("Parry. ");

            if ((bool) (UnityEngine.Object) collisionstruct.sourceColliderGroup)
            {
                if ((bool) (UnityEngine.Object) collisionstruct.sourceColliderGroup.collisionHandler.item?.leftPlayerHand)
                {
                    TactsuitVR.FeedbackType feedback = TactsuitVR.GetPlayerMeleeFeedbackType(collisionstruct.damageStruct.damageType, collisionstruct.sourceMaterial, collisionstruct.targetMaterial);
                    tactsuitVr?.ProvideHapticFeedback(0, 0, feedback, false, collisionstruct.intensity, TactsuitVR.FeedbackType.NoFeedback, true);
                    LOG("Player parry something with left Hand: Intensity: " + collisionstruct.intensity);
                }

                if ((bool) (UnityEngine.Object) collisionstruct.sourceColliderGroup.collisionHandler.item?.rightPlayerHand)
                {
                    TactsuitVR.FeedbackType feedback = TactsuitVR.GetPlayerMeleeFeedbackType(collisionstruct.damageStruct.damageType, collisionstruct.sourceMaterial, collisionstruct.targetMaterial);
                    tactsuitVr?.ProvideHapticFeedback(0, 0, feedback, false, collisionstruct.intensity, TactsuitVR.FeedbackType.NoFeedback, false);
                    LOG("Player parry something with right Hand: Intensity: " + collisionstruct.intensity);
                }
            }

            if ((bool) (UnityEngine.Object) collisionstruct.targetColliderGroup)
            {
                if ((bool) (UnityEngine.Object) collisionstruct.targetColliderGroup.collisionHandler.item?.leftPlayerHand)
                {
                    TactsuitVR.FeedbackType feedback = TactsuitVR.GetPlayerMeleeFeedbackType(collisionstruct.damageStruct.damageType, collisionstruct.sourceMaterial, collisionstruct.targetMaterial);
                    tactsuitVr?.ProvideHapticFeedback(0, 0, feedback, false, collisionstruct.intensity, TactsuitVR.FeedbackType.NoFeedback, true);
                    LOG("Something parry Player's left Hand item: Intensity: " + collisionstruct.intensity);
                }

                if ((bool) (UnityEngine.Object) collisionstruct.targetColliderGroup.collisionHandler.item?.rightPlayerHand)
                {
                    TactsuitVR.FeedbackType feedback = TactsuitVR.GetPlayerMeleeFeedbackType(collisionstruct.damageStruct.damageType, collisionstruct.sourceMaterial, collisionstruct.targetMaterial);
                    tactsuitVr?.ProvideHapticFeedback(0, 0, feedback, false, collisionstruct.intensity, TactsuitVR.FeedbackType.NoFeedback, false);
                    LOG("Something parry Player's right Hand item: Intensity: " + collisionstruct.intensity);
                }
            }
        }
        
        private void OnKillFunc(CollisionInstance collisionstruct, EventTime eventTime)
        {
            if (eventTime != EventTime.OnStart)
                return;
            var @struct = collisionstruct;
            Thread thread = new Thread(() => PlayerGotHit(@struct, true,0f));
            thread.Start();
            LOG("Player is killed.");
            Heartbeating = false;
            HeartbeatingFast = false;
            //lastFrameVelocity = Vector3.zero;
        }

        private void OnCreatureKillFunc(Creature creature, Player player, CollisionInstance collisionstruct, EventTime eventTime)
        {
            if (creature && Player.local && Player.local.creature && Player.local.creature == creature)
            {
                var @struct = collisionstruct;
                Thread thread = new Thread(() => PlayerGotHit(@struct, true,0f));
                thread.Start();
                LOG("Player is killed.");
                Heartbeating = false;
                HeartbeatingFast = false;
                tactsuitVr?.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.FallDamage, true, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);
                tactsuitVr?.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.PlayerSpellCrushRight, true, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);
                tactsuitVr?.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.PlayerSpellCrushRight, true, 1.0f, TactsuitVR.FeedbackType.NoFeedback, true);
                //lastFrameVelocity = Vector3.zero;
            }
        }
        
        private void OnCreatureHealFunc(Creature creature, float heal, Creature healer, EventTime eventTime)
        {
            if (creature && Player.local && Player.local.creature && Player.local.creature == creature)
            {
                //Play just healed effect.
                tactsuitVr?.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.Healing, true, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);
                LOG("Player is healed. Amount: " + heal.ToString(CultureInfo.InvariantCulture));
            }
        }

        private void OnDeflectFunc(Creature source, Item item, Creature target)
        {
            if (source && Player.local && Player.local.creature && Player.local.creature == source)
            {
                LOG("Player deflected source. Item: " + item.itemId);
            }

            if (target && Player.local && Player.local.creature && Player.local.creature == target)
            {
                LOG("Player deflected target. Item: " + item.itemId);
            }
        }

        private void OnEdibleConsumedFunc(Item edible, Creature consumer, EventTime eventTime)
        {
            if (consumer && Player.local && Player.local.creature && Player.local.creature == consumer)
            {
                tactsuitVr?.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.ConsumableFood, true, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);
            }
        }

        private void OnLiquidConsumedFunc(LiquidContainer liquidContainer, Creature consumer, EventTime eventTime)
        {
            if (consumer && Player.local && Player.local.creature && Player.local.creature == consumer)
            {
                tactsuitVr?.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.ConsumableFood, true, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);
            }
        }
        

        #endregion
    }
}