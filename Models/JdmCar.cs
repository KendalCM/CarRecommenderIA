using System.ComponentModel.DataAnnotations;

namespace CarRecommenderIA.Models;

public class JdmCar
{
    [Key]
    public int Id { get; set; }
    public int Year { get; set; }
    [Required]
    public string Make { get; set; }
    [Required]
    public string Model { get; set; }
    public string Engine { get; set; }
    public string Num_Of_Cyl { get; set; }
    public string Aspiration { get; set; }
    public string Horsepower { get; set; }
    public string Torque { get; set; }
    public string Top_Speed { get; set; }
    public string Drive_Type { get; set; }
    public string Curb_Weight { get; set; }
    public string Fuel_Type { get; set; }
    public string Transmission { get; set; }
    public float? Fuel_Economy_MPG { get; set; }
    public int Price_USD { get; set; }
}
