using System.ComponentModel.DataAnnotations;

namespace CicekSepeti.Model
{
    public sealed class Bouquet : Entity<int>
    {
        //The model of the a row in Bouquets table

        [Required(ErrorMessage = "Lütfen buket çeşidi adı giriniz.")]
        public string Name { get; set; }
    }
}