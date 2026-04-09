using System.ComponentModel.DataAnnotations;

namespace Presentation.WebApp.Areas.Admin.Models;

public sealed class TrainingSessionForm
{
    [Required]
    [StringLength(200)]
    [Display(Name = "Name")]
    public string Name { get; set; } = null!;

    [Required]
    [Display(Name = "Start time")]
    public DateTime StartTime { get; set; }

    [Required]
    [Display(Name = "End time")]
    public DateTime EndTime { get; set; }

    [Range(1, 500)]
    [Display(Name = "Max participants")]
    public int MaxParticipants { get; set; } = 20;
}
