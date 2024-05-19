namespace EconoMe.Api.Domain.Services.Interfaces
{
    /// <summary>
    /// Interface Genérica para criação de serviços do tipo CRUD
    /// </summary>
    /// <typeparam name="RQ">Contrato de Request</typeparam>
    /// <typeparam name="RS">Contarto de Response</typeparam>
    /// <typeparam name="I">Tipo do Id</typeparam>
    public interface IService<RQ, RS, I> where RQ : class
    {
        Task<IEnumerable<RS>> Get(I idUser);
        Task<RS> GetById(I id, I idUser);
        Task<RS> Create(RQ model, I idUser);
        Task<RS> Update(I id,RQ model, I idUser);
        Task Delete(I id, I idUser);
    }
}