using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Manager.Core.Exceptions;
using Manager.Domain.Entities;
using Manager.Infra.Interfaces;
using Manager.Services.DTO;
using Manager.Services.Interfaces;

namespace Manager.Services.Services
{
  public class UserService : IUserService
  {

    private readonly IMapper _mapper;

    private readonly IUserRepository _userRepository;

    public UserService(IMapper mapper, IUserRepository userRepository)
    {
      _mapper = mapper;
      _userRepository = userRepository;
    }

    public async Task<UserDTO> Create(UserDTO userDTO)
    {
      var userExists = await _userRepository.GetByEmail(userDTO.Email);
      if (userExists != null)
        throw new DomainException("Usuario já possui cadastro");

      var user = _mapper.Map<User>(userDTO);
      user.Validate();

      var userCreated = await _userRepository.Create(user);

      return _mapper.Map<UserDTO>(userCreated);
    }

    public async Task<UserDTO> Get(long id)
    {
      throw new System.NotImplementedException();
    }

    public async Task<List<UserDTO>> Get()
    {
      throw new System.NotImplementedException();
    }

    public async Task<UserDTO> GetByEmail(string email)
    {
      throw new System.NotImplementedException();
    }

    public async Task Remove(long id)
    {
      throw new System.NotImplementedException();
    }

    public async Task<List<UserDTO>> SearchByEmail(string email)
    {
      throw new System.NotImplementedException();
    }

    public async Task<List<UserDTO>> SearchByName(string name)
    {
      throw new System.NotImplementedException();
    }

    public async Task<UserDTO> Update(UserDTO userDTO)
    {
      throw new System.NotImplementedException();
    }
  }
}