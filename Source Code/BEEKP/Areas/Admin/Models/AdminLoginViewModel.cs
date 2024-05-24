using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BEEKP.Areas.Admin.Models
{
    public class AdminLoginViewModel
    {
        public String email_id { get; set; }
        public String user_password { get; set; }
        public AdminLoginViewModel()
        {
            email_id = "";
            user_password = "";
         
        }
    }

    public class LoginDetail
    {
        public Int32 user_id { get; set; }
        public Int32 user_type_id { get; set; }
        public String password { get; set; }
        public String email_id { get; set; }
        public String first_name { get; set; }
        public String last_name { get; set; }
        public String mobile { get; set; }
        public Int32 role_id { get; set; }

       
        public LoginDetail()
        {
            first_name = "";
            last_name = "";
            password = "";
            email_id = "";
            mobile = "";

        }

    }

    public class ForgetPasswordViewModel
    {
        public String email_id { get; set; }
    }
    public class ForgetPasswordOTP
    {
        public String email_id { get; set; }
        public Int32 MessageID { get; set; }
        public String OTP { get; set; }
    }

    public class ResetPasswordViewModel
    {
        public String OTP { get; set; }
        public String email_id { get; set; }
        public String password { get; set; }
        public String confirm_password { get; set; }
    }

    public class RegistrationViewModel
    {
        //public String user_name { get; set; }
        //public String user_password { get; set; }
        public Registration Registration { get; set; }
        public List<State> ListState { get; set; }
        public RegistrationViewModel()
        {
            Registration = new Registration();
            ListState = new List<State>();
        }
    }

    public class Registration
    {
        public Int32 user_id { get; set; }
        public Int32 user_type_id { get; set; }

        public String user_name { get; set; }
        public String password { get; set; }
        public String confirm_password { get; set; }
        public String emailid { get; set; }
        public String mobile { get; set; }
        public Int32 role_id { get; set; }
        public String address { get; set; }
        public String first_name { get; set; }
        public String last_name { get; set; }
       
        public State State{get;set;}
        public String city { get; set; }
        public Int32 pincode { get; set; }

        public Registration()
        {
            user_name = "";
            password = "";
            emailid = "";
            mobile = "";

        }
    }

    public class ChangePasswordViewModel
    {
     
        public ChangePassword ChangePassword { get; set; }
        public Int32 user_id { get; set; }
        public ChangePasswordViewModel()
        {
            ChangePassword = new ChangePassword();
        }
    }

    public class ChangePassword
    {
        [Required(ErrorMessage = "Old Password is required.")]
        public String old_password { get; set; }

        [Required(ErrorMessage = "New Password is required.")]
        //[RegularExpression(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%])(?=.{6,15})", ErrorMessage = "Invalid New Password")]
        public String new_password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required.")]
        [Compare(nameof(new_password), ErrorMessage = "Passwords don't match.")]
        public String confirm_password { get; set; }
    }
    



    //public class ChangePasswordModel
    //{
    //    public String user_id { get; set; }
    //    [Required(ErrorMessage = "Old Password is required.")]
    //    [StringLength(50, ErrorMessage = "Old Password cannot be longer than 50 characters.")]
    //    [RegularExpression("^([a-zA-Z0-9 .&'_]+)$", ErrorMessage = "Invalid Old Password")]
    //    [Display(Name = "Old Password")]
    //    public String old_password { get; set; }
    //    [DisplayFormat(ConvertEmptyStringToNull = true)]
    //    [Required(ErrorMessage = "New Password is required.")]
    //    [StringLength(50, ErrorMessage = "New Password cannot be longer than 50 characters.")]
    //    [RegularExpression("^([a-zA-Z0-9 .&'_]+)$", ErrorMessage = "Invalid New Password")]
    //    [Display(Name = "New Password")]
    //    public String new_password { get; set; }

    //    [Required(ErrorMessage = "Confirm Password is required.")]
    //    [StringLength(50, ErrorMessage = "Confirm Password cannot be longer than 50 characters.")]
    //    [RegularExpression("^([a-zA-Z0-9 .&'_]+)$", ErrorMessage = "Invalid Confirm Password")]
    //    [Display(Name = "Confirm Password")]
    //    public String confirm_password { get; set; }
    //}
}





