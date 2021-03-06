﻿using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WallpaperTool.ViewModels;

namespace WallpaperTool
{
    public class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer container;

        public Bootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            //自定义消息拦截
            container = new SimpleContainer();

            container.Singleton<IWindowManager, WindowManager>();

            container.Singleton<MainViewModel>(nameof(MainViewModel));
            container.PerRequest<CreateWallpaperViewModel>();
        }

        private object GetCefSource(ActionExecutionContext arg)
        {
            return arg.Source;
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<MainViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }
    }
}
