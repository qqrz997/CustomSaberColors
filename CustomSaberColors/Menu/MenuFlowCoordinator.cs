using CustomSaberColors.Menu.Views;
using HMUI;
using Zenject;

namespace CustomSaberColors.Menu;

internal class MenuFlowCoordinator : FlowCoordinator
{
    [Inject] private readonly MainViewController mainView;
    [Inject] private readonly MainFlowCoordinator mainFlowCoordinator;

    private void Start()
    {
        SetTitle("Custom Saber Colors");
        showBackButton = true;
    }

    public override void DidActivate(bool firstActivation, bool addedToHierarchy, bool screenSystemEnabling) => 
        ProvideInitialViewControllers(mainView);

    public override void BackButtonWasPressed(ViewController _) => 
        mainFlowCoordinator.DismissFlowCoordinator(this);
}
