using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Prism_App1.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }


        //5.vlin -> vlINavigationServiceDeclaration tab *2
        private readonly INavigationService _navigationService;
        

        //1.Cmd Tab*2 ->Command Name
        public DelegateCommand 顯示New1PageCommand { get; private set; }


        //4.在viewmodel()中輸入 vlin ->vlINavigationServiceCtorDI tab*2 [使用在建構式]
        public MainPageViewModel(INavigationService navigationService)
        {
            //2.定義指令 -> Crtl+. 產生方法
            顯示New1PageCommand = new DelegateCommand(顯示New1Page);
            
        }

        //3.方法產生後 , 增加async (非同步) , 指定導航至頁面
        private async void 顯示New1Page()
        {
            await _navigationService.NavigateAsync("New1Page");
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";
        }
    }
}
