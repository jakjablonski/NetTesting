using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP_MVC_Testing.Models
{
    public class Pracownik
    {
        public int PracownikId { get; set; }
        public int StanowiskoId { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-ZĄĆĘŁŃÓŚŹŻąćęłńóżź \\s \\-]*$")]
        [Display(Name = "Imie")]
        public string Imie { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-ZĄĆĘŁŃÓŚŹŻąćęłńóżź \\s \\-]*$")]
        [Display(Name = "Nazwisko")]
        public string Nazwisko { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]*$")]
        [Display(Name = "Pesel")]
        [StringLength(11, ErrorMessage = "Pesel musi miec 11 znaków")]
        public string Pesel { get; set; }

        public virtual Stanowisko Stanowisko { get; set; }


    }
}