using System.ComponentModel.DataAnnotations;

namespace HR_Project_Group3_Domain.Entities
{
    public enum Status
    {
        [Display(Name = "Aktif")]

        Active = 1,
        [Display(Name = "Güncellendi")]
        Modified,
        [Display(Name = "Pasif")]
        Passive
    }
}