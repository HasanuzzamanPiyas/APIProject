
using APIProject.Model;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIProject.Repository.IRepository
{
    public interface IListModelRepository
    {
        Task<int> AddListModel(List<ListModel> model);
        Task<List<ListModel>> GetListAsync();
        Task<ListModel> GetListByIdAsync(int id);
        Task<int> AddList(ListModel list);
        Task UpdateListAsync(ListModel list, int id);
        Task UpdateListPatchAsync(JsonPatchDocument list, int id);
        Task ListDeleteAsync(int listId);
    }
}
