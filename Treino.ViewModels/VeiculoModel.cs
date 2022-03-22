using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Treino.ViewModels
{
    public partial class VeiculoModel
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("vehicle_class")]
        public string VehicleClass { get; set; }

        [JsonProperty("length")]
        public string Length { get; set; }

        [JsonProperty("pilot")]
        public string Pilot { get; set; }

        [JsonProperty("films")]
        public string[] Films { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
    public partial class VeiculoModel
    {
        public static VeiculoModel FromJson(string json) => JsonConvert.DeserializeObject<VeiculoModel>(json,Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this VeiculoModel self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
