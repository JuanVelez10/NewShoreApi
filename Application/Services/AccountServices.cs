using Application.Contracts.Persistence;
using Application.Interfaces;
using Application.References;
using Domain.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Enums.Enums;

namespace Application.Services
{
    public class AccountServices : IAccountServices
    {

        private readonly IAccountRepository accountRepository;
        private readonly IMessageServices messageServices;

        public AccountServices(IAccountRepository accountRepository, IMessageServices messageServices)
        {
            this.accountRepository = accountRepository;
            this.messageServices = messageServices;
        }

        //Method to obtain an account for id
        public async Task<Account> GetPersonForId(Guid? id)
        {
            return accountRepository.Get(id);
        }

        public async Task<BaseResponse<Login>> GetPersonLogin(string email, string password)
        {
            BaseResponse<Login> response = new BaseResponse<Login>();

            if (string.IsNullOrEmpty(email)) return MessageResponse(4, MessageType.Error, "Email");
            if (string.IsNullOrEmpty(password)) return MessageResponse(4, MessageType.Error, "Passwork");

            var account = accountRepository.GetAll().Where(x => x.Email == email && x.Password == password).FirstOrDefault();

            if (account == null) return MessageResponse(3, MessageType.Error, "Account");
            if (account.RoleType != RoleType.Admin) return MessageResponse(6, MessageType.Error, "Rol invalid");
            response = MessageResponse(1, MessageType.Success, "Account");

            response.Data = new Login();
            response.Data.account = account;

            return response;
        }

        //Method to return response message
        private BaseResponse<Login> MessageResponse(int code, MessageType messageType, string additionalMessage = "")
        {
            BaseResponse<Login> response = new BaseResponse<Login>();
            response.Code = code;
            response.Message = String.Format("{0} {1}", messageServices.GetMessage(code, messageType), additionalMessage);
            response.MessageType = messageType;
            return response;
        }


    }
}
