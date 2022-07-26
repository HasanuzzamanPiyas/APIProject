using APIProject.Data;
using APIProject.Data.Entitties;
using APIProject.Model;
using APIProject.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIProject.Repository
{
    public class ListModelRepository: IListModelRepository
    {
        private readonly DBContext _context;
        private readonly IMapper _mapper;

        public ListModelRepository(DBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AddList(ListModel list)
        {
            var item = new ListModel()
            {
                Name = list.Name,
            };
           _context.ListModels.Add(item);
            await _context.SaveChangesAsync();
            return item.Id;
        }

        public async Task<int> AddListModel(List<ListModel> model)
             
        {

            foreach (ListModel item in model)
            {

                    _context.ListModels.Add(item);     
            }

            await _context.SaveChangesAsync();
            return 3;
            
        }

        public async Task<List<ListModel>> GetListAsync()
        {
            var records = await _context.ListModels.ToListAsync();
            return _mapper.Map<List<ListModel>>(records);
        }
        public async Task<ListModel> GetListByIdAsync(int id)
        {
            var list = await _context.ListModels.FindAsync(id);
            return _mapper.Map<ListModel>(list);
        }

        public async Task ListDeleteAsync(int listId)
        {
            var item = new ListModel()
            {
                Id = listId
            };

            _context.ListModels.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateListAsync(ListModel list, int id)
        {
            var item = new ListModel()
            {
                Id = id,
                Name = list.Name,
            };

            _context.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateListPatchAsync(JsonPatchDocument list, int id)
        {
            var listById = await _context.ListModels.FindAsync(id);

            if (listById != null)
            {
                list.ApplyTo(listById);
                await _context.SaveChangesAsync();
            }
            await _context.SaveChangesAsync();
        }
    }
}
