using Business.Services.Interfeces;
using Entities;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ProjeIt_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactUsController : Controller
    {
        private readonly IContactUsService _contactUsService;
        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            return Ok(_contactUsService.GetList());
        }
        [HttpGet("getActives")]
        public IActionResult GetActives()
        {
            int CompanyID=2;
            return Ok(_contactUsService.GetActives((int)CompanyID));
        }

   
        [HttpGet("getActivesById")]
        public IActionResult GetActivesById(int CompanyID)
        {
            return Ok(_contactUsService.GetActivesById(CompanyID));
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int ID)
        {
            return Ok(_contactUsService.GetById(ID));
        }

        [HttpPost("add")]
        public IActionResult Add(ContactUs contactUs)
        {
            contactUs.CreatedDate = DateTime.Now;
            contactUs.Status = 1;
            contactUs.CompanyID = 2;
            MailWM mailEntity = new MailWM();
            mailEntity.To = "taner.yildiz@projeit.com";
            mailEntity.Body = "Company Name :"+ contactUs.CompanyName + "<br/>"+ "<br/>" + "Full Name :" + contactUs.NameSurName + "<br/>" + "<br/>" + "Phone :" + contactUs.Phone + "<br/>" + "<br/>" + "E-mail :" + contactUs.Email
                + "<br/>" + "<br/>" + "Description :" +contactUs.Description;
            try
            {
                MailMessage ePosta = new MailMessage();
                ePosta.From = new MailAddress("info@crfhubspot.com");
                ePosta.Subject = contactUs.CompanyName;
                ePosta.Body =  mailEntity.Body;
                ePosta.IsBodyHtml = true;
                ePosta.To.Add(mailEntity.To);
                SmtpClient smtp = new SmtpClient();
                smtp.Credentials = new NetworkCredential("info@crfhubspot.com", "Crf.Digital134!!");
                smtp.Port = 587;
                smtp.Host = "mail.kurumsaleposta.com";
                smtp.EnableSsl = false;
                smtp.Send(ePosta);

            }
            catch (Exception ex)
            {
                throw;
                //return 0;

            }
            //Email(mailEntity);
            return Ok(_contactUsService.Add(contactUs));
           
        }
       
        [HttpPost("update")]
        public IActionResult Update(ContactUs contactUs)
        {
            return Ok(_contactUsService.Update(contactUs));
        }
        [HttpPost("delete")]
        public IActionResult Delete(ContactUs contactUs)
        {
            return Ok(_contactUsService.Delete(contactUs));
        }
    }
}
