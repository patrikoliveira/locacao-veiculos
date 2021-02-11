using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace locacao_veiculos_api.Domain.Entities
{
    [Table("users")]
    public class User
    {
        [Key]
        public int id {get;set;}
        [Required]
        public string login {get;set;}
        [Required]
        public string password {get;set;}
        public string name {get;set;}
        public UserType userType {get;set;}
    }
}