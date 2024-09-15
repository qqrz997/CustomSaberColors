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

    private MenuButton button;

    public void Initialize()
    {
        button = new("Saber Colors", "todo hover hint", PresentFlowCoordinator);
        MenuButtons.Instance.RegisterButton(button);
    }

    public void Dispose()
    {
        MenuButtons.Instance.UnregisterButton(button);
    }

    private void PresentFlowCoordinator()
    {
        mainFlowCoordinator.PresentFlowCoordinator(menuFlowCoordinator);
    }
}
