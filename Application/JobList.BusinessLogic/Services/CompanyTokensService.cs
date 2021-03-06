using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using AutoMapper;
using KsuEmployment.Common.DTOS;
using KsuEmployment.Common.Requests;
using KsuEmployment.DataAccess.Entities;
using KsuEmployment.DataAccess.Interfaces;
using KsuEmployment.BusinessLogic.Interfaces;
using KsuEmployment.Common.DTOS;
using KsuEmployment.Common.Errors;
using KsuEmployment.Common.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace KsuEmployment.BusinessLogic.Services
{
    public class CompanyTokensService : ITokensService<CompanyDTO>
    {
        private readonly IOptions<JobListTokenOptions> tokenOptions;
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public CompanyTokensService(IUnitOfWork _uow, IMapper _mapper, IOptions<JobListTokenOptions> _tokenOptions)
        {
            uow = _uow;
            mapper = _mapper;
            tokenOptions = _tokenOptions;
        }

        public async Task<TokenDTO> CreateTokenAsync(LoginRequest request)
        {
            var entity = await uow.CompaniesRepository.GetFirstOrDefaultAsync(
                filter: u => u.Email == request.Email,
                include: r => r.Include(o => o.Role));

            if (entity == null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Login is uncorrect!");
            }

            byte[] hashPasswordFromDB = Convert.FromBase64String(entity.Password);//got password from DB
            byte[] salt = new byte[16];//reserve bytes for salt
            Array.Copy(hashPasswordFromDB, 0, salt, 0, 16);//copy salt from hashPasswordFromDB
            var hashRequestPassword = new Rfc2898DeriveBytes(request.Password, salt, 1000);//encrypting RequestedPassword with salt using 1000 iterations 
            byte[] bytesFromHashRequest = hashRequestPassword.GetBytes(20);
            bool flag = false;
            for (int i = 0; i < 20; i++)
            {
                if (hashPasswordFromDB[i + 16] == bytesFromHashRequest[i])//compare byte by byte  password from db and requested password (excluding salt)
                {
                    flag = true;
                }
                else break;

            }

            if (flag == false) //if all bytes are similar- success!
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Password is uncorrect!");
            }

            var refreshToken = GenerateRefreshToken();

            entity.RefreshToken = refreshToken;

            var result = await uow.SaveAsync();
            if (!result)
            {
                return null;
            }

            var dto = mapper.Map<Company, CompanyDTO>(entity);

            var jwt = GenerateJWT(dto);

            return new TokenDTO(jwt, refreshToken);
        }

        public string GenerateJWT(CompanyDTO companyDTO)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, companyDTO.Id.ToString()),
                new Claim(ClaimTypes.Email, companyDTO.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, companyDTO.Role.Name)
            };

            var now = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Value.Issuer,
                audience: tokenOptions.Value.Audience,
                notBefore: now,
                claims: claims,
                expires: now.Add(TimeSpan.FromMinutes(tokenOptions.Value.Access_Token_Lifetime)),
                signingCredentials: new SigningCredentials(tokenOptions.Value.GetSymmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature)
            );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public async Task<TokenDTO> RefreshTokenAsync(RefreshTokenRequest request)
        {
            var entity = await uow.CompaniesRepository.GetEntityAsync(
                request.UId,
                include: r => r.Include(o => o.Role));

            if (entity == null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Company with such Id not registered yet!");
            }

            if (entity.RefreshToken != request.RefreshToken)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "RefreshToken is Invalid!");
            }

            var refreshToken = GenerateRefreshToken();

            entity.RefreshToken = refreshToken;

            var result = await uow.SaveAsync();
            if (!result)
            {
                return null;
            }

            var dto = mapper.Map<Company, CompanyDTO>(entity);

            var jwt = GenerateJWT(dto);

            return new TokenDTO(jwt, refreshToken);
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
    }
}
