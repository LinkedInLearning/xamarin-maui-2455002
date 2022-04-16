using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace OldFormsApp.Effects
{
    public class TextColorEffect : RoutingEffect
    {
        public TextColorEffect() : base($"OldFormsAppEffect.{nameof(TextColorEffect)}")
        {
        }
    }
}
