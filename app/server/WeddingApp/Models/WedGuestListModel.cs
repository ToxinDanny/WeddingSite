using Npoi.Mapper.Attributes;

namespace WeddingApp.Models;

public class WedGuestListModel
{
    [Column("Nome")]
    public string FirstName { get; set; }

    [Column("Cognome")]
    public string LastName { get; set; }

    [Column("Età")]
    public AgeEnum Age { get; set; }

    [Column("Indirizzo")]
    public string Address { get; set; }

    [Column("Partecipazione")]
    public bool Participation { get; set; }

    [Column("Consegnata")]
    public bool HasBeenDelivered { get; set; }

    [Column("Risposta a invito")]
    public ParticipationResponseEnum ParticipationResponse { get; set; }

    [Column("Tavolo")]
    public string Table { get; set; }

    [Column("Esigenze alimentari particolari")]
    public string DietNotes { get; set; }

    [Column("Menu")]
    public MenuEnum Menu { get; set; }

    [Column("Note")]
    public string Notes { get; set; }
}
