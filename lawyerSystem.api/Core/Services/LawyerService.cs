using AutoMapper;
using lawyerSystem.api.Core.Dtos;
using lawyerSystem.api.Core.Interfaces;
using lawyerSystem.api.Domain.Enums.Lawyer;
using lawyerSystem.api.Domain.Models;
using lawyerSystem.api.Infrastructure.Configurations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace lawyerSystem.api.Core.Services;

public class LawyerService
{
    private readonly ILawyerProfileRepositoyry _lawyerProfileRepository;
    private readonly IUserProfileRepository _userProfileRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public LawyerService(
        ILawyerProfileRepositoyry lawyerProfileRepository,
        IUserProfileRepository userProfileRepository,
        IRoleRepository roleRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _lawyerProfileRepository = lawyerProfileRepository;
        _userProfileRepository = userProfileRepository;
        _roleRepository = roleRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<UserDto> CreateLawyerAsync(CreateLawyerCommand lawyerCommand)
    {

        await VerifyLawyer(lawyerCommand);

        var salt = CryptoHelper.GenerateSalt();

        var hashedPassword = CryptoHelper.HashPassword(lawyerCommand.Password, salt);

        var lawyerRole = await _unitOfWork.Roles.GetRoleByName("Lawyer");

        if (lawyerRole == null)
        {
            throw new KeyNotFoundException("Lawyer role not found");
        }

        var user = new User
        {
            Id = Guid.NewGuid(),
            Name = lawyerCommand.Name,
            Email = lawyerCommand.Email,
            Phone = lawyerCommand.Phone,
            PasswordHash = hashedPassword,
            Salt = salt,
        };

        var lawyer = new Lawyer
        {
            Id = Guid.NewGuid(),
            OABNumber = lawyerCommand.OABNumber,
            OABState = lawyerCommand.OABState,
            Position = lawyerCommand.Position,
            Biography = lawyerCommand.Biography,
            IsActive = true,
            UserId = user.Id,
            User = user,
        };

        user.UserRoles.Add(new UserRole { Role = lawyerRole, User = user});

        await _unitOfWork.Users.AddAsync(user);

        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<UserDto>(user);

    }

    public async Task<UserDto> GetLawyerDetailsAsync(Guid Id)
    {
        if(Id == Guid.Empty)
        {
            throw new ArgumentException("Id cannot be empty", nameof(Id));
        }

        var user = await _userProfileRepository.GetUserAsync(Id);

        if (user == null)
        {
            throw new KeyNotFoundException("User not found");
        }

        return _mapper.Map<UserDto>(user);
    }

    public async Task<LawyerDto> UpdateLawyerProfileAsync(Guid Id, UpdateLawyerDto lawyerDto)
    {
        if(Id == Guid.Empty)
        {
            throw new ArgumentException("Id cannot be empty", nameof(Id));
        }

        if (lawyerDto == null)
        {
            throw new ArgumentNullException(nameof(lawyerDto), "UserDto cannot be null");
        }

        var lawyerUpdated = await _lawyerProfileRepository.GetLawyerAsync(Id);

        if (lawyerDto.OABState != null)
        {
            lawyerUpdated.OABState = lawyerDto.OABState;
        }

        if (lawyerDto.OABNumber != null)
        {
            lawyerUpdated.OABNumber = lawyerDto.OABNumber;
        }

        if (lawyerDto.Position.HasValue)
        {
            lawyerUpdated.Position = lawyerDto.Position.Value;
        }

        if (lawyerDto.Biography != null)
        {
            lawyerUpdated.Biography = lawyerDto.Biography;
        }

        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<LawyerDto>(lawyerUpdated);
    }

    private async Task<bool> VerifyLawyer(CreateLawyerCommand lawyerCommand)
    {
        if (lawyerCommand == null)
        {
            throw new ArgumentNullException("Lawyer command cannot be null");
        }

        var userExist = await _userProfileRepository.GetUserByEmail(lawyerCommand.Email);

        if (userExist != null)
        {
            // TODO:
            // Create a customize Exception to put here
            throw new Exception("User with this email already exists");
        }

        var oabExists = await _unitOfWork.Lawyers.GetLawyerByOab(lawyerCommand.OABNumber);
        if (oabExists != null)
        {
            // TODO:
            // Create a customize Exception to put here
            throw new Exception("Esta OAB já está cadastrada no sistema.");
        }

        return true;
    }

}
