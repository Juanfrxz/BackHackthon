namespace Application.DTOs.PersonProfile;

public class PersonProfileDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public int CityId { get; set; }
    public int PersonTypeId { get; set; }
    public int MemberId { get; set; }
}
