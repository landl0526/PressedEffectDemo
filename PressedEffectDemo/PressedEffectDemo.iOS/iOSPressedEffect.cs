using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using PressedEffectDemo.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("MyApp")]
[assembly: ExportEffect(typeof(iOSPressedEffect), "PressedEffect")]
namespace PressedEffectDemo.iOS
{
    public class iOSPressedEffect : PlatformEffect
    {
        private bool _attached;
        private readonly UILongPressGestureRecognizer _longPressRecognizer;
        private readonly UITapGestureRecognizer _tapRecognizer;
        public iOSPressedEffect()
        {
            _longPressRecognizer = new UILongPressGestureRecognizer(HandleLongClick);
            _tapRecognizer = new UITapGestureRecognizer(HandleClick);
        }

        protected override void OnAttached()
        {
            if (!_attached)
            {
                Container.AddGestureRecognizer(_longPressRecognizer);
                Container.AddGestureRecognizer(_tapRecognizer);
                _attached = true;
            }
        }

        private void HandleClick()
        {
            var command = PressedEffect.GetTapCommand(Element);
            command?.Execute(PressedEffect.GetTapParameter(Element));
        }
        private void HandleLongClick(UILongPressGestureRecognizer recognizer)
        {
            if (recognizer.State == UIGestureRecognizerState.Ended)
            {
                var command = PressedEffect.GetLongTapCommand(Element);
                command?.Execute(PressedEffect.GetLongParameter(Element));
            }           
        }

        protected override void OnDetached()
        {
            if (_attached)
            {
                Container.RemoveGestureRecognizer(_longPressRecognizer);
                Container.RemoveGestureRecognizer(_tapRecognizer);
                _attached = false;
            }
        }
    }
}