using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Windows.Input;
using System.Diagnostics.Eventing.Reader;
using Projekt_DatabaseApp.Model;
using Projekt_DatabaseApp.Repositories;
using System.Net;
using System.Threading;
using System.Security.Principal;

namespace Projekt_DatabaseApp.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        // ### Fields ###
        private string _username;
        private SecureString _password;
        private string _errorMessage;
        private bool _isViewVisible = true;

        private IUserRepository userRepository;

        // ### Properties ###
        public string Username 
        { 
            get => _username;
            set { _username = value; OnPropwrtyChanged(nameof(Username)); }
        }
        public SecureString Password 
        { 
            get => _password;
            set { _password = value; OnPropwrtyChanged(nameof(Password)); }
        }
        public string ErrorMessage 
        { 
            get => _errorMessage;
            set { _errorMessage = value; OnPropwrtyChanged(nameof(ErrorMessage)); }
        }
        public bool IsViewVisible 
        { 
            get => _isViewVisible;
            set { _isViewVisible = value; OnPropwrtyChanged(nameof(IsViewVisible)); }
        }

        // ### Commands ###
        public ICommand LoginCommand { get; }
        public ICommand RecoverPasswordCommand { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand RememberPasswordCommand { get; }

        // ### Constructor ###
        public LoginViewModel()
        {
            userRepository = new UserRepository();
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            RecoverPasswordCommand = new ViewModelCommand(p => ExecuteRecoverPassCommand("", ""));
        }

        private void ExecuteLoginCommand(object obj)
        {
            var isValidUser = userRepository.AuthenticateUser(new NetworkCredential(Username, Password));

            if (isValidUser)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(Username), null);

                IsViewVisible = false;
            }
            else
            {
                ErrorMessage = "* Invalid username or password";
            }
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;

            if(string.IsNullOrWhiteSpace(Username) || Username.Length < 3 || Password == null || Password.Length < 3)
                validData = false;
            else 
                validData = true;

            return validData;
        }

        private void ExecuteRecoverPassCommand(string username, string email)
        {
            throw new NotImplementedException();
        }
    }
}
