using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DesafioFull_WebAPI.Data;
using DesafioFull_WebAPI.Models;

namespace DesafioFull_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DividaController : ControllerBase
    {
        private readonly IRepository _repo;

        public DividaController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllDividasAsync(true);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
        [HttpGet("{DividaId}")]
        public async Task<IActionResult> GetByDividaId(int DividaId)
        {
            try
            {
                var result = await _repo.GetDividaAsyncById(DividaId, true);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> post(Divida model)
        {
            try
            {
                _repo.Add(model);
                if (await _repo.SaveChangesAsync())
                    return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
            return BadRequest();

        }
        [HttpPut("{DividaId}")]
        public async Task<IActionResult> put(int DividaId, Divida model)
        {
            try
            {
                var divida = await _repo.GetDividaAsyncById(DividaId, false);
                if (divida == null) return NotFound("Divida Não Encontrada");

                _repo.Update(model);

                if (await _repo.SaveChangesAsync())
                    return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
            return BadRequest();

        }
        [HttpDelete("{DividaId}")]
        public async Task<IActionResult> delete(int DividaId)
        {
            try
            {
                var divida = await _repo.GetDividaAsyncById(DividaId, false);
                if(divida == null) return NotFound("Divida Não Encontrada");

                _repo.Delete(divida);

                if(await _repo.SaveChangesAsync())
                {
                    return Ok(new {message = "Deletado"});
                }                
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }

    }
}