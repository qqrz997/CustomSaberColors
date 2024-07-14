using CustomSaberColors.UI.Views;
using HMUI;
using SiraUtil.Logging;
using System;
using Zenject;

namespace CustomSaberColors.UI
{
    internal class MenuFlowCoordinator : FlowCoordinator
    {
        [Inject] private readonly MainViewController mainView;
        [Inject] private readonly MainFlowCoordinator mainFlowCoordinator;

        private void Start()
        {
            SetTitle("Custom Saber Colors");
            showBackButton = true;
        }

        protected override void DidActivate(bool firstActivation, bool addedToHierarchy, bool screenSystemEnabling) => 
            ProvideInitialViewControllers(mainView);

        protected override void BackButtonWasPressed(ViewController _) => 
            mainFlowCoordinator.DismissFlowCoordinator(this);
    }
}
