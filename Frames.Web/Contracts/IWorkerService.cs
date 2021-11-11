namespace Frames.Web.Contracts;

public interface IWorkerService
{
    Task<IQueryable<Worker>> GetWorkers(Query query = null);
    Task<Worker> GetWorker(int id, Query query = null);
    Task<Worker> AddWorker(Worker worker);
    Task<Worker> UpdateWorker(Worker worker);
    Task<Worker> DeleteWorker(int workerId);
    Task<int> GetTotalCount();
    Task<bool> DoesWorkerExists(string name);
}
