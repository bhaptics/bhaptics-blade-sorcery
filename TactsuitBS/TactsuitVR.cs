using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Bhaptics.Tact;
using ThunderRoad;
using UnityEngine;

namespace TactsuitBS
{
    public class TactsuitVR
    {
        public float IntensityDefaultDamage = 1.0f;
        public float IntensityPlayerBowPull = 1.0f;

        public float IntensityPlayerMeleeBladeWoodPierce = 1.0f;
        public float IntensityPlayerMeleeBladeMetalPierce = 1.0f;
        public float IntensityPlayerMeleeBladeStonePierce = 1.0f;
        public float IntensityPlayerMeleeBladeFabricPierce = 1.0f;
        public float IntensityPlayerMeleeBladeFleshPierce = 1.0f;
        public float IntensityPlayerMeleeBladeWoodSlash = 1.0f;
        public float IntensityPlayerMeleeBladeMetalSlash = 1.0f;
        public float IntensityPlayerMeleeBladeStoneSlash = 1.0f;
        public float IntensityPlayerMeleeBladeFabricSlash = 1.0f;
        public float IntensityPlayerMeleeBladeFleshSlash = 1.0f;
        public float IntensityPlayerMeleeBladeWoodBlunt = 1.0f;
        public float IntensityPlayerMeleeBladeMetalBlunt = 1.0f;
        public float IntensityPlayerMeleeBladeStoneBlunt = 1.0f;
        public float IntensityPlayerMeleeBladeFabricBlunt = 1.0f;
        public float IntensityPlayerMeleeBladeFleshBlunt = 1.0f;
        public float IntensityPlayerMeleeWoodWoodBlunt = 1.0f;
        public float IntensityPlayerMeleeWoodMetalBlunt = 1.0f;
        public float IntensityPlayerMeleeWoodStoneBlunt = 1.0f;
        public float IntensityPlayerMeleeWoodFabricBlunt = 1.0f;
        public float IntensityPlayerMeleeWoodFleshBlunt = 1.0f;
        public float IntensityPlayerMeleeStoneStoneBlunt = 1.0f;
        public float IntensityPlayerMeleeStoneFabricBlunt = 1.0f;
        public float IntensityPlayerMeleeStoneFleshBlunt = 1.0f;

        public float IntensityPlayerMeleeLightsaberClashRight = 1.0f;
        public float IntensityPlayerMeleeLightsaberSlashRight = 1.0f;
        public float IntensityPlayerMeleeLightsaberPierceRight = 1.0f;
        public float IntensityPlayerMeleeLightsaberBluntRight = 1.0f;

        public float IntensityPlayerSpellFire = 1.0f;
        public float IntensityPlayerSpellLightning = 1.0f;
        public float IntensityPlayerSpellGravity = 1.0f;
        public float IntensityPlayerSpellIce = 1.0f;
        public float IntensityPlayerSpellCrush = 1.0f;
        public float IntensityPlayerSpellHeal = 1.0f;
        public float IntensityPlayerSpellImplosion = 1.0f;
        public float IntensityPlayerSpellInvisibility = 1.0f;
        public float IntensityPlayerSpellTesla = 1.0f;
        public float IntensityPlayerSpellUtility = 1.0f;
        public float IntensityPlayerSpellCorruption = 1.0f;
        public float IntensityPlayerSpellTeleport = 1.0f;
        public float IntensityPlayerSpellRasengan = 1.0f;
        public float IntensityPlayerSpellNeedle = 1.0f;
        public float IntensityPlayerSpellDrain = 1.0f;
        public float IntensityPlayerSpellForceField = 1.0f;
        public float IntensityPlayerSpellOther = 1.0f;

        public float IntensityPlayerTelekinesisActive = 1.0f;
        public float IntensityPlayerTelekinesisPull = 0.3f;
        public float IntensityPlayerTelekinesisRepel = 0.3f;
        public float IntensityPlayerTelekinesisCatch = 2.0f;

        public float IntensityDamageVestArrow= 1.0f;
        public float IntensityDamageArmArrow= 1.0f;
        public float IntensityDamageHeadArrow= 1.0f;
        public float IntensityDamageVestFireArrow= 1.0f;
        public float IntensityDamageArmFireArrow= 1.0f;
        public float IntensityDamageHeadFireArrow= 1.0f;
        public float IntensityDamageVestLightningArrow= 1.0f;
        public float IntensityDamageArmLightningArrow= 1.0f;
        public float IntensityDamageHeadLightningArrow= 1.0f;
        public float IntensityDamageVestIceArrow= 1.0f;
        public float IntensityDamageArmIceArrow= 1.0f;
        public float IntensityDamageHeadIceArrow= 1.0f;
        public float IntensityDamageHeadFire= 1.0f;
        public float IntensityDamageHeadLightning= 1.0f;
        public float IntensityDamageHeadGravity= 1.0f;
        public float IntensityDamageHeadIce= 1.0f;
        public float IntensityDamageHeadDrain= 1.0f;
        public float IntensityDamageHeadEnergy= 1.0f;
        public float IntensityDamageArmFire= 1.0f;
        public float IntensityDamageArmLightning= 1.0f;
        public float IntensityDamageArmGravity= 1.0f;
        public float IntensityDamageArmIce= 1.0f;
        public float IntensityDamageArmDrain= 1.0f;
        public float IntensityDamageArmEnergy= 1.0f;
        
        public float IntensityDamageVestEnergy = 1.0f;
        public float IntensityDamageVestFire = 1.0f;
        public float IntensityDamageVestIce = 1.0f;
        public float IntensityDamageVestDrain = 1.0f;
        public float IntensityDamageVestLightning = 1.0f;
        public float IntensityDamageVestGravity = 1.0f;

        public float IntensityDamageVestPierceBladeSmall = 1.0f;
        public float IntensityDamageVestSlashBladeSmall = 1.0f;
        public float IntensityDamageVestBluntBladeSmall = 1.0f;
        public float IntensityDamageVestBluntWoodSmall = 1.0f;
        public float IntensityDamageVestBluntMetalSmall = 1.0f;
        public float IntensityDamageVestBluntStoneSmall = 1.0f;
        public float IntensityDamageVestBluntFleshSmall = 1.0f;
        public float IntensityDamageVestPierceFireSmall = 1.0f;
        public float IntensityDamageVestSlashFireSmall = 1.0f;
        public float IntensityDamageVestBluntFireSmall = 1.0f;
        public float IntensityDamageVestPierceLightningSmall = 1.0f;
        public float IntensityDamageVestSlashLightningSmall = 1.0f;
        public float IntensityDamageVestBluntLightningSmall = 1.0f;
        public float IntensityDamageVestPierceIceSmall = 1.0f;
        public float IntensityDamageVestSlashIceSmall = 1.0f;
        public float IntensityDamageVestBluntIceSmall = 1.0f;
        public float IntensityDamageVestPierceBladeLarge = 1.0f;
        public float IntensityDamageVestSlashBladeLarge = 1.0f;
        public float IntensityDamageVestBluntBladeLarge = 1.0f;
        public float IntensityDamageVestBluntWoodLarge = 1.0f;
        public float IntensityDamageVestBluntMetalLarge = 1.0f;
        public float IntensityDamageVestBluntStoneLarge = 1.0f;
        public float IntensityDamageVestBluntFleshLarge = 1.0f;
        public float IntensityDamageVestPierceFireLarge = 1.0f;
        public float IntensityDamageVestSlashFireLarge = 1.0f;
        public float IntensityDamageVestBluntFireLarge = 1.0f;
        public float IntensityDamageVestPierceLightningLarge = 1.0f;
        public float IntensityDamageVestSlashLightningLarge = 1.0f;
        public float IntensityDamageVestBluntLightningLarge = 1.0f;
        public float IntensityDamageVestPierceIceLarge = 1.0f;
        public float IntensityDamageVestSlashIceLarge = 1.0f;
        public float IntensityDamageVestBluntIceLarge = 1.0f;

        public float IntensityDamageVestBlaster = 1.0f;
        public float IntensityDamageVestBlasterStun = 1.0f;
        public float IntensityDamageArmBlaster = 1.0f;
        public float IntensityDamageArmBlasterStun = 1.0f;
        public float IntensityDamageHeadBlaster = 1.0f;
        public float IntensityDamageHeadBlasterStun = 1.0f;
        
        public float IntensityDamageVestPierceLightsaber = 1.0f;
        public float IntensityDamageVestSlashLightsaber = 1.0f;
        public float IntensityDamageVestBluntLightsaber = 1.0f;
        public float IntensityDamageRightArmBluntLightsaber = 1.0f;
        public float IntensityDamageRightArmPierceLightsaber = 1.0f;
        public float IntensityDamageRightArmSlashLightsaber = 1.0f;
        public float IntensityDamageHeadPierceLightsaber = 1.0f;
        public float IntensityDamageHeadSlashLightsaber = 1.0f;
        public float IntensityDamageHeadBluntLightsaber = 1.0f;

        public float IntensityDamageArmPierceBladeSmall = 1.0f;
        public float IntensityDamageArmSlashBladeSmall = 1.0f;
        public float IntensityDamageArmBluntBladeSmall = 1.0f;
        public float IntensityDamageArmBluntWoodSmall = 1.0f;
        public float IntensityDamageArmBluntMetalSmall = 1.0f;
        public float IntensityDamageArmBluntStoneSmall = 1.0f;
        public float IntensityDamageArmBluntFleshSmall = 1.0f;
        public float IntensityDamageArmPierceFireSmall = 1.0f;
        public float IntensityDamageArmSlashFireSmall = 1.0f;
        public float IntensityDamageArmBluntFireSmall = 1.0f;
        public float IntensityDamageArmPierceLightningSmall = 1.0f;
        public float IntensityDamageArmSlashLightningSmall = 1.0f;
        public float IntensityDamageArmBluntLightningSmall = 1.0f;
        public float IntensityDamageArmPierceIceSmall = 1.0f;
        public float IntensityDamageArmSlashIceSmall = 1.0f;
        public float IntensityDamageArmBluntIceSmall = 1.0f;
        public float IntensityDamageArmPierceBladeLarge = 1.0f;
        public float IntensityDamageArmSlashBladeLarge = 1.0f;
        public float IntensityDamageArmBluntBladeLarge = 1.0f;
        public float IntensityDamageArmBluntWoodLarge = 1.0f;
        public float IntensityDamageArmBluntMetalLarge = 1.0f;
        public float IntensityDamageArmBluntStoneLarge = 1.0f;
        public float IntensityDamageArmBluntFleshLarge = 1.0f;
        public float IntensityDamageArmPierceFireLarge = 1.0f;
        public float IntensityDamageArmSlashFireLarge = 1.0f;
        public float IntensityDamageArmBluntFireLarge = 1.0f;
        public float IntensityDamageArmPierceLightningLarge = 1.0f;
        public float IntensityDamageArmSlashLightningLarge = 1.0f;
        public float IntensityDamageArmBluntLightningLarge = 1.0f;
        public float IntensityDamageArmPierceIceLarge = 1.0f;
        public float IntensityDamageArmSlashIceLarge = 1.0f;
        public float IntensityDamageArmBluntIceLarge = 1.0f;
        public float IntensityDamageHeadPierceBladeSmall = 1.0f;
        public float IntensityDamageHeadSlashBladeSmall = 1.0f;
        public float IntensityDamageHeadBluntBladeSmall = 1.0f;
        public float IntensityDamageHeadBluntWoodSmall = 1.0f;
        public float IntensityDamageHeadBluntMetalSmall = 1.0f;
        public float IntensityDamageHeadBluntStoneSmall = 1.0f;
        public float IntensityDamageHeadBluntFleshSmall = 1.0f;
        public float IntensityDamageHeadPierceFireSmall = 1.0f;
        public float IntensityDamageHeadSlashFireSmall = 1.0f;
        public float IntensityDamageHeadBluntFireSmall = 1.0f;
        public float IntensityDamageHeadPierceLightningSmall = 1.0f;
        public float IntensityDamageHeadSlashLightningSmall = 1.0f;
        public float IntensityDamageHeadBluntLightningSmall = 1.0f;
        public float IntensityDamageHeadPierceIceSmall = 1.0f;
        public float IntensityDamageHeadSlashIceSmall = 1.0f;
        public float IntensityDamageHeadBluntIceSmall = 1.0f;
        public float IntensityDamageHeadPierceBladeLarge = 1.0f;
        public float IntensityDamageHeadSlashBladeLarge = 1.0f;
        public float IntensityDamageHeadBluntBladeLarge = 1.0f;
        public float IntensityDamageHeadBluntWoodLarge = 1.0f;
        public float IntensityDamageHeadBluntMetalLarge = 1.0f;
        public float IntensityDamageHeadBluntStoneLarge = 1.0f;
        public float IntensityDamageHeadBluntFleshLarge = 1.0f;
        public float IntensityDamageHeadPierceFireLarge = 1.0f;
        public float IntensityDamageHeadSlashFireLarge = 1.0f;
        public float IntensityDamageHeadBluntFireLarge = 1.0f;
        public float IntensityDamageHeadPierceLightningLarge = 1.0f;
        public float IntensityDamageHeadSlashLightningLarge = 1.0f;
        public float IntensityDamageHeadBluntLightningLarge = 1.0f;
        public float IntensityDamageHeadPierceIceLarge = 1.0f;
        public float IntensityDamageHeadSlashIceLarge = 1.0f;
        public float IntensityDamageHeadBluntIceLarge = 1.0f;

        public float IntensityHeartBeat = 0.5f;
        public float IntensityHeartBeatFast = 0.5f;
        public float IntensityHealing = 1.5f;
        public float IntensityPotionDrinking = 1.5f;
        public float IntensityPoisonDrinking = 1.5f;
        public float IntensityFallDamage = 1.5f;
        public float IntensityFallDamageFeet = 1.0f;
        public float IntensitySlowMotion = 1.0f;
        public float IntensityHolster = 1.0f;
        public float IntensityUnholster = 1.0f;
        public float IntensityHolsterArrow = 1.0f;
        public float IntensityUnholsterArrow = 1.0f;
        public float IntensityClimbing = 1.0f;
        public float IntensityPlayerKickOther = 1.0f;
        public float IntensityPlayerKickWood = 1.0f;
        public float IntensityPlayerKickFlesh = 1.0f;
        public float IntensityPlayerKickStone = 1.0f;
        public float IntensityPlayerKickMetal = 1.0f;
        public float IntensityPlayerKickFabric = 1.0f;
        public float IntensityPlayerPunchOther = 1.0f;
        public float IntensityPlayerPunchWood = 1.0f;
        public float IntensityPlayerPunchFlesh = 1.0f;
        public float IntensityPlayerPunchStone = 1.0f;
        public float IntensityPlayerPunchMetal = 1.0f;
        public float IntensityPlayerPunchFabric = 1.0f;

        public float IntensityPlayerGun = 1.0f;
        public float IntensityPlayerGunBlaster = 1.0f;
        public float IntensityPlayerGunAutomatic = 1.0f;
        public float IntensityPlayerGunBallistic = 1.0f;
        public float IntensityPlayerGunSpray = 1.0f;
        public float IntensityPlayerGunMiniGun = 1.0f;
        public float IntensityPlayerGunBazooka = 1.0f;
        public float IntensityPlayerGunHeavy = 1.0f;
        public float IntensityPlayerGunLaser = 1.0f;
        public float IntensityPlayerGunRifle = 1.0f;
        public float IntensityPlayerGunPistol = 1.0f;
        public float IntensityPlayerGunPlasma = 1.0f;
        public float IntensityPlayerGunShotgun = 1.0f;
        public float IntensityPlayerGunEnergy = 1.0f;
        public float IntensityKickbackPlayerGun = 1.0f;
        public float IntensityKickbackPlayerGunPistol = 1.0f;
        public float IntensityKickbackPlayerGunBallistic = 1.0f;
        public float IntensityKickbackPlayerGunLaser = 1.0f;
        public float IntensityKickbackPlayerGunPlasma = 1.0f;
        public float IntensityKickbackPlayerGunSpray = 1.0f;
        public float IntensityKickbackPlayerGunHeavy = 1.0f;

        public float IntensityPlayerThrow = 1.0f;

        public float IntensityExplosion = 1.0f;

        public float IntensityShoulderTurret = 1.0f;
        public float IntensityHoverJetFeet = 1.0f;



        public bool Logging = false;
        
        public TactsuitVR()
        {
            FillFeedbackList();
        }

        void LOG(string logStr)
        {
            if (Logging)
            {
                Utility.LOG(logStr);
            }
        }

