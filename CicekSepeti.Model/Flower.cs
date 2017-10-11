using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CicekSepeti.Model
{
    //The model of the a row in Flowers table
    public class Flower : Entity<int>, IEnumerable
    {
        private IEnumerable _enumerableImplementation;

        [DisplayName("Çiçek Adı")]
        [Required(ErrorMessage = "Lütfen çiçek adı giriniz.")]
        public string Name { get; set; }

        [DisplayName("Çiçekli mi?")]
        public bool IsFlowering { get; set; }

        [DisplayName("Dikenli mi?")]
        public bool IsThorny { get; set; }

        [DisplayName("Yapraklı mı?")]
        public bool IsLeafy { get; set; }


        public IEnumerator GetEnumerator()
        {
            return _enumerableImplementation.GetEnumerator();
        }
    }
}