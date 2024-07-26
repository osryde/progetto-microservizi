using System.Text.Json;
using Utility.Kafka.Constants;
using Utility.Kafka.Messages;
using PokemonCaptureService.Repository.Model;
using PokemonCaptureService.Shared;

namespace Pagamenti.Business.Factory;

public static class TransactionalOutboxFactory
{

    #region Pokemon
    public static TransactionalOutbox CreateInsert(PokemonDTO dto) => Create(dto, Operations.Insert);

    private static TransactionalOutbox Create(PokemonDTO dto, string operation) => Create(nameof(Pokemon), dto, operation);

    #endregion

    #region Item
    public static TransactionalOutbox CreateInsert(ItemDTO dto) => Create(dto, Operations.Insert);

    private static TransactionalOutbox Create(ItemDTO dto, string operation) => Create(nameof(Items), dto, operation);

    #endregion


    private static TransactionalOutbox Create<TDTO>(string table, TDTO dto, string operation) where TDTO : class, new()
    {
        OperationMessage<TDTO> opMsg = new OperationMessage<TDTO>() {
            Dto = dto,
            Operation = operation
        };
        opMsg.CheckMessage();

        return new TransactionalOutbox(){
            Tabella = table,
            Messaggio = JsonSerializer.Serialize(opMsg)
        };
    }
}
