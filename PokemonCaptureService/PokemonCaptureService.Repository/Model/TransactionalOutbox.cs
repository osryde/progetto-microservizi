using System.ComponentModel.DataAnnotations.Schema;

namespace PokemonCaptureService.Repository.Model {
    public class TransactionalOutbox {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        // Nome della tabella
        public string Tabella { get; set; } = string.Empty;

        // Messaggio contenente il record
        public string Messaggio { get; set; } = string.Empty;
    }
}
