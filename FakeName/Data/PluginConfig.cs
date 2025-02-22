﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Dalamud.Configuration;

namespace FakeName.Data;

[Serializable]
public class PluginConfig : IPluginConfiguration
{
    
    public int Version { get; set; } = 0;

    public bool Enabled = false;

    public bool IncognitoMode = false;

    public bool HideSupport = false;

    public Dictionary<uint, Dictionary<string, CharacterConfig>> WorldCharacterDictionary = new();
    
    public bool TryGetCharacterConfig(string name, uint world, [MaybeNullWhen(false)] out CharacterConfig characterConfig) {
        characterConfig = null;
        if (!WorldCharacterDictionary.TryGetValue(world, out var w)) return false;
        return w.TryGetValue(name, out characterConfig);
    }
    
    public bool TryAddCharacter(string name, uint homeWorld) {
        if (!WorldCharacterDictionary.ContainsKey(homeWorld)) WorldCharacterDictionary.Add(homeWorld, new Dictionary<string, CharacterConfig>());
        if (WorldCharacterDictionary.TryGetValue(homeWorld, out var world)) {
            return world.TryAdd(name, new CharacterConfig());
        }

        return false;
    }
    
    public bool TryGetWorldDic(uint world, [MaybeNullWhen(false)] out Dictionary<string, CharacterConfig> worldDic) {
        worldDic = null;
        return WorldCharacterDictionary.TryGetValue(world, out worldDic);
    }
}
