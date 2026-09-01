namespace apitest.DTO;

public class PetDto
{
    public string id { get; set; }
    public string name { get; set; }
    public string Species { get; set; }
    public string Breed { get; set; }
    public int AgeMonths { get; set; }
    public string Size { get; set; }
    public string Status { get; set; }
    public string Price { get; set; }
    public string Currency { get; set; }
    public bool GoodWithKids {  get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public MedicalInfo MedicalDto { get; set; }
}