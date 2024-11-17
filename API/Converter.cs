﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace GitHubUpdater.API
{
    internal static class Converter
    {
        internal static readonly JsonSerializerSettings Settings = new()
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            }
        };
    }
}