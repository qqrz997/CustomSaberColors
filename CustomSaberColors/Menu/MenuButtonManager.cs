using BeatSaberMarkupLanguage.MenuButtons;
using System;
using Zenject;

namespace CustomSaberColors.Menu;

internal class MenuButtonManager : IInitializable, IDisposable
{
    private readonly MainFlowCoordinator mainFlowCoordinator;
    private readonly MenuFlowCoordinator menuFlowCoordinator;

    public MenuButtonManager(MainFlowCoordinator mainFlowCoordinator, MenuFlowCoordinator menuFlowCoordinator)
    {
        this.mainFlowCoordinator = mainFlowCoordinator;
        this.menuFlowCoordinator = menuFlowCoordinator;
    }

    private MenuButton menuButton;

    public void Initialize()
    {
        menuButton = new("Saber Colors", PresentFlowCoordinator);
        MenuButtons.Instance.RegisterButton(menuButton);
    }

    public void Dispose()
    {
        MenuButtons.Instance.UnregisterButton(menuButton);
    }

    private void PresentFlowCoordinator()
    {
        mainFlowCoordinator.PresentFlowCoordinator(menuFlowCoordinator);
    }
}
