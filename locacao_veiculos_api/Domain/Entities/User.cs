using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace locacao_veiculos_api.Domain.Entities
{
    public class User
    {
        [Key]
        public int id {get;set;}
        [Required]
        public string login {get;set;}
        [Required]
        public string password {get;set;}
    }
}