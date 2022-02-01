using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aventuras.Validation;
using aventuras.ViewModels;
using aventuras.BindingModels;
using aventuras.data.sql;
using aventuras.data.sql.DAO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace aventuras.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]

    public class ShareController : Controller
    {
        private readonly AventurasDbContext _context;

        public ShareController(AventurasDbContext context)
        {
            _context = context;
        }

        [HttpGet("{shareId:min(1)}", Name = "GetShareById")]
        public async Task<IActionResult> GetShareById(int shareId)
        {
            var share = await _context.Share.FirstOrDefaultAsync(x => x.ShareId == shareId);
            if (share != null)
            {
                return Ok(new ShareViewModel
                {
                    ShareId = share.ShareId,
                    PostId = share.PostId,
                    UserId = share.UserId
                });
            }

            return NotFound();
        }


        [ValidateModel]
        public async Task<IActionResult> Post([FromBody] CreateShare createShare)
        {
            var share = new Share
            {
                ShareId = createShare.ShareId,
                PostId = createShare.PostId,
                UserId = createShare.UserId,

            };
            await _context.AddAsync(share);
            await _context.SaveChangesAsync();

            return Created(share.ShareId.ToString(), new ShareViewModel
            {
                ShareId = share.ShareId,
                PostId = share.PostId,
                UserId = share.UserId
            });
        }

        [ValidateModel]
        [HttpPatch("edit/{shareId:min(1)}", Name = "EditShare")]
        public async Task<IActionResult> EditShare([FromBody] EditShare editShare, int shareId)
        {
            var share = await _context.Share.FirstOrDefaultAsync(x => x.ShareId == shareId);
            share.ShareId = editShare.ShareId;
            share.PostId = editShare.PostId;
            share.UserId = editShare.UserId;
            await _context.SaveChangesAsync();
            return Ok(new ShareViewModel
            {
                ShareId = share.ShareId,
                PostId = share.PostId,
                UserId = share.UserId
            });
        }

        [HttpDelete("{shareId:min(1)}", Name = "DeleteShare")]
        public async Task<IActionResult> DeleteShare(int shareId)
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