        private void FillFeedbackList()
        {
            feedbackMap.Clear();
            feedbackMap.Add(FeedbackType.HeartBeat, new Feedback(FeedbackType.HeartBeat, "HeartBeat_", 0));
            feedbackMap.Add(FeedbackType.HeartBeatFast, new Feedback(FeedbackType.HeartBeatFast, "HeartBeatFast_", 0));

            feedbackMap.Add(FeedbackType.DefaultDamage, new Feedback(FeedbackType.DefaultDamage, "DefaultDamage_", 0));

            feedbackMap.Add(FeedbackType.PlayerBowPullRight, new Feedback(FeedbackType.PlayerBowPullRight, "PlayerBowPullRight_", 0));
            
            feedbackMap.Add(FeedbackType.PlayerMeleeBladeWoodPierceRight, new Feedback(FeedbackType.PlayerMeleeBladeWoodPierceRight, "PlayerMeleeBladeWoodPierceRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerMeleeBladeMetalPierceRight, new Feedback(FeedbackType.PlayerMeleeBladeMetalPierceRight, "PlayerMeleeBladeMetalPierceRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerMeleeBladeStonePierceRight, new Feedback(FeedbackType.PlayerMeleeBladeStonePierceRight, "PlayerMeleeBladeStonePierceRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerMeleeBladeFabricPierceRight, new Feedback(FeedbackType.PlayerMeleeBladeFabricPierceRight, "PlayerMeleeBladeFabricPierceRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerMeleeBladeFleshPierceRight, new Feedback(FeedbackType.PlayerMeleeBladeFleshPierceRight, "PlayerMeleeBladeFleshPierceRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerMeleeBladeWoodSlashRight, new Feedback(FeedbackType.PlayerMeleeBladeWoodSlashRight, "PlayerMeleeBladeWoodSlashRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerMeleeBladeMetalSlashRight, new Feedback(FeedbackType.PlayerMeleeBladeMetalSlashRight, "PlayerMeleeBladeMetalSlashRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerMeleeBladeStoneSlashRight, new Feedback(FeedbackType.PlayerMeleeBladeStoneSlashRight, "PlayerMeleeBladeStoneSlashRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerMeleeBladeFabricSlashRight, new Feedback(FeedbackType.PlayerMeleeBladeFabricSlashRight, "PlayerMeleeBladeFabricSlashRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerMeleeBladeFleshSlashRight, new Feedback(FeedbackType.PlayerMeleeBladeFleshSlashRight, "PlayerMeleeBladeFleshSlashRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerMeleeBladeWoodBluntRight, new Feedback(FeedbackType.PlayerMeleeBladeWoodBluntRight, "PlayerMeleeBladeWoodBluntRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerMeleeBladeMetalBluntRight, new Feedback(FeedbackType.PlayerMeleeBladeMetalBluntRight, "PlayerMeleeBladeMetalBluntRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerMeleeBladeStoneBluntRight, new Feedback(FeedbackType.PlayerMeleeBladeStoneBluntRight, "PlayerMeleeBladeStoneBluntRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerMeleeBladeFabricBluntRight, new Feedback(FeedbackType.PlayerMeleeBladeFabricBluntRight, "PlayerMeleeBladeFabricBluntRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerMeleeBladeFleshBluntRight, new Feedback(FeedbackType.PlayerMeleeBladeFleshBluntRight, "PlayerMeleeBladeFleshBluntRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerMeleeWoodWoodBluntRight, new Feedback(FeedbackType.PlayerMeleeWoodWoodBluntRight, "PlayerMeleeWoodWoodBluntRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerMeleeWoodMetalBluntRight, new Feedback(FeedbackType.PlayerMeleeWoodMetalBluntRight, "PlayerMeleeWoodMetalBluntRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerMeleeWoodStoneBluntRight, new Feedback(FeedbackType.PlayerMeleeWoodStoneBluntRight, "PlayerMeleeWoodStoneBluntRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerMeleeWoodFabricBluntRight, new Feedback(FeedbackType.PlayerMeleeWoodFabricBluntRight, "PlayerMeleeWoodFabricBluntRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerMeleeWoodFleshBluntRight, new Feedback(FeedbackType.PlayerMeleeWoodFleshBluntRight, "PlayerMeleeWoodFleshBluntRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerMeleeStoneStoneBluntRight, new Feedback(FeedbackType.PlayerMeleeStoneStoneBluntRight, "PlayerMeleeStoneStoneBluntRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerMeleeStoneFabricBluntRight, new Feedback(FeedbackType.PlayerMeleeStoneFabricBluntRight, "PlayerMeleeStoneFabricBluntRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerMeleeStoneFleshBluntRight, new Feedback(FeedbackType.PlayerMeleeStoneFleshBluntRight, "PlayerMeleeStoneFleshBluntRight_", 0));

            feedbackMap.Add(FeedbackType.PlayerMeleeLightsaberClashRight, new Feedback(FeedbackType.PlayerMeleeLightsaberClashRight, "PlayerMeleeLightsaberClashRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerMeleeLightsaberSlashRight, new Feedback(FeedbackType.PlayerMeleeLightsaberSlashRight, "PlayerMeleeLightsaberSlashRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerMeleeLightsaberPierceRight, new Feedback(FeedbackType.PlayerMeleeLightsaberPierceRight, "PlayerMeleeLightsaberPierceRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerMeleeLightsaberBluntRight, new Feedback(FeedbackType.PlayerMeleeLightsaberBluntRight, "PlayerMeleeLightsaberBluntRight_", 0));

            feedbackMap.Add(FeedbackType.PlayerSpellFireRight, new Feedback(FeedbackType.PlayerSpellFireRight, "PlayerSpellFireRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerSpellLightningRight, new Feedback(FeedbackType.PlayerSpellLightningRight, "PlayerSpellLightningRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerSpellGravityRight, new Feedback(FeedbackType.PlayerSpellGravityRight, "PlayerSpellGravityRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerSpellIceRight, new Feedback(FeedbackType.PlayerSpellIceRight, "PlayerSpellIceRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerSpellCrushRight, new Feedback(FeedbackType.PlayerSpellCrushRight, "PlayerSpellCrushRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerSpellHealRight, new Feedback(FeedbackType.PlayerSpellHealRight, "PlayerSpellHealRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerSpellImplosionRight, new Feedback(FeedbackType.PlayerSpellImplosionRight, "PlayerSpellImplosionRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerSpellInvisibilityRight, new Feedback(FeedbackType.PlayerSpellInvisibilityRight, "PlayerSpellInvisibilityRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerSpellTeslaRight, new Feedback(FeedbackType.PlayerSpellTeslaRight, "PlayerSpellTeslaRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerSpellUtilityRight, new Feedback(FeedbackType.PlayerSpellUtilityRight, "PlayerSpellUtilityRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerSpellCorruptionRight, new Feedback(FeedbackType.PlayerSpellCorruptionRight, "PlayerSpellCorruptionRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerSpellTeleportRight, new Feedback(FeedbackType.PlayerSpellTeleportRight, "PlayerSpellTeleportRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerSpellRasenganRight, new Feedback(FeedbackType.PlayerSpellRasenganRight, "PlayerSpellRasenganRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerSpellNeedleRight, new Feedback(FeedbackType.PlayerSpellNeedleRight, "PlayerSpellNeedleRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerSpellDrainRight, new Feedback(FeedbackType.PlayerSpellDrainRight, "PlayerSpellDrainRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerSpellForceFieldRight, new Feedback(FeedbackType.PlayerSpellForceFieldRight, "PlayerSpellForceFieldRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerSpellOtherRight, new Feedback(FeedbackType.PlayerSpellOtherRight, "PlayerSpellOtherRight_", 0));

            feedbackMap.Add(FeedbackType.PlayerTelekinesisActiveRight, new Feedback(FeedbackType.PlayerTelekinesisActiveRight, "PlayerTelekinesisActiveRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerTelekinesisPullRight, new Feedback(FeedbackType.PlayerTelekinesisPullRight, "PlayerTelekinesisPullRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerTelekinesisRepelRight, new Feedback(FeedbackType.PlayerTelekinesisRepelRight, "PlayerTelekinesisRepelRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerTelekinesisCatchRight, new Feedback(FeedbackType.PlayerTelekinesisCatchRight, "PlayerTelekinesisCatchRight_", 0));

            feedbackMap.Add(FeedbackType.DamageVestPierceBladeSmall, new Feedback(FeedbackType.DamageVestPierceBladeSmall, "DamageVestPierceBladeSmall_", 0));
            feedbackMap.Add(FeedbackType.DamageVestSlashBladeSmallLRD, new Feedback(FeedbackType.DamageVestSlashBladeSmallLRD, "DamageVestSlashBladeSmallLRD_", 0));
            feedbackMap.Add(FeedbackType.DamageVestSlashBladeSmallLRU, new Feedback(FeedbackType.DamageVestSlashBladeSmallLRU, "DamageVestSlashBladeSmallLRU_", 0));
            feedbackMap.Add(FeedbackType.DamageVestSlashBladeSmallRLD, new Feedback(FeedbackType.DamageVestSlashBladeSmallRLD, "DamageVestSlashBladeSmallRLD_", 0));
            feedbackMap.Add(FeedbackType.DamageVestSlashBladeSmallRLU, new Feedback(FeedbackType.DamageVestSlashBladeSmallRLU, "DamageVestSlashBladeSmallRLU_", 0));
            feedbackMap.Add(FeedbackType.DamageVestBluntBladeSmall, new Feedback(FeedbackType.DamageVestBluntBladeSmall, "DamageVestBluntBladeSmall_", 0));
            feedbackMap.Add(FeedbackType.DamageVestBluntWoodSmall, new Feedback(FeedbackType.DamageVestBluntWoodSmall, "DamageVestBluntWoodSmall_", 0));
            feedbackMap.Add(FeedbackType.DamageVestBluntMetalSmall, new Feedback(FeedbackType.DamageVestBluntMetalSmall, "DamageVestBluntMetalSmall_", 0));
            feedbackMap.Add(FeedbackType.DamageVestBluntStoneSmall, new Feedback(FeedbackType.DamageVestBluntStoneSmall, "DamageVestBluntStoneSmall_", 0));
            feedbackMap.Add(FeedbackType.DamageVestBluntFleshSmall, new Feedback(FeedbackType.DamageVestBluntFleshSmall, "DamageVestBluntFleshSmall_", 0));
            feedbackMap.Add(FeedbackType.DamageVestPierceFireSmall, new Feedback(FeedbackType.DamageVestPierceFireSmall, "DamageVestPierceFireSmall_", 0));
            feedbackMap.Add(FeedbackType.DamageVestSlashFireSmallLRD, new Feedback(FeedbackType.DamageVestSlashFireSmallLRD, "DamageVestSlashFireSmallLRD_", 0));
            feedbackMap.Add(FeedbackType.DamageVestSlashFireSmallLRU, new Feedback(FeedbackType.DamageVestSlashFireSmallLRU, "DamageVestSlashFireSmallLRU_", 0));
            feedbackMap.Add(FeedbackType.DamageVestSlashFireSmallRLD, new Feedback(FeedbackType.DamageVestSlashFireSmallRLD, "DamageVestSlashFireSmallRLD_", 0));
            feedbackMap.Add(FeedbackType.DamageVestSlashFireSmallRLU, new Feedback(FeedbackType.DamageVestSlashFireSmallRLU, "DamageVestSlashFireSmallRLU_", 0));
            feedbackMap.Add(FeedbackType.DamageVestBluntFireSmall, new Feedback(FeedbackType.DamageVestBluntFireSmall, "DamageVestBluntFireSmall_", 0));
            feedbackMap.Add(FeedbackType.DamageVestPierceLightningSmall, new Feedback(FeedbackType.DamageVestPierceLightningSmall, "DamageVestPierceLightningSmall_", 0));
            feedbackMap.Add(FeedbackType.DamageVestSlashLightningSmallLRD, new Feedback(FeedbackType.DamageVestSlashLightningSmallLRD, "DamageVestSlashLightningSmallLRD_", 0));
            feedbackMap.Add(FeedbackType.DamageVestSlashLightningSmallLRU, new Feedback(FeedbackType.DamageVestSlashLightningSmallLRU, "DamageVestSlashLightningSmallLRU_", 0));
            feedbackMap.Add(FeedbackType.DamageVestSlashLightningSmallRLD, new Feedback(FeedbackType.DamageVestSlashLightningSmallRLD, "DamageVestSlashLightningSmallRLD_", 0));
            feedbackMap.Add(FeedbackType.DamageVestSlashLightningSmallRLU, new Feedback(FeedbackType.DamageVestSlashLightningSmallRLU, "DamageVestSlashLightningSmallRLU_", 0));
            feedbackMap.Add(FeedbackType.DamageVestBluntLightningSmall, new Feedback(FeedbackType.DamageVestBluntLightningSmall, "DamageVestBluntLightningSmall_", 0));
            feedbackMap.Add(FeedbackType.DamageVestPierceIceSmall, new Feedback(FeedbackType.DamageVestPierceIceSmall, "DamageVestPierceIceSmall_", 0));
            feedbackMap.Add(FeedbackType.DamageVestSlashIceSmallLRD, new Feedback(FeedbackType.DamageVestSlashIceSmallLRD, "DamageVestSlashIceSmallLRD_", 0));
            feedbackMap.Add(FeedbackType.DamageVestSlashIceSmallLRU, new Feedback(FeedbackType.DamageVestSlashIceSmallLRU, "DamageVestSlashIceSmallLRU_", 0));
            feedbackMap.Add(FeedbackType.DamageVestSlashIceSmallRLD, new Feedback(FeedbackType.DamageVestSlashIceSmallRLD, "DamageVestSlashIceSmallRLD_", 0));
            feedbackMap.Add(FeedbackType.DamageVestSlashIceSmallRLU, new Feedback(FeedbackType.DamageVestSlashIceSmallRLU, "DamageVestSlashIceSmallRLU_", 0));
            feedbackMap.Add(FeedbackType.DamageVestBluntIceSmall, new Feedback(FeedbackType.DamageVestBluntIceSmall, "DamageVestBluntIceSmall_", 0));
            feedbackMap.Add(FeedbackType.DamageVestPierceBladeLarge, new Feedback(FeedbackType.DamageVestPierceBladeLarge, "DamageVestPierceBladeLarge_", 0));
            feedbackMap.Add(FeedbackType.DamageVestSlashBladeLargeLRD, new Feedback(FeedbackType.DamageVestSlashBladeLargeLRD, "DamageVestSlashBladeLargeLRD_", 0));
            feedbackMap.Add(FeedbackType.DamageVestSlashBladeLargeLRU, new Feedback(FeedbackType.DamageVestSlashBladeLargeLRU, "DamageVestSlashBladeLargeLRU_", 0));
            feedbackMap.Add(FeedbackType.DamageVestSlashBladeLargeRLD, new Feedback(FeedbackType.DamageVestSlashBladeLargeRLD, "DamageVestSlashBladeLargeRLD_", 0));
            feedbackMap.Add(FeedbackType.DamageVestSlashBladeLargeRLU, new Feedback(FeedbackType.DamageVestSlashBladeLargeRLU, "DamageVestSlashBladeLargeRLU_", 0));
            feedbackMap.Add(FeedbackType.DamageVestBluntBladeLarge, new Feedback(FeedbackType.DamageVestBluntBladeLarge, "DamageVestBluntBladeLarge_", 0));
            feedbackMap.Add(FeedbackType.DamageVestBluntWoodLarge, new Feedback(FeedbackType.DamageVestBluntWoodLarge, "DamageVestBluntWoodLarge_", 0));
            feedbackMap.Add(FeedbackType.DamageVestBluntMetalLarge, new Feedback(FeedbackType.DamageVestBluntMetalLarge, "DamageVestBluntMetalLarge_", 0));
            feedbackMap.Add(FeedbackType.DamageVestBluntStoneLarge, new Feedback(FeedbackType.DamageVestBluntStoneLarge, "DamageVestBluntStoneLarge_", 0));
            feedbackMap.Add(FeedbackType.DamageVestBluntFleshLarge, new Feedback(FeedbackType.DamageVestBluntFleshLarge, "DamageVestBluntFleshLarge_", 0));
            feedbackMap.Add(FeedbackType.DamageVestPierceFireLarge, new Feedback(FeedbackType.DamageVestPierceFireLarge, "DamageVestPierceFireLarge_", 0));
            feedbackMap.Add(FeedbackType.DamageVestSlashFireLargeLRD, new Feedback(FeedbackType.DamageVestSlashFireLargeLRD, "DamageVestSlashFireLargeLRD_", 0));
            feedbackMap.Add(FeedbackType.DamageVestSlashFireLargeLRU, new Feedback(FeedbackType.DamageVestSlashFireLargeLRU, "DamageVestSlashFireLargeLRU_", 0));
            feedbackMap.Add(FeedbackType.DamageVestSlashFireLargeRLD, new Feedback(FeedbackType.DamageVestSlashFireLargeRLD, "DamageVestSlashFireLargeRLD_", 0));
            feedbackMap.Add(FeedbackType.DamageVestSlashFireLargeRLU, new Feedback(FeedbackType.DamageVestSlashFireLargeRLU, "DamageVestSlashFireLargeRLU_", 0));
            feedbackMap.Add(FeedbackType.DamageVestBluntFireLarge, new Feedback(FeedbackType.DamageVestBluntFireLarge, "DamageVestBluntFireLarge_", 0));
            feedbackMap.Add(FeedbackType.DamageVestPierceLightningLarge, new Feedback(FeedbackType.DamageVestPierceLightningLarge, "DamageVestPierceLightningLarge_", 0));
            feedbackMap.Add(FeedbackType.DamageVestSlashLightningLargeLRD, new Feedback(FeedbackType.DamageVestSlashLightningLargeLRD, "DamageVestSlashLightningLargeLRD_", 0));
            feedbackMap.Add(FeedbackType.DamageVestSlashLightningLargeLRU, new Feedback(FeedbackType.DamageVestSlashLightningLargeLRU, "DamageVestSlashLightningLargeLRU_", 0));
            feedbackMap.Add(FeedbackType.DamageVestSlashLightningLargeRLD, new Feedback(FeedbackType.DamageVestSlashLightningLargeRLD, "DamageVestSlashLightningLargeRLD_", 0));
            feedbackMap.Add(FeedbackType.DamageVestSlashLightningLargeRLU, new Feedback(FeedbackType.DamageVestSlashLightningLargeRLU, "DamageVestSlashLightningLargeRLU_", 0));
            feedbackMap.Add(FeedbackType.DamageVestBluntLightningLarge, new Feedback(FeedbackType.DamageVestBluntLightningLarge, "DamageVestBluntLightningLarge_", 0));
            feedbackMap.Add(FeedbackType.DamageVestPierceIceLarge, new Feedback(FeedbackType.DamageVestPierceIceLarge, "DamageVestPierceIceLarge_", 0));
            feedbackMap.Add(FeedbackType.DamageVestSlashIceLargeLRD, new Feedback(FeedbackType.DamageVestSlashIceLargeLRD, "DamageVestSlashIceLargeLRD_", 0));
            feedbackMap.Add(FeedbackType.DamageVestSlashIceLargeLRU, new Feedback(FeedbackType.DamageVestSlashIceLargeLRU, "DamageVestSlashIceLargeLRU_", 0));
            feedbackMap.Add(FeedbackType.DamageVestSlashIceLargeRLD, new Feedback(FeedbackType.DamageVestSlashIceLargeRLD, "DamageVestSlashIceLargeRLD_", 0));
            feedbackMap.Add(FeedbackType.DamageVestSlashIceLargeRLU, new Feedback(FeedbackType.DamageVestSlashIceLargeRLU, "DamageVestSlashIceLargeRLU_", 0));
            feedbackMap.Add(FeedbackType.DamageVestBluntIceLarge, new Feedback(FeedbackType.DamageVestBluntIceLarge, "DamageVestBluntIceLarge_", 0));

            feedbackMap.Add(FeedbackType.DamageVestBlaster, new Feedback(FeedbackType.DamageVestBlaster, "DamageVestBlaster_", 0));
            feedbackMap.Add(FeedbackType.DamageVestBlasterStun, new Feedback(FeedbackType.DamageVestBlasterStun, "DamageVestBlasterStun_", 0));
            feedbackMap.Add(FeedbackType.DamageRightArmBlaster, new Feedback(FeedbackType.DamageRightArmBlaster, "DamageRightArmBlaster_", 0));
            feedbackMap.Add(FeedbackType.DamageRightArmBlasterStun, new Feedback(FeedbackType.DamageRightArmBlasterStun, "DamageRightArmBlasterStun_", 0));
            feedbackMap.Add(FeedbackType.DamageHeadBlaster, new Feedback(FeedbackType.DamageHeadBlaster, "DamageHeadBlaster_", 0));
            feedbackMap.Add(FeedbackType.DamageHeadBlasterStun, new Feedback(FeedbackType.DamageHeadBlasterStun, "DamageHeadBlasterStun_", 0));
            
            feedbackMap.Add(FeedbackType.DamageVestPierceLightsaber, new Feedback(FeedbackType.DamageVestPierceLightsaber, "DamageVestPierceLightsaber_", 0));
            feedbackMap.Add(FeedbackType.DamageVestSlashLightsaberLRD, new Feedback(FeedbackType.DamageVestSlashLightsaberLRD, "DamageVestSlashLightsaberLRD_", 0));
            feedbackMap.Add(FeedbackType.DamageVestSlashLightsaberLRU, new Feedback(FeedbackType.DamageVestSlashLightsaberLRU, "DamageVestSlashLightsaberLRU_", 0));
            feedbackMap.Add(FeedbackType.DamageVestSlashLightsaberRLD, new Feedback(FeedbackType.DamageVestSlashLightsaberRLD, "DamageVestSlashLightsaberRLD_", 0));
            feedbackMap.Add(FeedbackType.DamageVestSlashLightsaberRLU, new Feedback(FeedbackType.DamageVestSlashLightsaberRLU, "DamageVestSlashLightsaberRLU_", 0));
            feedbackMap.Add(FeedbackType.DamageVestBluntLightsaber, new Feedback(FeedbackType.DamageVestBluntLightsaber, "DamageVestBluntLightsaber_", 0));
            feedbackMap.Add(FeedbackType.DamageRightArmBluntLightsaber, new Feedback(FeedbackType.DamageRightArmBluntLightsaber, "DamageRightArmBluntLightsaber_", 0));
            feedbackMap.Add(FeedbackType.DamageRightArmPierceLightsaber, new Feedback(FeedbackType.DamageRightArmPierceLightsaber, "DamageRightArmPierceLightsaber_", 0));
            feedbackMap.Add(FeedbackType.DamageRightArmSlashLightsaber, new Feedback(FeedbackType.DamageRightArmSlashLightsaber, "DamageRightArmSlashLightsaber_", 0));
            feedbackMap.Add(FeedbackType.DamageHeadPierceLightsaber, new Feedback(FeedbackType.DamageHeadPierceLightsaber, "DamageHeadPierceLightsaber_", 0));
            feedbackMap.Add(FeedbackType.DamageHeadSlashLightsaber, new Feedback(FeedbackType.DamageHeadSlashLightsaber, "DamageHeadSlashLightsaber_", 0));
            feedbackMap.Add(FeedbackType.DamageHeadBluntLightsaber, new Feedback(FeedbackType.DamageHeadBluntLightsaber, "DamageHeadBluntLightsaber_", 0));

            feedbackMap.Add(FeedbackType.DamageRightArmPierceBladeSmall, new Feedback(FeedbackType.DamageRightArmPierceBladeSmall, "DamageRightArmPierceBladeSmall_", 0));
            feedbackMap.Add(FeedbackType.DamageRightArmSlashBladeSmall, new Feedback(FeedbackType.DamageRightArmSlashBladeSmall, "DamageRightArmSlashBladeSmall_", 0));
            feedbackMap.Add(FeedbackType.DamageRightArmBluntBladeSmall, new Feedback(FeedbackType.DamageRightArmBluntBladeSmall, "DamageRightArmBluntBladeSmall_", 0));
            feedbackMap.Add(FeedbackType.DamageRightArmBluntWoodSmall, new Feedback(FeedbackType.DamageRightArmBluntWoodSmall, "DamageRightArmBluntWoodSmall_", 0));
            feedbackMap.Add(FeedbackType.DamageRightArmBluntMetalSmall, new Feedback(FeedbackType.DamageRightArmBluntMetalSmall, "DamageRightArmBluntMetalSmall_", 0));
            feedbackMap.Add(FeedbackType.DamageRightArmBluntStoneSmall, new Feedback(FeedbackType.DamageRightArmBluntStoneSmall, "DamageRightArmBluntStoneSmall_", 0));
            feedbackMap.Add(FeedbackType.DamageRightArmBluntFleshSmall, new Feedback(FeedbackType.DamageRightArmBluntFleshSmall, "DamageRightArmBluntFleshSmall_", 0));
            feedbackMap.Add(FeedbackType.DamageRightArmPierceFireSmall, new Feedback(FeedbackType.DamageRightArmPierceFireSmall, "DamageRightArmPierceFireSmall_", 0));
            feedbackMap.Add(FeedbackType.DamageRightArmSlashFireSmall, new Feedback(FeedbackType.DamageRightArmSlashFireSmall, "DamageRightArmSlashFireSmall_", 0));
            feedbackMap.Add(FeedbackType.DamageRightArmBluntFireSmall, new Feedback(FeedbackType.DamageRightArmBluntFireSmall, "DamageRightArmBluntFireSmall_", 0));
            feedbackMap.Add(FeedbackType.DamageRightArmPierceLightningSmall, new Feedback(FeedbackType.DamageRightArmPierceLightningSmall, "DamageRightArmPierceLightningSmall_", 0));
            feedbackMap.Add(FeedbackType.DamageRightArmSlashLightningSmall, new Feedback(FeedbackType.DamageRightArmSlashLightningSmall, "DamageRightArmSlashLightningSmall_", 0));
            feedbackMap.Add(FeedbackType.DamageRightArmBluntLightningSmall, new Feedback(FeedbackType.DamageRightArmBluntLightningSmall, "DamageRightArmBluntLightningSmall_", 0));
            feedbackMap.Add(FeedbackType.DamageRightArmPierceIceSmall, new Feedback(FeedbackType.DamageRightArmPierceIceSmall, "DamageRightArmPierceIceSmall_", 0));
            feedbackMap.Add(FeedbackType.DamageRightArmSlashIceSmall, new Feedback(FeedbackType.DamageRightArmSlashIceSmall, "DamageRightArmSlashIceSmall_", 0));
            feedbackMap.Add(FeedbackType.DamageRightArmBluntIceSmall, new Feedback(FeedbackType.DamageRightArmBluntIceSmall, "DamageRightArmBluntIceSmall_", 0));
            feedbackMap.Add(FeedbackType.DamageRightArmPierceBladeLarge, new Feedback(FeedbackType.DamageRightArmPierceBladeLarge, "DamageRightArmPierceBladeLarge_", 0));
            feedbackMap.Add(FeedbackType.DamageRightArmSlashBladeLarge, new Feedback(FeedbackType.DamageRightArmSlashBladeLarge, "DamageRightArmSlashBladeLarge_", 0));
            feedbackMap.Add(FeedbackType.DamageRightArmBluntBladeLarge, new Feedback(FeedbackType.DamageRightArmBluntBladeLarge, "DamageRightArmBluntBladeLarge_", 0));
            feedbackMap.Add(FeedbackType.DamageRightArmBluntWoodLarge, new Feedback(FeedbackType.DamageRightArmBluntWoodLarge, "DamageRightArmBluntWoodLarge_", 0));
            feedbackMap.Add(FeedbackType.DamageRightArmBluntMetalLarge, new Feedback(FeedbackType.DamageRightArmBluntMetalLarge, "DamageRightArmBluntMetalLarge_", 0));
            feedbackMap.Add(FeedbackType.DamageRightArmBluntStoneLarge, new Feedback(FeedbackType.DamageRightArmBluntStoneLarge, "DamageRightArmBluntStoneLarge_", 0));
            feedbackMap.Add(FeedbackType.DamageRightArmBluntFleshLarge, new Feedback(FeedbackType.DamageRightArmBluntFleshLarge, "DamageRightArmBluntFleshLarge_", 0));
            feedbackMap.Add(FeedbackType.DamageRightArmPierceFireLarge, new Feedback(FeedbackType.DamageRightArmPierceFireLarge, "DamageRightArmPierceFireLarge_", 0));
            feedbackMap.Add(FeedbackType.DamageRightArmSlashFireLarge, new Feedback(FeedbackType.DamageRightArmSlashFireLarge, "DamageRightArmSlashFireLarge_", 0));
            feedbackMap.Add(FeedbackType.DamageRightArmBluntFireLarge, new Feedback(FeedbackType.DamageRightArmBluntFireLarge, "DamageRightArmBluntFireLarge_", 0));
            feedbackMap.Add(FeedbackType.DamageRightArmPierceLightningLarge, new Feedback(FeedbackType.DamageRightArmPierceLightningLarge, "DamageRightArmPierceLightningLarge_", 0));
            feedbackMap.Add(FeedbackType.DamageRightArmSlashLightningLarge, new Feedback(FeedbackType.DamageRightArmSlashLightningLarge, "DamageRightArmSlashLightningLarge_", 0));
            feedbackMap.Add(FeedbackType.DamageRightArmBluntLightningLarge, new Feedback(FeedbackType.DamageRightArmBluntLightningLarge, "DamageRightArmBluntLightningLarge_", 0));
            feedbackMap.Add(FeedbackType.DamageRightArmPierceIceLarge, new Feedback(FeedbackType.DamageRightArmPierceIceLarge, "DamageRightArmPierceIceLarge_", 0));
            feedbackMap.Add(FeedbackType.DamageRightArmSlashIceLarge, new Feedback(FeedbackType.DamageRightArmSlashIceLarge, "DamageRightArmSlashIceLarge_", 0));
            feedbackMap.Add(FeedbackType.DamageRightArmBluntIceLarge, new Feedback(FeedbackType.DamageRightArmBluntIceLarge, "DamageRightArmBluntIceLarge_", 0));
            feedbackMap.Add(FeedbackType.DamageHeadPierceBladeSmall, new Feedback(FeedbackType.DamageHeadPierceBladeSmall, "DamageHeadPierceBladeSmall_", 0));
            feedbackMap.Add(FeedbackType.DamageHeadSlashBladeSmall, new Feedback(FeedbackType.DamageHeadSlashBladeSmall, "DamageHeadSlashBladeSmall_", 0));
            feedbackMap.Add(FeedbackType.DamageHeadBluntBladeSmall, new Feedback(FeedbackType.DamageHeadBluntBladeSmall, "DamageHeadBluntBladeSmall_", 0));
            feedbackMap.Add(FeedbackType.DamageHeadBluntWoodSmall, new Feedback(FeedbackType.DamageHeadBluntWoodSmall, "DamageHeadBluntWoodSmall_", 0));
            feedbackMap.Add(FeedbackType.DamageHeadBluntMetalSmall, new Feedback(FeedbackType.DamageHeadBluntMetalSmall, "DamageHeadBluntMetalSmall_", 0));
            feedbackMap.Add(FeedbackType.DamageHeadBluntStoneSmall, new Feedback(FeedbackType.DamageHeadBluntStoneSmall, "DamageHeadBluntStoneSmall_", 0));
            feedbackMap.Add(FeedbackType.DamageHeadBluntFleshSmall, new Feedback(FeedbackType.DamageHeadBluntFleshSmall, "DamageHeadBluntFleshSmall_", 0));
            feedbackMap.Add(FeedbackType.DamageHeadPierceFireSmall, new Feedback(FeedbackType.DamageHeadPierceFireSmall, "DamageHeadPierceFireSmall_", 0));
            feedbackMap.Add(FeedbackType.DamageHeadSlashFireSmall, new Feedback(FeedbackType.DamageHeadSlashFireSmall, "DamageHeadSlashFireSmall_", 0));
            feedbackMap.Add(FeedbackType.DamageHeadBluntFireSmall, new Feedback(FeedbackType.DamageHeadBluntFireSmall, "DamageHeadBluntFireSmall_", 0));
            feedbackMap.Add(FeedbackType.DamageHeadPierceLightningSmall, new Feedback(FeedbackType.DamageHeadPierceLightningSmall, "DamageHeadPierceLightningSmall_", 0));
            feedbackMap.Add(FeedbackType.DamageHeadSlashLightningSmall, new Feedback(FeedbackType.DamageHeadSlashLightningSmall, "DamageHeadSlashLightningSmall_", 0));
            feedbackMap.Add(FeedbackType.DamageHeadBluntLightningSmall, new Feedback(FeedbackType.DamageHeadBluntLightningSmall, "DamageHeadBluntLightningSmall_", 0));
            feedbackMap.Add(FeedbackType.DamageHeadPierceIceSmall, new Feedback(FeedbackType.DamageHeadPierceIceSmall, "DamageHeadPierceIceSmall_", 0));
            feedbackMap.Add(FeedbackType.DamageHeadSlashIceSmall, new Feedback(FeedbackType.DamageHeadSlashIceSmall, "DamageHeadSlashIceSmall_", 0));
            feedbackMap.Add(FeedbackType.DamageHeadBluntIceSmall, new Feedback(FeedbackType.DamageHeadBluntIceSmall, "DamageHeadBluntIceSmall_", 0));
            feedbackMap.Add(FeedbackType.DamageHeadPierceBladeLarge, new Feedback(FeedbackType.DamageHeadPierceBladeLarge, "DamageHeadPierceBladeLarge_", 0));
            feedbackMap.Add(FeedbackType.DamageHeadSlashBladeLarge, new Feedback(FeedbackType.DamageHeadSlashBladeLarge, "DamageHeadSlashBladeLarge_", 0));
            feedbackMap.Add(FeedbackType.DamageHeadBluntBladeLarge, new Feedback(FeedbackType.DamageHeadBluntBladeLarge, "DamageHeadBluntBladeLarge_", 0));
            feedbackMap.Add(FeedbackType.DamageHeadBluntWoodLarge, new Feedback(FeedbackType.DamageHeadBluntWoodLarge, "DamageHeadBluntWoodLarge_", 0));
            feedbackMap.Add(FeedbackType.DamageHeadBluntMetalLarge, new Feedback(FeedbackType.DamageHeadBluntMetalLarge, "DamageHeadBluntMetalLarge_", 0));
            feedbackMap.Add(FeedbackType.DamageHeadBluntStoneLarge, new Feedback(FeedbackType.DamageHeadBluntStoneLarge, "DamageHeadBluntStoneLarge_", 0));
            feedbackMap.Add(FeedbackType.DamageHeadBluntFleshLarge, new Feedback(FeedbackType.DamageHeadBluntFleshLarge, "DamageHeadBluntFleshLarge_", 0));
            feedbackMap.Add(FeedbackType.DamageHeadPierceFireLarge, new Feedback(FeedbackType.DamageHeadPierceFireLarge, "DamageHeadPierceFireLarge_", 0));
            feedbackMap.Add(FeedbackType.DamageHeadSlashFireLarge, new Feedback(FeedbackType.DamageHeadSlashFireLarge, "DamageHeadSlashFireLarge_", 0));
            feedbackMap.Add(FeedbackType.DamageHeadBluntFireLarge, new Feedback(FeedbackType.DamageHeadBluntFireLarge, "DamageHeadBluntFireLarge_", 0));
            feedbackMap.Add(FeedbackType.DamageHeadPierceLightningLarge, new Feedback(FeedbackType.DamageHeadPierceLightningLarge, "DamageHeadPierceLightningLarge_", 0));
            feedbackMap.Add(FeedbackType.DamageHeadSlashLightningLarge, new Feedback(FeedbackType.DamageHeadSlashLightningLarge, "DamageHeadSlashLightningLarge_", 0));
            feedbackMap.Add(FeedbackType.DamageHeadBluntLightningLarge, new Feedback(FeedbackType.DamageHeadBluntLightningLarge, "DamageHeadBluntLightningLarge_", 0));
            feedbackMap.Add(FeedbackType.DamageHeadPierceIceLarge, new Feedback(FeedbackType.DamageHeadPierceIceLarge, "DamageHeadPierceIceLarge_", 0));
            feedbackMap.Add(FeedbackType.DamageHeadSlashIceLarge, new Feedback(FeedbackType.DamageHeadSlashIceLarge, "DamageHeadSlashIceLarge_", 0));
            feedbackMap.Add(FeedbackType.DamageHeadBluntIceLarge, new Feedback(FeedbackType.DamageHeadBluntIceLarge, "DamageHeadBluntIceLarge_", 0));

            feedbackMap.Add(FeedbackType.DamageVestArrow, new Feedback(FeedbackType.DamageVestArrow, "DamageVestArrow_", 0));
            feedbackMap.Add(FeedbackType.DamageRightArmArrow, new Feedback(FeedbackType.DamageRightArmArrow, "DamageRightArmArrow_", 0));
            feedbackMap.Add(FeedbackType.DamageHeadArrow, new Feedback(FeedbackType.DamageHeadArrow, "DamageHeadArrow_", 0));
            feedbackMap.Add(FeedbackType.DamageVestFireArrow, new Feedback(FeedbackType.DamageVestFireArrow, "DamageVestFireArrow_", 0));
            feedbackMap.Add(FeedbackType.DamageRightArmFireArrow, new Feedback(FeedbackType.DamageRightArmFireArrow, "DamageRightArmFireArrow_", 0));
            feedbackMap.Add(FeedbackType.DamageHeadFireArrow, new Feedback(FeedbackType.DamageHeadFireArrow, "DamageHeadFireArrow_", 0));
            feedbackMap.Add(FeedbackType.DamageVestLightningArrow, new Feedback(FeedbackType.DamageVestLightningArrow, "DamageVestLightningArrow_", 0));
            feedbackMap.Add(FeedbackType.DamageRightArmLightningArrow, new Feedback(FeedbackType.DamageRightArmLightningArrow, "DamageRightArmLightningArrow_", 0));
            feedbackMap.Add(FeedbackType.DamageHeadLightningArrow, new Feedback(FeedbackType.DamageHeadLightningArrow, "DamageHeadLightningArrow_", 0));
            feedbackMap.Add(FeedbackType.DamageVestIceArrow, new Feedback(FeedbackType.DamageVestIceArrow, "DamageVestIceArrow_", 0));
            feedbackMap.Add(FeedbackType.DamageRightArmIceArrow, new Feedback(FeedbackType.DamageRightArmIceArrow, "DamageRightArmIceArrow_", 0));
            feedbackMap.Add(FeedbackType.DamageHeadIceArrow, new Feedback(FeedbackType.DamageHeadIceArrow, "DamageHeadIceArrow_", 0));
            feedbackMap.Add(FeedbackType.DamageRightArmFire, new Feedback(FeedbackType.DamageRightArmFire, "DamageRightArmFire_", 0));
            feedbackMap.Add(FeedbackType.DamageRightArmLightning, new Feedback(FeedbackType.DamageRightArmLightning, "DamageRightArmLightning_", 0));
            feedbackMap.Add(FeedbackType.DamageRightArmGravity, new Feedback(FeedbackType.DamageRightArmGravity, "DamageRightArmGravity_", 0));
            feedbackMap.Add(FeedbackType.DamageRightArmIce, new Feedback(FeedbackType.DamageRightArmIce, "DamageRightArmIce_", 0));
            feedbackMap.Add(FeedbackType.DamageRightArmDrain, new Feedback(FeedbackType.DamageRightArmDrain, "DamageRightArmDrain_", 0));
            feedbackMap.Add(FeedbackType.DamageRightArmEnergy, new Feedback(FeedbackType.DamageRightArmEnergy, "DamageRightArmEnergy_", 0));

            feedbackMap.Add(FeedbackType.DamageHeadFire, new Feedback(FeedbackType.DamageHeadFire, "DamageHeadFire_", 0));
            feedbackMap.Add(FeedbackType.DamageHeadLightning, new Feedback(FeedbackType.DamageHeadLightning, "DamageHeadLightning_", 0));
            feedbackMap.Add(FeedbackType.DamageHeadGravity, new Feedback(FeedbackType.DamageHeadGravity, "DamageHeadGravity_", 0));
            feedbackMap.Add(FeedbackType.DamageHeadIce, new Feedback(FeedbackType.DamageHeadIce, "DamageHeadIce_", 0));
            feedbackMap.Add(FeedbackType.DamageHeadDrain, new Feedback(FeedbackType.DamageHeadDrain, "DamageHeadDrain_", 0));
            feedbackMap.Add(FeedbackType.DamageHeadEnergy, new Feedback(FeedbackType.DamageHeadEnergy, "DamageHeadEnergy_", 0));

            feedbackMap.Add(FeedbackType.DamageVestEnergy, new Feedback(FeedbackType.DamageVestEnergy, "DamageVestEnergy_", 0));
            feedbackMap.Add(FeedbackType.DamageVestFire, new Feedback(FeedbackType.DamageVestFire, "DamageVestFire_", 0));
            feedbackMap.Add(FeedbackType.DamageVestIce, new Feedback(FeedbackType.DamageVestIce, "DamageVestIce_", 0));
            feedbackMap.Add(FeedbackType.DamageVestDrain, new Feedback(FeedbackType.DamageVestDrain, "DamageVestDrain_", 0));
            feedbackMap.Add(FeedbackType.DamageVestLightning, new Feedback(FeedbackType.DamageVestLightning, "DamageVestLightning_", 0));
            feedbackMap.Add(FeedbackType.DamageVestGravity, new Feedback(FeedbackType.DamageVestGravity, "DamageVestGravity_", 0));
            feedbackMap.Add(FeedbackType.PotionDrinking, new Feedback(FeedbackType.PotionDrinking, "PotionDrinking_", 0));
            feedbackMap.Add(FeedbackType.PoisonDrinking, new Feedback(FeedbackType.PoisonDrinking, "PoisonDrinking_", 0));
            feedbackMap.Add(FeedbackType.Healing, new Feedback(FeedbackType.Healing, "Healing_", 0));
            feedbackMap.Add(FeedbackType.FallDamage, new Feedback(FeedbackType.FallDamage, "FallDamage_", 0));
            feedbackMap.Add(FeedbackType.FallDamageFeet, new Feedback(FeedbackType.FallDamageFeet, "FallDamageFeet_", 0));
            feedbackMap.Add(FeedbackType.SlowMotion, new Feedback(FeedbackType.SlowMotion, "SlowMotion_", 0));
            feedbackMap.Add(FeedbackType.HolsterLeftShoulder, new Feedback(FeedbackType.HolsterLeftShoulder, "HolsterLeftShoulder_", 0));
            feedbackMap.Add(FeedbackType.HolsterRightShoulder, new Feedback(FeedbackType.HolsterRightShoulder, "HolsterRightShoulder_", 0));
            feedbackMap.Add(FeedbackType.UnholsterLeftShoulder, new Feedback(FeedbackType.UnholsterLeftShoulder, "UnholsterLeftShoulder_", 0));
            feedbackMap.Add(FeedbackType.UnholsterRightShoulder, new Feedback(FeedbackType.UnholsterRightShoulder, "UnholsterRightShoulder_", 0));
            feedbackMap.Add(FeedbackType.HolsterArrowLeftShoulder, new Feedback(FeedbackType.HolsterArrowLeftShoulder, "HolsterArrowLeftShoulder_", 0));
            feedbackMap.Add(FeedbackType.HolsterArrowRightShoulder, new Feedback(FeedbackType.HolsterArrowRightShoulder, "HolsterArrowRightShoulder_", 0));
            feedbackMap.Add(FeedbackType.UnholsterArrowLeftShoulder, new Feedback(FeedbackType.UnholsterArrowLeftShoulder, "UnholsterArrowLeftShoulder_", 0));
            feedbackMap.Add(FeedbackType.UnholsterArrowRightShoulder, new Feedback(FeedbackType.UnholsterArrowRightShoulder, "UnholsterArrowRightShoulder_", 0));
            feedbackMap.Add(FeedbackType.ClimbingRight, new Feedback(FeedbackType.ClimbingRight, "ClimbingRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerKickOtherRight, new Feedback(FeedbackType.PlayerKickOtherRight, "PlayerKickOtherRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerKickWoodRight, new Feedback(FeedbackType.PlayerKickWoodRight, "PlayerKickWoodRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerKickFleshRight, new Feedback(FeedbackType.PlayerKickFleshRight, "PlayerKickFleshRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerKickStoneRight, new Feedback(FeedbackType.PlayerKickStoneRight, "PlayerKickStoneRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerKickMetalRight, new Feedback(FeedbackType.PlayerKickMetalRight, "PlayerKickMetalRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerKickFabricRight, new Feedback(FeedbackType.PlayerKickFabricRight, "PlayerKickFabricRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerPunchOtherRight, new Feedback(FeedbackType.PlayerPunchOtherRight, "PlayerPunchOtherRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerPunchWoodRight, new Feedback(FeedbackType.PlayerPunchWoodRight, "PlayerPunchWoodRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerPunchFleshRight, new Feedback(FeedbackType.PlayerPunchFleshRight, "PlayerPunchFleshRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerPunchStoneRight, new Feedback(FeedbackType.PlayerPunchStoneRight, "PlayerPunchStoneRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerPunchMetalRight, new Feedback(FeedbackType.PlayerPunchMetalRight, "PlayerPunchMetalRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerPunchFabricRight, new Feedback(FeedbackType.PlayerPunchFabricRight, "PlayerPunchFabricRight_", 0));

            feedbackMap.Add(FeedbackType.PlayerGunRight, new Feedback(FeedbackType.PlayerGunRight, "PlayerGunRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerGunBlasterRight, new Feedback(FeedbackType.PlayerGunBlasterRight, "PlayerGunBlasterRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerGunAutomaticRight, new Feedback(FeedbackType.PlayerGunAutomaticRight, "PlayerGunAutomaticRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerGunBallisticRight, new Feedback(FeedbackType.PlayerGunBallisticRight, "PlayerGunBallisticRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerGunSprayRight, new Feedback(FeedbackType.PlayerGunSprayRight, "PlayerGunSprayRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerGunMiniGunRight, new Feedback(FeedbackType.PlayerGunMiniGunRight, "PlayerGunMiniGunRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerGunBazookaRight, new Feedback(FeedbackType.PlayerGunBazookaRight, "PlayerGunBazookaRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerGunHeavyRight, new Feedback(FeedbackType.PlayerGunHeavyRight, "PlayerGunHeavyRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerGunLaserRight, new Feedback(FeedbackType.PlayerGunLaserRight, "PlayerGunLaserRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerGunRifleRight, new Feedback(FeedbackType.PlayerGunRifleRight, "PlayerGunRifleRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerGunPistolRight, new Feedback(FeedbackType.PlayerGunPistolRight, "PlayerGunPistolRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerGunPlasmaRight, new Feedback(FeedbackType.PlayerGunPlasmaRight, "PlayerGunPlasmaRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerGunShotgunRight, new Feedback(FeedbackType.PlayerGunShotgunRight, "PlayerGunShotgunRight_", 0));
            feedbackMap.Add(FeedbackType.PlayerGunEnergyRight, new Feedback(FeedbackType.PlayerGunEnergyRight, "PlayerGunEnergyRight_", 0));
            feedbackMap.Add(FeedbackType.KickbackPlayerGunRight, new Feedback(FeedbackType.KickbackPlayerGunRight, "KickbackPlayerGunRight_", 0));
            feedbackMap.Add(FeedbackType.KickbackPlayerGunPistolRight, new Feedback(FeedbackType.KickbackPlayerGunPistolRight, "KickbackPlayerGunPistolRight_", 0));
            feedbackMap.Add(FeedbackType.KickbackPlayerGunBallisticRight, new Feedback(FeedbackType.KickbackPlayerGunBallisticRight, "KickbackPlayerGunBallisticRight_", 0));
            feedbackMap.Add(FeedbackType.KickbackPlayerGunLaserRight, new Feedback(FeedbackType.KickbackPlayerGunLaserRight, "KickbackPlayerGunLaserRight_", 0));
            feedbackMap.Add(FeedbackType.KickbackPlayerGunPlasmaRight, new Feedback(FeedbackType.KickbackPlayerGunPlasmaRight, "KickbackPlayerGunPlasmaRight_", 0));
            feedbackMap.Add(FeedbackType.KickbackPlayerGunSprayRight, new Feedback(FeedbackType.KickbackPlayerGunSprayRight, "KickbackPlayerGunSprayRight_", 0));
            feedbackMap.Add(FeedbackType.KickbackPlayerGunHeavyRight, new Feedback(FeedbackType.KickbackPlayerGunHeavyRight, "KickbackPlayerGunHeavyRight_", 0));
            feedbackMap.Add(FeedbackType.KickbackPlayerGunLeft, new Feedback(FeedbackType.KickbackPlayerGunLeft, "KickbackPlayerGunLeft_", 0));
            feedbackMap.Add(FeedbackType.KickbackPlayerGunPistolLeft, new Feedback(FeedbackType.KickbackPlayerGunPistolLeft, "KickbackPlayerGunPistolLeft_", 0));
            feedbackMap.Add(FeedbackType.KickbackPlayerGunBallisticLeft, new Feedback(FeedbackType.KickbackPlayerGunBallisticLeft, "KickbackPlayerGunBallisticLeft_", 0));
            feedbackMap.Add(FeedbackType.KickbackPlayerGunLaserLeft, new Feedback(FeedbackType.KickbackPlayerGunLaserLeft, "KickbackPlayerGunLaserLeft_", 0));
            feedbackMap.Add(FeedbackType.KickbackPlayerGunPlasmaLeft, new Feedback(FeedbackType.KickbackPlayerGunPlasmaLeft, "KickbackPlayerGunPlasmaLeft_", 0));
            feedbackMap.Add(FeedbackType.KickbackPlayerGunSprayLeft, new Feedback(FeedbackType.KickbackPlayerGunSprayLeft, "KickbackPlayerGunSprayLeft_", 0));
            feedbackMap.Add(FeedbackType.KickbackPlayerGunHeavyLeft, new Feedback(FeedbackType.KickbackPlayerGunHeavyLeft, "KickbackPlayerGunHeavyLeft_", 0));

            feedbackMap.Add(FeedbackType.PlayerThrowRight, new Feedback(FeedbackType.PlayerThrowRight, "PlayerThrowRight_", 0));

            feedbackMap.Add(FeedbackType.Explosion, new Feedback(FeedbackType.Explosion, "Explosion_", 0));

            feedbackMap.Add(FeedbackType.LeftShoulderTurret, new Feedback(FeedbackType.LeftShoulderTurret, "LeftShoulderTurret_", 0));
            feedbackMap.Add(FeedbackType.HoverJetFeet, new Feedback(FeedbackType.HoverJetFeet, "HoverJetFeet_", 0));

        }

        public bool systemInitialized = false;
        public HapticPlayer hapticPlayer;

        public Dictionary<FeedbackType, Feedback> feedbackMap = new Dictionary<FeedbackType, Feedback>();

        public enum FeedbackType
        {
            //Default Damages on Player
            DefaultDamage,

            //Player Bow
            PlayerBowPullRight,

            //Player Melee
            PlayerMeleeBladeWoodPierceRight,
            PlayerMeleeBladeMetalPierceRight,
            PlayerMeleeBladeStonePierceRight,
            PlayerMeleeBladeFabricPierceRight,
            PlayerMeleeBladeFleshPierceRight,
            PlayerMeleeBladeWoodSlashRight,
            PlayerMeleeBladeMetalSlashRight,
            PlayerMeleeBladeStoneSlashRight,
            PlayerMeleeBladeFabricSlashRight,
            PlayerMeleeBladeFleshSlashRight,
            PlayerMeleeBladeWoodBluntRight,
            PlayerMeleeBladeMetalBluntRight,
            PlayerMeleeBladeStoneBluntRight,
            PlayerMeleeBladeFabricBluntRight,
            PlayerMeleeBladeFleshBluntRight,
            PlayerMeleeWoodWoodBluntRight,
            PlayerMeleeWoodMetalBluntRight,
            PlayerMeleeWoodStoneBluntRight,
            PlayerMeleeWoodFabricBluntRight,
            PlayerMeleeWoodFleshBluntRight,
            PlayerMeleeStoneStoneBluntRight,
            PlayerMeleeStoneFabricBluntRight,
            PlayerMeleeStoneFleshBluntRight,


            PlayerMeleeLightsaberClashRight,
            PlayerMeleeLightsaberSlashRight,
            PlayerMeleeLightsaberPierceRight,
            PlayerMeleeLightsaberBluntRight,


            //Player Spell Cast
            PlayerSpellFireRight,
            PlayerSpellLightningRight,
            PlayerSpellGravityRight,
            PlayerSpellIceRight,
            PlayerSpellCrushRight,
            PlayerSpellHealRight,
            PlayerSpellImplosionRight,
            PlayerSpellInvisibilityRight,
            PlayerSpellTeslaRight,
            PlayerSpellUtilityRight,
            PlayerSpellCorruptionRight,
            PlayerSpellTeleportRight,
            PlayerSpellRasenganRight,
            PlayerSpellNeedleRight,
            PlayerSpellDrainRight,
            PlayerSpellForceFieldRight,
            PlayerSpellOtherRight,
            
            PlayerTelekinesisActiveRight,
            PlayerTelekinesisPullRight,
            PlayerTelekinesisRepelRight,
            PlayerTelekinesisCatchRight,

            //Damage On Player

            DamageVestArrow,
            DamageRightArmArrow,
            DamageHeadArrow,
            DamageVestFireArrow,
            DamageRightArmFireArrow,
            DamageHeadFireArrow,
            DamageVestLightningArrow,
            DamageRightArmLightningArrow,
            DamageHeadLightningArrow,
            DamageVestIceArrow,
            DamageRightArmIceArrow,
            DamageHeadIceArrow,


            DamageHeadFire,
            DamageHeadLightning,
            DamageHeadGravity,
            DamageHeadIce,
            DamageHeadDrain,
            DamageHeadEnergy,

            DamageRightArmFire,
            DamageRightArmLightning,
            DamageRightArmGravity,
            DamageRightArmIce,
            DamageRightArmDrain,
            DamageRightArmEnergy,

            DamageVestFire,
            DamageVestLightning,
            DamageVestGravity,
            DamageVestIce,
            DamageVestDrain,
            DamageVestEnergy,

            DamageVestPierceBladeSmall,
            DamageVestSlashBladeSmallLRD,
            DamageVestSlashBladeSmallLRU,
            DamageVestSlashBladeSmallRLD,
            DamageVestSlashBladeSmallRLU,
            DamageVestBluntBladeSmall,
            DamageVestBluntWoodSmall,
            DamageVestBluntMetalSmall,
            DamageVestBluntStoneSmall,
            DamageVestBluntFleshSmall,
            DamageVestPierceFireSmall,
            DamageVestSlashFireSmallLRD,
            DamageVestSlashFireSmallLRU,
            DamageVestSlashFireSmallRLD,
            DamageVestSlashFireSmallRLU,
            DamageVestBluntFireSmall,
            DamageVestPierceLightningSmall,
            DamageVestSlashLightningSmallLRD,
            DamageVestSlashLightningSmallLRU,
            DamageVestSlashLightningSmallRLD,
            DamageVestSlashLightningSmallRLU,
            DamageVestBluntLightningSmall,
            DamageVestPierceIceSmall,
            DamageVestSlashIceSmallLRD,
            DamageVestSlashIceSmallLRU,
            DamageVestSlashIceSmallRLD,
            DamageVestSlashIceSmallRLU,
            DamageVestBluntIceSmall,
            DamageVestPierceBladeLarge,
            DamageVestSlashBladeLargeLRD,
            DamageVestSlashBladeLargeLRU,
            DamageVestSlashBladeLargeRLD,
            DamageVestSlashBladeLargeRLU,
            DamageVestBluntBladeLarge,
            DamageVestBluntWoodLarge,
            DamageVestBluntMetalLarge,
            DamageVestBluntStoneLarge,
            DamageVestBluntFleshLarge,
            DamageVestPierceFireLarge,
            DamageVestSlashFireLargeLRD,
            DamageVestSlashFireLargeLRU,
            DamageVestSlashFireLargeRLD,
            DamageVestSlashFireLargeRLU,
            DamageVestBluntFireLarge,
            DamageVestPierceLightningLarge,
            DamageVestSlashLightningLargeLRD,
            DamageVestSlashLightningLargeLRU,
            DamageVestSlashLightningLargeRLD,
            DamageVestSlashLightningLargeRLU,
            DamageVestBluntLightningLarge,
            DamageVestPierceIceLarge,
            DamageVestSlashIceLargeLRD,
            DamageVestSlashIceLargeLRU,
            DamageVestSlashIceLargeRLD,
            DamageVestSlashIceLargeRLU,
            DamageVestBluntIceLarge,

            DamageVestBlaster,
            DamageVestBlasterStun,
            DamageRightArmBlaster,
            DamageRightArmBlasterStun,
            DamageHeadBlaster,
            DamageHeadBlasterStun,

            DamageVestPierceLightsaber,
            DamageVestSlashLightsaberLRD,
            DamageVestSlashLightsaberLRU,
            DamageVestSlashLightsaberRLD,
            DamageVestSlashLightsaberRLU,
            DamageVestBluntLightsaber,
            DamageRightArmBluntLightsaber,
            DamageRightArmPierceLightsaber,
            DamageRightArmSlashLightsaber,
            DamageHeadPierceLightsaber,
            DamageHeadSlashLightsaber,
            DamageHeadBluntLightsaber,


            DamageRightArmPierceBladeSmall,
            DamageRightArmSlashBladeSmall,
            DamageRightArmBluntBladeSmall,
            DamageRightArmBluntWoodSmall,
            DamageRightArmBluntMetalSmall,
            DamageRightArmBluntStoneSmall,
            DamageRightArmBluntFleshSmall,
            DamageRightArmPierceFireSmall,
            DamageRightArmSlashFireSmall,
            DamageRightArmBluntFireSmall,
            DamageRightArmPierceLightningSmall,
            DamageRightArmSlashLightningSmall,
            DamageRightArmBluntLightningSmall,
            DamageRightArmPierceIceSmall,
            DamageRightArmSlashIceSmall,
            DamageRightArmBluntIceSmall,
            DamageRightArmPierceBladeLarge,
            DamageRightArmSlashBladeLarge,
            DamageRightArmBluntBladeLarge,
            DamageRightArmBluntWoodLarge,
            DamageRightArmBluntMetalLarge,
            DamageRightArmBluntStoneLarge,
            DamageRightArmBluntFleshLarge,
            DamageRightArmPierceFireLarge,
            DamageRightArmSlashFireLarge,
            DamageRightArmBluntFireLarge,
            DamageRightArmPierceLightningLarge,
            DamageRightArmSlashLightningLarge,
            DamageRightArmBluntLightningLarge,
            DamageRightArmPierceIceLarge,
            DamageRightArmSlashIceLarge,
            DamageRightArmBluntIceLarge,
            DamageHeadPierceBladeSmall,
            DamageHeadSlashBladeSmall,
            DamageHeadBluntBladeSmall,
            DamageHeadBluntWoodSmall,
            DamageHeadBluntMetalSmall,
            DamageHeadBluntStoneSmall,
            DamageHeadBluntFleshSmall,
            DamageHeadPierceFireSmall,
            DamageHeadSlashFireSmall,
            DamageHeadBluntFireSmall,
            DamageHeadPierceLightningSmall,
            DamageHeadSlashLightningSmall,
            DamageHeadBluntLightningSmall,
            DamageHeadPierceIceSmall,
            DamageHeadSlashIceSmall,
            DamageHeadBluntIceSmall,
            DamageHeadPierceBladeLarge,
            DamageHeadSlashBladeLarge,
            DamageHeadBluntBladeLarge,
            DamageHeadBluntWoodLarge,
            DamageHeadBluntMetalLarge,
            DamageHeadBluntStoneLarge,
            DamageHeadBluntFleshLarge,
            DamageHeadPierceFireLarge,
            DamageHeadSlashFireLarge,
            DamageHeadBluntFireLarge,
            DamageHeadPierceLightningLarge,
            DamageHeadSlashLightningLarge,
            DamageHeadBluntLightningLarge,
            DamageHeadPierceIceLarge,
            DamageHeadSlashIceLarge,
            DamageHeadBluntIceLarge,

            //Special stuff
            HeartBeat,
            HeartBeatFast,

            PotionDrinking,
            PoisonDrinking,
            Healing,

            FallDamage,
            FallDamageFeet,
            SlowMotion,

            HolsterLeftShoulder,
            HolsterRightShoulder,
            UnholsterLeftShoulder,
            UnholsterRightShoulder,

            HolsterArrowLeftShoulder,
            HolsterArrowRightShoulder,
            UnholsterArrowLeftShoulder,
            UnholsterArrowRightShoulder,

            ClimbingRight,

            PlayerKickOtherRight,
            PlayerKickWoodRight,
            PlayerKickFleshRight,
            PlayerKickStoneRight,
            PlayerKickMetalRight,
            PlayerKickFabricRight,

            PlayerPunchOtherRight,
            PlayerPunchWoodRight,
            PlayerPunchFleshRight,
            PlayerPunchStoneRight,
            PlayerPunchMetalRight,
            PlayerPunchFabricRight,

            //Player Gun
            PlayerGunRight,
            PlayerGunBlasterRight,
            PlayerGunAutomaticRight,
            PlayerGunBallisticRight,
            PlayerGunSprayRight,
            PlayerGunMiniGunRight,
            PlayerGunBazookaRight,
            PlayerGunHeavyRight,
            PlayerGunLaserRight,
            PlayerGunRifleRight,
            PlayerGunPistolRight,
            PlayerGunPlasmaRight,
            PlayerGunShotgunRight,
            PlayerGunEnergyRight,

            //Kickback Player Arm Feedbacks
            KickbackPlayerGunRight,
            KickbackPlayerGunPistolRight,
            KickbackPlayerGunBallisticRight,
            KickbackPlayerGunLaserRight,
            KickbackPlayerGunPlasmaRight,
            KickbackPlayerGunSprayRight,
            KickbackPlayerGunHeavyRight,

            KickbackPlayerGunLeft,
            KickbackPlayerGunPistolLeft,
            KickbackPlayerGunBallisticLeft,
            KickbackPlayerGunLaserLeft,
            KickbackPlayerGunPlasmaLeft,
            KickbackPlayerGunSprayLeft,
            KickbackPlayerGunHeavyLeft,

            PlayerThrowRight,

            Explosion,

            LeftShoulderTurret,
            HoverJetFeet,

            NoFeedback
        }

        public static FeedbackType GetSpellFeedbackFromId(string id)
        {
            string lowerId = id.ToLowerInvariant();
            if (lowerId.Contains("fire"))
            {
                return FeedbackType.PlayerSpellFireRight;
            }
            else if (lowerId.Contains("lightning") || lowerId.Contains("electric") || lowerId.Contains("shock"))
            {
                return FeedbackType.PlayerSpellLightningRight;
            }
            else if (lowerId.Contains("gravity"))
            {
                return FeedbackType.PlayerSpellGravityRight;
            }
            else if (lowerId.Contains("ice") || lowerId.Contains("ıce"))
            {
                return FeedbackType.PlayerSpellIceRight;
            }
            else if (lowerId.Contains("crush"))
            {
                return FeedbackType.PlayerSpellCrushRight;
            }
            else if (lowerId.Contains("heal"))
            {
                return FeedbackType.PlayerSpellHealRight;
            }
            else if (lowerId.Contains("mplos"))
            {
                return FeedbackType.PlayerSpellImplosionRight;
            }
            else if (lowerId.Contains("nvisi"))
            {
                return FeedbackType.PlayerSpellInvisibilityRight;
            }
            else if (lowerId.Contains("tesla"))
            {
                return FeedbackType.PlayerSpellTeslaRight;
            }
            else if (lowerId.Contains("util"))
            {
                return FeedbackType.PlayerSpellUtilityRight;
            }
            else if (lowerId.Contains("corrupt"))
            {
                return FeedbackType.PlayerSpellCorruptionRight;
            }
            else if (lowerId.Contains("teleport"))
            {
                return FeedbackType.PlayerSpellTeleportRight;
            }
            else if (lowerId.Contains("rasengan") || lowerId.Contains("whirl"))
            {
                return FeedbackType.PlayerSpellRasenganRight;
            }
            else if (lowerId.Contains("needle") || lowerId.Contains("spawn"))
            {
                return FeedbackType.PlayerSpellNeedleRight;
            }
            else if (lowerId.Contains("drain"))
            {
                return FeedbackType.PlayerSpellDrainRight;
            }
            else if (lowerId.Contains("force"))
            {
                return FeedbackType.PlayerSpellForceFieldRight;
            }
            else
            {
                return FeedbackType.PlayerSpellOtherRight;
            }
        }

        public static FeedbackType GetPlayerMeleeFeedbackType(DamageType damageType, MaterialData sourceMaterialData, MaterialData targetMaterialData)
        {
            string sourceMaterial = "";
            string targetMaterial = "";
            if (sourceMaterialData != null)
            {
                sourceMaterial = sourceMaterialData.id;
            }
            if (targetMaterialData != null)
            {
                targetMaterial = targetMaterialData.id;
            }

            
            if (damageType == DamageType.Pierce)
            {
                if (sourceMaterial == "Blade" || sourceMaterial == "Metal")
                {
                    if (targetMaterial == "Blade" || targetMaterial == "Metal" || targetMaterial == "Chainmail" || targetMaterial == "Plate" || targetMaterial == "Lightsaber")
                    {
                        return FeedbackType.PlayerMeleeBladeMetalPierceRight;
                    }
                    else if (targetMaterial == "Wood" || targetMaterial == "Arrow")
                    {
                        return FeedbackType.PlayerMeleeBladeWoodPierceRight;
                    }
                    else if (targetMaterial == "Flesh")
                    {
                        return FeedbackType.PlayerMeleeBladeFleshPierceRight;
                    }
                    else if (targetMaterial == "Fabric" || targetMaterial == "Leather" || targetMaterial == "Rope")
                    {
                        return FeedbackType.PlayerMeleeBladeFabricPierceRight;
                    }
                    else
                    {
                        return FeedbackType.PlayerMeleeBladeStonePierceRight;
                    }
                }
                else if (sourceMaterial == "Wood")
                {
                    if (targetMaterial == "Blade" || targetMaterial == "Metal" || targetMaterial == "Chainmail" || targetMaterial == "Plate" || targetMaterial == "Lightsaber")
                    {
                        return FeedbackType.PlayerMeleeWoodMetalBluntRight;
                    }
                    else if (targetMaterial == "Wood" || targetMaterial == "Arrow")
                    {
                        return FeedbackType.PlayerMeleeWoodWoodBluntRight;
                    }
                    else if (targetMaterial == "Flesh")
                    {
                        return FeedbackType.PlayerMeleeWoodFleshBluntRight;
                    }
                    else if (targetMaterial == "Fabric" || targetMaterial == "Leather" || targetMaterial == "Rope")
                    {
                        return FeedbackType.PlayerMeleeWoodFabricBluntRight;
                    }
                    else
                    {
                        return FeedbackType.PlayerMeleeWoodStoneBluntRight;
                    }
                }
                else if (sourceMaterial == "Flesh")
                {
                    if (targetMaterial == "Blade" || targetMaterial == "Metal" || targetMaterial == "Chainmail" || targetMaterial == "Plate" || targetMaterial == "Lightsaber")
                    {
                        return FeedbackType.PlayerPunchMetalRight;
                    }
                    else if (targetMaterial == "Wood" || targetMaterial == "Arrow")
                    {
                        return FeedbackType.PlayerPunchWoodRight;
                    }
                    else if (targetMaterial == "Flesh")
                    {
                        return FeedbackType.PlayerPunchFleshRight;
                    }
                    else if (targetMaterial == "Fabric" || targetMaterial == "Leather" || targetMaterial == "Rope")
                    {
                        return FeedbackType.PlayerPunchFabricRight;
                    }
                    else if (targetMaterial == "Stone" || targetMaterial == "Glass")
                    {
                        return FeedbackType.PlayerPunchStoneRight;
                    }
                    else
                    {
                        return FeedbackType.PlayerPunchOtherRight;
                    }
                }
                else if (sourceMaterial.Contains("Lightsaber"))
                {
                    if (targetMaterial == "Lightsaber")
                    {
                        return FeedbackType.PlayerMeleeLightsaberClashRight;
                    }
                    else
                    {
                        return FeedbackType.PlayerMeleeLightsaberPierceRight;
                    }
                }
                else if (sourceMaterial.Contains("Fire"))
                {
                    if (targetMaterial == "Blade" || targetMaterial == "Metal" || targetMaterial == "Chainmail" || targetMaterial == "Plate" || targetMaterial == "Lightsaber")
                    {
                        return FeedbackType.PlayerMeleeBladeMetalPierceRight;
                    }
                    else if (targetMaterial == "Wood" || targetMaterial == "Arrow")
                    {
                        return FeedbackType.PlayerMeleeBladeFabricPierceRight;
                    }
                    else if (targetMaterial == "Flesh")
                    {
                        return FeedbackType.PlayerMeleeBladeFabricPierceRight;
                    }
                    else if (targetMaterial == "Fabric" || targetMaterial == "Leather" || targetMaterial == "Rope")
                    {
                        return FeedbackType.PlayerMeleeBladeFabricPierceRight;
                    }
                    else if (targetMaterial == "Stone")
                    {
                        return FeedbackType.PlayerMeleeBladeFabricPierceRight;
                    }
                    else
                    {
                        return FeedbackType.PlayerMeleeBladeStonePierceRight;
                    }
                }
                else
                {
                    if (targetMaterial == "Blade" || targetMaterial == "Metal" || targetMaterial == "Chainmail" || targetMaterial == "Plate" || targetMaterial == "Lightsaber")
                    {
                        return FeedbackType.PlayerMeleeBladeMetalBluntRight;
                    }
                    else if (targetMaterial == "Wood" || targetMaterial == "Arrow")
                    {
                        return FeedbackType.PlayerMeleeWoodStoneBluntRight;
                    }
                    else if (targetMaterial == "Flesh")
                    {
                        return FeedbackType.PlayerMeleeStoneFleshBluntRight;
                    }
                    else if (targetMaterial == "Fabric" || targetMaterial == "Leather" || targetMaterial == "Rope")
                    {
                        return FeedbackType.PlayerMeleeStoneFabricBluntRight;
                    }
                    else
                    {
                        return FeedbackType.PlayerMeleeStoneStoneBluntRight;
                    }
                }
            }
            else if (damageType == DamageType.Slash)
            {
                if (sourceMaterial == "Lightsaber")
                {
                    if (targetMaterial == "Lightsaber")
                    {
                        return FeedbackType.PlayerMeleeLightsaberClashRight;
                    }
                    else
                    {
                        return FeedbackType.PlayerMeleeLightsaberSlashRight;
                    }
                }
                if (sourceMaterial == "Blade" || sourceMaterial == "Metal" || sourceMaterial == "SpellFire")
                {
                    if (targetMaterial == "Blade" || targetMaterial == "Metal" || targetMaterial == "Chainmail" || targetMaterial == "Plate" || targetMaterial == "Lightsaber")
                    {
                        return FeedbackType.PlayerMeleeBladeMetalSlashRight;
                    }
                    else if (targetMaterial == "Wood" || targetMaterial == "Arrow")
                    {
                        return FeedbackType.PlayerMeleeBladeWoodSlashRight;
                    }
                    else if (targetMaterial == "Flesh")
                    {
                        return FeedbackType.PlayerMeleeBladeFleshSlashRight;
                    }
                    else if (targetMaterial == "Fabric" || targetMaterial == "Leather" || targetMaterial == "Rope")
                    {
                        return FeedbackType.PlayerMeleeBladeFabricSlashRight;
                    }
                    else
                    {
                        return FeedbackType.PlayerMeleeBladeStoneSlashRight;
                    }
                }
                else if (sourceMaterial == "Wood")
                {
                    if (targetMaterial == "Blade" || targetMaterial == "Metal" || targetMaterial == "Chainmail" || targetMaterial == "Plate" || targetMaterial == "Lightsaber")
                    {
                        return FeedbackType.PlayerMeleeWoodMetalBluntRight;
                    }
                    else if (targetMaterial == "Wood" || targetMaterial == "Arrow")
                    {
                        return FeedbackType.PlayerMeleeWoodWoodBluntRight;
                    }
                    else if (targetMaterial == "Flesh")
                    {
                        return FeedbackType.PlayerMeleeWoodFleshBluntRight;
                    }
                    else if (targetMaterial == "Fabric" || targetMaterial == "Leather" || targetMaterial == "Rope")
                    {
                        return FeedbackType.PlayerMeleeWoodFabricBluntRight;
                    }
                    else
                    {
                        return FeedbackType.PlayerMeleeWoodStoneBluntRight;
                    }
                }
                else if (sourceMaterial == "Flesh")
                {
                    if (targetMaterial == "Blade" || targetMaterial == "Metal" || targetMaterial == "Chainmail" || targetMaterial == "Plate" || targetMaterial == "Lightsaber")
                    {
                        return FeedbackType.PlayerPunchMetalRight;
                    }
                    else if (targetMaterial == "Wood" || targetMaterial == "Arrow")
                    {
                        return FeedbackType.PlayerPunchWoodRight;
                    }
                    else if (targetMaterial == "Flesh")
                    {
                        return FeedbackType.PlayerPunchFleshRight;
                    }
                    else if (targetMaterial == "Fabric" || targetMaterial == "Leather" || targetMaterial == "Rope")
                    {
                        return FeedbackType.PlayerPunchFabricRight;
                    }
                    else if (targetMaterial == "Stone" || targetMaterial == "Glass")
                    {
                        return FeedbackType.PlayerPunchStoneRight;
                    }
                    else
                    {
                        return FeedbackType.PlayerPunchOtherRight;
                    }
                }
                else
                {
                    if (targetMaterial == "Blade" || targetMaterial == "Metal" || targetMaterial == "Chainmail" || targetMaterial == "Plate" || targetMaterial == "Lightsaber")
                    {
                        return FeedbackType.PlayerMeleeBladeMetalBluntRight;
                    }
                    else if (targetMaterial == "Wood" || targetMaterial == "Arrow")
                    {
                        return FeedbackType.PlayerMeleeWoodStoneBluntRight;
                    }
                    else if (targetMaterial == "Flesh")
                    {
                        return FeedbackType.PlayerMeleeStoneFleshBluntRight;
                    }
                    else if (targetMaterial == "Fabric" || targetMaterial == "Leather" || targetMaterial == "Rope")
                    {
                        return FeedbackType.PlayerMeleeStoneFabricBluntRight;
                    }
                    else
                    {
                        return FeedbackType.PlayerMeleeStoneStoneBluntRight;
                    }
                }
            }
            else
            {
                if (sourceMaterial == "Blade" || sourceMaterial == "Metal" || sourceMaterial == "SpellFire")
                {
                    if (targetMaterial == "Blade" || targetMaterial == "Metal" || targetMaterial == "Chainmail" || targetMaterial == "Plate" || targetMaterial == "Lightsaber")
                    {
                        return FeedbackType.PlayerMeleeBladeMetalBluntRight;
                    }
                    else if (targetMaterial == "Wood" || targetMaterial == "Arrow")
                    {
                        return FeedbackType.PlayerMeleeBladeWoodBluntRight;
                    }
                    else if (targetMaterial == "Flesh")
                    {
                        return FeedbackType.PlayerMeleeBladeFleshBluntRight;
                    }
                    else if (targetMaterial == "Fabric" || targetMaterial == "Leather" || targetMaterial == "Rope")
                    {
                        return FeedbackType.PlayerMeleeBladeFabricBluntRight;
                    }
                    else
                    {
                        return FeedbackType.PlayerMeleeBladeStoneBluntRight;
                    }
                }
                else if (sourceMaterial == "Lightsaber")
                {
                    if (targetMaterial == "Lightsaber")
                    {
                        return FeedbackType.PlayerMeleeLightsaberClashRight;
                    }
                    else
                    {
                        return FeedbackType.PlayerMeleeLightsaberBluntRight;
                    }
                }
                else if (sourceMaterial == "Wood")
                {
                    if (targetMaterial == "Blade" || targetMaterial == "Metal" || targetMaterial == "Chainmail" || targetMaterial == "Plate" || targetMaterial == "Lightsaber")
                    {
                        return FeedbackType.PlayerMeleeWoodMetalBluntRight;
                    }
                    else if (targetMaterial == "Wood" || targetMaterial == "Arrow")
                    {
                        return FeedbackType.PlayerMeleeWoodWoodBluntRight;
                    }
                    else if (targetMaterial == "Flesh")
                    {
                        return FeedbackType.PlayerMeleeWoodFleshBluntRight;
                    }
                    else if (targetMaterial == "Fabric" || targetMaterial == "Leather" || targetMaterial == "Rope")
                    {
                        return FeedbackType.PlayerMeleeWoodFabricBluntRight;
                    }
                    else
                    {
                        return FeedbackType.PlayerMeleeWoodStoneBluntRight;
                    }
                }
                else if (sourceMaterial == "Flesh")
                {
                    if (targetMaterial == "Blade" || targetMaterial == "Metal" || targetMaterial == "Chainmail" || targetMaterial == "Plate" || targetMaterial == "Lightsaber")
                    {
                        return FeedbackType.PlayerPunchMetalRight;
                    }
                    else if (targetMaterial == "Wood" || targetMaterial == "Arrow")
                    {
                        return FeedbackType.PlayerPunchWoodRight;
                    }
                    else if (targetMaterial == "Flesh")
                    {
                        return FeedbackType.PlayerPunchFleshRight;
                    }
                    else if (targetMaterial == "Fabric" || targetMaterial == "Leather" || targetMaterial == "Rope")
                    {
                        return FeedbackType.PlayerPunchFabricRight;
                    }
                    else if (targetMaterial == "Stone" || targetMaterial == "Glass")
                    {
                        return FeedbackType.PlayerPunchStoneRight;
                    }
                    else
                    {
                        return FeedbackType.PlayerPunchOtherRight;
                    }
                }
                else
                {
                    if (targetMaterial == "Blade" || targetMaterial == "Metal" || targetMaterial == "Chainmail" || targetMaterial == "Plate" || targetMaterial == "Lightsaber")
                    {
                        return FeedbackType.PlayerMeleeBladeMetalBluntRight;
                    }
                    else if (targetMaterial == "Wood" || targetMaterial == "Arrow")
                    {
                        return FeedbackType.PlayerMeleeWoodStoneBluntRight;
                    }
                    else if (targetMaterial == "Flesh")
                    {
                        return FeedbackType.PlayerMeleeStoneFleshBluntRight;
                    }
                    else if (targetMaterial == "Fabric" || targetMaterial == "Leather" || targetMaterial == "Rope")
                    {
                        return FeedbackType.PlayerMeleeStoneFabricBluntRight;
                    }
                    else
                    {
                        return FeedbackType.PlayerMeleeStoneStoneBluntRight;
                    }
                }
            }
            
        }

        public static FeedbackType GetPlayerGotHitFeedbackType(DamageType damageType, MaterialData sourceMaterialData, MaterialData targetMaterialData, string spellId, DamagerData.PenetrationSize penetrationSize, string sourceColliderName, string targetColliderName, Direction direction, string imbueSpellId, string damagerId)
        {
            string sourceMaterial = "";
            string targetMaterial = "";

            if (sourceMaterialData != null)
            {
                sourceMaterial = sourceMaterialData.id;
            }
            if (targetMaterialData != null)
            {
                targetMaterial = targetMaterialData.id;
            }

            if (targetColliderName.Contains("Arm") && (targetColliderName.Contains("Left") || targetColliderName.Contains("Right")))
            {
                if (damagerId == "BlasterBolt")
                {
                    return FeedbackType.DamageRightArmBlaster;
                }
                else if (damagerId == "BlasterStun")
                {
                    return FeedbackType.DamageRightArmBlasterStun;
                }
                else if (sourceColliderName == "Tip" || sourceMaterial == "Arrow")
                {
                    if (sourceMaterial.Contains("Fire") || imbueSpellId.Contains("Fire"))
                    {
                        return FeedbackType.DamageRightArmFireArrow;
                    }
                    else if (sourceMaterial.Contains("Lightning") || imbueSpellId.Contains("Lightning"))
                    {
                        return FeedbackType.DamageRightArmLightningArrow;
                    }
                    else if (sourceMaterial.Contains("Ice") || imbueSpellId.Contains("Ice"))
                    {
                        return FeedbackType.DamageRightArmIceArrow;
                    }
                    else
                    {
                        return FeedbackType.DamageRightArmArrow;
                    }
                }
                else if (damageType == DamageType.Pierce)
                {
                    if (penetrationSize == DamagerData.PenetrationSize.Small)
                    {
                        if (sourceMaterial == "Lightsaber")
                        {
                            return FeedbackType.DamageRightArmPierceLightsaber;
                        }
                        else if (sourceMaterial.Contains("Fire") || imbueSpellId.Contains("Fire"))
                        {
                            return FeedbackType.DamageRightArmPierceFireSmall;
                        }
                        else if (sourceMaterial.Contains("Lightning") || imbueSpellId.Contains("Lightning"))
                        {
                            return FeedbackType.DamageRightArmPierceLightningSmall;
                        }
                        else if (sourceMaterial.Contains("Ice") || imbueSpellId.Contains("Ice"))
                        {
                            return FeedbackType.DamageRightArmPierceIceSmall;
                        }
                        else if (sourceMaterial == "Blade")
                        {
                            return FeedbackType.DamageRightArmPierceBladeSmall;
                        }
                        else if (sourceMaterial == "Wood")
                        {
                            return FeedbackType.DamageRightArmBluntWoodSmall;
                        }
                        else if (sourceMaterial == "Flesh")
                        {
                            return FeedbackType.DamageRightArmBluntFleshSmall;
                        }
                        else if (sourceMaterial == "Metal")
                        {
                            return FeedbackType.DamageRightArmBluntMetalSmall;
                        }
                        else if (sourceMaterial == "Stone")
                        {
                            return FeedbackType.DamageRightArmBluntStoneSmall;
                        }
                        else
                        {
                            return FeedbackType.DamageRightArmPierceBladeSmall;
                        }
                    }
                    else //Large
                    {
                        if (sourceMaterial == "Lightsaber")
                        {
                            return FeedbackType.DamageRightArmPierceLightsaber;
                        }
                        else if (sourceMaterial.Contains("Fire") || imbueSpellId.Contains("Fire"))
                        {
                            return FeedbackType.DamageRightArmPierceFireLarge;
                        }
                        else if (sourceMaterial.Contains("Lightning") || imbueSpellId.Contains("Lightning"))
                        {
                            return FeedbackType.DamageRightArmPierceLightningLarge;
                        }
                        else if (sourceMaterial.Contains("Ice") || imbueSpellId.Contains("Ice"))
                        {
                            return FeedbackType.DamageRightArmPierceIceLarge;
                        }
                        else if (sourceMaterial == "Blade")
                        {
                            return FeedbackType.DamageRightArmPierceBladeLarge;
                        }
                        else if (sourceMaterial == "Wood")
                        {
                            return FeedbackType.DamageRightArmBluntWoodLarge;
                        }
                        else if (sourceMaterial == "Flesh")
                        {
                            return FeedbackType.DamageRightArmBluntFleshLarge;
                        }
                        else if (sourceMaterial == "Metal")
                        {
                            return FeedbackType.DamageRightArmBluntMetalLarge;
                        }
                        else if (sourceMaterial == "Stone")
                        {
                            return FeedbackType.DamageRightArmBluntStoneLarge;
                        }
                        else
                        {
                            return FeedbackType.DamageRightArmPierceBladeLarge;
                        }
                    }
                }
                else if (damageType == DamageType.Slash)
                {
                    if (penetrationSize == DamagerData.PenetrationSize.Small)
                    {
                        if (sourceMaterial == "Lightsaber")
                        {
                            return FeedbackType.DamageRightArmSlashLightsaber;
                        }
                        else if (sourceMaterial.Contains("Fire") || imbueSpellId.Contains("Fire"))
                        {
                            return FeedbackType.DamageRightArmSlashFireSmall;
                        }
                        else if (sourceMaterial.Contains("Lightning") || imbueSpellId.Contains("Lightning"))
                        {
                            return FeedbackType.DamageRightArmSlashLightningSmall;
                        }
                        else if (sourceMaterial.Contains("Ice") || imbueSpellId.Contains("Ice"))
                        {
                            return FeedbackType.DamageRightArmSlashIceSmall;
                        }
                        else if (sourceMaterial == "Blade")
                        {
                            return FeedbackType.DamageRightArmSlashBladeSmall;
                        }
                        else if (sourceMaterial == "Wood")
                        {
                            return FeedbackType.DamageRightArmBluntWoodSmall;
                        }
                        else if (sourceMaterial == "Flesh")
                        {
                            return FeedbackType.DamageRightArmBluntFleshSmall;
                        }
                        else if (sourceMaterial == "Metal")
                        {
                            return FeedbackType.DamageRightArmBluntMetalSmall;
                        }
                        else if (sourceMaterial == "Stone")
                        {
                            return FeedbackType.DamageRightArmBluntStoneSmall;
                        }
                        else
                        {
                            return FeedbackType.DamageRightArmSlashBladeSmall;
                        }
                    }
                    else //Large
                    {
                        if (sourceMaterial == "Lightsaber")
                        {
                            return FeedbackType.DamageRightArmSlashLightsaber;
                        }
                        else if (sourceMaterial.Contains("Fire") || imbueSpellId.Contains("Fire"))
                        {
                            return FeedbackType.DamageRightArmSlashFireLarge;
                        }
                        else if (sourceMaterial.Contains("Lightning") || imbueSpellId.Contains("Lightning"))
                        {
                            return FeedbackType.DamageRightArmSlashLightningLarge;
                        }
                        else if (sourceMaterial.Contains("Ice") || imbueSpellId.Contains("Ice"))
                        {
                            return FeedbackType.DamageRightArmSlashIceLarge;
                        }
                        else if (sourceMaterial == "Blade")
                        {
                            return FeedbackType.DamageRightArmSlashBladeLarge;
                        }
                        else if (sourceMaterial == "Wood")
                        {
                            return FeedbackType.DamageRightArmBluntWoodLarge;
                        }
                        else if (sourceMaterial == "Flesh")
                        {
                            return FeedbackType.DamageRightArmBluntFleshLarge;
                        }
                        else if (sourceMaterial == "Metal")
                        {
                            return FeedbackType.DamageRightArmBluntMetalLarge;
                        }
                        else if (sourceMaterial == "Stone")
                        {
                            return FeedbackType.DamageRightArmBluntStoneLarge;
                        }
                        else
                        {
                            return FeedbackType.DamageRightArmSlashBladeLarge;
                        }
                    }
                }
                else if (damageType == DamageType.Energy)
                {
                    string lowerId = spellId != "" ? spellId.ToLowerInvariant() : sourceMaterial.ToLowerInvariant();
                    if (sourceMaterial == "Lightsaber")
                    {
                        return FeedbackType.DamageRightArmSlashLightsaber;
                    }
                    else if (lowerId.Contains("fire"))
                    {
                        return FeedbackType.DamageRightArmFire;
                    }
                    else if (lowerId.Contains("blaster"))
                    {
                        return FeedbackType.DamageRightArmFire;
                    }
                    else if (lowerId.Contains("lightning") || lowerId.Contains("electric") || lowerId.Contains("shock"))
                    {
                        return FeedbackType.DamageRightArmLightning;
                    }
                    else if (lowerId.Contains("gravity"))
                    {
                        return FeedbackType.DamageRightArmGravity;
                    }
                    else if (lowerId.Contains("ice") || lowerId.Contains("ıce"))
                    {
                        return FeedbackType.DamageRightArmIce;
                    }
                    else if (lowerId.Contains("drain") || lowerId.Contains("mplo"))
                    {
                        return FeedbackType.DamageRightArmDrain;
                    }
                    else
                    {
                        return FeedbackType.DamageRightArmEnergy;
                    }
                }
                else //Blunt
                {
                    if (penetrationSize == DamagerData.PenetrationSize.Small)
                    {
                        if (sourceMaterial == "Lightsaber")
                        {
                            return FeedbackType.DamageRightArmBluntLightsaber;
                        }
                        else if (sourceMaterial.Contains("Fire") || imbueSpellId.Contains("Fire"))
                        {
                            return FeedbackType.DamageRightArmBluntFireSmall;
                        }
                        else if (sourceMaterial.Contains("Lightning") || imbueSpellId.Contains("Lightning"))
                        {
                            return FeedbackType.DamageRightArmBluntLightningSmall;
                        }
                        else if (sourceMaterial.Contains("Ice") || imbueSpellId.Contains("Ice"))
                        {
                            return FeedbackType.DamageRightArmBluntIceSmall;
                        }
                        else if (sourceMaterial == "Blade")
                        {
                            return FeedbackType.DamageRightArmBluntBladeSmall;
                        }
                        else if (sourceMaterial == "Wood")
                        {
                            return FeedbackType.DamageRightArmBluntWoodSmall;
                        }
                        else if (sourceMaterial == "Flesh")
                        {
                            return FeedbackType.DamageRightArmBluntFleshSmall;
                        }
                        else if (sourceMaterial == "Metal")
                        {
                            return FeedbackType.DamageRightArmBluntMetalSmall;
                        }
                        else if (sourceMaterial == "Stone")
                        {
                            return FeedbackType.DamageRightArmBluntStoneSmall;
                        }
                        else
                        {
                            return FeedbackType.DamageRightArmBluntBladeSmall;
                        }
                    }
                    else //Large
                    {
                        if (sourceMaterial == "Lightsaber")
                        {
                            return FeedbackType.DamageRightArmBluntLightsaber;
                        }
                        else if (sourceMaterial.Contains("Fire") || imbueSpellId.Contains("Fire"))
                        {
                            return FeedbackType.DamageRightArmBluntFireLarge;
                        }
                        else if (sourceMaterial.Contains("Lightning") || imbueSpellId.Contains("Lightning"))
                        {
                            return FeedbackType.DamageRightArmBluntLightningLarge;
                        }
                        else if (sourceMaterial.Contains("Ice") || imbueSpellId.Contains("Ice"))
                        {
                            return FeedbackType.DamageRightArmBluntIceLarge;
                        }
                        else if (sourceMaterial == "Blade")
                        {
                            return FeedbackType.DamageRightArmBluntBladeLarge;
                        }
                        else if (sourceMaterial == "Wood")
                        {
                            return FeedbackType.DamageRightArmBluntWoodLarge;
                        }
                        else if (sourceMaterial == "Flesh")
                        {
                            return FeedbackType.DamageRightArmBluntFleshLarge;
                        }
                        else if (sourceMaterial == "Metal")
                        {
                            return FeedbackType.DamageRightArmBluntMetalLarge;
                        }
                        else if (sourceMaterial == "Stone")
                        {
                            return FeedbackType.DamageRightArmBluntStoneLarge;
                        }
                        else
                        {
                            return FeedbackType.DamageRightArmBluntBladeLarge;
                        }
                    }
                }
            }
            else
            {
                if (targetColliderName.Contains("Head")) //Head
                {
                    if (damagerId == "BlasterBolt")
                    {
                        return FeedbackType.DamageHeadBlaster;
                    }
                    else if (damagerId == "BlasterStun")
                    {
                        return FeedbackType.DamageHeadBlasterStun;
                    }
                    else if (sourceColliderName == "Tip" || sourceMaterial == "Arrow")
                    {
                        if (sourceMaterial.Contains("Fire") || imbueSpellId.Contains("Fire"))
                        {
                            return FeedbackType.DamageHeadFireArrow;
                        }
                        else if (sourceMaterial.Contains("Lightning") || imbueSpellId.Contains("Lightning"))
                        {
                            return FeedbackType.DamageHeadLightningArrow;
                        }
                        else if (sourceMaterial.Contains("Ice") || imbueSpellId.Contains("Ice"))
                        {
                            return FeedbackType.DamageHeadIceArrow;
                        }
                        else
                        {
                            return FeedbackType.DamageHeadArrow;
                        }
                    }
                    else if (damageType == DamageType.Pierce)
                    {
                        if (penetrationSize == DamagerData.PenetrationSize.Small)
                        {
                            if (sourceMaterial == "Lightsaber")
                            {
                                return FeedbackType.DamageHeadPierceLightsaber;
                            }
                            else if (sourceMaterial.Contains("Fire") || imbueSpellId.Contains("Fire"))
                            {
                                return FeedbackType.DamageHeadPierceFireSmall;
                            }
                            else if (sourceMaterial.Contains("Lightning") || imbueSpellId.Contains("Lightning"))
                            {
                                return FeedbackType.DamageHeadPierceLightningSmall;
                            }
                            else if (sourceMaterial.Contains("Ice") || imbueSpellId.Contains("Ice"))
                            {
                                return FeedbackType.DamageHeadPierceIceSmall;
                            }
                            else if (sourceMaterial == "Blade")
                            {
                                return FeedbackType.DamageHeadPierceBladeSmall;
                            }
                            else if (sourceMaterial == "Wood")
                            {
                                return FeedbackType.DamageHeadBluntWoodSmall;
                            }
                            else if (sourceMaterial == "Flesh")
                            {
                                return FeedbackType.DamageHeadBluntFleshSmall;
                            }
                            else if (sourceMaterial == "Metal")
                            {
                                return FeedbackType.DamageHeadBluntMetalSmall;
                            }
                            else if (sourceMaterial == "Stone")
                            {
                                return FeedbackType.DamageHeadBluntStoneSmall;
                            }
                            else
                            {
                                return FeedbackType.DamageHeadPierceBladeSmall;
                            }
                        }
                        else //Large
                        {
                            if (sourceMaterial == "Lightsaber")
                            {
                                return FeedbackType.DamageHeadPierceLightsaber;
                            }
                            else if (sourceMaterial.Contains("Fire") || imbueSpellId.Contains("Fire"))
                            {
                                return FeedbackType.DamageHeadPierceFireLarge;
                            }
                            else if (sourceMaterial.Contains("Lightning") || imbueSpellId.Contains("Lightning"))
                            {
                                return FeedbackType.DamageHeadPierceLightningLarge;
                            }
                            else if (sourceMaterial.Contains("Ice") || imbueSpellId.Contains("Ice"))
                            {
                                return FeedbackType.DamageHeadPierceIceLarge;
                            }
                            else if (sourceMaterial == "Blade")
                            {
                                return FeedbackType.DamageHeadPierceBladeLarge;
                            }
                            else if (sourceMaterial == "Wood")
                            {
                                return FeedbackType.DamageHeadBluntWoodLarge;
                            }
                            else if (sourceMaterial == "Flesh")
                            {
                                return FeedbackType.DamageHeadBluntFleshLarge;
                            }
                            else if (sourceMaterial == "Metal")
                            {
                                return FeedbackType.DamageHeadBluntMetalLarge;
                            }
                            else if (sourceMaterial == "Stone")
                            {
                                return FeedbackType.DamageHeadBluntStoneLarge;
                            }
                            else
                            {
                                return FeedbackType.DamageHeadPierceBladeLarge;
                            }
                        }
                    }
                    else if (damageType == DamageType.Slash)
                    {
                        if (penetrationSize == DamagerData.PenetrationSize.Small)
                        {
                            if (sourceMaterial == "Lightsaber")
                            {
                                return FeedbackType.DamageHeadSlashLightsaber;
                            }
                            else if (sourceMaterial.Contains("Fire") || imbueSpellId.Contains("Fire"))
                            {
                                return FeedbackType.DamageHeadSlashFireSmall;
                            }
                            else if (sourceMaterial.Contains("Lightning") || imbueSpellId.Contains("Lightning"))
                            {
                                return FeedbackType.DamageHeadSlashLightningSmall;
                            }
                            else if (sourceMaterial.Contains("Ice") || imbueSpellId.Contains("Ice"))
                            {
                                return FeedbackType.DamageHeadSlashIceSmall;
                            }
                            else if (sourceMaterial == "Blade")
                            {
                                return FeedbackType.DamageHeadSlashBladeSmall;
                            }
                            else if (sourceMaterial == "Wood")
                            {
                                return FeedbackType.DamageHeadBluntWoodSmall;
                            }
                            else if (sourceMaterial == "Flesh")
                            {
                                return FeedbackType.DamageHeadBluntFleshSmall;
                            }
                            else if (sourceMaterial == "Metal")
                            {
                                return FeedbackType.DamageHeadBluntMetalSmall;
                            }
                            else if (sourceMaterial == "Stone")
                            {
                                return FeedbackType.DamageHeadBluntStoneSmall;
                            }
                            else
                            {
                                return FeedbackType.DamageHeadSlashBladeSmall;
                            }
                        }
                        else //Large
                        {
                            if (sourceMaterial == "Lightsaber")
                            {
                                return FeedbackType.DamageHeadSlashLightsaber;
                            }
                            else if (sourceMaterial.Contains("Fire") || imbueSpellId.Contains("Fire"))
                            {
                                return FeedbackType.DamageHeadSlashFireLarge;
                            }
                            else if (sourceMaterial.Contains("Lightning") || imbueSpellId.Contains("Lightning"))
                            {
                                return FeedbackType.DamageHeadSlashLightningLarge;
                            }
                            else if (sourceMaterial.Contains("Ice") || imbueSpellId.Contains("Ice"))
                            {
                                return FeedbackType.DamageHeadSlashIceLarge;
                            }
                            else if (sourceMaterial == "Blade")
                            {
                                return FeedbackType.DamageHeadSlashBladeLarge;
                            }
                            else if (sourceMaterial == "Wood")
                            {
                                return FeedbackType.DamageHeadBluntWoodLarge;
                            }
                            else if (sourceMaterial == "Flesh")
                            {
                                return FeedbackType.DamageHeadBluntFleshLarge;
                            }
                            else if (sourceMaterial == "Metal")
                            {
                                return FeedbackType.DamageHeadBluntMetalLarge;
                            }
                            else if (sourceMaterial == "Stone")
                            {
                                return FeedbackType.DamageHeadBluntStoneLarge;
                            }
                            else
                            {
                                return FeedbackType.DamageHeadSlashBladeLarge;
                            }
                        }
                    }
                    else if (damageType == DamageType.Energy)
                    {
                        string lowerId = spellId != "" ? spellId.ToLowerInvariant() : sourceMaterial.ToLowerInvariant();
                        if (sourceMaterial == "Lightsaber")
                        {
                            return FeedbackType.DamageHeadSlashLightsaber;
                        }
                        else if (lowerId.Contains("fire"))
                        {
                            return FeedbackType.DamageHeadFire;
                        }
                        else if (lowerId.Contains("lightning") || lowerId.Contains("electric") || lowerId.Contains("shock"))
                        {
                            return FeedbackType.DamageHeadLightning;
                        }
                        else if (lowerId.Contains("gravity"))
                        {
                            return FeedbackType.DamageHeadGravity;
                        }
                        else if (lowerId.Contains("ice") || lowerId.Contains("ıce"))
                        {
                            return FeedbackType.DamageHeadIce;
                        }
                        else if (lowerId.Contains("drain") || lowerId.Contains("mplo"))
                        {
                            return FeedbackType.DamageHeadDrain;
                        }
                        else
                        {
                            return FeedbackType.DamageHeadEnergy;
                        }
                    }
                    else //Blunt
                    {
                        if (penetrationSize == DamagerData.PenetrationSize.Small)
                        {
                            if (sourceMaterial == "Lightsaber")
                            {
                                return FeedbackType.DamageHeadBluntLightsaber;
                            }
                            else if (sourceMaterial.Contains("Fire") || imbueSpellId.Contains("Fire"))
                            {
                                return FeedbackType.DamageHeadBluntFireSmall;
                            }
                            else if (sourceMaterial.Contains("Lightning") || imbueSpellId.Contains("Lightning"))
                            {
                                return FeedbackType.DamageHeadBluntLightningSmall;
                            }
                            else if (sourceMaterial.Contains("Ice") || imbueSpellId.Contains("Ice"))
                            {
                                return FeedbackType.DamageHeadBluntIceSmall;
                            }
                            else if (sourceMaterial == "Blade")
                            {
                                return FeedbackType.DamageHeadBluntBladeSmall;
                            }
                            else if (sourceMaterial == "Wood")
                            {
                                return FeedbackType.DamageHeadBluntWoodSmall;
                            }
                            else if (sourceMaterial == "Flesh")
                            {
                                return FeedbackType.DamageHeadBluntFleshSmall;
                            }
                            else if (sourceMaterial == "Metal")
                            {
                                return FeedbackType.DamageHeadBluntMetalSmall;
                            }
                            else if (sourceMaterial == "Stone")
                            {
                                return FeedbackType.DamageHeadBluntStoneSmall;
                            }
                            else
                            {
                                return FeedbackType.DamageHeadBluntBladeSmall;
                            }
                        }
                        else //Large
                        {
                            if (sourceMaterial == "Lightsaber")
                            {
                                return FeedbackType.DamageHeadBluntLightsaber;
                            }
                            else if (sourceMaterial.Contains("Fire") || imbueSpellId.Contains("Fire"))
                            {
                                return FeedbackType.DamageHeadBluntFireLarge;
                            }
                            else if (sourceMaterial.Contains("Lightning") || imbueSpellId.Contains("Lightning"))
                            {
                                return FeedbackType.DamageHeadBluntLightningLarge;
                            }
                            else if (sourceMaterial.Contains("Ice") || imbueSpellId.Contains("Ice"))
                            {
                                return FeedbackType.DamageHeadBluntIceLarge;
                            }
                            else if (sourceMaterial == "Blade")
                            {
                                return FeedbackType.DamageHeadBluntBladeLarge;
                            }
                            else if (sourceMaterial == "Wood")
                            {
                                return FeedbackType.DamageHeadBluntWoodLarge;
                            }
                            else if (sourceMaterial == "Flesh")
                            {
                                return FeedbackType.DamageHeadBluntFleshLarge;
                            }
                            else if (sourceMaterial == "Metal")
                            {
                                return FeedbackType.DamageHeadBluntMetalLarge;
                            }
                            else if (sourceMaterial == "Stone")
                            {
                                return FeedbackType.DamageHeadBluntStoneLarge;
                            }
                            else
                            {
                                return FeedbackType.DamageHeadBluntBladeLarge;
                            }
                        }
                    }
                }
                else //Vest
                {
                    if (damagerId == "BlasterBolt")
                    {
                        return FeedbackType.DamageVestBlaster;
                    }
                    else if (damagerId == "BlasterStun")
                    {
                        return FeedbackType.DamageVestBlasterStun;
                    }
                    else if (sourceColliderName == "Tip" || sourceMaterial == "Arrow")
                    {
                        if (sourceMaterial == "Lightsaber")
                        {
                            return FeedbackType.DamageVestPierceLightsaber;
                        }
                        else if (sourceMaterial.Contains("Fire") || imbueSpellId.Contains("Fire"))
                        {
                            return FeedbackType.DamageVestFireArrow;
                        }
                        else if (sourceMaterial.Contains("Lightning") || imbueSpellId.Contains("Lightning"))
                        {
                            return FeedbackType.DamageVestLightningArrow;
                        }
                        else if (sourceMaterial.Contains("Ice") || imbueSpellId.Contains("Ice"))
                        {
                            return FeedbackType.DamageVestIceArrow;
                        }
                        else
                        {
                            return FeedbackType.DamageVestArrow;
                        }
                    }
                    else if (damageType == DamageType.Pierce)
                    {
                        if (penetrationSize == DamagerData.PenetrationSize.Small)
                        {
                            if (sourceMaterial == "Lightsaber")
                            {
                                return FeedbackType.DamageVestPierceLightsaber;
                            }
                            else if (sourceMaterial.Contains("Fire") || imbueSpellId.Contains("Fire"))
                            {
                                return FeedbackType.DamageVestPierceFireSmall;
                            }
                            else if (sourceMaterial.Contains("Ice") || imbueSpellId.Contains("Ice"))
                            {
                                return FeedbackType.DamageVestPierceIceSmall;
                            }
                            else if (sourceMaterial.Contains("Lightning") || imbueSpellId.Contains("Lightning"))
                            {
                                return FeedbackType.DamageVestPierceLightningSmall;
                            }
                            else if (sourceMaterial == "Blade")
                            {
                                return FeedbackType.DamageVestPierceBladeSmall;
                            }
                            else if (sourceMaterial == "Wood")
                            {
                                return FeedbackType.DamageVestBluntWoodSmall;
                            }
                            else if (sourceMaterial == "Flesh")
                            {
                                return FeedbackType.DamageVestBluntFleshSmall;
                            }
                            else if (sourceMaterial == "Metal")
                            {
                                return FeedbackType.DamageVestBluntMetalSmall;
                            }
                            else if (sourceMaterial == "Stone")
                            {
                                return FeedbackType.DamageVestBluntStoneSmall;
                            }
                            else
                            {
                                return FeedbackType.DamageVestPierceBladeSmall;
                            }
                        }
                        else //Large
                        {
                            if (sourceMaterial == "Lightsaber")
                            {
                                return FeedbackType.DamageVestPierceLightsaber;
                            }
                            else if (sourceMaterial.Contains("Fire") || imbueSpellId.Contains("Fire"))
                            {
                                return FeedbackType.DamageVestPierceFireLarge;
                            }
                            else if (sourceMaterial.Contains("Ice") || imbueSpellId.Contains("Ice"))
                            {
                                return FeedbackType.DamageVestPierceIceLarge;
                            }
                            else if (sourceMaterial.Contains("Lightning") || imbueSpellId.Contains("Lightning"))
                            {
                                return FeedbackType.DamageVestPierceLightningLarge;
                            }
                            else if (sourceMaterial == "Blade")
                            {
                                return FeedbackType.DamageVestPierceBladeLarge;
                            }
                            else if (sourceMaterial == "Wood")
                            {
                                return FeedbackType.DamageVestBluntWoodLarge;
                            }
                            else if (sourceMaterial == "Flesh")
                            {
                                return FeedbackType.DamageVestBluntFleshLarge;
                            }
                            else if (sourceMaterial == "Metal")
                            {
                                return FeedbackType.DamageVestBluntMetalLarge;
                            }
                            else if (sourceMaterial == "Stone")
                            {
                                return FeedbackType.DamageVestBluntStoneLarge;
                            }
                            else
                            {
                                return FeedbackType.DamageVestPierceBladeLarge;
                            }
                        }
                    }
                    else if (damageType == DamageType.Slash)
                    {
                        if (penetrationSize == DamagerData.PenetrationSize.Small)
                        {
                            if (sourceMaterial.Contains("Fire") || imbueSpellId.Contains("Fire"))
                            {
                                if (direction == Direction.LeftRightDown)
                                    return FeedbackType.DamageVestSlashFireSmallLRD;
                                else if (direction == Direction.LeftRightUp)
                                    return FeedbackType.DamageVestSlashFireSmallLRU;
                                else if (direction == Direction.RightLeftDown)
                                    return FeedbackType.DamageVestSlashFireSmallRLD;
                                else if (direction == Direction.RightLeftUp)
                                    return FeedbackType.DamageVestSlashFireSmallRLU;
                                else
                                    return FeedbackType.DamageVestSlashFireSmallLRD;
                            }
                            else if (sourceMaterial.Contains("Lightning") || imbueSpellId.Contains("Lightning"))
                            {
                                if (direction == Direction.LeftRightDown)
                                    return FeedbackType.DamageVestSlashLightningSmallLRD;
                                else if (direction == Direction.LeftRightUp)
                                    return FeedbackType.DamageVestSlashLightningSmallLRU;
                                else if (direction == Direction.RightLeftDown)
                                    return FeedbackType.DamageVestSlashLightningSmallRLD;
                                else if (direction == Direction.RightLeftUp)
                                    return FeedbackType.DamageVestSlashLightningSmallRLU;
                                else
                                    return FeedbackType.DamageVestSlashLightningSmallLRD;
                            }
                            else if (sourceMaterial.Contains("Ice") || imbueSpellId.Contains("Ice"))
                            {
                                if (direction == Direction.LeftRightDown)
                                    return FeedbackType.DamageVestSlashIceSmallLRD;
                                else if (direction == Direction.LeftRightUp)
                                    return FeedbackType.DamageVestSlashIceSmallLRU;
                                else if (direction == Direction.RightLeftDown)
                                    return FeedbackType.DamageVestSlashIceSmallRLD;
                                else if (direction == Direction.RightLeftUp)
                                    return FeedbackType.DamageVestSlashIceSmallRLU;
                                else
                                    return FeedbackType.DamageVestSlashIceSmallLRD;
                            }
                            else if (sourceMaterial == "Lightsaber")
                            {
                                if (direction == Direction.LeftRightDown)
                                    return FeedbackType.DamageVestSlashLightsaberLRD;
                                else if (direction == Direction.LeftRightUp)
                                    return FeedbackType.DamageVestSlashLightsaberLRU;
                                else if (direction == Direction.RightLeftDown)
                                    return FeedbackType.DamageVestSlashLightsaberRLD;
                                else if (direction == Direction.RightLeftUp)
                                    return FeedbackType.DamageVestSlashLightsaberRLU;
                                else
                                    return FeedbackType.DamageVestSlashLightsaberLRD;
                            }
                            else if (sourceMaterial == "Blade")
                            {
                                if (direction == Direction.LeftRightDown)
                                    return FeedbackType.DamageVestSlashBladeSmallLRD;
                                else if (direction == Direction.LeftRightUp)
                                    return FeedbackType.DamageVestSlashBladeSmallLRU;
                                else if (direction == Direction.RightLeftDown)
                                    return FeedbackType.DamageVestSlashBladeSmallRLD;
                                else if (direction == Direction.RightLeftUp)
                                    return FeedbackType.DamageVestSlashBladeSmallRLU;
                                else
                                    return FeedbackType.DamageVestSlashBladeSmallLRD;
                            }
                            else if (sourceMaterial == "Wood")
                            {
                                return FeedbackType.DamageVestBluntWoodSmall;
                            }
                            else if (sourceMaterial == "Flesh")
                            {
                                return FeedbackType.DamageVestBluntFleshSmall;
                            }
                            else if (sourceMaterial == "Metal")
                            {
                                return FeedbackType.DamageVestBluntMetalSmall;
                            }
                            else if (sourceMaterial == "Stone")
                            {
                                return FeedbackType.DamageVestBluntStoneSmall;
                            }
                            else
                            {
                                if (direction == Direction.LeftRightDown)
                                    return FeedbackType.DamageVestSlashBladeSmallLRD;
                                else if (direction == Direction.LeftRightUp)
                                    return FeedbackType.DamageVestSlashBladeSmallLRU;
                                else if (direction == Direction.RightLeftDown)
                                    return FeedbackType.DamageVestSlashBladeSmallRLD;
                                else if (direction == Direction.RightLeftUp)
                                    return FeedbackType.DamageVestSlashBladeSmallRLU;
                                else
                                    return FeedbackType.DamageVestSlashBladeSmallLRD;
                            }
                        }
                        else //Large
                        {
                            if (sourceMaterial.Contains("Fire") || imbueSpellId.Contains("Fire"))
                            {
                                if (direction == Direction.LeftRightDown)
                                    return FeedbackType.DamageVestSlashFireLargeLRD;
                                else if (direction == Direction.LeftRightUp)
                                    return FeedbackType.DamageVestSlashFireLargeLRU;
                                else if (direction == Direction.RightLeftDown)
                                    return FeedbackType.DamageVestSlashFireLargeRLD;
                                else if (direction == Direction.RightLeftUp)
                                    return FeedbackType.DamageVestSlashFireLargeRLU;
                                else
                                    return FeedbackType.DamageVestSlashFireLargeLRD;
                            }
                            else if (sourceMaterial.Contains("Ice") || imbueSpellId.Contains("Ice"))
                            {
                                if (direction == Direction.LeftRightDown)
                                    return FeedbackType.DamageVestSlashIceLargeLRD;
                                else if (direction == Direction.LeftRightUp)
                                    return FeedbackType.DamageVestSlashIceLargeLRU;
                                else if (direction == Direction.RightLeftDown)
                                    return FeedbackType.DamageVestSlashIceLargeRLD;
                                else if (direction == Direction.RightLeftUp)
                                    return FeedbackType.DamageVestSlashIceLargeRLU;
                                else
                                    return FeedbackType.DamageVestSlashIceLargeLRD;
                            }
                            else if (sourceMaterial.Contains("Lightning") || imbueSpellId.Contains("Lightning"))
                            {
                                if (direction == Direction.LeftRightDown)
                                    return FeedbackType.DamageVestSlashLightningLargeLRD;
                                else if (direction == Direction.LeftRightUp)
                                    return FeedbackType.DamageVestSlashLightningLargeLRU;
                                else if (direction == Direction.RightLeftDown)
                                    return FeedbackType.DamageVestSlashLightningLargeRLD;
                                else if (direction == Direction.RightLeftUp)
                                    return FeedbackType.DamageVestSlashLightningLargeRLU;
                                else
                                    return FeedbackType.DamageVestSlashLightningLargeLRD;
                            }
                            else if (sourceMaterial == "Lightsaber")
                            {
                                if (direction == Direction.LeftRightDown)
                                    return FeedbackType.DamageVestSlashLightsaberLRD;
                                else if (direction == Direction.LeftRightUp)
                                    return FeedbackType.DamageVestSlashLightsaberLRU;
                                else if (direction == Direction.RightLeftDown)
                                    return FeedbackType.DamageVestSlashLightsaberRLD;
                                else if (direction == Direction.RightLeftUp)
                                    return FeedbackType.DamageVestSlashLightsaberRLU;
                                else
                                    return FeedbackType.DamageVestSlashLightsaberLRD;
                            }
                            else if (sourceMaterial == "Blade")
                            {
                                if (direction == Direction.LeftRightDown)
                                    return FeedbackType.DamageVestSlashBladeLargeLRD;
                                else if (direction == Direction.LeftRightUp)
                                    return FeedbackType.DamageVestSlashBladeLargeLRU;
                                else if (direction == Direction.RightLeftDown)
                                    return FeedbackType.DamageVestSlashBladeLargeRLD;
                                else if (direction == Direction.RightLeftUp)
                                    return FeedbackType.DamageVestSlashBladeLargeRLU;
                                else
                                    return FeedbackType.DamageVestSlashBladeLargeLRD;
                            }
                            else if (sourceMaterial == "Wood")
                            {
                                return FeedbackType.DamageVestBluntWoodLarge;
                            }
                            else if (sourceMaterial == "Flesh")
                            {
                                return FeedbackType.DamageVestBluntFleshLarge;
                            }
                            else if (sourceMaterial == "Metal")
                            {
                                return FeedbackType.DamageVestBluntMetalLarge;
                            }
                            else if (sourceMaterial == "Stone")
                            {
                                return FeedbackType.DamageVestBluntStoneLarge;
                            }
                            else
                            {
                                if (direction == Direction.LeftRightDown)
                                    return FeedbackType.DamageVestSlashBladeLargeLRD;
                                else if (direction == Direction.LeftRightUp)
                                    return FeedbackType.DamageVestSlashBladeLargeLRU;
                                else if (direction == Direction.RightLeftDown)
                                    return FeedbackType.DamageVestSlashBladeLargeRLD;
                                else if (direction == Direction.RightLeftUp)
                                    return FeedbackType.DamageVestSlashBladeLargeRLU;
                                else
                                    return FeedbackType.DamageVestSlashBladeLargeLRD;
                            }
                        }
                    }
                    else if (damageType == DamageType.Energy)
                    {
                        string lowerId = spellId != "" ? spellId.ToLowerInvariant() : sourceMaterial.ToLowerInvariant();
                        if (sourceMaterial == "Lightsaber")
                        {
                            if (direction == Direction.LeftRightDown)
                                return FeedbackType.DamageVestSlashLightsaberLRD;
                            else if (direction == Direction.LeftRightUp)
                                return FeedbackType.DamageVestSlashLightsaberLRU;
                            else if (direction == Direction.RightLeftDown)
                                return FeedbackType.DamageVestSlashLightsaberRLD;
                            else if (direction == Direction.RightLeftUp)
                                return FeedbackType.DamageVestSlashLightsaberRLU;
                            else
                                return FeedbackType.DamageVestSlashLightsaberLRD;
                        }
                        else if (lowerId.Contains("fire"))
                        {
                            return FeedbackType.DamageVestFire;
                        }
                        else if (lowerId.Contains("lightning") || lowerId.Contains("electric") || lowerId.Contains("shock"))
                        {
                            return FeedbackType.DamageVestLightning;
                        }
                        else if (lowerId.Contains("ice") || lowerId.Contains("ıce"))
                        {
                            return FeedbackType.DamageVestIce;
                        }
                        else if (lowerId.Contains("drain") || lowerId.Contains("mplo"))
                        {
                            return FeedbackType.DamageVestDrain;
                        }
                        else if (lowerId.Contains("gravity"))
                        {
                            return FeedbackType.DamageVestGravity;
                        }
                        else
                        {
                            return FeedbackType.DamageVestEnergy;
                        }
                    }
                    else //Blunt
                    {
                        if (penetrationSize == DamagerData.PenetrationSize.Small)
                        {
                            if (sourceMaterial == "Lightsaber")
                            {
                                return FeedbackType.DamageVestBluntLightsaber;
                            }
                            else if (sourceMaterial.Contains("Fire") || imbueSpellId.Contains("Fire"))
                            {
                                return FeedbackType.DamageVestBluntFireSmall;
                            }
                            else if (sourceMaterial.Contains("Lightning") || imbueSpellId.Contains("Lightning"))
                            {
                                return FeedbackType.DamageVestBluntLightningSmall;
                            }
                            else if (sourceMaterial.Contains("Ice") || imbueSpellId.Contains("Ice"))
                            {
                                return FeedbackType.DamageVestBluntIceSmall;
                            }
                            else if (sourceMaterial == "Blade")
                            {
                                return FeedbackType.DamageVestBluntBladeSmall;
                            }
                            else if (sourceMaterial == "Wood")
                            {
                                return FeedbackType.DamageVestBluntWoodSmall;
                            }
                            else if (sourceMaterial == "Flesh")
                            {
                                return FeedbackType.DamageVestBluntFleshSmall;
                            }
                            else if (sourceMaterial == "Metal")
                            {
                                return FeedbackType.DamageVestBluntMetalSmall;
                            }
                            else if (sourceMaterial == "Stone")
                            {
                                return FeedbackType.DamageVestBluntStoneSmall;
                            }
                            else
                            {
                                return FeedbackType.DamageVestBluntBladeSmall;
                            }
                        }
                        else //Large
                        {
                            if (sourceMaterial == "Lightsaber")
                            {
                                return FeedbackType.DamageVestBluntLightsaber;
                            }
                            else if (sourceMaterial.Contains("Fire") || imbueSpellId.Contains("Fire"))
                            {
                                return FeedbackType.DamageVestBluntFireLarge;
                            }
                            else if (sourceMaterial.Contains("Lightning") || imbueSpellId.Contains("Lightning"))
                            {
                                return FeedbackType.DamageVestBluntLightningLarge;
                            }
                            else if (sourceMaterial.Contains("Ice") || imbueSpellId.Contains("Ice"))
                            {
                                return FeedbackType.DamageVestBluntIceLarge;
                            }
                            else if (sourceMaterial == "Blade")
                            {
                                return FeedbackType.DamageVestBluntBladeLarge;
                            }
                            else if (sourceMaterial == "Wood")
                            {
                                return FeedbackType.DamageVestBluntWoodLarge;
                            }
                            else if (sourceMaterial == "Flesh")
                            {
                                return FeedbackType.DamageVestBluntFleshLarge;
                            }
                            else if (sourceMaterial == "Metal")
                            {
                                return FeedbackType.DamageVestBluntMetalLarge;
                            }
                            else if (sourceMaterial == "Stone")
                            {
                                return FeedbackType.DamageVestBluntStoneLarge;
                            }
                            else
                            {
                                return FeedbackType.DamageVestBluntBladeLarge;
                            }
                        }
                    }
                }
            }

            return FeedbackType.DefaultDamage;
        }

        public struct Feedback
        {
            public Feedback(FeedbackType _feedbackType, string _prefix, int _feedbackFileCount)
            {
                feedbackType = _feedbackType;
                prefix = _prefix;
                feedbackFileCount = _feedbackFileCount;
            }
            public FeedbackType feedbackType;
            public string prefix;
            public int feedbackFileCount;
        };

        void TactFileRegister(string fullname, Feedback feedback)
        {
            if (feedbackMap.ContainsKey(feedback.feedbackType))
            {
                Feedback f = feedbackMap[feedback.feedbackType];
                f.feedbackFileCount += 1;
                feedbackMap[feedback.feedbackType] = f;

                string tactFileStr = File.ReadAllText(fullname);
                hapticPlayer.RegisterTactFileStr(feedback.prefix + (feedbackMap[feedback.feedbackType].feedbackFileCount).ToString(), tactFileStr);
                if (feedback.prefix.Contains("Right"))
                {
                    string reflectedStr = tactFileStr;
                    if(reflectedStr.Contains("Forearm"))
                        reflectedStr = reflectedStr.Replace("\"ForearmR\"", "\"ForearmM\"").Replace("\"ForearmL\"", "\"ForearmR\"").Replace("\"ForearmM\"", "\"ForearmL\"");
                    if (reflectedStr.Contains("Foot"))
                        reflectedStr = reflectedStr.Replace("\"FootR\"", "\"FootM\"").Replace("\"FootL\"", "\"FootR\"").Replace("\"FootM\"", "\"FootL\"");

                    hapticPlayer.RegisterTactFileStr("Reflected_" + feedback.prefix + (feedbackMap[feedback.feedbackType].feedbackFileCount).ToString(), reflectedStr);
                }
            }
        }

        void RegisterFeedbackFiles()
        {
            string configPath = Directory.GetCurrentDirectory() + "\\BladeAndSorcery_Data\\StreamingAssets";

            DirectoryInfo d = new DirectoryInfo(configPath);
            FileInfo[] Files = d.GetFiles("*.tact", SearchOption.AllDirectories);

            for (int i = 0; i < Files.Length; i++)
            {
                string filename = Files[i].Name;
                string fullName = Files[i].FullName;
                if (filename == "." || filename == "..")
                    continue;

                foreach (var element in feedbackMap)
                {
                    if (filename.StartsWith(element.Value.prefix))
                    {
                        TactFileRegister(fullName, element.Value);
                        LOG("Tact file registered: " + filename);
                        break;
                    }
                }
            }

            
        }

        public void CreateSystem()
        {
            if (!systemInitialized)
            {
                hapticPlayer = new Bhaptics.Tact.HapticPlayer("mod_blade_sorcery", "mod_blade_sorcery");

                if (hapticPlayer != null)
                {
                    RegisterFeedbackFiles();
                    systemInitialized = true;
                }
            }
        }

        bool IsPlayingKeyAll(bool reflected, string prefix, int feedbackFileCount)
        {
            for (int i = 1; i <= feedbackFileCount; i++)
            {
                string key = (reflected ? "Reflected_" : "") + prefix + i.ToString();
                if (hapticPlayer.IsPlaying(key))
                {
                    return true;
                }
            }
            return false;
        }

        public float GetIntensityMultiplier(TactsuitVR.FeedbackType feedbackType)
        {
            switch (feedbackType)
            {
                case TactsuitVR.FeedbackType.DefaultDamage: return IntensityDefaultDamage; break;
                case TactsuitVR.FeedbackType.PlayerBowPullRight: return IntensityPlayerBowPull; break;
                case TactsuitVR.FeedbackType.PlayerMeleeBladeWoodPierceRight: return IntensityPlayerMeleeBladeWoodPierce; break;
                case TactsuitVR.FeedbackType.PlayerMeleeBladeMetalPierceRight: return IntensityPlayerMeleeBladeMetalPierce; break;
                case TactsuitVR.FeedbackType.PlayerMeleeBladeStonePierceRight: return IntensityPlayerMeleeBladeStonePierce; break;
                case TactsuitVR.FeedbackType.PlayerMeleeBladeFabricPierceRight: return IntensityPlayerMeleeBladeFabricPierce; break;
                case TactsuitVR.FeedbackType.PlayerMeleeBladeFleshPierceRight: return IntensityPlayerMeleeBladeFleshPierce; break;
                case TactsuitVR.FeedbackType.PlayerMeleeBladeWoodSlashRight: return IntensityPlayerMeleeBladeWoodSlash; break;
                case TactsuitVR.FeedbackType.PlayerMeleeBladeMetalSlashRight: return IntensityPlayerMeleeBladeMetalSlash; break;
                case TactsuitVR.FeedbackType.PlayerMeleeBladeStoneSlashRight: return IntensityPlayerMeleeBladeStoneSlash; break;
                case TactsuitVR.FeedbackType.PlayerMeleeBladeFabricSlashRight: return IntensityPlayerMeleeBladeFabricSlash; break;
                case TactsuitVR.FeedbackType.PlayerMeleeBladeFleshSlashRight: return IntensityPlayerMeleeBladeFleshSlash; break;
                case TactsuitVR.FeedbackType.PlayerMeleeBladeWoodBluntRight: return IntensityPlayerMeleeBladeWoodBlunt; break;
                case TactsuitVR.FeedbackType.PlayerMeleeBladeMetalBluntRight: return IntensityPlayerMeleeBladeMetalBlunt; break;
                case TactsuitVR.FeedbackType.PlayerMeleeBladeStoneBluntRight: return IntensityPlayerMeleeBladeStoneBlunt; break;
                case TactsuitVR.FeedbackType.PlayerMeleeBladeFabricBluntRight: return IntensityPlayerMeleeBladeFabricBlunt; break;
                case TactsuitVR.FeedbackType.PlayerMeleeBladeFleshBluntRight: return IntensityPlayerMeleeBladeFleshBlunt; break;
                case TactsuitVR.FeedbackType.PlayerMeleeWoodWoodBluntRight: return IntensityPlayerMeleeWoodWoodBlunt; break;
                case TactsuitVR.FeedbackType.PlayerMeleeWoodMetalBluntRight: return IntensityPlayerMeleeWoodMetalBlunt; break;
                case TactsuitVR.FeedbackType.PlayerMeleeWoodStoneBluntRight: return IntensityPlayerMeleeWoodStoneBlunt; break;
                case TactsuitVR.FeedbackType.PlayerMeleeWoodFabricBluntRight: return IntensityPlayerMeleeWoodFabricBlunt; break;
                case TactsuitVR.FeedbackType.PlayerMeleeWoodFleshBluntRight: return IntensityPlayerMeleeWoodFleshBlunt; break;
                case TactsuitVR.FeedbackType.PlayerMeleeStoneStoneBluntRight: return IntensityPlayerMeleeStoneStoneBlunt; break;
                case TactsuitVR.FeedbackType.PlayerMeleeStoneFabricBluntRight: return IntensityPlayerMeleeStoneFabricBlunt; break;
                case TactsuitVR.FeedbackType.PlayerMeleeStoneFleshBluntRight: return IntensityPlayerMeleeStoneFleshBlunt; break;

                case TactsuitVR.FeedbackType.PlayerMeleeLightsaberClashRight: return IntensityPlayerMeleeLightsaberClashRight; break;
                case TactsuitVR.FeedbackType.PlayerMeleeLightsaberSlashRight: return IntensityPlayerMeleeLightsaberSlashRight; break;
                case TactsuitVR.FeedbackType.PlayerMeleeLightsaberPierceRight: return IntensityPlayerMeleeLightsaberPierceRight; break;
                case TactsuitVR.FeedbackType.PlayerMeleeLightsaberBluntRight: return IntensityPlayerMeleeLightsaberBluntRight; break;

                case TactsuitVR.FeedbackType.PlayerSpellFireRight: return IntensityPlayerSpellFire; break;
                case TactsuitVR.FeedbackType.PlayerSpellLightningRight: return IntensityPlayerSpellLightning; break;
                case TactsuitVR.FeedbackType.PlayerSpellGravityRight: return IntensityPlayerSpellGravity; break;
                case TactsuitVR.FeedbackType.PlayerSpellIceRight: return IntensityPlayerSpellIce; break;
                case TactsuitVR.FeedbackType.PlayerSpellCrushRight: return IntensityPlayerSpellCrush; break;
                case TactsuitVR.FeedbackType.PlayerSpellHealRight: return IntensityPlayerSpellHeal; break;
                case TactsuitVR.FeedbackType.PlayerSpellImplosionRight: return IntensityPlayerSpellImplosion; break;
                case TactsuitVR.FeedbackType.PlayerSpellInvisibilityRight: return IntensityPlayerSpellInvisibility; break;
                case TactsuitVR.FeedbackType.PlayerSpellTeslaRight: return IntensityPlayerSpellTesla; break;
                case TactsuitVR.FeedbackType.PlayerSpellUtilityRight: return IntensityPlayerSpellUtility; break;
                case TactsuitVR.FeedbackType.PlayerSpellCorruptionRight: return IntensityPlayerSpellCorruption; break;
                case TactsuitVR.FeedbackType.PlayerSpellTeleportRight: return IntensityPlayerSpellTeleport; break;
                case TactsuitVR.FeedbackType.PlayerSpellRasenganRight: return IntensityPlayerSpellRasengan; break;
                case TactsuitVR.FeedbackType.PlayerSpellNeedleRight: return IntensityPlayerSpellNeedle; break;
                case TactsuitVR.FeedbackType.PlayerSpellDrainRight: return IntensityPlayerSpellDrain; break;
                case TactsuitVR.FeedbackType.PlayerSpellForceFieldRight: return IntensityPlayerSpellForceField; break;
                case TactsuitVR.FeedbackType.PlayerSpellOtherRight: return IntensityPlayerSpellOther; break;
                case TactsuitVR.FeedbackType.PlayerTelekinesisActiveRight: return IntensityPlayerTelekinesisActive; break;
                case TactsuitVR.FeedbackType.PlayerTelekinesisPullRight: return IntensityPlayerTelekinesisPull; break;
                case TactsuitVR.FeedbackType.PlayerTelekinesisRepelRight: return IntensityPlayerTelekinesisRepel; break;
                case TactsuitVR.FeedbackType.PlayerTelekinesisCatchRight: return IntensityPlayerTelekinesisCatch; break;
                case TactsuitVR.FeedbackType.DamageVestArrow: return IntensityDamageVestArrow; break;
                case TactsuitVR.FeedbackType.DamageRightArmArrow: return IntensityDamageArmArrow; break;
                case TactsuitVR.FeedbackType.DamageHeadArrow: return IntensityDamageHeadArrow; break;
                case TactsuitVR.FeedbackType.DamageVestFireArrow: return IntensityDamageVestFireArrow; break;
                case TactsuitVR.FeedbackType.DamageRightArmFireArrow: return IntensityDamageArmFireArrow; break;
                case TactsuitVR.FeedbackType.DamageHeadFireArrow: return IntensityDamageHeadFireArrow; break;
                case TactsuitVR.FeedbackType.DamageVestLightningArrow: return IntensityDamageVestLightningArrow; break;
                case TactsuitVR.FeedbackType.DamageRightArmLightningArrow: return IntensityDamageArmLightningArrow; break;
                case TactsuitVR.FeedbackType.DamageHeadLightningArrow: return IntensityDamageHeadLightningArrow; break;
                case TactsuitVR.FeedbackType.DamageVestIceArrow: return IntensityDamageVestIceArrow; break;
                case TactsuitVR.FeedbackType.DamageRightArmIceArrow: return IntensityDamageArmIceArrow; break;
                case TactsuitVR.FeedbackType.DamageHeadIceArrow: return IntensityDamageHeadIceArrow; break;
                case TactsuitVR.FeedbackType.DamageHeadFire: return IntensityDamageHeadFire; break;
                case TactsuitVR.FeedbackType.DamageHeadLightning: return IntensityDamageHeadLightning; break;
                case TactsuitVR.FeedbackType.DamageHeadGravity: return IntensityDamageHeadGravity; break;
                case TactsuitVR.FeedbackType.DamageHeadIce: return IntensityDamageHeadIce; break;
                case TactsuitVR.FeedbackType.DamageHeadDrain: return IntensityDamageHeadDrain; break;
                case TactsuitVR.FeedbackType.DamageHeadEnergy: return IntensityDamageHeadEnergy; break;
                case TactsuitVR.FeedbackType.DamageRightArmFire: return IntensityDamageArmFire; break;
                case TactsuitVR.FeedbackType.DamageRightArmLightning: return IntensityDamageArmLightning; break;
                case TactsuitVR.FeedbackType.DamageRightArmGravity: return IntensityDamageArmGravity; break;
                case TactsuitVR.FeedbackType.DamageRightArmIce: return IntensityDamageArmIce; break;
                case TactsuitVR.FeedbackType.DamageRightArmDrain: return IntensityDamageArmDrain; break;
                case TactsuitVR.FeedbackType.DamageRightArmEnergy: return IntensityDamageArmEnergy; break;
                case TactsuitVR.FeedbackType.DamageVestEnergy: return IntensityDamageVestEnergy; break;
                case TactsuitVR.FeedbackType.DamageVestFire: return IntensityDamageVestFire; break;
                case TactsuitVR.FeedbackType.DamageVestIce: return IntensityDamageVestIce; break;
                case TactsuitVR.FeedbackType.DamageVestDrain: return IntensityDamageVestDrain; break;
                case TactsuitVR.FeedbackType.DamageVestLightning: return IntensityDamageVestLightning; break;
                case TactsuitVR.FeedbackType.DamageVestGravity: return IntensityDamageVestGravity; break;
                case TactsuitVR.FeedbackType.DamageVestPierceBladeSmall: return IntensityDamageVestPierceBladeSmall; break;
                case TactsuitVR.FeedbackType.DamageVestSlashBladeSmallLRD: return IntensityDamageVestSlashBladeSmall; break;
                case TactsuitVR.FeedbackType.DamageVestSlashBladeSmallLRU: return IntensityDamageVestSlashBladeSmall; break;
                case TactsuitVR.FeedbackType.DamageVestSlashBladeSmallRLD: return IntensityDamageVestSlashBladeSmall; break;
                case TactsuitVR.FeedbackType.DamageVestSlashBladeSmallRLU: return IntensityDamageVestSlashBladeSmall; break;
                case TactsuitVR.FeedbackType.DamageVestBluntBladeSmall: return IntensityDamageVestBluntBladeSmall; break;
                case TactsuitVR.FeedbackType.DamageVestBluntWoodSmall: return IntensityDamageVestBluntWoodSmall; break;
                case TactsuitVR.FeedbackType.DamageVestBluntMetalSmall: return IntensityDamageVestBluntMetalSmall; break;
                case TactsuitVR.FeedbackType.DamageVestBluntStoneSmall: return IntensityDamageVestBluntStoneSmall; break;
                case TactsuitVR.FeedbackType.DamageVestBluntFleshSmall: return IntensityDamageVestBluntFleshSmall; break;
                case TactsuitVR.FeedbackType.DamageVestPierceFireSmall: return IntensityDamageVestPierceFireSmall; break;
                case TactsuitVR.FeedbackType.DamageVestSlashFireSmallLRD: return IntensityDamageVestSlashFireSmall; break;
                case TactsuitVR.FeedbackType.DamageVestSlashFireSmallLRU: return IntensityDamageVestSlashFireSmall; break;
                case TactsuitVR.FeedbackType.DamageVestSlashFireSmallRLD: return IntensityDamageVestSlashFireSmall; break;
                case TactsuitVR.FeedbackType.DamageVestSlashFireSmallRLU: return IntensityDamageVestSlashFireSmall; break;
                case TactsuitVR.FeedbackType.DamageVestBluntFireSmall: return IntensityDamageVestBluntFireSmall; break;
                case TactsuitVR.FeedbackType.DamageVestPierceLightningSmall: return IntensityDamageVestPierceLightningSmall; break;
                case TactsuitVR.FeedbackType.DamageVestSlashLightningSmallLRD: return IntensityDamageVestSlashLightningSmall; break;
                case TactsuitVR.FeedbackType.DamageVestSlashLightningSmallLRU: return IntensityDamageVestSlashLightningSmall; break;
                case TactsuitVR.FeedbackType.DamageVestSlashLightningSmallRLD: return IntensityDamageVestSlashLightningSmall; break;
                case TactsuitVR.FeedbackType.DamageVestSlashLightningSmallRLU: return IntensityDamageVestSlashLightningSmall; break;
                case TactsuitVR.FeedbackType.DamageVestBluntLightningSmall: return IntensityDamageVestBluntLightningSmall; break;
                case TactsuitVR.FeedbackType.DamageVestPierceIceSmall: return IntensityDamageVestPierceIceSmall; break;
                case TactsuitVR.FeedbackType.DamageVestSlashIceSmallLRD: return IntensityDamageVestSlashIceSmall; break;
                case TactsuitVR.FeedbackType.DamageVestSlashIceSmallLRU: return IntensityDamageVestSlashIceSmall; break;
                case TactsuitVR.FeedbackType.DamageVestSlashIceSmallRLD: return IntensityDamageVestSlashIceSmall; break;
                case TactsuitVR.FeedbackType.DamageVestSlashIceSmallRLU: return IntensityDamageVestSlashIceSmall; break;
                case TactsuitVR.FeedbackType.DamageVestBluntIceSmall: return IntensityDamageVestBluntIceSmall; break;
                case TactsuitVR.FeedbackType.DamageVestPierceBladeLarge: return IntensityDamageVestPierceBladeLarge; break;
                case TactsuitVR.FeedbackType.DamageVestSlashBladeLargeLRD: return IntensityDamageVestSlashBladeLarge; break;
                case TactsuitVR.FeedbackType.DamageVestSlashBladeLargeLRU: return IntensityDamageVestSlashBladeLarge; break;
                case TactsuitVR.FeedbackType.DamageVestSlashBladeLargeRLD: return IntensityDamageVestSlashBladeLarge; break;
                case TactsuitVR.FeedbackType.DamageVestSlashBladeLargeRLU: return IntensityDamageVestSlashBladeLarge; break;
                case TactsuitVR.FeedbackType.DamageVestBluntBladeLarge: return IntensityDamageVestBluntBladeLarge; break;
                case TactsuitVR.FeedbackType.DamageVestBluntWoodLarge: return IntensityDamageVestBluntWoodLarge; break;
                case TactsuitVR.FeedbackType.DamageVestBluntMetalLarge: return IntensityDamageVestBluntMetalLarge; break;
                case TactsuitVR.FeedbackType.DamageVestBluntStoneLarge: return IntensityDamageVestBluntStoneLarge; break;
                case TactsuitVR.FeedbackType.DamageVestBluntFleshLarge: return IntensityDamageVestBluntFleshLarge; break;
                case TactsuitVR.FeedbackType.DamageVestPierceFireLarge: return IntensityDamageVestPierceFireLarge; break;
                case TactsuitVR.FeedbackType.DamageVestSlashFireLargeLRD: return IntensityDamageVestSlashFireLarge; break;
                case TactsuitVR.FeedbackType.DamageVestSlashFireLargeLRU: return IntensityDamageVestSlashFireLarge; break;
                case TactsuitVR.FeedbackType.DamageVestSlashFireLargeRLD: return IntensityDamageVestSlashFireLarge; break;
                case TactsuitVR.FeedbackType.DamageVestSlashFireLargeRLU: return IntensityDamageVestSlashFireLarge; break;
                case TactsuitVR.FeedbackType.DamageVestBluntFireLarge: return IntensityDamageVestBluntFireLarge; break;
                case TactsuitVR.FeedbackType.DamageVestPierceLightningLarge: return IntensityDamageVestPierceLightningLarge; break;
                case TactsuitVR.FeedbackType.DamageVestSlashLightningLargeLRD: return IntensityDamageVestSlashLightningLarge; break;
                case TactsuitVR.FeedbackType.DamageVestSlashLightningLargeLRU: return IntensityDamageVestSlashLightningLarge; break;
                case TactsuitVR.FeedbackType.DamageVestSlashLightningLargeRLD: return IntensityDamageVestSlashLightningLarge; break;
                case TactsuitVR.FeedbackType.DamageVestSlashLightningLargeRLU: return IntensityDamageVestSlashLightningLarge; break;
                case TactsuitVR.FeedbackType.DamageVestBluntLightningLarge: return IntensityDamageVestBluntLightningLarge; break;
                case TactsuitVR.FeedbackType.DamageVestPierceIceLarge: return IntensityDamageVestPierceIceLarge; break;
                case TactsuitVR.FeedbackType.DamageVestSlashIceLargeLRD: return IntensityDamageVestSlashIceLarge; break;
                case TactsuitVR.FeedbackType.DamageVestSlashIceLargeLRU: return IntensityDamageVestSlashIceLarge; break;
                case TactsuitVR.FeedbackType.DamageVestSlashIceLargeRLD: return IntensityDamageVestSlashIceLarge; break;
                case TactsuitVR.FeedbackType.DamageVestSlashIceLargeRLU: return IntensityDamageVestSlashIceLarge; break;
                case TactsuitVR.FeedbackType.DamageVestBluntIceLarge: return IntensityDamageVestBluntIceLarge; break;

                case TactsuitVR.FeedbackType.DamageVestBlaster: return IntensityDamageVestBlaster; break;
                case TactsuitVR.FeedbackType.DamageVestBlasterStun: return IntensityDamageVestBlasterStun; break;
                case TactsuitVR.FeedbackType.DamageRightArmBlaster: return IntensityDamageArmBlaster; break;
                case TactsuitVR.FeedbackType.DamageRightArmBlasterStun: return IntensityDamageArmBlasterStun; break;
                case TactsuitVR.FeedbackType.DamageHeadBlaster: return IntensityDamageHeadBlaster; break;
                case TactsuitVR.FeedbackType.DamageHeadBlasterStun: return IntensityDamageHeadBlasterStun; break;

                case TactsuitVR.FeedbackType.DamageVestPierceLightsaber: return IntensityDamageVestPierceLightsaber; break;
                case TactsuitVR.FeedbackType.DamageVestSlashLightsaberLRD: return IntensityDamageVestSlashLightsaber; break;
                case TactsuitVR.FeedbackType.DamageVestSlashLightsaberRLD: return IntensityDamageVestSlashLightsaber; break;
                case TactsuitVR.FeedbackType.DamageVestSlashLightsaberLRU: return IntensityDamageVestSlashLightsaber; break;
                case TactsuitVR.FeedbackType.DamageVestSlashLightsaberRLU: return IntensityDamageVestSlashLightsaber; break;
                case TactsuitVR.FeedbackType.DamageVestBluntLightsaber: return IntensityDamageVestBluntLightsaber; break;
                case TactsuitVR.FeedbackType.DamageRightArmBluntLightsaber: return IntensityDamageRightArmBluntLightsaber; break;
                case TactsuitVR.FeedbackType.DamageRightArmPierceLightsaber: return IntensityDamageRightArmPierceLightsaber; break;
                case TactsuitVR.FeedbackType.DamageRightArmSlashLightsaber: return IntensityDamageRightArmSlashLightsaber; break;
                case TactsuitVR.FeedbackType.DamageHeadPierceLightsaber: return IntensityDamageHeadPierceLightsaber; break;
                case TactsuitVR.FeedbackType.DamageHeadSlashLightsaber: return IntensityDamageHeadSlashLightsaber; break;
                case TactsuitVR.FeedbackType.DamageHeadBluntLightsaber: return IntensityDamageHeadBluntLightsaber; break;

                case TactsuitVR.FeedbackType.DamageRightArmPierceBladeSmall: return IntensityDamageArmPierceBladeSmall; break;
                case TactsuitVR.FeedbackType.DamageRightArmSlashBladeSmall: return IntensityDamageArmSlashBladeSmall; break;
                case TactsuitVR.FeedbackType.DamageRightArmBluntBladeSmall: return IntensityDamageArmBluntBladeSmall; break;
                case TactsuitVR.FeedbackType.DamageRightArmBluntWoodSmall: return IntensityDamageArmBluntWoodSmall; break;
                case TactsuitVR.FeedbackType.DamageRightArmBluntMetalSmall: return IntensityDamageArmBluntMetalSmall; break;
                case TactsuitVR.FeedbackType.DamageRightArmBluntStoneSmall: return IntensityDamageArmBluntStoneSmall; break;
                case TactsuitVR.FeedbackType.DamageRightArmBluntFleshSmall: return IntensityDamageArmBluntFleshSmall; break;
                case TactsuitVR.FeedbackType.DamageRightArmPierceFireSmall: return IntensityDamageArmPierceFireSmall; break;
                case TactsuitVR.FeedbackType.DamageRightArmSlashFireSmall: return IntensityDamageArmSlashFireSmall; break;
                case TactsuitVR.FeedbackType.DamageRightArmBluntFireSmall: return IntensityDamageArmBluntFireSmall; break;
                case TactsuitVR.FeedbackType.DamageRightArmPierceLightningSmall: return IntensityDamageArmPierceLightningSmall; break;
                case TactsuitVR.FeedbackType.DamageRightArmSlashLightningSmall: return IntensityDamageArmSlashLightningSmall; break;
                case TactsuitVR.FeedbackType.DamageRightArmBluntLightningSmall: return IntensityDamageArmBluntLightningSmall; break;
                case TactsuitVR.FeedbackType.DamageRightArmPierceIceSmall: return IntensityDamageArmPierceIceSmall; break;
                case TactsuitVR.FeedbackType.DamageRightArmSlashIceSmall: return IntensityDamageArmSlashIceSmall; break;
                case TactsuitVR.FeedbackType.DamageRightArmBluntIceSmall: return IntensityDamageArmBluntIceSmall; break;
                case TactsuitVR.FeedbackType.DamageRightArmPierceBladeLarge: return IntensityDamageArmPierceBladeLarge; break;
                case TactsuitVR.FeedbackType.DamageRightArmSlashBladeLarge: return IntensityDamageArmSlashBladeLarge; break;
                case TactsuitVR.FeedbackType.DamageRightArmBluntBladeLarge: return IntensityDamageArmBluntBladeLarge; break;
                case TactsuitVR.FeedbackType.DamageRightArmBluntWoodLarge: return IntensityDamageArmBluntWoodLarge; break;
                case TactsuitVR.FeedbackType.DamageRightArmBluntMetalLarge: return IntensityDamageArmBluntMetalLarge; break;
                case TactsuitVR.FeedbackType.DamageRightArmBluntStoneLarge: return IntensityDamageArmBluntStoneLarge; break;
                case TactsuitVR.FeedbackType.DamageRightArmBluntFleshLarge: return IntensityDamageArmBluntFleshLarge; break;
                case TactsuitVR.FeedbackType.DamageRightArmPierceFireLarge: return IntensityDamageArmPierceFireLarge; break;
                case TactsuitVR.FeedbackType.DamageRightArmSlashFireLarge: return IntensityDamageArmSlashFireLarge; break;
                case TactsuitVR.FeedbackType.DamageRightArmBluntFireLarge: return IntensityDamageArmBluntFireLarge; break;
                case TactsuitVR.FeedbackType.DamageRightArmPierceLightningLarge: return IntensityDamageArmPierceLightningLarge; break;
                case TactsuitVR.FeedbackType.DamageRightArmSlashLightningLarge: return IntensityDamageArmSlashLightningLarge; break;
                case TactsuitVR.FeedbackType.DamageRightArmBluntLightningLarge: return IntensityDamageArmBluntLightningLarge; break;
                case TactsuitVR.FeedbackType.DamageRightArmPierceIceLarge: return IntensityDamageArmPierceIceLarge; break;
                case TactsuitVR.FeedbackType.DamageRightArmSlashIceLarge: return IntensityDamageArmSlashIceLarge; break;
                case TactsuitVR.FeedbackType.DamageRightArmBluntIceLarge: return IntensityDamageArmBluntIceLarge; break;
                case TactsuitVR.FeedbackType.DamageHeadPierceBladeSmall: return IntensityDamageHeadPierceBladeSmall; break;
                case TactsuitVR.FeedbackType.DamageHeadSlashBladeSmall: return IntensityDamageHeadSlashBladeSmall; break;
                case TactsuitVR.FeedbackType.DamageHeadBluntBladeSmall: return IntensityDamageHeadBluntBladeSmall; break;
                case TactsuitVR.FeedbackType.DamageHeadBluntWoodSmall: return IntensityDamageHeadBluntWoodSmall; break;
                case TactsuitVR.FeedbackType.DamageHeadBluntMetalSmall: return IntensityDamageHeadBluntMetalSmall; break;
                case TactsuitVR.FeedbackType.DamageHeadBluntStoneSmall: return IntensityDamageHeadBluntStoneSmall; break;
                case TactsuitVR.FeedbackType.DamageHeadBluntFleshSmall: return IntensityDamageHeadBluntFleshSmall; break;
                case TactsuitVR.FeedbackType.DamageHeadPierceFireSmall: return IntensityDamageHeadPierceFireSmall; break;
                case TactsuitVR.FeedbackType.DamageHeadSlashFireSmall: return IntensityDamageHeadSlashFireSmall; break;
                case TactsuitVR.FeedbackType.DamageHeadBluntFireSmall: return IntensityDamageHeadBluntFireSmall; break;
                case TactsuitVR.FeedbackType.DamageHeadPierceLightningSmall: return IntensityDamageHeadPierceLightningSmall; break;
                case TactsuitVR.FeedbackType.DamageHeadSlashLightningSmall: return IntensityDamageHeadSlashLightningSmall; break;
                case TactsuitVR.FeedbackType.DamageHeadBluntLightningSmall: return IntensityDamageHeadBluntLightningSmall; break;
                case TactsuitVR.FeedbackType.DamageHeadPierceIceSmall: return IntensityDamageHeadPierceIceSmall; break;
                case TactsuitVR.FeedbackType.DamageHeadSlashIceSmall: return IntensityDamageHeadSlashIceSmall; break;
                case TactsuitVR.FeedbackType.DamageHeadBluntIceSmall: return IntensityDamageHeadBluntIceSmall; break;
                case TactsuitVR.FeedbackType.DamageHeadPierceBladeLarge: return IntensityDamageHeadPierceBladeLarge; break;
                case TactsuitVR.FeedbackType.DamageHeadSlashBladeLarge: return IntensityDamageHeadSlashBladeLarge; break;
                case TactsuitVR.FeedbackType.DamageHeadBluntBladeLarge: return IntensityDamageHeadBluntBladeLarge; break;
                case TactsuitVR.FeedbackType.DamageHeadBluntWoodLarge: return IntensityDamageHeadBluntWoodLarge; break;
                case TactsuitVR.FeedbackType.DamageHeadBluntMetalLarge: return IntensityDamageHeadBluntMetalLarge; break;
                case TactsuitVR.FeedbackType.DamageHeadBluntStoneLarge: return IntensityDamageHeadBluntStoneLarge; break;
                case TactsuitVR.FeedbackType.DamageHeadBluntFleshLarge: return IntensityDamageHeadBluntFleshLarge; break;
                case TactsuitVR.FeedbackType.DamageHeadPierceFireLarge: return IntensityDamageHeadPierceFireLarge; break;
                case TactsuitVR.FeedbackType.DamageHeadSlashFireLarge: return IntensityDamageHeadSlashFireLarge; break;
                case TactsuitVR.FeedbackType.DamageHeadBluntFireLarge: return IntensityDamageHeadBluntFireLarge; break;
                case TactsuitVR.FeedbackType.DamageHeadPierceLightningLarge: return IntensityDamageHeadPierceLightningLarge; break;
                case TactsuitVR.FeedbackType.DamageHeadSlashLightningLarge: return IntensityDamageHeadSlashLightningLarge; break;
                case TactsuitVR.FeedbackType.DamageHeadBluntLightningLarge: return IntensityDamageHeadBluntLightningLarge; break;
                case TactsuitVR.FeedbackType.DamageHeadPierceIceLarge: return IntensityDamageHeadPierceIceLarge; break;
                case TactsuitVR.FeedbackType.DamageHeadSlashIceLarge: return IntensityDamageHeadSlashIceLarge; break;
                case TactsuitVR.FeedbackType.DamageHeadBluntIceLarge: return IntensityDamageHeadBluntIceLarge; break;
                case TactsuitVR.FeedbackType.HeartBeat: return IntensityHeartBeat; break;
                case TactsuitVR.FeedbackType.HeartBeatFast: return IntensityHeartBeatFast; break;
                case TactsuitVR.FeedbackType.Healing: return IntensityHealing; break;
                case TactsuitVR.FeedbackType.PotionDrinking: return IntensityPotionDrinking; break;
                case TactsuitVR.FeedbackType.PoisonDrinking: return IntensityPoisonDrinking; break;
                case TactsuitVR.FeedbackType.FallDamage: return IntensityFallDamage; break;
                case TactsuitVR.FeedbackType.FallDamageFeet: return IntensityFallDamageFeet; break;
                case TactsuitVR.FeedbackType.SlowMotion: return IntensitySlowMotion; break;
                case TactsuitVR.FeedbackType.HolsterLeftShoulder: return IntensityHolster; break;
                case TactsuitVR.FeedbackType.HolsterRightShoulder: return IntensityHolster; break;
                case TactsuitVR.FeedbackType.UnholsterLeftShoulder: return IntensityUnholster; break;
                case TactsuitVR.FeedbackType.UnholsterRightShoulder: return IntensityUnholster; break;
                case TactsuitVR.FeedbackType.HolsterArrowLeftShoulder: return IntensityHolsterArrow; break;
                case TactsuitVR.FeedbackType.HolsterArrowRightShoulder: return IntensityHolsterArrow; break;
                case TactsuitVR.FeedbackType.UnholsterArrowLeftShoulder: return IntensityUnholsterArrow; break;
                case TactsuitVR.FeedbackType.UnholsterArrowRightShoulder: return IntensityUnholsterArrow; break;
                case TactsuitVR.FeedbackType.ClimbingRight: return IntensityClimbing; break;
                case TactsuitVR.FeedbackType.PlayerKickOtherRight: return IntensityPlayerKickOther; break;
                case TactsuitVR.FeedbackType.PlayerKickWoodRight: return IntensityPlayerKickWood; break;
                case TactsuitVR.FeedbackType.PlayerKickFleshRight: return IntensityPlayerKickFlesh; break;
                case TactsuitVR.FeedbackType.PlayerKickStoneRight: return IntensityPlayerKickStone; break;
                case TactsuitVR.FeedbackType.PlayerKickMetalRight: return IntensityPlayerKickMetal; break;
                case TactsuitVR.FeedbackType.PlayerKickFabricRight: return IntensityPlayerKickFabric; break;
                case TactsuitVR.FeedbackType.PlayerPunchOtherRight: return IntensityPlayerPunchOther; break;
                case TactsuitVR.FeedbackType.PlayerPunchWoodRight: return IntensityPlayerPunchWood; break;
                case TactsuitVR.FeedbackType.PlayerPunchFleshRight: return IntensityPlayerPunchFlesh; break;
                case TactsuitVR.FeedbackType.PlayerPunchStoneRight: return IntensityPlayerPunchStone; break;
                case TactsuitVR.FeedbackType.PlayerPunchMetalRight: return IntensityPlayerPunchMetal; break;
                case TactsuitVR.FeedbackType.PlayerPunchFabricRight: return IntensityPlayerPunchFabric; break;

                case TactsuitVR.FeedbackType.PlayerGunRight: return IntensityPlayerGun; break;
                case TactsuitVR.FeedbackType.PlayerGunBlasterRight: return IntensityPlayerGunBlaster; break;
                case TactsuitVR.FeedbackType.PlayerGunAutomaticRight: return IntensityPlayerGunAutomatic; break;
                case TactsuitVR.FeedbackType.PlayerGunBallisticRight: return IntensityPlayerGunBallistic; break;
                case TactsuitVR.FeedbackType.PlayerGunSprayRight: return IntensityPlayerGunSpray; break;
                case TactsuitVR.FeedbackType.PlayerGunMiniGunRight: return IntensityPlayerGunMiniGun; break;
                case TactsuitVR.FeedbackType.PlayerGunBazookaRight: return IntensityPlayerGunBazooka; break;
                case TactsuitVR.FeedbackType.PlayerGunHeavyRight: return IntensityPlayerGunHeavy; break;
                case TactsuitVR.FeedbackType.PlayerGunLaserRight: return IntensityPlayerGunLaser; break;
                case TactsuitVR.FeedbackType.PlayerGunRifleRight: return IntensityPlayerGunRifle; break;
                case TactsuitVR.FeedbackType.PlayerGunPistolRight: return IntensityPlayerGunPistol; break;
                case TactsuitVR.FeedbackType.PlayerGunPlasmaRight: return IntensityPlayerGunPlasma; break;
                case TactsuitVR.FeedbackType.PlayerGunShotgunRight: return IntensityPlayerGunShotgun; break;
                case TactsuitVR.FeedbackType.PlayerGunEnergyRight: return IntensityPlayerGunEnergy; break;
                case TactsuitVR.FeedbackType.KickbackPlayerGunRight: return IntensityKickbackPlayerGun; break;
                case TactsuitVR.FeedbackType.KickbackPlayerGunPistolRight: return IntensityKickbackPlayerGunPistol; break;
                case TactsuitVR.FeedbackType.KickbackPlayerGunBallisticRight: return IntensityKickbackPlayerGunBallistic; break;
                case TactsuitVR.FeedbackType.KickbackPlayerGunLaserRight: return IntensityKickbackPlayerGunLaser; break;
                case TactsuitVR.FeedbackType.KickbackPlayerGunPlasmaRight: return IntensityKickbackPlayerGunPlasma; break;
                case TactsuitVR.FeedbackType.KickbackPlayerGunSprayRight: return IntensityKickbackPlayerGunSpray; break;
                case TactsuitVR.FeedbackType.KickbackPlayerGunHeavyRight: return IntensityKickbackPlayerGunHeavy; break;
                case TactsuitVR.FeedbackType.KickbackPlayerGunLeft: return IntensityKickbackPlayerGun; break;
                case TactsuitVR.FeedbackType.KickbackPlayerGunPistolLeft: return IntensityKickbackPlayerGunPistol; break;
                case TactsuitVR.FeedbackType.KickbackPlayerGunBallisticLeft: return IntensityKickbackPlayerGunBallistic; break;
                case TactsuitVR.FeedbackType.KickbackPlayerGunLaserLeft: return IntensityKickbackPlayerGunLaser; break;
                case TactsuitVR.FeedbackType.KickbackPlayerGunPlasmaLeft: return IntensityKickbackPlayerGunPlasma; break;
                case TactsuitVR.FeedbackType.KickbackPlayerGunSprayLeft: return IntensityKickbackPlayerGunSpray; break;
                case TactsuitVR.FeedbackType.KickbackPlayerGunHeavyLeft: return IntensityKickbackPlayerGunHeavy; break;
                case TactsuitVR.FeedbackType.PlayerThrowRight: return IntensityPlayerThrow; break;
                case TactsuitVR.FeedbackType.Explosion: return IntensityExplosion; break;
                case TactsuitVR.FeedbackType.LeftShoulderTurret: return IntensityShoulderTurret; break;
                case TactsuitVR.FeedbackType.HoverJetFeet: return IntensityHoverJetFeet; break;


            }

            return IntensityDefaultDamage;
        }

        public void ProvideDotFeedback(PositionType position, int index, int intensity, int durationMillis)
        {
            if (intensity < 0.001f)
                return;

            if (!systemInitialized || hapticPlayer == null)
                CreateSystem();
            
            List<DotPoint> points = new List<DotPoint>() { new DotPoint(index, intensity) };
            
            hapticPlayer.Submit("", position, points, durationMillis);
        }

        public void ProvideHapticFeedbackThread(float locationAngle, float locationHeight, FeedbackType effect, float intensityMultiplier, bool waitToPlay, bool reflected, float duration = 1.0f)
        {
            if (intensityMultiplier < 0.001f)
                return;

            if (!systemInitialized || hapticPlayer == null)
                CreateSystem();

            if (hapticPlayer != null)
            {
                if (feedbackMap.ContainsKey(effect))
                {
                    if (feedbackMap[effect].feedbackFileCount > 0)
                    {
                        if (waitToPlay)
                        {
                            if (IsPlayingKeyAll(reflected, feedbackMap[effect].prefix, feedbackMap[effect].feedbackFileCount))
                            {
                                return;
                            }
                        }

                        string key = (reflected ? "Reflected_" : "") + feedbackMap[effect].prefix + (RandomNumber.Between(1, feedbackMap[effect].feedbackFileCount)).ToString();

                        if (locationHeight < -0.5f)
                            locationHeight = -0.5f;
                        else if (locationHeight > 0.5f)
                            locationHeight = 0.5f;

                        Bhaptics.Tact.RotationOption RotOption = new RotationOption(locationAngle, locationHeight);

                        Bhaptics.Tact.ScaleOption scaleOption = new ScaleOption(intensityMultiplier, duration);

                        //hapticPlayer.SubmitRegistered(key, scaleOption);
                        hapticPlayer.SubmitRegisteredVestRotation(key, key, RotOption, scaleOption);
                        LOG("===> Submitted Feedback: " + key + " Intensity: " + intensityMultiplier + " Height: " + locationHeight + " Angle: " + locationAngle);
                    }
                }
            }
        }
        
        public void ProvideHapticFeedback(float locationAngle, float locationHeight, FeedbackType effect, bool waitToPlay, float intensity, FeedbackType secondEffect, bool reflected, float duration = 1.0f)
        {
            if (effect != FeedbackType.NoFeedback)
            {
                float intensityMultiplier = GetIntensityMultiplier(effect)*intensity;
                if (intensityMultiplier > 0.01f)
                {
                    Thread thread = new Thread(() => ProvideHapticFeedbackThread(locationAngle, locationHeight, effect, intensityMultiplier, waitToPlay, reflected, duration));
                    thread.Start();
                    if (secondEffect != FeedbackType.NoFeedback)
                    {
                        Thread thread2 = new Thread(() => ProvideHapticFeedbackThread(locationAngle, locationHeight, secondEffect, intensityMultiplier, waitToPlay, reflected, duration));
                        thread2.Start();
                    }
                }
            }
        }

        public void StopHapticFeedback(FeedbackType effect)
        {
            if (hapticPlayer != null)
            {
                if (feedbackMap.ContainsKey(effect))
                {
                    if (feedbackMap[effect].feedbackFileCount > 0)
                    {
                        for (int i = 1; i <= feedbackMap[effect].feedbackFileCount; i++)
                        {
                            string key = feedbackMap[effect].prefix + i.ToString();
                            hapticPlayer.TurnOff(key);
                        }
                    }
                }
            }
        }

        public static FeedbackType GetPlayerGunShootFeedback(string itemName, string displayName, bool stun)
        {
            string lower = itemName.ToLowerInvariant() + " " + displayName.ToLowerInvariant();

            if(lower.Contains("blaster") || lower.Contains("starwars") || lower.Contains("peace") || lower.Contains("keeper"))
                return stun ? FeedbackType.PlayerGunPlasmaRight : FeedbackType.PlayerGunBlasterRight;
            else if (lower.Contains("spray") || lower.Contains("flame"))
                return FeedbackType.PlayerGunSprayRight;
            else if (lower.Contains("bazooka") || lower.Contains("launcher") || lower.Contains("mortar"))
                return FeedbackType.PlayerGunBazookaRight;
            else if (lower.Contains("heavy") || lower.Contains("lmg"))
                return FeedbackType.PlayerGunHeavyRight;
            else if (lower.Contains("laser") || lower.Contains("beam") || lower.Contains("bond"))
                return FeedbackType.PlayerGunLaserRight;
            else if (lower.Contains("rifle") || lower.Contains("assault") || lower.Contains("m4") || lower.Contains("47") || lower.Contains("m16") || lower.Contains("tony") || lower.Contains("friend") || lower.Contains("enfield") || lower.Contains("carbine"))
                return FeedbackType.PlayerGunRifleRight;
            else if (lower.Contains("minigun") || lower.Contains("usurper"))
                return FeedbackType.PlayerGunMiniGunRight;
            else if (lower.Contains("plasma") || lower.Contains("arrow"))
                return FeedbackType.PlayerGunPlasmaRight;
            else if (lower.Contains("shotgun"))
                return FeedbackType.PlayerGunShotgunRight;
            else if (lower.Contains("revolver") || lower.Contains("beretta") || lower.Contains("pistol") || lower.Contains("kitchen") || lower.Contains("glock") || lower.Contains("hamada") || lower.Contains("luger") || lower.Contains("mustang") || lower.Contains("m1911"))
                return FeedbackType.PlayerGunPistolRight;
            else if (lower.Contains("auto") || lower.Contains("sentinel") || lower.Contains("smg") || lower.Contains("modular") || lower.Contains("mp5") || lower.Contains("ump") || lower.Contains("alternator") || lower.Contains("machine") ||lower.Contains("s2200"))
                return FeedbackType.PlayerGunAutomaticRight;
            else if (lower.Contains("ball") || lower.Contains("grapple") || lower.Contains("flint"))
                return FeedbackType.PlayerGunBallisticRight;
            else if (lower.Contains("sibyl") || lower.Contains("energy"))
                return FeedbackType.PlayerGunEnergyRight;
            else
                return FeedbackType.PlayerGunRight;
        }

        public static FeedbackType GetPlayerGunShootFeedbackKickback(FeedbackType feedback, Side side)
        {
            switch (feedback)
            {
                case TactsuitVR.FeedbackType.PlayerGunRight:
                    return (side == Side.Left ? FeedbackType.KickbackPlayerGunLeft : FeedbackType.KickbackPlayerGunRight);
                    break;
                case TactsuitVR.FeedbackType.PlayerGunBlasterRight:
                    return (side == Side.Left ? FeedbackType.KickbackPlayerGunPlasmaLeft : FeedbackType.KickbackPlayerGunPlasmaRight);
                    break;
                case TactsuitVR.FeedbackType.PlayerGunAutomaticRight:
                    return (side == Side.Left ? FeedbackType.KickbackPlayerGunHeavyLeft : FeedbackType.KickbackPlayerGunHeavyRight);
                    break;
                case TactsuitVR.FeedbackType.PlayerGunBallisticRight:
                    return (side == Side.Left ? FeedbackType.KickbackPlayerGunBallisticLeft : FeedbackType.KickbackPlayerGunBallisticRight);
                    break;
                case TactsuitVR.FeedbackType.PlayerGunSprayRight:
                    return (side == Side.Left ? FeedbackType.KickbackPlayerGunSprayLeft : FeedbackType.KickbackPlayerGunSprayRight);
                    break;
                case TactsuitVR.FeedbackType.PlayerGunMiniGunRight:
                    return (side == Side.Left ? FeedbackType.KickbackPlayerGunHeavyLeft : FeedbackType.KickbackPlayerGunHeavyRight);
                    break;
                case TactsuitVR.FeedbackType.PlayerGunBazookaRight:
                    return (side == Side.Left ? FeedbackType.KickbackPlayerGunHeavyLeft : FeedbackType.KickbackPlayerGunHeavyRight);
                    break;
                case TactsuitVR.FeedbackType.PlayerGunHeavyRight:
                    return (side == Side.Left ? FeedbackType.KickbackPlayerGunHeavyLeft : FeedbackType.KickbackPlayerGunHeavyRight);
                    break;
                case TactsuitVR.FeedbackType.PlayerGunLaserRight:
                    return (side == Side.Left ? FeedbackType.KickbackPlayerGunLaserLeft : FeedbackType.KickbackPlayerGunLaserRight);
                    break;
                case TactsuitVR.FeedbackType.PlayerGunRifleRight:
                    return (side == Side.Left ? FeedbackType.KickbackPlayerGunBallisticLeft : FeedbackType.KickbackPlayerGunBallisticRight);
                    break;
                case TactsuitVR.FeedbackType.PlayerGunPistolRight:
                    return (side == Side.Left ? FeedbackType.KickbackPlayerGunPistolLeft : FeedbackType.KickbackPlayerGunPistolRight);
                    break;
                case TactsuitVR.FeedbackType.PlayerGunPlasmaRight:
                    return (side == Side.Left ? FeedbackType.KickbackPlayerGunPlasmaLeft : FeedbackType.KickbackPlayerGunPlasmaRight);
                    break;
                case TactsuitVR.FeedbackType.PlayerGunShotgunRight:
                    return (side == Side.Left ? FeedbackType.KickbackPlayerGunLeft : FeedbackType.KickbackPlayerGunRight);
                    break;
                case TactsuitVR.FeedbackType.PlayerGunEnergyRight:
                    return (side == Side.Left ? FeedbackType.KickbackPlayerGunLaserLeft : FeedbackType.KickbackPlayerGunLaserRight);
                    break;
                default:
                    return FeedbackType.NoFeedback;
            }
        }

        public void PauseHapticFeedBack(FeedbackType effect)
        {
            for (int i = 1; i <= feedbackMap[effect].feedbackFileCount; i++)
            {
                hapticPlayer.TurnOff(feedbackMap[effect].prefix + i.ToString());
            }
        }
    }
}
