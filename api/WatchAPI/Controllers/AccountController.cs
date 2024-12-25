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
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        /// <summary>
        /// Tạo mới
        /// </summary>
        //[SystemsAuthorize(BaseConst.RoleCode.ADMIN)]
        [HttpPost]
        public async Task<ActionResult<BaseResponse<Account>>> Create([FromBody] Account model, CancellationToken cancellationToken)
        {
            var result = await _accountService.Create(model, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Cập nhật
        /// </summary>
        [HttpPut]
        [Route(BaseConst.Route.ID)]
        public async Task<ActionResult<BaseResponse<Account>>> Update([FromRoute] string id, [FromBody] Account model, CancellationToken cancellationToken)
        {
            model.Id = id;
            var result = await _accountService.Update(model, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Xóa
        /// </summary>
        [HttpDelete]
        [Route(BaseConst.Route.ID)]
        public async Task<ActionResult<BaseResponse<Account>>> Delete([FromRoute] string id, CancellationToken cancellationToken)
        {
            var result = await _accountService.Delete(id, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Lấy theo Id
        /// </summary>
        [HttpGet]
        [Route(BaseConst.Route.ID)]
        public async Task<ActionResult<BaseResponse<Account>>> GetById([FromRoute] string id, CancellationToken cancellationToken)
        {
            var result = await _accountService.GetById(id, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Lấy danh sách
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<BaseResponse<List<Account>>>> GetList(CancellationToken cancellationToken)
        {
            var result = await _accountService.GetList(cancellationToken);
            return Ok(result);
        }
    }
}
