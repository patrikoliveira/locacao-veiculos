using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LocacaoVeiculosApi.Domain.Entities
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
        public UserType userType {get;set;}
    }
}