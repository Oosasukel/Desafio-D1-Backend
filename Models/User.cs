using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using System;

namespace backend.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Phone[] Phones { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public Address[] Addresses { get; set; }
        [Required]
        public SocialMedias SocialMedias { get; set; }
        [Required]
        public string Cpf { get; set; }
        [Required]
        public string Rg { get; set; }
    }
}