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
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        /// <summary>
        /// Tạo componentColor mới
        /// </summary>
        //[SystemsAuthorize(BaseConst.RoleCode.ADMIN)]
        [HttpPost]
        public async Task<ActionResult<BaseResponse<Order>>> Create([FromBody] Order model, CancellationToken cancellationToken)
        {
            var result = await _orderService.Create(model, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Cập nhật componentColor
        /// </summary>
        [HttpPut]
        [Route(BaseConst.Route.ID)]
        public async Task<ActionResult<BaseResponse<Order>>> Update([FromRoute] string id, [FromBody] Order model, CancellationToken cancellationToken)
        {
            model.Id = id;
            var result = await _orderService.Update(model, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Xóa componentColor
        /// </summary>
        [HttpDelete]
        [Route(BaseConst.Route.ID)]
        public async Task<ActionResult<BaseResponse<Order>>> Delete([FromRoute] string id, CancellationToken cancellationToken)
        {
            var result = await _orderService.Delete(id, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Lấy một componentColor theo Id
        /// </summary>
        [HttpGet]
        [Route(BaseConst.Route.ID)]
        public async Task<ActionResult<BaseResponse<Order>>> GetById([FromRoute] string id, CancellationToken cancellationToken)
        {
            var result = await _orderService.GetById(id, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Lấy danh sách componentColor
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<BaseResponse<List<Order>>>> GetList(
            CancellationToken cancellationToken)
        {
            var result = await _orderService.GetList(cancellationToken);
            return Ok(result);
        }
    }
}
