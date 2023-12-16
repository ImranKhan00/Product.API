using Product.API.Models.Domain;

namespace Product.API.Models.DTO_s
{
  public class UserDTO
  {
    public UserDTO(User user)
    {

      // assign values by reflection
      foreach (var prop in user?.GetType().GetProperties())
      {
        var value = prop.GetValue(user);
        GetType().GetProperty(prop.Name)?.SetValue(this, value);
      }
      //RoleName = eRole.Salesman.Get(user.RoleId).GetFriendlyName();
    }
    public long Id { get; set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string Phone { get; private set; }
    public string Address { get; private set; }
    public string Username { get; private set; }
    public string RoleName { get; set; }
    public long RoleId { get; set; }
  }
}
