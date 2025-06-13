namespace Application.DTOs.RefreshToken;

public class RefreshTokenDto
{
    public int Id { get; set; }
    public string? Token { get; set; }
    public DateTime Expire { get; set; }
    public DateTime Created { get; set; }
    public DateTime Revoked { get; set; }
    public int MemberId { get; set; }
}
