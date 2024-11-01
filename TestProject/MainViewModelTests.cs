using Jeu_de_la_vie.Models;
using Jeu_de_la_vie.Services;
using Jeu_de_la_vie.ViewModels;
using Moq;

namespace TestProject
{
    public class MainViewModelTests
    {
        [Fact]
        public void GridColumns_ShouldReturnCorrectValue()
        {
            var gameGridMock = new Mock<IGameGrid>();
            gameGridMock.Setup(g => g.Columns).Returns(20);
            var viewModel = new MainViewModel(gameGridMock.Object, Mock.Of<ITimerService>(), Mock.Of<IGameLogicService>());

            Assert.Equal(20, viewModel.GridColumns);
        }

        [Fact]
        public void GridRows_ShouldReturnCorrectValue()
        {
            var gameGridMock = new Mock<IGameGrid>();
            gameGridMock.Setup(g => g.Rows).Returns(20);
            var viewModel = new MainViewModel(gameGridMock.Object, Mock.Of<ITimerService>(), Mock.Of<IGameLogicService>());

            Assert.Equal(20, viewModel.GridRows);
        }

        [Fact]
        public void StartCommand_ShouldStartTimerService()
        {
            var timerServiceMock = new Mock<ITimerService>();
            var viewModel = new MainViewModel(Mock.Of<IGameGrid>(), timerServiceMock.Object, Mock.Of<IGameLogicService>());

            viewModel.StartCommand.Execute(null);

            timerServiceMock.Verify(t => t.Start(), Times.Once);
        }

        [Fact]
        public void StopCommand_ShouldStopTimerService()
        {
            var timerServiceMock = new Mock<ITimerService>();
            var viewModel = new MainViewModel(Mock.Of<IGameGrid>(), timerServiceMock.Object, Mock.Of<IGameLogicService>());

            viewModel.StopCommand.Execute(null);

            timerServiceMock.Verify(t => t.Stop(), Times.Once);
        }

        [Fact]
        public void ResetCommand_ShouldResetGrid()
        {
            var gameGridMock = new Mock<IGameGrid>();
            var viewModel = new MainViewModel(gameGridMock.Object, Mock.Of<ITimerService>(), Mock.Of<IGameLogicService>());

            viewModel.ResetCommand.Execute(null);

            gameGridMock.Verify(g => g.InitializeGrid(), Times.Once);
        }

        [Fact]
        public void UpdateGrid_ShouldUpdateCellViewModels()
        {
            var gameGridMock = new Mock<IGameGrid>();
            var cellMock = new Mock<ICell>();
            gameGridMock.Setup(g => g.GetCell(It.IsAny<int>(), It.IsAny<int>())).Returns(cellMock.Object);
            var viewModel = new MainViewModel(gameGridMock.Object, Mock.Of<ITimerService>(), Mock.Of<IGameLogicService>());

            viewModel.UpdateGrid();

            foreach (var cellViewModel in viewModel.Cells)
            {
                cellViewModel.OnPropertyChanged(nameof(cellViewModel.IsAlive));
            }
        }
    }
}