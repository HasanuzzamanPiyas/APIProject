
using AutoMapper;
using APIProject.Data.Entitties;
using APIProject.Model;

namespace APIProject.Helper
{
    public class ListMapper : Profile 
    {
        public ListMapper()
        {
           CreateMap<ListModels, ListModel>().ReverseMap();
        }
        
    }
}
