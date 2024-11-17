﻿using System.Text.Json;
using System.Text.Json.Serialization;

// ReSharper disable InconsistentNaming

namespace GitHubUpdater.API
{
    public class GHApiObject
    {
        public string ToJson(bool prettyPrint = true)
            => JsonSerializer.Serialize(this, new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                WriteIndented = prettyPrint
            });

        public static T FromJson<T>(string json)
            => JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            });
    }
}