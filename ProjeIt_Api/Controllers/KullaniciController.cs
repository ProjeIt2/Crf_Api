using Business.Services.Interfeces;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeIt_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KullaniciController : ControllerBase
    {
        private readonly IKullaniciService _kullaniciService;
        public KullaniciController(IKullaniciService rolService)
        {
            _kullaniciService = rolService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_kullaniciService.GetList());
        }
        [HttpGet("Login")]
        public IActionResult Login(string KullaniciAdi, string Sifre)
        {
            return Ok(_kullaniciService.Login(KullaniciAdi, Sifre));
        }

        [HttpGet("GetListKullanici")]
        public IActionResult GetListKullanici()
        {

            return Ok(_kullaniciService.GetListKullanici());

        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int KullaniciId)
        {
            return Ok(_kullaniciService.GetById(KullaniciId));
        }

        [HttpPost("add")]
        public IActionResult Add(Kullanici kullanici)
        {
            return Ok(_kullaniciService.Add(kullanici));
        }
        [HttpPost("update")]
        public IActionResult Update(Kullanici kullanici)
        {
            return Ok(_kullaniciService.Update(kullanici));
        }
        [HttpPost("delete")]
        public IActionResult Delete(Kullanici kullanici)
        {
            return Ok(_kullaniciService.Delete(kullanici));
        }
    }
}
