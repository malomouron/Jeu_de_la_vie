using Jeu_de_la_vie.Utilities;

namespace TestProject
{
    public class RelayCommandTests
    {
        [Fact]
        public void CanExecute_ShouldReturnTrue_WhenCanExecuteIsNull()
        {
            var command = new RelayCommand(_ => { });
            Assert.True(command.CanExecute(null));
        }

        [Fact]
        public void CanExecute_ShouldReturnFalse_WhenCanExecuteReturnsFalse()
        {
            var command = new RelayCommand(_ => { }, _ => false);
            Assert.False(command.CanExecute(null));
        }

        [Fact]
        public void CanExecute_ShouldReturnTrue_WhenCanExecuteReturnsTrue()
        {
            var command = new RelayCommand(_ => { }, _ => true);
            Assert.True(command.CanExecute(null));
        }

        [Fact]
        public void Execute_ShouldInvokeExecuteAction()
        {
            bool executed = false;
            var command = new RelayCommand(_ => executed = true);
            command.Execute(null);
            Assert.True(executed);
        }

        [Fact]
        public void RaiseCanExecuteChanged_ShouldInvokeCanExecuteChangedEvent()
        {
            var command = new RelayCommand(_ => { });
            bool eventInvoked = false;
            command.CanExecuteChanged += (s, e) => eventInvoked = true;
            command.RaiseCanExecuteChanged();
            Assert.True(eventInvoked);
        }
    }
}