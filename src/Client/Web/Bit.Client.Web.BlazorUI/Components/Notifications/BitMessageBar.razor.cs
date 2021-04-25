﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Bit.Client.Web.BlazorUI
{
    public partial class BitMessageBar
    {
        private MessageBarStyle messageBarStyle = MessageBarStyle.Default;

        [Parameter] public RenderFragment ChildContent { get; set; }

        [Parameter]
        public MessageBarStyle MessageBarStyle
        {
            get => messageBarStyle;
            set
            {
                messageBarStyle = value;
                ClassBuilder.Reset();
            }
        }

        protected override string RootElementClass => "bit-message-bar";

        protected override void RegisterComponentClasses()
        {
            ClassBuilder.Register(() => MessageBarStyle == MessageBarStyle.Warning ? "warning"
                                      : MessageBarStyle == MessageBarStyle.Severe ? "severe"
                                      : MessageBarStyle == MessageBarStyle.Error ? "error"
                                      : MessageBarStyle == MessageBarStyle.Success ? "success"
                                      : "default");
        }

        public override Task SetParametersAsync(ParameterView parameters)
        {
            foreach (ParameterValue parameter in parameters)
            {
                switch (parameter.Name)
                {
                    case nameof(MessageBarStyle):
                        MessageBarStyle = (MessageBarStyle)parameter.Value;
                        break;

                    case nameof(ChildContent):
                        ChildContent = (RenderFragment)parameter.Value;
                        break;
                }
            }

            return base.SetParametersAsync(parameters);
        }
    }
}