﻿using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace TestMaker.Evaluation.API.Models
{
    public class AlternativeAttributesModel
    {
        public long Id { get; set; }

        [JsonProperty("valor")]
        public string BaseValue { get; set; }

        [JsonProperty("nomeAtributo")]
        public string Name { get; set; }

        public string Value
        {
            get => BaseValue is null ? string.Empty : Regex.Replace(BaseValue, "<.*?>", string.Empty);
        }
    }
}