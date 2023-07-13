using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Projekt_DatabaseApp.Model;
using Projekt_DatabaseApp.Repositories;

namespace Projekt_DatabaseApp.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        // ### Fields ###
        private UserAccountModel _currentUserAccount;
        private IUserRepository userRepository;

        private ViewModelBase _currentChildView;
        private string _caption;

        // ### Properties ###
        public UserAccountModel CurrentUserAccount
        {
            get => _currentUserAccount;
            set { _currentUserAccount = value; OnPropwrtyChanged(nameof(CurrentUserAccount)); }
        }

        public ViewModelBase CurrentChildView 
        { 
            get => _currentChildView;
            set { _currentChildView = value; OnPropwrtyChanged(nameof(CurrentChildView)); }
        }
        public string Caption 
        { 
            get => _caption; 
            set { _caption = value; OnPropwrtyChanged(nameof(Caption)); }
        }

        // ### Commands ###
        public ICommand ShowHomeViewCommand { get; }
        public ICommand ShowStarsViewCommand { get; }
        public ICommand ShowPlanetsViewCommand { get; }

        public MainViewModel()
        {
            userRepository = new UserRepository();
            CurrentUserAccount = new UserAccountModel();

            // ### Initialize Commands ###
            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);
            ShowStarsViewCommand = new ViewModelCommand(ExecuteShowStarsViewCommand);
            ShowPlanetsViewCommand = new ViewModelCommand(ExecuteShowPlanetsViewCommand);

            // ### Default view ###
            ExecuteShowHomeViewCommand(null);

            LoadCurrentUserData();
        }

        private void ExecuteShowPlanetsViewCommand(object obj)
        {
            CurrentChildView = new PlanetsViewModel();
            Caption = "Planets";
        }

        private void ExecuteShowStarsViewCommand(object obj)
        {
            CurrentChildView = new StarsViewModel();
            Caption = "Stars";

        }

        private void ExecuteShowHomeViewCommand(object obj)
        {
            CurrentChildView = new HomeViewModel();
            Caption = "Home";
        }

        private void LoadCurrentUserData()
        {
            var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {
                CurrentUserAccount.Username = user.Username;
                CurrentUserAccount.DisplayName = $"{user.Name} {user.LastName}";
            }
            else
            {
                CurrentUserAccount.DisplayName="You are not logged in";
            }
        }
    }
}
