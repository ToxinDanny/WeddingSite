using System;

namespace Guests.FunctionApp;

public class Guest
{
    public string PartitionKey { get; set; } = "guest";
    public string RowKey { get; set; } = Guid.NewGuid().ToString();
    public DateTimeOffset Timestamp { get; set; } = DateTimeOffset.Now;
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public AgeEnum Age { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public bool Participation { get; set; }
    public bool HasBeenDelivered { get; set; }
    public ParticipationResponseEnum ParticipationResponse { get; set; }
    public string Table { get; set; }
    public string DietNotes { get; set; }
    public MenuEnum Menu { get; set; }
    public string Notes { get; set; }
}