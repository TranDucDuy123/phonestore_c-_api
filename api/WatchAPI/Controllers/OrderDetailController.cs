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
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService;

        public OrderDetailController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }
        /// <summary>
        /// Tạo componentColor mới
        /// </summary>
        //[SystemsAuthorize(BaseConst.RoleCode.ADMIN)]
        [HttpPost]
        public async Task<ActionResult<BaseResponse<OrderDetail>>> Create([FromBody] OrderDetail model, CancellationToken cancellationToken)
        {
            var result = await _orderDetailService.Create(model, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Cập nhật componentColor
        /// </summary>
        [HttpPut]
        [Route(BaseConst.Route.ID)]
        public async Task<ActionResult<BaseResponse<OrderDetail>>> Update([FromRoute] string id, [FromBody] OrderDetail model, CancellationToken cancellationToken)
        {
            model.Id = id;
            var result = await _orderDetailService.Update(model, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Xóa componentColor
        /// </summary>
        [HttpDelete]
        [Route(BaseConst.Route.ID)]
        public async Task<ActionResult<BaseResponse<OrderDetail>>> Delete([FromRoute] string id, CancellationToken cancellationToken)
        {
            var result = await _orderDetailService.Delete(id, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Lấy một componentColor theo Id
        /// </summary>
        [HttpGet]
        [Route(BaseConst.Route.ID)]
        public async Task<ActionResult<BaseResponse<OrderDetail>>> GetById([FromRoute] string id, CancellationToken cancellationToken)
        {
            var result = await _orderDetailService.GetById(id, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Lấy danh sách componentColor
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<BaseResponse<List<OrderDetail>>>> GetList(
            CancellationToken cancellationToken)
        {
            var result = await _orderDetailService.GetList(cancellationToken);
            return Ok(result);
        }
    }
}
