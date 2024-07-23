using BeatSaberMarkupLanguage.MenuButtons;
using SiraUtil.Logging;
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
        MenuButtons.instance.RegisterButton(button);
    }

    public void Dispose()
    {
        MenuButtons.instance.UnregisterButton(button);
    }

    private void PresentFlowCoordinator()
    {
        mainFlowCoordinator.PresentFlowCoordinator(menuFlowCoordinator);
    }
}
