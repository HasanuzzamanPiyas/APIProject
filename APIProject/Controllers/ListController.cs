using APIProject.Model;
using APIProject.Repository.IRepository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProject.Controllers
{
    public class ListController : Controller
    {
        private readonly IListModelRepository _ListModelRepository;

        public ListController(IListModelRepository listModelRepository)
        {
            _ListModelRepository = listModelRepository;
        }

        [HttpGet("api/list/all")]
        public async Task<string> GetAllNamelist()
        {
            var list = await _ListModelRepository.GetListAsync();
            string[] listFind;
            int getMaxLength;
            var count = 0;
            string[] temp = new string[500];
            foreach (ListModel authorsList in list)
            {

                listFind = authorsList.Name.Split(", ");
                getMaxLength = listFind.Max(w => w.Length);
                for (int i = 0; i < listFind.Length; i++)
                {
                    if (getMaxLength == listFind[i].Length)
                    {
                        temp[count] = listFind[i];
                        count++;
                    }
                }

            }
            var storeWord = "";
            for (int j = list.Count; j >= 0; j--)
            {
                storeWord = temp[j] + " " + storeWord;
            }
            var st = storeWord;
            return st;
        }

        [HttpGet("api/list/{id}")]
        public async Task<IActionResult> GetSingleNameById([FromRoute] int id)
        {
            var list = await _ListModelRepository.GetListByIdAsync(id);

            if (list == null)
            {
                return NotFound();
            }
            return Ok(list);
        }


        [HttpPost("api/list/create")]
        public async Task<IActionResult> AddNameList([FromBody] List<ListModel> list)
        {

            var id = await _ListModelRepository.AddListModel(list);
            return CreatedAtAction(nameof(GetSingleNameById), new { id = id, controller = "list" }, id);
        }



        [HttpPut("api/list/{id}")]
        public async Task<IActionResult> UpdateProduct([FromBody] ListModel list, [FromRoute] int id)
        {

            await _ListModelRepository.UpdateListAsync(list, id);
            return Ok();

        }
        [HttpPatch("api/list/{id}")]
        public async Task<IActionResult> UpdateListPatch([FromBody] JsonPatchDocument list, [FromRoute] int id)
        {

            await _ListModelRepository.UpdateListPatchAsync(list, id);
            return Ok();

        }

        [HttpDelete("api/list/{id}")]
        public async Task<IActionResult> DeleteNameAsync([FromRoute] int id)
        {
            await _ListModelRepository.ListDeleteAsync(id);
            return Ok();
        }

    }
}
