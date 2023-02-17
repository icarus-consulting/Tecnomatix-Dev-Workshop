using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InspectorGadget.App;
using InspectorGadget.App.Api;
using System;
using System.Linq;
using Yaapii.Atoms.Collection;

namespace InspectorGadget.Tmx.Plugin.ViewModels
{
    public partial class VMMain : ObservableObject
    {
        private string document;

        public string Document
        {
            get => document;
            private set => SetProperty(ref document, value);
        }

        private bool isInvalid;

        public bool IsInvalid
        {
            get => isInvalid;
            private set => SetProperty(ref isInvalid, value);
        }

        private readonly IApp app;
        private string media = "xml";

        public VMMain(IApp app)
		{
			IsInvalid= false;
            this.app = app;
        }
        
        [RelayCommand]
		private void ApplyMedia(string media)
		{
            this.media = media;
            Update();
		}

        [RelayCommand]
        private void Translate(string axis)
        {
            var delta = new double[3] { 0, 0, 0 };
            switch (axis)
            {
                case "x":
                    delta[0] = 100;
                    break;
                case "y":
                    delta[1] = 100;
                    break;
                case "z":
                    delta[2] = 100;
                    break;
                default:
                    throw new InvalidOperationException($"Cannot perform translation becuase the given axis '{axis}' is unknown.");
            }

            this.app
                .Api()
                .Send(
                    new Api.Location.Translate.Request(
                        delta, 
                        Mapped.New(
                            program => program.Id(),
                            app.Programs()
                        ).ToArray()
                    )
                );
        }


        public async void Update()
        {
            Document = await this.app.Api().Send(new Print.Request(this.media));
            IsInvalid = string.IsNullOrEmpty(Document);
        }

    }
}
