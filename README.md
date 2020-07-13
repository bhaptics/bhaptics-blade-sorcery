# TACTSUIT BLADE & SORCERY INTEGRATION


* MOD LINK: 1.0 Beta 1: https://mega.nz/file/OU5nUSBB#fO2lsZAloSvzogK_fK7lfNPoPB6_BTmvnz3SWyym-7w

Remove the older one instead of overwriting it if you are updating from the previous version.
SUMMARY
bHaptics Tactsuit integration mod for Blade & Sorcery. Many different haptic effects on Vest, Arms and Face including feedback from enemy melee, ranged, spell damage, player melee, bow, spell usage, potion drinking, heartbeat, climbing, fall damage etc. and also support for mod added gun, spell, weapon effects too.

Everything is configurable in the mod. Check Configuration section below for details.

### COMPATIBILITY
It should be compatible with everything. Also this mod comes with special feedback effects to support mod added spells, guns, melee weapons, explosions etc. too. 

### INSTALLATION
Manual Installation: Extract the contents of the zip file inside your “Steam\steamapps\common\Blade & Sorcery\BladeAndSorcery_Data\StreamingAssets” directory.
OR
Mod Manager Installation: Use Vortex and install it like any other mod. 

### DESCRIPTION
This mod communicates with Tactsuit when certain events are detected in Blade & Sorcery to give you haptic feedback. It supports Tactot(Haptic Vest for Torso), Tactosy(Haptic Sleeve for Arms), Tactosy(for Feet) and Tactal(Haptic Face Cushion for HMD)
These are the currently implemented haptic effects (220 different effects):

When player is attacked: (These feedbacks are applied to the angle they come from, and the attack direction is used as well for slash attacks like left to right, right to left, up to down etc.)
- Melee attacks on player vest, arms, head (32x different effects based on materials, imbuement, attack type and direction combinations for each body part)
- Ranged hits on player vest, arms, head (4x different effects based on imbuement)
- Spell hits on player vest, arms, head (3x different effects based on spell types and 3x different effects for mod added spells for each body part)
- [MOD Support] Explosion effect on vest

When player is attacking: 
- Player charging or firing spell effects on arms (3 different effects based on spell types and 13 different effects for mod added spells)
- Player Spell throwing effect on arms
- Player melee attack effect on arms (23 different effects based on material pairs, imbuement and action type combinations, meaning you get a different effect based on the material you are holding and the material you hit it to)
- Player bow string pull effect on arms. Intensity changes according to how much you pull.
- Player kick effect on feet (6 different effects based on kicked material: flesh, wood, stone/glass, metal, fabric, other)
- Player punch effect on arms (6 different effects based on punched material: flesh, wood, stone/glass, metal, fabric, other)
- [MOD Support] Player gun shooting effect on arms and kickback effects on vest (22 different effects based on different gun types)

Special Effects:
- Heartbeat effects on the vest when your health is low and very low (2 different effects).
- Consumable effects on Vest like potion drinking (2 different effects) 
- Healing effect on vest
- Player Telekinesis Activate, Pull, Repel, Catch effects on arms (4 different effects)
- Fall damage effect on vest and feet
- Slow Motion heartbeat effect on vest
- Holster and unholster effects on back of the vest (4 different effects for each side)
- Climbing effect on arms
- Wall hitting effect on vest on sudden extreme deceleration
- [MOD Support] Grapple gun grappling hook effect on arms


More specially designed effects will be added for released mods when they are available (for example: The Outer Rim). No B.A.R.Z.E.L Mensch (Battle suit) support right now, will be added later.

### CONFIGURATION
This mod comes with a configuration file Level_TactsuitBS_Settings.json. Everything in this mod is configurable including some sleep times between feedback plays and intensity of all effects played. 

This way, you won’t have to modify the actual feedback files to adjust it for your preferences.

There are comments in the config file for explaining what each setting does.

For intensity settings, you can modify them to increase or decrease the intensity of the effect or set it to 0 to disable it if you don’t want it. The values are decimal values, so they act like a percentage increase. For example 0.5 means 50% of the original intensity. 10 means 1000% of the original intensity.




