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
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        /// <summary>
        /// Tạo componentColor mới
        /// </summary>
        //[SystemsAuthorize(BaseConst.RoleCode.ADMIN)]
        [HttpPost]
        public async Task<ActionResult<BaseResponse<Product>>> Create([FromBody] Product model, CancellationToken cancellationToken)
        {
            var result = await _productService.Create(model, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Cập nhật componentColor
        /// </summary>
        [HttpPut]
        [Route(BaseConst.Route.ID)]
        public async Task<ActionResult<BaseResponse<Product>>> Update([FromRoute] string id, [FromBody] Product model, CancellationToken cancellationToken)
        {
            model.Id = id;
            var result = await _productService.Update(model, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Xóa componentColor
        /// </summary>
        [HttpDelete]
        [Route(BaseConst.Route.ID)]
        public async Task<ActionResult<BaseResponse<Product>>> Delete([FromRoute] string id, CancellationToken cancellationToken)
        {
            var result = await _productService.Delete(id, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Lấy một componentColor theo Id
        /// </summary>
        [HttpGet]
        [Route(BaseConst.Route.ID)]
        public async Task<ActionResult<BaseResponse<Product>>> GetById([FromRoute] string id, CancellationToken cancellationToken)
        {
            var result = await _productService.GetById(id, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Lấy danh sách componentColor
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<BaseResponse<List<Product>>>> GetList(
            CancellationToken cancellationToken)
        {
            var result = await _productService.GetList(cancellationToken);
            return Ok(result);
        }
    }
}
