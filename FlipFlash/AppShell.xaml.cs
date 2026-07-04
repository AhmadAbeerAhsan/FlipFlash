using FlipFlash.CardCollectionPage;
using FlipFlash.FlashCardPage;

namespace FlipFlash
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(FlashCardEditerView), typeof(FlashCardEditerView));
            Routing.RegisterRoute(nameof(CardCollectionView), typeof(CardCollectionView));
        }
    }
}
