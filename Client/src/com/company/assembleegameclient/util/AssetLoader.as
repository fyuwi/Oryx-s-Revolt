﻿package com.company.assembleegameclient.util {
import com.company.assembleegameclient.engine3d.Model3D;
import com.company.assembleegameclient.map.GroundLibrary;
import com.company.assembleegameclient.map.RegionLibrary;
import com.company.assembleegameclient.objects.ObjectLibrary;
import com.company.assembleegameclient.objects.particles.ParticleLibrary;
import com.company.assembleegameclient.parameters.Parameters;
import com.company.assembleegameclient.sound.SFX;
import com.company.assembleegameclient.sound.SoundEffectLibrary;
import com.company.assembleegameclient.ui.options.Options;
import com.company.util.AssetLibrary;

import flash.utils.ByteArray;
import flash.utils.getQualifiedClassName;

import kabam.rotmg.assets.EmbeddedAssets;
import kabam.rotmg.assets.EmbeddedData;
import kabam.rotmg.emotes.Emotes;

public class AssetLoader {

    public static var currentXmlIsTesting:Boolean = false;

    public function load():void {
        this.addImages();
        this.addAnimatedCharacters();
        this.addSoundEffects();
        this.parse3DModels();
        this.parseParticleEffects();
        this.parseGroundFiles();
        this.parseObjectFiles();
        this.parseRegionFiles();
        Parameters.load();
        Emotes.load();
        Options.refreshCursor();
        SFX.load();
    }

    private function addImages():void {
        AssetLibrary.addImageSet("lofiChar8x8", new EmbeddedAssets.lofiCharEmbed_().bitmapData, 8, 8);
        AssetLibrary.addImageSet("lofiChar16x8", new EmbeddedAssets.lofiCharEmbed_().bitmapData, 16, 8);
        AssetLibrary.addImageSet("lofiChar16x16", new EmbeddedAssets.lofiCharEmbed_().bitmapData, 16, 16);
        AssetLibrary.addImageSet("lofiChar28x8", new EmbeddedAssets.lofiChar2Embed_().bitmapData, 8, 8);
        AssetLibrary.addImageSet("lofiChar216x8", new EmbeddedAssets.lofiChar2Embed_().bitmapData, 16, 8);
        AssetLibrary.addImageSet("lofiChar216x16", new EmbeddedAssets.lofiChar2Embed_().bitmapData, 16, 16);
        AssetLibrary.addImageSet("lofiCharBig", new EmbeddedAssets.lofiCharBigEmbed_().bitmapData, 16, 16);
        AssetLibrary.addImageSet("lofiEnvironment", new EmbeddedAssets.lofiEnvironmentEmbed_().bitmapData, 8, 8);
        AssetLibrary.addImageSet("lofiEnvironment2", new EmbeddedAssets.lofiEnvironment2Embed_().bitmapData, 8, 8);
        AssetLibrary.addImageSet("lofiEnvironment3", new EmbeddedAssets.lofiEnvironment3Embed_().bitmapData, 8, 8);
        AssetLibrary.addImageSet("lofiInterface", new EmbeddedAssets.lofiInterfaceEmbed_().bitmapData, 8, 8);
        AssetLibrary.addImageSet("redLootBag", new EmbeddedAssets.redLootBagEmbed_().bitmapData, 8, 8);
        AssetLibrary.addImageSet("lofiInterfaceBig", new EmbeddedAssets.lofiInterfaceBigEmbed_().bitmapData, 16, 16);
        AssetLibrary.addImageSet("lofiInterface2", new EmbeddedAssets.lofiInterface2Embed_().bitmapData, 8, 8);
        AssetLibrary.addImageSet("lofiObj", new EmbeddedAssets.lofiObjEmbed_().bitmapData, 8, 8);
        AssetLibrary.addImageSet("lofiObj2", new EmbeddedAssets.lofiObj2Embed_().bitmapData, 8, 8);
        AssetLibrary.addImageSet("lofiObj3", new EmbeddedAssets.lofiObj3Embed_().bitmapData, 8, 8);
        AssetLibrary.addImageSet("lofiObj3Alt", new EmbeddedAssets.lofiObj3Alt().bitmapData, 8, 8);
        AssetLibrary.addImageSet("lofiObj4", new EmbeddedAssets.lofiObj4Embed_().bitmapData, 8, 8);
        AssetLibrary.addImageSet("lofiObj5", new EmbeddedAssets.lofiObj5Embed_().bitmapData, 8, 8);
        AssetLibrary.addImageSet("lofiObj6", new EmbeddedAssets.lofiObj6Embed_().bitmapData, 8, 8);
        AssetLibrary.addImageSet("lofiObjBig", new EmbeddedAssets.lofiObjBigEmbed_().bitmapData, 16, 16);
        AssetLibrary.addImageSet("lofiObj40x40", new EmbeddedAssets.lofiObj40x40Embed_().bitmapData, 40, 40);
        AssetLibrary.addImageSet("lofiProjs", new EmbeddedAssets.lofiProjsEmbed_().bitmapData, 8, 8);
        AssetLibrary.addImageSet("lofiProjsAlt", new EmbeddedAssets.lofiProjsAlt_().bitmapData, 8, 8);
        AssetLibrary.addImageSet("lofiParticlesShocker", new EmbeddedAssets.lofiParticlesShockerEmbed_().bitmapData, 16, 16);
        AssetLibrary.addImageSet("lofiProjsBig", new EmbeddedAssets.lofiProjsBigEmbed_().bitmapData, 16, 16);
        AssetLibrary.addImageSet("lofiParts", new EmbeddedAssets.lofiPartsEmbed_().bitmapData, 8, 8);
        AssetLibrary.addImageSet("stars", new EmbeddedAssets.starsEmbed_().bitmapData, 5, 5);
        AssetLibrary.addImageSet("textile4x4", new EmbeddedAssets.textile4x4Embed_().bitmapData, 4, 4);
        AssetLibrary.addImageSet("textile5x5", new EmbeddedAssets.textile5x5Embed_().bitmapData, 5, 5);
        AssetLibrary.addImageSet("textile9x9", new EmbeddedAssets.textile9x9Embed_().bitmapData, 9, 9);
        AssetLibrary.addImageSet("textile10x10", new EmbeddedAssets.textile10x10Embed_().bitmapData, 10, 10);
        AssetLibrary.addImageSet("inner_mask", new EmbeddedAssets.innerMaskEmbed_().bitmapData, 4, 4);
        AssetLibrary.addImageSet("sides_mask", new EmbeddedAssets.sidesMaskEmbed_().bitmapData, 4, 4);
        AssetLibrary.addImageSet("outer_mask", new EmbeddedAssets.outerMaskEmbed_().bitmapData, 4, 4);
        AssetLibrary.addImageSet("innerP1_mask", new EmbeddedAssets.innerP1MaskEmbed_().bitmapData, 4, 4);
        AssetLibrary.addImageSet("innerP2_mask", new EmbeddedAssets.innerP2MaskEmbed_().bitmapData, 4, 4);
        AssetLibrary.addImageSet("invisible", new BitmapDataSpy(8, 8, true, 0), 8, 8);
        AssetLibrary.addImageSet("d3LofiObjEmbed", new EmbeddedAssets.d3LofiObjEmbed_().bitmapData, 8, 8);
        AssetLibrary.addImageSet("d3LofiObjEmbedAlt", new EmbeddedAssets.d3LofiObjAlt_().bitmapData, 8, 8);
        AssetLibrary.addImageSet("legendaries8x8Embed", new EmbeddedAssets.legendaries8x8Embed_().bitmapData, 8, 8);
        AssetLibrary.addImageSet("customEffects16x16", new EmbeddedAssets.customEffects16x16Embed_().bitmapData, 16, 16);
        AssetLibrary.addImageSet("customEffects8x8", new EmbeddedAssets.customEffects8x8Embed_().bitmapData, 8, 8);
        AssetLibrary.addImageSet("d3LofiObjBigEmbed", new EmbeddedAssets.d3LofiObjBigEmbed_().bitmapData, 16, 16);
        AssetLibrary.addImageSet("d1lofiObjBig", new EmbeddedAssets.d1LofiObjBigEmbed_().bitmapData, 16, 16);
        AssetLibrary.addImageSet("cursorsEmbed", new EmbeddedAssets.cursorsEmbed_().bitmapData, 32, 32);
        AssetLibrary.addImageSet("marks10x10", new EmbeddedAssets.marksEmbed_().bitmapData, 10, 10);
        AssetLibrary.addImageSet("HanamiParts8x8", new EmbeddedAssets.HanamiParts8x8Embed_().bitmapData, 8, 8);
        AssetLibrary.addImageSet("mountainTempleObjects8x8", new EmbeddedAssets.mountainTempleObjects8x8Embed_().bitmapData, 8, 8);
        AssetLibrary.addImageSet("mountainTempleObjects16x16", new EmbeddedAssets.mountainTempleObjects16x16Embed_().bitmapData, 16, 16);
        AssetLibrary.addImageSet("SakuraEnvironment8x8", new EmbeddedAssets.SakuraEnvironment8x8Embed_().bitmapData, 8, 8);
        AssetLibrary.addImageSet("SakuraEnvironment16x16", new EmbeddedAssets.SakuraEnvironment16x16Embed_().bitmapData, 16, 16);
        AssetLibrary.addImageSet("buffedBunnyObjects8x8", new EmbeddedAssets.buffedBunnyObjects8x8Embed_().bitmapData, 8, 8);
        AssetLibrary.addImageSet("buffedBunnyObjects16x16", new EmbeddedAssets.buffedBunnyObjects16x16Embed_().bitmapData, 16, 16);
        AssetLibrary.addImageSet("emotes", new EmbeddedAssets.emotesEmbed_().bitmapData, 16, 16);
        AssetLibrary.addImageSet("lofiObj7", new EmbeddedAssets.lofiObj7Embed_().bitmapData, 8, 8);
    }

    private function addAnimatedCharacters():void {
        AnimatedChars.add("d1chars8x8r", new EmbeddedAssets.d1Chars8x8rEmbed_().bitmapData, null, 8, 8, 56, 8, AnimatedChar.RIGHT);
        AnimatedChars.add("chars8x8rBeach", new EmbeddedAssets.chars8x8rBeachEmbed_().bitmapData, null, 8, 8, 56, 8, AnimatedChar.RIGHT);
        AnimatedChars.add("chars8x8dBeach", new EmbeddedAssets.chars8x8dBeachEmbed_().bitmapData, null, 8, 8, 56, 8, AnimatedChar.DOWN);
        AnimatedChars.add("chars8x8rLow1", new EmbeddedAssets.chars8x8rLow1Embed_().bitmapData, null, 8, 8, 56, 8, AnimatedChar.RIGHT);
        AnimatedChars.add("chars8x8rLow2", new EmbeddedAssets.chars8x8rLow2Embed_().bitmapData, null, 8, 8, 56, 8, AnimatedChar.RIGHT);
        AnimatedChars.add("chars8x8rMid", new EmbeddedAssets.chars8x8rMidEmbed_().bitmapData, null, 8, 8, 56, 8, AnimatedChar.RIGHT);
        AnimatedChars.add("chars8x8rMid2", new EmbeddedAssets.chars8x8rMid2Embed_().bitmapData, null, 8, 8, 56, 8, AnimatedChar.RIGHT);
        AnimatedChars.add("chars8x8rHigh", new EmbeddedAssets.chars8x8rHighEmbed_().bitmapData, null, 8, 8, 56, 8, AnimatedChar.RIGHT);
        AnimatedChars.add("chars8x8rHero1", new EmbeddedAssets.chars8x8rHero1Embed_().bitmapData, null, 8, 8, 56, 8, AnimatedChar.RIGHT);
        AnimatedChars.add("chars8x8rHero2", new EmbeddedAssets.chars8x8rHero2Embed_().bitmapData, null, 8, 8, 56, 8, AnimatedChar.RIGHT);
        AnimatedChars.add("chars8x8dHero1", new EmbeddedAssets.chars8x8dHero1Embed_().bitmapData, null, 8, 8, 56, 8, AnimatedChar.DOWN);
        AnimatedChars.add("chars16x16dMountains1", new EmbeddedAssets.chars16x16dMountains1Embed_().bitmapData, null, 16, 16, 112, 16, AnimatedChar.DOWN);
        AnimatedChars.add("chars16x16dMountains2", new EmbeddedAssets.chars16x16dMountains2Embed_().bitmapData, null, 16, 16, 112, 16, AnimatedChar.DOWN);
        AnimatedChars.add("chars8x8dEncounters", new EmbeddedAssets.chars8x8dEncountersEmbed_().bitmapData, null, 8, 8, 56, 8, AnimatedChar.DOWN);
        AnimatedChars.add("chars8x8rEncounters", new EmbeddedAssets.chars8x8rEncountersEmbed_().bitmapData, null, 8, 8, 56, 8, AnimatedChar.RIGHT);
        AnimatedChars.add("chars16x8dEncounters", new EmbeddedAssets.chars16x8dEncountersEmbed_().bitmapData, null, 16, 8, 112, 8, AnimatedChar.DOWN);
        AnimatedChars.add("chars16x8rEncounters", new EmbeddedAssets.chars16x8rEncountersEmbed_().bitmapData, null, 16, 8, 112, 8, AnimatedChar.DOWN);
        AnimatedChars.add("chars16x16dEncounters", new EmbeddedAssets.chars16x16dEncountersEmbed_().bitmapData, null, 16, 16, 112, 16, AnimatedChar.DOWN);
        AnimatedChars.add("chars16x16dEncounters2", new EmbeddedAssets.chars16x16dEncounters2Embed_().bitmapData, null, 16, 16, 112, 16, AnimatedChar.DOWN);
        AnimatedChars.add("chars16x16rEncounters", new EmbeddedAssets.chars16x16rEncountersEmbed_().bitmapData, null, 16, 16, 112, 16, AnimatedChar.RIGHT);
        AnimatedChars.add("d3Chars8x8rEmbed", new EmbeddedAssets.d3Chars8x8rEmbed_().bitmapData, null, 8, 8, 56, 8, AnimatedChar.RIGHT);
        AnimatedChars.add("d3Chars8x8rEmbedAlt", new EmbeddedAssets.d3Chars8x8rAlt_().bitmapData, null, 8, 8, 56, 8, AnimatedChar.RIGHT);
        AnimatedChars.add("d3Chars16x16rEmbed", new EmbeddedAssets.d3Chars16x16rEmbed_().bitmapData, null, 16, 16, 112, 16, AnimatedChar.RIGHT);
        AnimatedChars.add("d3Chars16x16rEmbedAlt", new EmbeddedAssets.d3Chars16x16rAlt_().bitmapData, null, 16, 16, 112, 16, AnimatedChar.RIGHT);
        AnimatedChars.add("players", new EmbeddedAssets.playersEmbed_().bitmapData, new EmbeddedAssets.playersMaskEmbed_().bitmapData, 8, 8, 56, 24, AnimatedChar.RIGHT);
        AnimatedChars.add("playerskins", new EmbeddedAssets.playersSkinsEmbed_().bitmapData, new EmbeddedAssets.playersSkinsMaskEmbed_().bitmapData, 8, 8, 56, 24, AnimatedChar.RIGHT);
        AnimatedChars.add("chars8x8rPets1", new EmbeddedAssets.chars8x8rPets1Embed_().bitmapData, new EmbeddedAssets.chars8x8rPets1MaskEmbed_().bitmapData, 8, 8, 56, 8, AnimatedChar.RIGHT);
        AnimatedChars.add("chars8x8rPets2", new EmbeddedAssets.chars8x8rPets2Embed_().bitmapData, new EmbeddedAssets.chars8x8rPets1MaskEmbed_().bitmapData, 8, 8, 56, 8, AnimatedChar.RIGHT);
        AnimatedChars.add("petsDivine", new EmbeddedAssets.petsDivineEmbed_().bitmapData, null, 16, 16, 112, 16, AnimatedChar.RIGHT);
        AnimatedChars.add("playerskins16", new EmbeddedAssets.playersSkins16Embed_().bitmapData, new EmbeddedAssets.playersSkins16MaskEmbed_().bitmapData, 16, 16, 112, 48, AnimatedChar.RIGHT);
        AnimatedChars.add("d1chars16x16r", new EmbeddedAssets.d1Chars16x16rEmbed_().bitmapData, null, 16, 16, 112, 16, AnimatedChar.RIGHT);
        AnimatedChars.add("buffedBunnyChars16x16", new EmbeddedAssets.buffedBunnyChars16x16Embed_().bitmapData, null, 16, 16, 112, 16, AnimatedChar.RIGHT);
        AnimatedChars.add("mountainTempleChars8x8",new EmbeddedAssets.mountainTempleChars8x8Embed_().bitmapData,null,8,8,56,8,AnimatedChar.RIGHT);
        AnimatedChars.add("mountainTempleChars16x16",new EmbeddedAssets.mountainTempleChars16x16Embed_().bitmapData,null,16,16,112,16,AnimatedChar.RIGHT);
        AnimatedChars.add("Hanami8x8chars",new EmbeddedAssets.Hanami8x8charsEmbed_().bitmapData,null,8,8,64,8,AnimatedChar.RIGHT);
        AnimatedChars.add("raiding32x32Embed",new EmbeddedAssets.raiding32x32Embed_().bitmapData,null,32,32,224,32,AnimatedChar.RIGHT);
        AnimatedChars.add("customEnemies16x16",new EmbeddedAssets.customEnemies16x16_().bitmapData,null,16,16,112,16,AnimatedChar.RIGHT);
    }

    private function addSoundEffects():void {
        SoundEffectLibrary.load("button_click");
        SoundEffectLibrary.load("death_screen");
        SoundEffectLibrary.load("enter_realm");
        SoundEffectLibrary.load("error");
        SoundEffectLibrary.load("inventory_move_item");
        SoundEffectLibrary.load("unbox_scroll");
        SoundEffectLibrary.load("level_up");
        SoundEffectLibrary.load("loot_appears");
        SoundEffectLibrary.load("no_mana");
        SoundEffectLibrary.load("use_key");
        SoundEffectLibrary.load("use_potion");
    }

    private function parse3DModels():void {
        var _local_1:String;
        var _local_2:ByteArray;
        var _local_3:String;
        for (_local_1 in EmbeddedAssets.models_) {
            _local_2 = EmbeddedAssets.models_[_local_1];
            _local_3 = _local_2.readUTFBytes(_local_2.length);
            Model3D.parse3DOBJ(_local_1, _local_2);
            Model3D.parseFromOBJ(_local_1, _local_3);
        }
    }

    private function parseParticleEffects():void {
        var _local_1:XML = XML(new EmbeddedAssets.particlesEmbed());
        ParticleLibrary.parseFromXML(_local_1);
    }

    private function parseGroundFiles():void {
        var _local_1:*;
        for each (_local_1 in EmbeddedData.groundFiles) {
            GroundLibrary.parseFromXML(XML(_local_1));
        }
    }

    private function parseObjectFiles():void {
        var _local_1:*;
        for each (_local_1 in EmbeddedData.objectFiles) {
            currentXmlIsTesting = this.checkIsTestingXML(_local_1);
            ObjectLibrary.parseFromXML(XML(_local_1));
        }
        currentXmlIsTesting = false;
    }

    private function parseRegionFiles():void {
        var _local_1:*;
        for each (_local_1 in EmbeddedData.regionFiles) {
            RegionLibrary.parseFromXML(XML(_local_1));
        }
    }

    private function checkIsTestingXML(_arg_1:*):Boolean {
        return (!((getQualifiedClassName(_arg_1).indexOf("TestingCXML", 33) == -1)));
    }


}
}//package com.company.assembleegameclient.util
