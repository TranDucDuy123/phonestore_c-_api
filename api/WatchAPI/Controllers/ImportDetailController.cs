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
    public class ImportDetailController : ControllerBase
    {
        private readonly IImportDetailService _importDetailService;

        public ImportDetailController(IImportDetailService importDetailService)
        {
            _importDetailService = importDetailService;
        }
        /// <summary>
        /// Tạo componentColor mới
        /// </summary>
        //[SystemsAuthorize(BaseConst.RoleCode.ADMIN)]
        [HttpPost]
        public async Task<ActionResult<BaseResponse<ImportDetail>>> Create([FromBody] ImportDetail model, CancellationToken cancellationToken)
        {
            var result = await _importDetailService.Create(model, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Cập nhật componentColor
        /// </summary>
        [HttpPut]
        [Route(BaseConst.Route.ID)]
        public async Task<ActionResult<BaseResponse<ImportDetail>>> Update([FromRoute] string id, [FromBody] ImportDetail model, CancellationToken cancellationToken)
        {
            model.Id = id;
            var result = await _importDetailService.Update(model, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Xóa componentColor
        /// </summary>
        [HttpDelete]
        [Route(BaseConst.Route.ID)]
        public async Task<ActionResult<BaseResponse<ImportDetail>>> Delete([FromRoute] string id, CancellationToken cancellationToken)
        {
            var result = await _importDetailService.Delete(id, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Lấy một componentColor theo Id
        /// </summary>
        [HttpGet]
        [Route(BaseConst.Route.ID)]
        public async Task<ActionResult<BaseResponse<ImportDetail>>> GetById([FromRoute] string id, CancellationToken cancellationToken)
        {
            var result = await _importDetailService.GetById(id, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Lấy danh sách componentColor
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<BaseResponse<List<ImportDetail>>>> GetList(CancellationToken cancellationToken)
        {
            var result = await _importDetailService.GetList(cancellationToken);
            return Ok(result);
        }
    }
}
