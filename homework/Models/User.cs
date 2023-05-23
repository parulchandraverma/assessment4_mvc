using System.ComponentModel.DataAnnotations;



namespace AssessmentUser.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }



        [DataType(DataType.Password)]
        public string Password { get; set; }
        public UserRole Role { get; set; }
        public int? ManagerId { get; set; }



        public virtual User Manager { get; set; }
    }



    public enum UserRole
    {

        Manager,
        Employee
    }



}