using MvvmCross.ViewModels;
using System.Threading.Tasks;
using TipCalc.Core.Services;

namespace TipCalc.Core.ViewModels
{
    public class TipViewModel: MvxViewModel
    {
        private readonly ICalculationService calculationService;

        public TipViewModel(ICalculationService calculationService)
        {
            this.calculationService = calculationService;
        }

        public override async Task Initialize()
        {
            await base.Initialize();

            this.SubTotal = 100;
            this.Generosity = 10;
            this.Recalcuate();
        }

        private double subTotal;
        public double SubTotal
        {
            get => this.subTotal;
            set
            {
                this.subTotal = value;
                this.RaisePropertyChanged(() => this.SubTotal);

                this.Recalcuate();
            }
        }

        private int generosity;
        public int Generosity
        {
            get => this.generosity;
            set
            {
                this.generosity = value;
                RaisePropertyChanged(() => this.Generosity);

                this.Recalcuate();
            }
        }

        private double tip;
        public double Tip
        {
            get => this.tip;
            set
            {
                this.tip = value;
                this.RaisePropertyChanged(() => this.Tip);
            }
        }

        private void Recalcuate()
        {
            this.Tip = this.calculationService.TipAmount(this.SubTotal, this.Generosity);
        }
    }
}
