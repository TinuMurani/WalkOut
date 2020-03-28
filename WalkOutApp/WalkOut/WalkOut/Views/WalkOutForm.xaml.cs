using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WalkOut.Common;
using WalkOut.ViewModels;
using Xamarin.Forms;

namespace WalkOut.Views
{
    public partial class WalkOutForm : ContentPage
    {
        public WalkOutForm()
        {
            InitializeComponent();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            var vm = (WalkOutFormViewModel)BindingContext; // Warning, the BindingContext View <-> ViewModel is already set

            vm.SignatureFromStream = async () =>
            {
                if (Semnatura.Points.Count() > 0)
                {
                    using (var stream = await Semnatura.GetImageStreamAsync(SignaturePad.Forms.SignatureImageFormat.Png))
                    {
                        return await ImageConverter.ReadFully(stream);
                    }
                }

                return await Task.Run(() => (byte[])null);
            };
        }

    }
}
