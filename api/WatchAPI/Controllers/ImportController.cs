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
    public class ImportController : ControllerBase
    {
        private readonly IImportService _importService;

        public ImportController(IImportService importService)
        {
            _importService = importService;
        }
        /// <summary>
        /// Tạo componentColor mới
        /// </summary>
        //[SystemsAuthorize(BaseConst.RoleCode.ADMIN)]
        [HttpPost]
        public async Task<ActionResult<BaseResponse<Import>>> Create([FromBody] Import model, CancellationToken cancellationToken)
        {
            var result = await _importService.Create(model, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Cập nhật componentColor
        /// </summary>
        [HttpPut]
        [Route(BaseConst.Route.ID)]
        public async Task<ActionResult<BaseResponse<Import>>> Update([FromRoute] string id, [FromBody] Import model, CancellationToken cancellationToken)
        {
            model.Id = id;
            var result = await _importService.Update(model, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Xóa componentColor
        /// </summary>
        [HttpDelete]
        [Route(BaseConst.Route.ID)]
        public async Task<ActionResult<BaseResponse<Import>>> Delete([FromRoute] string id, CancellationToken cancellationToken)
        {
            var result = await _importService.Delete(id, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Lấy một componentColor theo Id
        /// </summary>
        [HttpGet]
        [Route(BaseConst.Route.ID)]
        public async Task<ActionResult<BaseResponse<Import>>> GetById([FromRoute] string id, CancellationToken cancellationToken)
        {
            var result = await _importService.GetById(id, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Lấy danh sách componentColor
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<BaseResponse<List<Import>>>> GetList(CancellationToken cancellationToken)
        {
            var result = await _importService.GetList(cancellationToken);
            return Ok(result);
        }
    }
}
