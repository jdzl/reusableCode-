using System;
using System.ComponentModel.DataAnnotations;

namespace x.Models
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    sealed public class UserExistAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            bool result = false;          
            using (var db = new Entities3())
            {
                
                var usr = db.USUARIOS.Any(x => x.LOGIN.Equals(value.ToString()));
                
                if (!usr )
                {
                    result = true;
                }
            }
            return result;
        }
    }
  }
  
  /*
  Entity Model
  */
  public partial class USUARIOS
  {
    [UserExist(ErrorMessage = " El nombre de usuario ya se encuentra registrado.")]
    public string user{ get; set; }
    
  }
  
  
