using InspectorGadget.App;
using InspectorGadget.App.Api;
using InspectorGadget.Core;
using InspectorGadget.Entity;
using InspectorGadget.Tmx.Plugin.Api.Location;
using InspectorGadget.Tmx.Plugin.Entity.Program;
using InspectorGadget.Tmx.Plugin.ViewModels;
using InspectProgram.Tmx.Plugin.Views;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using Tecnomatix.Engineering;
using TmxSmarts.Location;
using TmxSmarts.Program;
using Yaapii.Atoms.Collection;

namespace InspectorGadget.Tmx.Plugin
{
    public sealed class Entrance : TxButtonCommand
    {
        private readonly InspectCore core;
        private readonly VMMain viewModel;

        public Entrance()
        {
            this.core = new InspectCore();
            this.viewModel = 
                new VMMain(
                    new InspectApp(
                        core,
                        new InspectApi(
                            core,
                            typeof(Print),
                            typeof(Translate)
                        )
                    )
                );
        }

        public override string Category => "Dev Workshop";

        public override string Name => "Inspector Gadget";

        public override string MediumBitmap => "Assets.inspect_logo_medium.png";

        public override string LargeBitmap => "Assets.inspect_logo_large.png";
        public override string Bitmap => "Assets.inspect_logo_small.png";

        public override void Execute(object cmdParams)
        {
            try
            {
                AppDomain.CurrentDomain.AssemblyResolve -= ResolveAssembly;
                AppDomain.CurrentDomain.AssemblyResolve += ResolveAssembly;
                Aggregate();
                var window = new MainWindow(viewModel);
                // Make sure we unsubscribe to assebly resolve events after app has been closed.
                // Otherwise our resolve method will be called even if our app is not running which might conflict with other apps.
                window.Closed += Window_Closed;
                window.Show();

                TxApplication.ActiveSelection.ItemsSet -= ItemsSet;
                TxApplication.ActiveSelection.ItemsSet += ItemsSet;
                TxApplication.ActiveSelection.ItemsAdded -= ItemsAdded;
                TxApplication.ActiveSelection.ItemsAdded += ItemsAdded;
                
            }
            catch (Exception ex)
            {
                /*
                 * Handle error here.
                 * A good way is to log the error with the full stacktrace and give the user a short message what's wrong.
                 * You can use a logging framework of your choice. If you have no idea, take a look at Serilog.
                 */
                Debug.WriteLine(ex);
                TxMessageBox.ShowModal(ex.ToString(), "Error in 'Inspect Program' App", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            AppDomain.CurrentDomain.AssemblyResolve -= ResolveAssembly;
        }

        /// <summary>
        /// This is a method which gets called by the runtime if it needs to load a DLL.
        /// You can look for DLL's in a location of your choice. In this case we are lokking in the directory of our app which is
        /// DotNetCommands/InspectorGadget
        /// If the requested DLL is found in this directory we load it.
        /// </summary>
        private Assembly ResolveAssembly(object sender, ResolveEventArgs args)
        {
            var assemblyFileName = $"{args.Name.Split(',')[0]}.dll";
            var assemblyPath =
                Path.Combine(
                    Path.GetDirectoryName(
                        this.GetType().Assembly.Location
                    ),
                    assemblyFileName
                );

            if (File.Exists(assemblyPath))
            {
                return Assembly.LoadFrom(assemblyPath);
            }
            return null;
        }

        private void ItemsAdded(object sender, TxSelection_ItemsAddedEventArgs args)
        {
            Aggregate();
        }

        private void ItemsSet(object sender, TxSelection_ItemsSetEventArgs args)
        {
            Aggregate();
        }

        private void Aggregate()
        {
            // TODO: Implement a class TsMapped which maps a list of objects into a given type.
            // Leaves out objects which are not if type ITxRoboticLocationOperation
            // Example: new TxMapped<ITxRoboticLocationOperation>(items)
            var programs =
                TxApplication.ActiveDocument.Selection
                    .GetItems()
                    .Where(item => item is ITxRoboticLocationOperation)
                    .Select(item => new TuRoboticLocationOperation(item).Value())
                    .Select(location => new TuRoboticCompoundOperation(location).Value())
                    .Distinct();

            // TODO: Get rid of this call to core.Update()
            // The core should not be called directly. 
            // Instead inject a Function into the core which whill aggregate the programs
            this.core.Update(
                    Mapped.New<ITxRoboticOrderedCompoundOperation, IProgram>(
                        program => new TmxProgram(program),
                        programs
                    )
                );
            this.viewModel.Update();
            TxApplication.StatusBarMessage = $"Found '{programs.Count()}' Programs";
        }
    }
}
