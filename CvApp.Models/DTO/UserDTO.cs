using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CvApp.Data.Entities;

namespace CvApp.Models.DTO
{
    public class UserDTO
    {

        public int UserId { get; set; }
        [Required(ErrorMessage = "İsim gereklidir.")]
        [MinLength(2, ErrorMessage = ("İsim minimum 2 karakter olmalı."))]
        [MaxLength(20, ErrorMessage = ("İsim maximum 20 karakter olmalı."))]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "İsim sadece harf içermelidir.")]
        public string FirstName { get; set; } = string.Empty;
        [Required(ErrorMessage = "İsim gereklidir.")]
        [MinLength(2, ErrorMessage = ("Soyisim minimum 2 karakter olmalı."))]
        [MaxLength(20, ErrorMessage = ("Soyisim maximum 20 karakter olmalı."))]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Soyisim sadece harf içermelidir.")]
        public string LastName { get; set; } = string.Empty;
        [EmailAddress(ErrorMessage = "Email adres tipinde giriş yapınız. ornek@ornek.com")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Şifre gereklidir.")]
        [MinLength(2, ErrorMessage = ("Şifre minimum 2 karakter olmalı."))]
        [MaxLength(8, ErrorMessage = ("Şifre maximum 8 karakter olmalı."))]
        public string Password { get; set; } = string.Empty;
        public string PasswordConfirm { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        [Required(ErrorMessage = "Kullanıcı adı gereklidir.")]
        [MinLength(2, ErrorMessage = ("Kullanıcı adı 2 karakter olmalı."))]
        [MaxLength(8, ErrorMessage = ("Kullanıcı adı 8 karakter olmalı."))]
        public string UserName { get; set; } = string.Empty;
        [Required]
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;
        public string UserDescription { get; set; } = string.Empty;
        public int UserCount { get; set; }
        public string fileName { get; set; } = string.Empty;
        public string filePath { get; set; } = string.Empty;
        public DateTime BirtDay { get; set; }
        public string Location { get; set; } = string.Empty;
        public string UK { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public bool MSwasDone { get; set; }
        public string Hobies { get; set; } = string.Empty;
        public int PersonId { get; set; }
        public string Roles { get; set; } = string.Empty;
        public string? Adress { get; set; } = string.Empty;
        public string? TwitterLink { get; set; } = string.Empty;
        public string? FacebookLink { get; set; } = string.Empty;
        public string? InstagramLınk { get; set; } = string.Empty;
        public string? SkypeLınk { get; set; } = string.Empty;
        public string? LinkedinLink { get; set; } = string.Empty;
        public UserDTO()
        {
            CreatedAt = DateTime.Now;
            PersonId = 1;
        }
    }
}
