namespace lawyerSystem.api.Core.Dtos;

public class LawyerSummaryDto
{
    public Guid UserId { get; set; }

    public string Name { get; set; }

    public string OABNumber { get; set; }

    public string Position { get; set; }

    public LawyerSummaryDto(Guid userId, string name, string oabNumber, string position)
    {
        UserId = userId;
        Name = name;
        OABNumber = oabNumber;
        Position = position;
    }
}
