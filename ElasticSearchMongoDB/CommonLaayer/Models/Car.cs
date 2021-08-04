using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace CommonLayer
{
    public class Car
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        [JsonProperty("Name")]
        public string CarName { get; set; }

        public string Engine { get; set; }

        public string DriveTrain { get; set; }

        public string Transmission { get; set; }

        public int Price_Dollar { get; set; }

        public int TopSpeed_KmHr { get; set; }

        public int Debut { get; set; }

        public string Fuel { get; set; }

        public string Manufacturer { get; set; }
    }
}
