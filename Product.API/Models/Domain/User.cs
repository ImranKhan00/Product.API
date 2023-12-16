namespace Product.API.Models.Domain
{
  public class User
  {
        public int Id { get; set; }
        public string Address { get; set; }

    public virtual string FirstName { get; set; }
    public virtual string LastName { get; set; }
    public virtual string Email { get; set; }
    public virtual string Password { get; set; }
    public virtual string Salt { get; set; }
    public virtual string Phone { get; set; }
    public virtual string Username { get; set; }
    /// <summary>
    /// Determines user status
    /// It can used as blocking flag, to indicate if user is blocked or not
    /// </summary>
    public virtual bool Status { get; set; }

    //public virtual cRole Role { get; set; }
    //public virtual int RoleId { get; set; }

    //public Distribution Distribution { get; set; }
    //public new int? DistributionId { get; set; }

    //public UserDto ToDto()
    //{
    //  return new UserDto(this);
    //}
  }
}
