using HMUI;
using System;
using UnityEngine;

namespace CustomSaberColors.Menu
{
    internal class SaberColorsToggleGroup : MonoBehaviour
    {
        private ColorSchemeColorToggleController saberAColorToggleController;
        private ColorSchemeColorToggleController saberBColorToggleController;

        private ToggleBinder toggleBinder;

        private ColorSchemeColorToggleController selectedColorToggleController;

        public Color Color
        {
            get => selectedColorToggleController?.color ?? Color.white;
            set => selectedColorToggleController.color = value;
        }

        public (Color, Color) EditedColors => (saberAColorToggleController.color, saberBColorToggleController.color);

        public event Action<Color> SelectedColorChanged;

        public void Init(ColorSchemeColorToggleController saberAColorToggleController, ColorSchemeColorToggleController saberBColorToggleController)
        {
            this.saberAColorToggleController = saberAColorToggleController;
            this.saberBColorToggleController = saberBColorToggleController;

            selectedColorToggleController = this.saberAColorToggleController;
            this.saberAColorToggleController.toggle.isOn = true;
            toggleBinder = new ToggleBinder();
            toggleBinder.AddBinding(saberAColorToggleController.toggle, (isOn) => HandleToggleSelected(saberAColorToggleController, isOn));
            toggleBinder.AddBinding(saberBColorToggleController.toggle, (isOn) => HandleToggleSelected(saberBColorToggleController, isOn));
        }

        public void SetColors(Color saberAColor, Color saberBColor)
        {
            saberAColorToggleController.color = saberAColor;
            saberBColorToggleController.color = saberBColor;
            SelectedColorChanged?.Invoke(Color);
        }

        private void HandleToggleSelected(ColorSchemeColorToggleController colorToggleController, bool isOn)
        {
            if (isOn)
            {
                selectedColorToggleController = colorToggleController;
                SelectedColorChanged?.Invoke(colorToggleController.color);
            }
        }

        private void OnDestroy() =>
            toggleBinder.ClearBindings();
    }
}
