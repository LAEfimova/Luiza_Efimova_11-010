using System.ComponentModel.DataAnnotations;

namespace WebPerson.Models
{
    public class Person
    {
        [Display(Name = "First Name"), StringLength(18, ErrorMessage = "Ur Firstname too long for us, go away!")]
        public string First_Name { get; set; }

        [Display(Name = "Last Name"), StringLength(18, ErrorMessage = "Ur Lastname too long for us, go away!")]
        public string Last_Name { get; set; }

        [Display(Name = "Age"), Range(0, 100, ErrorMessage = "Set age value between 0 and 100 or go away!")]
        public int? Age { get; set; }

        [Display(Name = "Gender")]
        public Gender Gender { get; set; }

        [Display(Name = "Card Number"), Range(16, 16, ErrorMessage = "Set right card info.")]
        public int? CardNumber { get; set; }

        [Display(Name = "CVV Code"), Range(3, 3, ErrorMessage = "Set right card info.")]
        public int? CVV { get; set; }
    }

    public enum Gender
    {
        Agender,
        Androgyne,
        Androgynous,
        Bigender,
        Cis,
        Cisgender,
        Cis_Female,
        Cis_Male,
        Cis_Man,
        Cis_Woman,
        Cisgender_Female,
        Cisgender_Male,
        Cisgender_Man,
        Cisgender_Woman,
        Female_to_Male,
        FTM,
        Gender_Fluid,
        Gender_Nonconforming,
        Gender_Questioning,
        Gender_Variant,
        Genderqueer,
        Intersex,
        Male_to_Female,
        MTF,
        Neither,
        Neutrois,
        Non_binary,
        Other,
        Pangender,
        Trans,
        Trans_Female,
        Trans_Male,
        Trans_Man,
        Trans_Person,
        Trans_Woman,
        Transfeminine,
        Transgender,
        Transgender_Female,
        Transgender_Male,
        Transgender_Man,
        Transgender_Person,
        Transgender_Woman,
        Transmasculine,
        Transsexual,
        Transsexual_Female,
        Transsexual_Male,
        Transsexual_Man,
        Transsexual_Person,
        Transsexual_Woman,
        Two_Spirit
    }
}
