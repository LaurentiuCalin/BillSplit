﻿using BillSplit.Contracts.User;
using BillSplit.Domain.Entities;
using BillSplit.Domain.Validators;
using BillSplit.Domain.Exceptions;
using BillSplit.Persistance.Repositories.Abstractions;
using BillSplit.Services.Abstractions.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System.Security.Authentication;

namespace BillSplit.Services.Services;

internal sealed class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public UserService(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _jwtTokenGenerator = jwtTokenGenerator ?? throw new ArgumentNullException(nameof(jwtTokenGenerator));
    }

    public async Task<long> Create(CreateUserDto request, CancellationToken cancellationToken = default)
    {
        var existingUser = await _userRepository.Get(request.Email, cancellationToken);

        if (existingUser is not null)
        {
            throw new UnavailableEmailException("Email address already in use");
        }

        var validator = new CreateUserDtoValidator();
        validator.ValidateAndThrow(request);

        var result = await _userRepository.Create(new UserEntity(0, request.Email, request.Name, request.PhoneNumber, string.Empty, DateTime.UtcNow));

        return result.Id;
    }

    public async Task SetPassword(SetPasswordDto request, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.Get(request.UserId, cancellationToken);

        if (user is null)
        {
            throw new NotFoundException(nameof(UserEntity), request.UserId);
        }

        if (!string.IsNullOrWhiteSpace(user.Password))
        {
            throw new PasswordCheckException("User has a password already set");
        }

        await UpdatePassword(request, cancellationToken);
    }

    public async Task UpdatePassword(SetPasswordDto request, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.Get(request.UserId, cancellationToken);

        if (user is null)
        {
            throw new NotFoundException(nameof(UserEntity), request.UserId);
        }

        var passwordHasher = new PasswordHasher<UserEntity>();
        var hash = passwordHasher.HashPassword(user, request.Password);

        var passwordCheck = passwordHasher.VerifyHashedPassword(user, hash, request.PasswordCheck);

        if (passwordCheck == PasswordVerificationResult.Failed)
        {
            throw new PasswordCheckException("The password did not match with the repeated password");
        }

        // should I? or can it be maliciously used to find passwords?
        if (string.Equals(user.Password, hash))
        {
            throw new PasswordCheckException("The new password must differ from the current password");
        }

        user.Password = hash;
        await _userRepository.Update(user, cancellationToken);
    }

    public async Task<LoginResponseDto> Login(LoginRequestDto loginRequest, CancellationToken cancellationToken)
    {
        var user = await _userRepository.Get(loginRequest.Email, cancellationToken);

        if (user is null)
        {
            throw new AuthenticationException("Wrong username or password");
        }

        var passwordHasher = new PasswordHasher<UserEntity>();
        var passwordCheck = passwordHasher.VerifyHashedPassword(user, user.Password, loginRequest.Password);

        if (passwordCheck == PasswordVerificationResult.Failed)
        {
            throw new AuthenticationException("Wrong username or password");
        }

        var token = _jwtTokenGenerator.Generate(user.Id);

        return new LoginResponseDto(token);
    }

    public async Task<IEnumerable<UserDto>> Get(CancellationToken cancellationToken = default)
    {
        var users = await _userRepository.Get(cancellationToken);
        return users.Select(MapToDto);
    }
    public Task<UserDto> Get(long id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    private UserDto MapToDto(UserEntity entity)
    {
        return new UserDto(entity.Id, entity.Email, entity.Name, entity.PhoneNumber);
    }
}