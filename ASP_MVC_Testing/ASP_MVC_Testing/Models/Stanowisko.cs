using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASP_MVC_Testing.Models
{
    public class Stanowisko
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StanowiskoId { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-ZĄĆĘŁŃÓŚŹŻąćęłńóżź \\s \\-]*$")]
        [Display(Name = "Stanowisko")]
        public string Nazwa { get; set; }
        [Display(Name = "Pensja")]
        [Range(1, 30000)]
        public decimal Pensja { get; set; }

        public virtual ICollection<Pracownik> Pracownik { get; set; }
    }
}