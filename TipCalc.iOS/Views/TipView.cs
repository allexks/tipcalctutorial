using UIKit;
using TipCalc.Core.ViewModels;
using MvvmCross.Platforms.Ios.Views;
using MvvmCross.Binding.BindingContext;

namespace TipCalcTutorial.iOS.Views
{
    public partial class TipView : MvxViewController<TipViewModel>
    {
        public TipView() : base("TipView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var set = this.CreateBindingSet<TipView, TipViewModel>();
            set.Bind(TipLabel).To(vm => vm.Tip);
            set.Bind(GenerositySlider).To(vm => vm.Generosity);
            set.Bind(SubTotalTextField).To(vm => vm.SubTotal);
            set.Apply();

            // Close the keyboard on tapping outside of it
            View.AddGestureRecognizer(new UITapGestureRecognizer(() =>
            {
                this.SubTotalTextField.ResignFirstResponder();
            }));
        }
    }
}

