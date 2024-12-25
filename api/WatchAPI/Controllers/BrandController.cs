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
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        /// <summary>
        /// Tạo mới
        /// </summary>
        //[SystemsAuthorize(BaseConst.RoleCode.ADMIN)]
        [HttpPost]
        public async Task<ActionResult<BaseResponse<Brand>>> Create([FromBody] Brand model, CancellationToken cancellationToken)
        {
            var result = await _brandService.Create(model, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Cập nhật
        /// </summary>
        [HttpPut]
        [Route(BaseConst.Route.ID)]
        public async Task<ActionResult<BaseResponse<Brand>>> Update([FromRoute] string id, [FromBody] Brand model, CancellationToken cancellationToken)
        {
            model.Id = id;
            var result = await _brandService.Update(model, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Xóa 
        /// </summary>
        [HttpDelete]
        [Route(BaseConst.Route.ID)]
        public async Task<ActionResult<BaseResponse<Brand>>> Delete([FromRoute] string id, CancellationToken cancellationToken)
        {
            var result = await _brandService.Delete(id, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Lấy theo Id
        /// </summary>
        [HttpGet]
        [Route(BaseConst.Route.ID)]
        public async Task<ActionResult<BaseResponse<Brand>>> GetById([FromRoute] string id, CancellationToken cancellationToken)
        {
            var result = await _brandService.GetById(id, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Lấy danh sách
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<BaseResponse<List<Brand>>>> GetList(CancellationToken cancellationToken)
        {
            var result = await _brandService.GetList(cancellationToken);
            return Ok(result);
        }
    }
}
