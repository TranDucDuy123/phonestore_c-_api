using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using WatchAPI.Datas.Models;
using WatchAPI.Datas.ViewModels.Base;
using WatchAPI.Services;
using WatchAPI.Services.Impl;
using WatchAPI.Utils;

namespace WatchAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        /// <summary>
        /// Tạo componentColor mới
        /// </summary>
        //[SystemsAuthorize(BaseConst.RoleCode.ADMIN)]
        [HttpPost]
        public async Task<ActionResult<BaseResponse<Category>>> Create([FromBody] Category model, CancellationToken cancellationToken)
        {
            var result = await _categoryService.Create(model, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Cập nhật componentColor
        /// </summary>
        [HttpPut]
        [Route(BaseConst.Route.ID)]
        public async Task<ActionResult<BaseResponse<Category>>> Update([FromRoute] string id, [FromBody] Category model, CancellationToken cancellationToken)
        {
            model.Id = id;
            var result = await _categoryService.Update(model, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Xóa componentColor
        /// </summary>
        [HttpDelete]
        [Route(BaseConst.Route.ID)]
        public async Task<ActionResult<BaseResponse<Category>>> Delete([FromRoute] string id, CancellationToken cancellationToken)
        {
            var result = await _categoryService.Delete(id, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Lấy một componentColor theo Id
        /// </summary>
        [HttpGet]
        [Route(BaseConst.Route.ID)]
        public async Task<ActionResult<BaseResponse<Category>>> GetById([FromRoute] string id, CancellationToken cancellationToken)
        {
            var result = await _categoryService.GetById(id, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Lấy danh sách componentColor
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<BaseResponse<List<Category>>>> GetList(CancellationToken cancellationToken)
        {
            var result = await _categoryService.GetList(cancellationToken);
            return Ok(result);
        }
    }
}
