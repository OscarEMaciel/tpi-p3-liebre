using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Application.Interfaces;
using Application.Models.Request;
using Application.Models;

namespace Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SysAdminController : ControllerBase
{
    private readonly ISysAdminServices _sysadminService;

    public SysAdminController(ISysAdminServices sysadminService)
    {
        _sysadminService = sysadminService;
    }

    [HttpGet]
    public ActionResult<List<SysAdminDTO>> GetAll()
    {
        var sysadmins = _sysadminService.GetAllSysAdmins();
        return Ok(sysadmins);
    }

    [HttpGet("{id}")]
    public ActionResult<SysAdminDTO> GetById(int id)
    {
        try
        {
            return _sysadminService.GetSysAdminById(id);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpPost]
    public IActionResult Create(SysAdminCreateRequest request)
    {
         _sysadminService.CreateSysAdmin(request);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, SysAdminUpdateRequest request)
    {
        try
        {
            _sysadminService.UpdateSysAdmin(id, request);
            return Ok();
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            _sysadminService.DeleteSysAdmin(id);
            return Ok();
        }
        catch (Exception)
        {
            return NotFound();
        }
    }
}
