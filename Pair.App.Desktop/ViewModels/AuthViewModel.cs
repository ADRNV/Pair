﻿using MvvmCross.Commands;
using Pair.App.Desktop.ViewModels.Common;
using Pair.Core.Models;
using Pair.Core.Repositories;
using Pair.Infrastructure.EF.Security.Entities.Configurations;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace Pair.App.Desktop.ViewModels
{
    public class AuthViewModel : ViewModelBase
    {
        private User _user = new();

        private readonly IAuthRepository<User> _authRepository;

        public bool _signed = false;

        public event Action<Permissions> WasSigned;

        public AuthViewModel(IAuthRepository<User> authRepository)
        {
            _authRepository = authRepository;
        }

        public IMvxAsyncCommand SignInCommand => new MvxAsyncCommand(SignIn);

        public string Login
        {
            get => _user.Login;

            set
            {
                _user.Login = value;
                RaisePropertyChanged(nameof(Login));
            }
        }

        public string Password
        {
            get => _user.Password;

            set
            {
                _user.Password = value;
                RaisePropertyChanged(nameof(Password));
            }
        }

        public bool Signed
        {
            get => _signed;

            set
            {
                _signed = value;
                RaisePropertyChanged(nameof(Signed));
            }
        }

        private async Task SignIn()
        {
            var user = await _authRepository.GetByLogin(Login);

            if (user is null)
            {
                MessageBox.Show("Вы не зарегестрированны");
                return;
            }
            if (user.Password == Password)
            {
                Signed = true;
                WasSigned.Invoke(user.Permissions);
            }

        }
    }
}
