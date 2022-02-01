using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aventuras.Mappers;
using aventuras.Validation;
using aventuras.data.sql;
using aventuras.iservices.Share;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace aventuras.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/share")]
    public class ShareV2Controller : Controller
    {
        private readonly AventurasDbContext _context;
        private readonly IShareService _shareService;

        public ShareV2Controller(AventurasDbContext context, IShareService shareService)
        {
            _context = context;
            _shareService = shareService;
        }

        [HttpGet("{shareId:min(1)}", Name = "GetShareById")]
        public async Task<IActionResult> GetShareById(int shareId)
        {
            var share = await _shareService.GetShareByShareId(shareId);
            if (share != null)
            {
                return Ok(ShareToShareViewModelMapper.ShareToShareViewModel(share));
            }
            return NotFound();
        }

        [ValidateModel]
        public async Task<IActionResult> Post([FromBody] iservices.Requests.CreateShare createShare)
        {
            var share = await _shareService.CreateShare(createShare);

            return Created(share.ShareId.ToString(), ShareToShareViewModelMapper.ShareToShareViewModel(share));
        }


        [ValidateModel]
        [HttpPatch("edit/{shareId:min(1)}", Name = "EditShare")]
        public async Task<IActionResult> EditShare([FromBody] iservices.Requests.EditShare editShare, int shareId)
        {
            await _shareService.EditShare(editShare, shareId);

            return NoContent();
        }

        [HttpDelete("{shareId:min(1)}", Name = "DeleteShare")]
        public async Task<ActionResult<domain.Share.Share>> DeleteShare(int shareId)
        {
            var share = await _context.Share.FirstOrDefaultAsync(x => x.ShareId == shareId);
            if (share != null)
            {
                _context.Share.Remove(share);
                await _context.SaveChangesAsync();
                return NoContent();
            }

            return NotFound();

        }

    }
}
