using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using PressedEffectDemo.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("MyApp")]
[assembly: ExportEffect(typeof(AndroidPressedEffect), "PressedEffect")]
namespace PressedEffectDemo.Droid
{
    public class AndroidPressedEffect : PlatformEffect
    {
        private bool _attached;

        public static void Initialize() { }

        public AndroidPressedEffect()
        {
        }

        protected override void OnAttached()
        {
            if (!_attached)
            {
                if (Control != null)
                {
                    Control.LongClickable = true;
                    Control.LongClick += Control_LongClick;
                    Control.Click += Control_Click;
                }
                else
                {
                    Container.LongClickable = true;
                    Container.LongClick += Control_LongClick;
                    Container.Click += Control_Click;
                }
                _attached = true;
            }
        }

        private void Control_Click(object sender, EventArgs e)
        {
            var command = PressedEffect.GetTapCommand(Element);
            command?.Execute(PressedEffect.GetTapParameter(Element));
        }

        private void Control_LongClick(object sender, Android.Views.View.LongClickEventArgs e)
        {
            var command = PressedEffect.GetLongTapCommand(Element);
            command?.Execute(PressedEffect.GetLongParameter(Element));
        }

        protected override void OnDetached()
        {
            if (_attached)
            {
                if (Control != null)
                {
                    Control.LongClickable = true;
                    Control.LongClick -= Control_LongClick;
                    Control.Click -= Control_Click;
                }
                else
                {
                    Container.LongClickable = true;
                    Container.LongClick -= Control_LongClick;
                    Control.Click -= Control_Click;
                }
                _attached = false;
            }
        }
    }
}