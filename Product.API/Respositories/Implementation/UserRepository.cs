﻿using Product.API.Models.Domain;
using Product.API.Respositories.Implementation;

using Products.API.Data;
using Products.API.Respositories.Interfaces;

namespace Products.API.Respositories.Implementation
{
  public class UserRepository : BaseRepository<User>, IUserRepository
  {
    private readonly ApplicationDbContext _context;
    public UserRepository(ApplicationDbContext context) : base(context)
    {
      _context = context;
    }
    public User Get(int id) => base.GetAll().FirstOrDefault(x => x.Id == id);
  }
}
